using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class ForumDescriptionChanged : IDomainEvent
    {
        public ForumDescriptionChanged(Tenant tenantId, ForumId forumId, string description, string exclusiveOwner)
        {
            TenantId = tenantId;
            ForumId = forumId;
            Description = description;
            ExclusiveOwner = exclusiveOwner;
        }

        public Tenant TenantId { get; private set; }
        public ForumId ForumId { get; private set; }
        public string Description { get; private set; }
        public string ExclusiveOwner { get; private set; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
