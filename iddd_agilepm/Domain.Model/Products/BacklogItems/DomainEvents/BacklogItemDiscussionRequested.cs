using System;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.DomainEvents
{
    public class BacklogItemDiscussionRequested : IDomainEvent
    {
        public BacklogItemDiscussionRequested(Tenants.TenantId tenantId, ProductId productId, BacklogItemId backlogItemId, bool isRequested)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            ProductId = productId;
            BacklogItemId = backlogItemId;
            IsRequested = isRequested;
        }

        public Tenants.TenantId TenantId { get; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public ProductId ProductId { get; }
        public BacklogItemId BacklogItemId { get; }

        public bool IsRequested { get; }
    }
}
