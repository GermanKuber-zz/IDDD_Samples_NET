using System;
using SaaSOvation.IdentityAccess.Domain.Model.Identity;

namespace SaaSOvation.IdentityAccess.Domain.Model.Access
{
    public class UserAssignedToRole : Common.Domain.Model.IDomainEvent
    {
        public UserAssignedToRole(
            TenantId tenantId,
            string roleName,
            string username,
            string firstName,
            string lastName,
            string emailAddress)
        {
            EmailAddress = emailAddress;
            EventVersion = 1;
            FirstName = firstName;
            LastName = lastName;
            OccurredOn = DateTime.Now;
            RoleName = roleName;
            TenantId = tenantId;
            Username = username;
        }

        public string EmailAddress { get; private set; }

        public int EventVersion { get; set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime OccurredOn { get; set; }

        public string RoleName { get; private set; }

        public TenantId TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
