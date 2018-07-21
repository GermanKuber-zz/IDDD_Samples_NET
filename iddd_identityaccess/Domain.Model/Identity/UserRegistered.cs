using System;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class UserRegistered : Common.Domain.Model.IDomainEvent
    {
        public UserRegistered(
                TenantId tenantId,
                String username,
                FullName name,
                EmailAddress emailAddress)
        {
            EmailAddress = emailAddress;
            EventVersion = 1;
            Name = name;
            OccurredOn = DateTime.Now;
            TenantId = tenantId.Id;
            Username = username;
        }

        public EmailAddress EmailAddress { get; private set; }

        public int EventVersion { get; set; }

        public FullName Name { get; private set; }

        public DateTime OccurredOn { get; set; }

        public string TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
