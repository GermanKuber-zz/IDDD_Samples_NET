using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BacklogItemMarkedAsRemoved : IDomainEvent
    {
        public BacklogItemMarkedAsRemoved(Tenants.TenantId tenantId, BacklogItemId backlogItemId)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;
        }

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; private set; }
    }
}
