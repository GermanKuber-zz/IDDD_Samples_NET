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

        public Tenant TenantId { get; }
        public ForumId ForumId { get; }
        public string Subject { get; }
        public string ExclusiveOwner { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
