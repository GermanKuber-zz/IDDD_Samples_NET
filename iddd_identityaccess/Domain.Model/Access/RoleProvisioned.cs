using System;
using SaaSOvation.IdentityAccess.Domain.Model.Identity;

namespace SaaSOvation.IdentityAccess.Domain.Model.Access
{
    public class RoleProvisioned : Common.Domain.Model.IDomainEvent
    {
        public RoleProvisioned(TenantId tenantId, string name)
        {
            EventVersion = 1;
            Name = name;
            OccurredOn = DateTime.Now;
            TenantId = tenantId.Id;
        }

        public int EventVersion { get; set; }

        public string Name { get; }

        public DateTime OccurredOn { get; set; }

        public string TenantId { get; }
    }
}
