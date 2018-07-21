using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class PostedToDiscussion : IDomainEvent
    {
        public PostedToDiscussion(Tenant tenantId, ForumId forumId, DiscussionId discussionId, PostId postId, Author author, string subject, string bodyText, PostId replyToPostId)
        {
            TenantId = tenantId;
            ForumId = forumId;
            DiscussionId = discussionId;
            PostId = postId;
            Author = author;
            Subject = subject;
            BodyText = bodyText;
            ReplyToPostId = replyToPostId;
        }

        public Tenant TenantId { get; }
        public ForumId ForumId { get; }
        public DiscussionId DiscussionId { get; }
        public PostId PostId { get; }
        public Author Author { get; }
        public string Subject { get; }
        public string BodyText { get; }
        public PostId ReplyToPostId { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
