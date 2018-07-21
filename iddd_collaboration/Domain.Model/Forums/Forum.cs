using System;
using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class Forum : EventSourcedRootEntity
    {
        public Forum(IEnumerable<IDomainEvent> eventStream, int streamVersion)
            : base(eventStream, streamVersion)
        {
        }

        public Forum(Tenant tenantId, ForumId forumId, Creator creator, Moderator moderator, string subject, string description, string exclusiveOwner)
        {
            AssertionConcern.AssertArgumentNotNull(tenantId, "The tenant must be provided.");
            AssertionConcern.AssertArgumentNotNull(forumId, "The forum id must be provided.");
            AssertionConcern.AssertArgumentNotNull(creator, "The creator must be provided.");
            AssertionConcern.AssertArgumentNotNull(moderator, "The moderator must be provided.");
            AssertionConcern.AssertArgumentNotEmpty(subject, "The subject must be provided.");
            AssertionConcern.AssertArgumentNotEmpty(description, "The description must be provided.");

            Apply(new ForumStarted(tenantId, forumId, creator, moderator, subject, description, exclusiveOwner));
        }

        private void When(ForumStarted e)
        {
            _tenantId = e.TenantId;
            _forumId = e.ForumId;
            _creator = e.Creator;
            _moderator = e.Moderator;
            _subject = e.Subject;
            _description = e.Description;
            _exclusiveOwner = e.ExclusiveOwner;
        }

        private Tenant _tenantId;
        private ForumId _forumId;
        private Creator _creator;
        private Moderator _moderator;
        private string _subject;
        private string _description;
        private string _exclusiveOwner;
        private bool _closed;

        public ForumId ForumId
        {
            get { return _forumId; }
        }

        private void AssertOpen()
        {
            if (_closed)
                throw new InvalidOperationException("Forum is closed.");
        }

        private void AssertClosed()
        {
            if (!_closed)
                throw new InvalidOperationException("Forum is open.");
        }

        public void AssignModerator(Moderator moderator)
        {
            AssertOpen();
            AssertionConcern.AssertArgumentNotNull(moderator, "The moderator must be provided.");
            Apply(new ForumModeratorChanged(_tenantId, _forumId, moderator, _exclusiveOwner));
        }

        private void When(ForumModeratorChanged e)
        {
            _moderator = e.Moderator;
        }


        public void ChangeDescription(string description)
        {
            AssertOpen();
            AssertionConcern.AssertArgumentNotEmpty(description, "The description must be provided.");
            Apply(new ForumDescriptionChanged(_tenantId, _forumId, description, _exclusiveOwner));
        }

        private void When(ForumDescriptionChanged e)
        {
            _description = e.Description;
        }


        public void ChangeSubject(string subject)
        {
            AssertOpen();
            AssertionConcern.AssertArgumentNotEmpty(subject, "The subject must be provided.");
            Apply(new ForumSubjectChanged(_tenantId, _forumId, subject, _exclusiveOwner));
        }

        private void When(ForumSubjectChanged e)
        {
            _subject = e.Subject;
        }


        public void Close()
        {
            AssertOpen();
            Apply(new ForumClosed(_tenantId, _forumId, _exclusiveOwner));
        }

        private void When(ForumClosed e)
        {
            _closed = true;
        }


        public void ModeratePost(Post post, Moderator moderator, string subject, string bodyText)
        {
            AssertOpen();
            AssertionConcern.AssertArgumentNotNull(post, "Post may not be null.");
            AssertionConcern.AssertArgumentEquals(_forumId, post.ForumId, "Not a post of this forum.");
            AssertionConcern.AssertArgumentTrue(IsModeratedBy(moderator), "Not the moderator of this forum.");
            post.AlterPostContent(subject, bodyText);
        }


        public void ReOpen()
        {
            AssertClosed();
            Apply(new ForumReopened(_tenantId, _forumId, _exclusiveOwner));
        }

        private void When(ForumReopened e)
        {
            _closed = false;
        }

        public Discussion StartDiscussionFor(ForumIdentityService forumIdService, Author author, string subject, string exclusiveOwner = null)
        {
            AssertOpen();
            return new Discussion(
                _tenantId,
                _forumId,
                forumIdService.GetNextDiscussionId(),
                author,
                subject,
                exclusiveOwner);
        }


        public bool IsModeratedBy(Moderator moderator)
        {
            return this._moderator.Equals(moderator);
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return _tenantId;
            yield return _forumId;
        }
    }
}
