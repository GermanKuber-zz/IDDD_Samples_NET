using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class Post : EventSourcedRootEntity
    {
        public Post(IEnumerable<IDomainEvent> eventStream, int streamVersion)
            : base(eventStream, streamVersion)
        {
        }

        private Tenant _tenantId;
        private ForumId _forumId;
        private DiscussionId _discussionId;
        private PostId _postId;
        private Author _author;
        private string _subject;
        private string _bodyText;
        private PostId _replyToPostId;

        public ForumId ForumId
        {
            get { return _forumId; }
        }

        public PostId PostId
        {
            get { return _postId; }
        }

        public Post(Tenant tenantId, ForumId forumId, DiscussionId discussionId, PostId postId, Author author, string subject, string bodyText, PostId replyToPostId = null)
        {
            AssertionConcern.AssertArgumentNotNull(tenantId, "The tenant must be provided.");
            AssertionConcern.AssertArgumentNotNull(forumId, "The forum id must be provided.");
            AssertionConcern.AssertArgumentNotNull(discussionId, "The discussion id must be provided.");
            AssertionConcern.AssertArgumentNotNull(postId, "The post id must be provided.");
            AssertionConcern.AssertArgumentNotNull(author, "The author must be provided.");
            AssertPostContent(subject, bodyText);

            Apply(new PostedToDiscussion(tenantId, forumId, discussionId, postId, author, subject, bodyText, replyToPostId));
        }

        private void When(PostedToDiscussion e)
        {
            _tenantId = e.TenantId;
            _forumId = e.ForumId;
            _discussionId = e.DiscussionId;
            _postId = e.PostId;
            _author = e.Author;
            _subject = e.Subject;
            _bodyText = e.BodyText;
            _replyToPostId = e.ReplyToPostId;
        }

        private void AssertPostContent(string subject, string bodyText)
        {
            AssertionConcern.AssertArgumentNotEmpty(subject, "The subject must be provided.");
            AssertionConcern.AssertArgumentNotEmpty(bodyText, "The body text must be provided.");
        }


        internal void AlterPostContent(string subject, string bodyText)
        {
            AssertPostContent(subject, bodyText);
            Apply(new PostedContentAltered(_tenantId, _forumId, _discussionId, _postId, subject, bodyText));
        }

        private void When(PostedContentAltered e)
        {
            _subject = e.Subject;
            _bodyText = e.BodyText;
        }
        

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return _tenantId;
            yield return _forumId;
            yield return _discussionId;
            yield return _postId;
        }
    }
}
