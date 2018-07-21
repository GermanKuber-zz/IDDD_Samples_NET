using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BacklogItemScheduled : IDomainEvent
    {
        public BacklogItemScheduled(Tenants.TenantId tenantId, BacklogItemId backlogItemId, Releases.ReleaseId releaseId)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;

            ReleaseId = releaseId;
        }

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; private set; }

        public Releases.ReleaseId ReleaseId { get; private set; }
    }
}
