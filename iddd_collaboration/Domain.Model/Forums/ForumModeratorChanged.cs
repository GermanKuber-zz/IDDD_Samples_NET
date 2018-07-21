using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class ForumModeratorChanged : IDomainEvent
    {
        public ForumModeratorChanged(Tenant tenantId, ForumId forumId, Moderator moderator,string exclusiveOwner)
        {
            TenantId = tenantId;
            ForumId = forumId;
            Moderator = moderator;
            ExclusiveOwner = exclusiveOwner;
        }

        public Tenant TenantId { get; }
        public ForumId ForumId { get; }
        public Moderator Moderator { get; }
        public string ExclusiveOwner { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
