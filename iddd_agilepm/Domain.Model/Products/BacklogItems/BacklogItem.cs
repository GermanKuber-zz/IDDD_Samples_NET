// Copyright 2012,2013 Vaughn Vernon
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Common.Domain.Model;    
    using Tenants;
    using Teams;
    using Sprints;
    using Releases;
    using Discussions;

    public class BacklogItem : EntityWithCompositeId
    {
        public BacklogItem(
            TenantId tenantId,
            ProductId productId,
            BacklogItemId backlogItemId,
            string summary,
            string category,
            BacklogItemType type,
            BacklogItemStatus backlogItemStatus,
            StoryPoints storyPoints)
        {
            BacklogItemId = backlogItemId;
            Category = category;
            ProductId = productId;
            Status = backlogItemStatus;
            StoryPoints = storyPoints;
            Summary = summary;
            TenantId = tenantId;
            Type = type;

            _tasks = new List<Task>();
        }

        private readonly List<Task> _tasks;

        public TenantId TenantId { get; private set; }

        public ProductId ProductId { get; private set; }

        public BacklogItemId BacklogItemId { get; private set; }

        private string _summary;

        public string Summary
        {
            get { return _summary; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The summary must be provided.");
                AssertionConcern.AssertArgumentLength(value, 100, "The summary must be 100 characters or less.");
                _summary = value;
            }
        }

        public string Category { get; private set; }

        public BacklogItemType Type { get; private set; }

        public BacklogItemStatus Status { get; private set; }

        public bool IsDone
        {
            get { return Status == BacklogItemStatus.Done; }
        }

        public bool IsPlanned
        {
            get { return Status == BacklogItemStatus.Planned; }
        }

        public bool IsRemoved
        {
            get { return Status == BacklogItemStatus.Removed; }
        }

        public StoryPoints StoryPoints { get; private set; }

        public string AssociatedIssueId { get; private set; }

        public void AssociateWithIssue(string issueId)
        {
            if (AssociatedIssueId == null)
            {
                AssociatedIssueId = issueId;
            }
        }

        public BusinessPriority BusinessPriority { get; private set; }

        public bool HasBusinessPriority
        {
            get { return BusinessPriority != null; }
        }

        public void AssignBusinessPriority(BusinessPriority businessPriority)
        {
            BusinessPriority = businessPriority;
            DomainEventPublisher.Instance.Publish(
                new BusinessPriorityAssigned(TenantId, BacklogItemId, businessPriority));
        }

        public void AssignStoryPoints(StoryPoints storyPoints)
        {
            StoryPoints = storyPoints;
            DomainEventPublisher.Instance.Publish(
                new BacklogItemStoryPointsAssigned(TenantId, BacklogItemId, storyPoints));
        }

        public Task GetTask(TaskId taskId)
        {
            return _tasks.FirstOrDefault(x => x.TaskId.Equals(taskId));
        }

        private Task LoadTask(TaskId taskId)
        {
            var task = GetTask(taskId);
            if (task == null)
                throw new InvalidOperationException("Task does not exist.");
            return task;
        }

        public void AssignTaskVolunteer(TaskId taskId, TeamMember volunteer)
        {
            var task = LoadTask(taskId);
            task.AssignVolunteer(volunteer);
        }

        public void ChangeCategory(string category)
        {
            Category = category;
            DomainEventPublisher.Instance.Publish(
                new BacklogItemCategoryChanged(TenantId, BacklogItemId, category));
        }

        public void ChangeTaskStatus(TaskId taskId, TaskStatus status)
        {
            var task = LoadTask(taskId);
            task.ChangeStatus(status);
        }

        public void ChangeType(BacklogItemType type)
        {
            Type = type;
            DomainEventPublisher.Instance.Publish(
                new BacklogItemTypeChanged(TenantId, BacklogItemId, type));
        }

        public ReleaseId ReleaseId { get; private set; }

        public bool IsScheduledForRelease
        {
            get { return ReleaseId != null; }
        }

        public SprintId SprintId { get; private set; }

        public bool IsCommittedToSprint
        {
            get { return SprintId != null; }
        }

        public void CommitTo(Sprint sprint)
        {
            AssertionConcern.AssertArgumentNotNull(sprint, "Sprint must not be null.");
            AssertionConcern.AssertArgumentEquals(sprint.TenantId, TenantId, "Sprint must be of same tenant.");
            AssertionConcern.AssertArgumentEquals(sprint.ProductId, ProductId, "Sprint must be of same product.");

            if (!IsScheduledForRelease)
                throw new InvalidOperationException("Must be scheduled for release to commit to sprint.");

            if (IsCommittedToSprint)
            {
                if (!sprint.SprintId.Equals(SprintId))
                {
                    UncommittFromSprint();
                }
            }

            ElevateStatusWith(BacklogItemStatus.Committed);

            SprintId = sprint.SprintId;

            DomainEventPublisher.Instance.Publish(
                new BacklogItemCommitted(TenantId, BacklogItemId, sprint.SprintId));
        }

        private void ElevateStatusWith(BacklogItemStatus status)
        {
            if (Status == BacklogItemStatus.Scheduled)
            {
                Status = BacklogItemStatus.Committed;
            }
        }

        public void UncommittFromSprint()
        {
            if (!IsCommittedToSprint)
                throw new InvalidOperationException("Not currently committed.");

            Status = BacklogItemStatus.Scheduled;
            var uncommittedSprintId = SprintId;
            SprintId = null;

            DomainEventPublisher.Instance.Publish(
                new BacklogItemUncommitted(TenantId, BacklogItemId, uncommittedSprintId));
        }

        public void DefineTask(TeamMember volunteer, string name, string description, int hoursRemaining)
        {
            var task = new Task(
                TenantId,
                BacklogItemId,
                new TaskId(),
                volunteer,
                name,
                description,
                hoursRemaining,
                TaskStatus.NotStarted);

            _tasks.Add(task);

            DomainEventPublisher.Instance.Publish(
                new TaskDefined(TenantId, BacklogItemId, task.TaskId, volunteer.TeamMemberId.Id, name, description));
        }

        public void DescribeTask(TaskId taskId, string description)
        {
            var task = LoadTask(taskId);
            task.DescribeAs(description);
        }

        public BacklogItemDiscussion Discussion { get; private set; }

        public void FailDiscussionInitiation()
        {
            if (Discussion.Availability == DiscussionAvailability.Ready)
            {
                DiscussionInitiationId = null;
                Discussion = BacklogItemDiscussion.FromAvailability(DiscussionAvailability.Failed);
            }
        }

        private string _discussionInitiationId;

        public string DiscussionInitiationId
        {
            get { return _discussionInitiationId; }
            private set
            {
                if (value != null)
                    AssertionConcern.AssertArgumentLength(value, 100, "Discussion initiation identity must be 100 characters or less.");
                _discussionInitiationId = value;
            }
        }

        public void InitiateDiscussion(DiscussionDescriptor descriptor)
        {
            AssertionConcern.AssertArgumentNotNull(descriptor, "The descriptor must not be null.");
            if (Discussion.Availability == DiscussionAvailability.Requested)
            {
                Discussion = Discussion.NowReady(descriptor);
                DomainEventPublisher.Instance.Publish(
                    new BacklogItemDiscussionInitiated(TenantId, BacklogItemId, Discussion));
            }
        }

        public void InitiateDiscussion(BacklogItemDiscussion discussion)
        {
            Discussion = discussion;
            DomainEventPublisher.Instance.Publish(
                new BacklogItemDiscussionInitiated(TenantId, BacklogItemId, discussion));
        }

        public int TotalTaskHoursRemaining
        {
            get { return _tasks.Select(x => x.HoursRemaining).Sum(); }
        }

        public bool AnyTaskHoursRemaining
        {
            get { return TotalTaskHoursRemaining > 0; }
        }

        public void EstimateTaskHoursRemaining(TaskId taskId, int hoursRemaining)
        {
            var task = LoadTask(taskId);
            task.EstimateHoursRemaining(hoursRemaining);

            var changedStatus = default(BacklogItemStatus?);

            if (hoursRemaining == 0)
            {
                if (!AnyTaskHoursRemaining)
                {
                    changedStatus = BacklogItemStatus.Done;
                }
            }
            else if (IsDone)
            {
                if (IsCommittedToSprint)
                {
                    changedStatus = BacklogItemStatus.Committed;
                }
                else if (IsScheduledForRelease)
                {
                    changedStatus = BacklogItemStatus.Scheduled;
                }
                else
                {
                    changedStatus = BacklogItemStatus.Planned;
                }
            }

            if (changedStatus != null)
            {
                Status = changedStatus.Value;
                DomainEventPublisher.Instance.Publish(
                    new BacklogItemStatusChanged(TenantId, BacklogItemId, changedStatus.Value));
            }
        }

        public void MarkAsRemoved()
        {
            if (IsRemoved)
                throw new InvalidOperationException("Already removed, not outstanding.");
            if (IsDone)
                throw new InvalidOperationException("Already done, not outstanding.");
            
            if (IsCommittedToSprint)
            {
                UncommittFromSprint();
            }

            if (IsScheduledForRelease)
            {
                UnscheduleFromRelease();
            }

            Status = BacklogItemStatus.Removed;

            DomainEventPublisher.Instance.Publish(
                new BacklogItemMarkedAsRemoved(TenantId, BacklogItemId));
        }

        public void UnscheduleFromRelease()
        {
            if (IsCommittedToSprint)
                throw new InvalidOperationException("Must first uncommit.");
            if (!IsScheduledForRelease)
                throw new InvalidOperationException("Not scheduled for release.");

            Status = BacklogItemStatus.Planned;
            var unscheduledReleaseId = ReleaseId;
            ReleaseId = null;

            DomainEventPublisher.Instance.Publish(
                new BacklogItemUnscheduled(TenantId, BacklogItemId, unscheduledReleaseId));
        }

        public void RemoveTask(TaskId taskId)
        {
            var task = LoadTask(taskId);

            if (!_tasks.Remove(task))
                throw new InvalidOperationException("Task was not removed.");

            DomainEventPublisher.Instance.Publish(
                new TaskRemoved(TenantId, BacklogItemId));
        }

        public void RenameTask(TaskId taskId, string name)
        {
            var task = LoadTask(taskId);
            task.Rename(name);
        }

        public void RequestDiscussion(DiscussionAvailability availability)
        {
            if (Discussion.Availability != DiscussionAvailability.Ready)
            {
                Discussion = BacklogItemDiscussion.FromAvailability(availability);

                DomainEventPublisher.Instance.Publish(
                    new BacklogItemDiscussionRequested(
                        TenantId,
                        ProductId,
                        BacklogItemId,
                        availability == DiscussionAvailability.Requested));

            }
        }

        public void ScheduleFor(Release release)
        {
            AssertionConcern.AssertArgumentNotNull(release, "Release must not be null.");
            AssertionConcern.AssertArgumentEquals(TenantId, release.TenantId, "Release must be of same tenant.");
            AssertionConcern.AssertArgumentEquals(ProductId, release.ProductId, "Release must be of same product.");

            if (IsScheduledForRelease && !ReleaseId.Equals(release.ReleaseId))
            {
                UnscheduleFromRelease();
            }

            if (Status == BacklogItemStatus.Planned)
            {
                Status = BacklogItemStatus.Scheduled;
            }

            ReleaseId = release.ReleaseId;

            DomainEventPublisher.Instance.Publish(
                new BacklogItemScheduled(TenantId, BacklogItemId, release.ReleaseId));

        }

        public void StartDiscussionInitiation(string discussionInitiationId)
        {
            if (Discussion.Availability != DiscussionAvailability.Ready)
            {
                DiscussionInitiationId = discussionInitiationId;
            }
        }

        public void Summarize(string summary)
        {
            Summary = summary;
            DomainEventPublisher.Instance.Publish(
                new BacklogItemSummarized(TenantId, BacklogItemId, summary));
        }

        public string Story { get; private set; }

        public void TellStory(string story)
        {
            if (story != null)
                AssertionConcern.AssertArgumentLength(story, 65000, "The story must be 65000 characters or less.");

            Story = story;

            DomainEventPublisher.Instance.Publish(
                new BacklogItemStoryTold(TenantId, BacklogItemId, story));
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return TenantId;
            yield return ProductId;
            yield return BacklogItemId;
        }
    }
}
