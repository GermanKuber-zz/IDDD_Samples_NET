using System;
using SaaSOvation.IdentityAccess.Domain.Model.Identity;

namespace SaaSOvation.IdentityAccess.Domain.Model.Access
{
    public class UserUnassignedFromRole : Common.Domain.Model.IDomainEvent
    {
        public UserUnassignedFromRole(TenantId tenantId, string roleName, string username)
        {
            EventVersion = 1;
            OccurredOn = DateTime.Now;
            RoleName = roleName;
            TenantId = tenantId;
            Username = username;
        }

        public int EventVersion { get; set; }

        public string Username { get; }

        public DateTime OccurredOn { get; set; }

        public string RoleName { get; }

        public TenantId TenantId { get; }
    }
}
