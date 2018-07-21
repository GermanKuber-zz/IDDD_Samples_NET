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

        public string EmailAddress { get; }

        public int EventVersion { get; set; }

        public string FirstName { get; }

        public string LastName { get; }

        public DateTime OccurredOn { get; set; }

        public string RoleName { get; }

        public TenantId TenantId { get; }

        public string Username { get; }
    }
}
