using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BacklogItemDiscussionInitiated : IDomainEvent
    {
        public BacklogItemDiscussionInitiated(Tenants.TenantId tenantId, BacklogItemId backlogItemId, BacklogItemDiscussion discussion)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;

            Discussion = discussion;
        }

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; private set; }

        public BacklogItemDiscussion Discussion { get; private set; }
    }
}
