using System;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class UserPasswordChanged : Common.Domain.Model.IDomainEvent
    {
        public UserPasswordChanged(
                TenantId tenantId,
                String username)
        {
            EventVersion = 1;
            OccurredOn = DateTime.Now;
            TenantId = tenantId.Id;
            Username = username;
        }

        public int EventVersion { get; set; }

        public DateTime OccurredOn { get; set; }

        public string TenantId { get; }

        public string Username { get; }
    }
}
