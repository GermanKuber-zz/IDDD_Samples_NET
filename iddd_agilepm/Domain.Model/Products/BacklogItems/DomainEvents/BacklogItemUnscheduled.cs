using System;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.DomainEvents
{
    public class BacklogItemUnscheduled : IDomainEvent
    {
        public BacklogItemUnscheduled(Tenants.TenantId tenantId, BacklogItemId backlogItemId, Releases.ReleaseId unscheduledReleaseId)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;

            UnscheduledReleaseId = unscheduledReleaseId;
        }

        public Tenants.TenantId TenantId { get; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; }

        public Releases.ReleaseId UnscheduledReleaseId { get; }
    }
}
