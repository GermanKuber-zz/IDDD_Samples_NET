using System;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class GroupProvisioned : Common.Domain.Model.IDomainEvent
    {
        public GroupProvisioned(TenantId tenantId, string name)
        {
            EventVersion = 1;
            Name = name;
            OccurredOn = DateTime.Now;
            TenantId = tenantId.Id;
        }

        public int EventVersion { get; set; }

        public string Name { get; private set; }

        public DateTime OccurredOn { get; set; }

        public string TenantId { get; private set; }
    }
}
