using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class DiscussionClosed : IDomainEvent
    {
        public DiscussionClosed(Tenant tenantId, ForumId forumId, DiscussionId discussionId, string exclusiveOwner)
        {
            TenantId = tenantId;
            ForumId = forumId;
            DiscussionId = discussionId;
            ExclusiveOwner = exclusiveOwner;
        }

        public Tenant TenantId { get; }
        public ForumId ForumId { get; }
        public DiscussionId DiscussionId { get; }
        public string ExclusiveOwner { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
