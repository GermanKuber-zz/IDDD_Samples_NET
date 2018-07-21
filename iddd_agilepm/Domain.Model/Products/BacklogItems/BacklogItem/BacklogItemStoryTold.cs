using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem
{
    public class BacklogItemStoryTold : IDomainEvent
    {
        public BacklogItemStoryTold(Tenants.TenantId tenantId, BacklogItemId backlogItemId, string story)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;
            Story = story;
        }

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; private set; }

        public string Story { get; private set; }
    }
}
