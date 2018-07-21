using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BacklogItemTypeChanged : IDomainEvent
    {
        public BacklogItemTypeChanged(Tenants.TenantId tenantId, BacklogItemId backlogItemId, BacklogItemType type)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;

            BacklogItemType = type;
        }

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; private set; }

        public BacklogItemType BacklogItemType { get; private set; }
    }
}
