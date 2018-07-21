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

        public Tenant TenantId { get; private set; }
        public ForumId ForumId { get; private set; }
        public Creator Creator { get; private set; }
        public Moderator Moderator { get; private set; }
        public string Subject { get; private set; }
        public string Description { get; private set; }
        public string ExclusiveOwner { get; private set; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
