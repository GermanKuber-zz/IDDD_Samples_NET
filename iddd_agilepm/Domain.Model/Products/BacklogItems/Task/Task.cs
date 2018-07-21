using System;
using System.Collections.Generic;
using System.Linq;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.AgilePM.Domain.Model.Teams;
using SaaSOvation.AgilePM.Domain.Model.Tenants;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.Task
{
    public class Task : EntityWithCompositeId
    {
        public Task(
            TenantId tenantId, 
            BacklogItemId backlogItemId, 
            TaskId taskId, 
            TeamMember teamMember, 
            string name, 
            string description, 
            int hoursRemaining, 
            TaskStatus status)
        {
            TenantId = tenantId;
            BacklogItemId = backlogItemId;
            TaskId = taskId;
            Volunteer = teamMember.TeamMemberId;
            Name = name;
            Description = description;
            HoursRemaining = hoursRemaining;
            Status = status;
            _estimationLog = new List<EstimationLogEntry>();
        }

        private TeamMemberId _volunteer;
        private List<EstimationLogEntry> _estimationLog;
        private string _name;
        private string _description;

        public TenantId TenantId { get; private set; }

        internal BacklogItemId BacklogItemId { get; private set; }

        internal TaskId TaskId { get; private set; }

        public string Name
        {
            get { return _name; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "Name is required.");
                AssertionConcern.AssertArgumentLength(value, 100, "Name must be 100 characters or less.");
                _name = value;
            }
        }

        public string Description
        {
            get { return _description; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "Description is required.");
                AssertionConcern.AssertArgumentLength(value, 65000, "Description must be 65000 characters or less.");
                _description = value;
            }
        }

        public TaskStatus Status { get; private set; }

        public TeamMemberId Volunteer
        {
            get { return _volunteer; }
            private set
            {
                AssertionConcern.AssertArgumentNotNull(value, "The volunteer id must be provided.");
                AssertionConcern.AssertArgumentEquals(TenantId, value.TenantId, "The volunteer must be of the same tenant.");
                _volunteer = value;
            }
        }
       
        internal int HoursRemaining { get; private set; }        

        internal void AssignVolunteer(TeamMember teamMember)
        {
            AssertionConcern.AssertArgumentNotNull(teamMember, "A volunteer must be provided.");
            Volunteer = teamMember.TeamMemberId;
            DomainEventPublisher.Instance.Publish(
                new TaskVolunteerAssigned(TenantId, BacklogItemId, TaskId, teamMember.TeamMemberId.Id));
        }

        internal void ChangeStatus(TaskStatus status)
        {
            Status = status;
            DomainEventPublisher.Instance.Publish(
                new TaskStatusChanged(TenantId, BacklogItemId, TaskId, status));
        }

        internal void DescribeAs(string description)
        {
            Description = description;
            DomainEventPublisher.Instance.Publish(
                new TaskDescribed(TenantId, BacklogItemId, TaskId, description));
        }

        internal void EstimateHoursRemaining(int hoursRemaining)
        {
            if (hoursRemaining < 0)
                throw new ArgumentOutOfRangeException("hoursRemaining");

            if (hoursRemaining != HoursRemaining)
            {
                HoursRemaining = hoursRemaining;
                DomainEventPublisher.Instance.Publish(
                    new TaskHoursRemainingEstimated(TenantId, BacklogItemId, TaskId, hoursRemaining));

                if (hoursRemaining == 0 && Status != TaskStatus.Done)
                {
                    ChangeStatus(TaskStatus.Done);
                }
                else if (hoursRemaining > 0 && Status != TaskStatus.InProgress)
                {
                    ChangeStatus(TaskStatus.InProgress);
                }

                LogEstimation(hoursRemaining);
            }
        }

        private void LogEstimation(int hoursRemaining)
        {
            var today = EstimationLogEntry.CurrentLogDate;
            var updatedLogForToday = _estimationLog.Any(entry => entry.UpdateHoursRemainingWhenDateMatches(hoursRemaining, today));
            if (updatedLogForToday)
            {
                _estimationLog.Add(
                    new EstimationLogEntry(TenantId, TaskId, today, hoursRemaining));
            }
        }

        internal void Rename(string name)
        {
            Name = name;
            DomainEventPublisher.Instance.Publish(
                new TaskRenamed(TenantId, BacklogItemId, TaskId, name));
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return TenantId;
            yield return BacklogItemId;
            yield return TaskId;
        }
    }
}
