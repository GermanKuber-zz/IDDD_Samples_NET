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

        public Tenant TenantId { get; private set; }
        public ForumId ForumId { get; private set; }
        public string ExclusiveOwner { get; private set; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
