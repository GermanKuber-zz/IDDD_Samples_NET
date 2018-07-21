using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Forums
{
    public class DiscussionStarted : IDomainEvent
    {
        public DiscussionStarted(Tenant tenantId, ForumId forumId, DiscussionId discussionId, Author author, string subject, string exclusiveOwner)
        {
            TenantId = tenantId;
            ForumId = forumId;
            DiscussionId = discussionId;
            Author = author;
            Subject = subject;
            ExclusiveOwner = exclusiveOwner;
        }

        public Tenant TenantId { get; }
        public ForumId ForumId { get; }
        public DiscussionId DiscussionId { get; }
        public Author Author { get; }
        public string Subject { get; }
        public string ExclusiveOwner { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
