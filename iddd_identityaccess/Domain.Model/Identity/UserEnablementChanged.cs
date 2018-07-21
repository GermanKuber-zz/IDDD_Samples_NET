using System;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class UserEnablementChanged : Common.Domain.Model.IDomainEvent
    {
        public UserEnablementChanged(
                TenantId tenantId,
                String username,
                Enablement enablement)
        {
            Enablement = enablement;
            EventVersion = 1;
            OccurredOn = DateTime.Now;
            TenantId = tenantId.Id;
            Username = username;
        }

        public Enablement Enablement { get; }

        public int EventVersion { get; set; }

        public DateTime OccurredOn { get; set; }

        public string TenantId { get; }

        public string Username { get; }
    }
}
