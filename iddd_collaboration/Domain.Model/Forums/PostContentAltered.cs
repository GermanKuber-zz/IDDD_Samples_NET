using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class PostedContentAltered : IDomainEvent
    {
        public PostedContentAltered(Tenant tenantId, ForumId forumId, DiscussionId discussionId, PostId postId, string subject, string bodyText)
        {
            TenantId = tenantId;
            ForumId = forumId;
            DiscussionId = discussionId;
            PostId = postId;
            Subject = subject;
            BodyText = bodyText;
        }

        public Tenant TenantId { get; }
        public ForumId ForumId { get; }
        public DiscussionId DiscussionId { get; }
        public PostId PostId { get; }
        public string Subject { get; }
        public string BodyText { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
