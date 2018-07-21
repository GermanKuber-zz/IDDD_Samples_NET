using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BacklogItemStatusChanged : IDomainEvent
    {
        public BacklogItemStatusChanged(Tenants.TenantId tenantId, BacklogItemId backlogItemId, BacklogItemStatus status)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;

            Status = status;
        }

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; private set; }

        public BacklogItemStatus Status { get; private set; }
    }
}
