using System;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class PersonNameChanged : Common.Domain.Model.IDomainEvent
    {
        public PersonNameChanged(
                TenantId tenantId,
                String username,
                FullName name)
        {
            EventVersion = 1;
            Name = name;
            OccurredOn = DateTime.Now;
            TenantId = tenantId.Id;
            Username = username;
        }

        public int EventVersion { get; set; }

        public FullName Name { get; private set; }

        public DateTime OccurredOn { get; set; }

        public string TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
