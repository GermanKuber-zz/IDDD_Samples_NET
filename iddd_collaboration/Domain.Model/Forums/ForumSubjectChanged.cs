using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class ForumSubjectChanged : IDomainEvent
    {
        public ForumSubjectChanged(Tenant tenantId, ForumId forumId, string subject, string exclusiveOwner)
        {
            TenantId = tenantId;
            ForumId = forumId;
            Subject = subject;
            ExclusiveOwner = exclusiveOwner;
        }

        public Tenant TenantId { get; private set; }
        public ForumId ForumId { get; private set; }
        public string Subject { get; private set; }
        public string ExclusiveOwner { get; private set; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
