using System;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.DomainEvents
{
    public class BacklogItemCategoryChanged : IDomainEvent
    {
        public BacklogItemCategoryChanged(Tenants.TenantId tenantId, BacklogItemId backlogItemId, string category)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;

            Category = category;
        }

        public Tenants.TenantId TenantId { get; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; }

        public string Category { get; }
    }
}
