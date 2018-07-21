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

        public Tenant TenantId { get; private set; }
        public ForumId ForumId { get; private set; }
        public DiscussionId DiscussionId { get; private set; }
        public Author Author { get; private set; }
        public string Subject { get; private set; }
        public string ExclusiveOwner { get; private set; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
