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

        public Tenant TenantId { get; }
        public ForumId ForumId { get; }
        public string Description { get; }
        public string ExclusiveOwner { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
