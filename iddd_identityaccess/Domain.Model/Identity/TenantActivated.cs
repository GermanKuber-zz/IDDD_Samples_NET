using System;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class TenantActivated : Common.Domain.Model.IDomainEvent
    {
        public TenantActivated(TenantId tenantId)
        {
            EventVersion = 1;
            OccurredOn = DateTime.Now;
            TenantId = tenantId.Id;
        }

        public int EventVersion { get; set; }

        public DateTime OccurredOn { get; set; }

        public string TenantId { get; private set; }
    }
}
