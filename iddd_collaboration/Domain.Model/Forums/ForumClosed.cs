using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class ForumClosed : IDomainEvent
    {
        public ForumClosed(Tenant tenantId, ForumId forumId, string exclusiveOwner)
        {
            TenantId = tenantId;
            ForumId = forumId;
            ExclusiveOwner = exclusiveOwner;
        }

        public Tenant TenantId { get; }
        public ForumId ForumId { get; }
        public string ExclusiveOwner { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
