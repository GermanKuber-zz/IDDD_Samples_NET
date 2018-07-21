using System;
using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class Discussion : EventSourcedRootEntity
    {
        public Discussion(IEnumerable<IDomainEvent> eventStream, int streamVersion)
            : base(eventStream, streamVersion)
        {
        }
    
        public Discussion(Tenant tenantId, ForumId forumId, DiscussionId discussionId, Author author, string subject, string exclusiveOwner = null)
        {
            AssertionConcern.AssertArgumentNotNull(tenantId, "The tenant must be provided.");
            AssertionConcern.AssertArgumentNotNull(forumId, "The forum id must be provided.");
            AssertionConcern.AssertArgumentNotNull(discussionId, "The discussion id must be provided.");
            AssertionConcern.AssertArgumentNotNull(author, "The author must be provided.");
            AssertionConcern.AssertArgumentNotEmpty(subject, "The subject must be provided.");

            Apply(new DiscussionStarted(tenantId, forumId, discussionId, author, subject, exclusiveOwner));
        }

        private void When(DiscussionStarted e)
        {
            _tenantId = e.TenantId;
            _forumId = e.ForumId;
            _discussionId = e.DiscussionId;
            _author = e.Author;
            _subject = e.Subject;
            _exclusiveOwner = e.ExclusiveOwner;
        }

        private Tenant _tenantId;
        private ForumId _forumId;
        private DiscussionId _discussionId;
        private Author _author;
        private string _subject;
        private string _exclusiveOwner;
        private bool _closed;

        public DiscussionId DiscussionId
        {
            get { return _discussionId; }
        }

        private void AssertClosed()
        {
            if (!_closed)
                throw new InvalidOperationException("This discussion is already open.");
        }

        public void Close()
        {
            if (_closed)
                throw new InvalidOperationException("This discussion is already closed.");

            Apply(new DiscussionClosed(_tenantId, _forumId, _discussionId, _exclusiveOwner));
        }

        private void When(DiscussionClosed e)
        {
            _closed = true;
        }


        public Post Post(ForumIdentityService forumIdService, Author author, string subject, string bodyText, PostId replyToPostId = null)
        {
            return new Post(
                _tenantId,
                _forumId,
                _discussionId,
                forumIdService.GetNexPostId(),
                author,
                subject,
                bodyText,
                replyToPostId);
        }


        public void ReOpen()
        {
            AssertClosed();
            Apply(new DiscussionReopened(_tenantId, _forumId, _discussionId, _exclusiveOwner));
        }

        private void When(DiscussionReopened e)
        {
            _closed = false;
        }




        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return _tenantId;
            yield return _forumId;
            yield return _discussionId;
        }
    }
}
