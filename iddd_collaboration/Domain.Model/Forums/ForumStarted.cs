using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class ForumStarted : IDomainEvent
    {
        public ForumStarted(Tenant tenantId, ForumId forumId, Creator creator, Moderator moderator, string subject, string description, string exclusiveOwner)
        {
            TenantId = tenantId;
            ForumId = forumId;
            Creator = creator;
            Moderator = moderator;
            Subject = subject;
            Description = description;
            ExclusiveOwner = exclusiveOwner;
        }

        public Tenant TenantId { get; }
        public ForumId ForumId { get; }
        public Creator Creator { get; }
        public Moderator Moderator { get; }
        public string Subject { get; }
        public string Description { get; }
        public string ExclusiveOwner { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
