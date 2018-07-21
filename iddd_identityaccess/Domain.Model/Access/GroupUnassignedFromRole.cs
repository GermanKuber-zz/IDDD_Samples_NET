using System;
using SaaSOvation.IdentityAccess.Domain.Model.Identity;

namespace SaaSOvation.IdentityAccess.Domain.Model.Access
{
    public class GroupUnassignedFromRole : Common.Domain.Model.IDomainEvent
    {
        public GroupUnassignedFromRole(TenantId tenantId, string roleName, string groupName)
        {
            EventVersion = 1;
            GroupName = groupName;
            OccurredOn = DateTime.Now;
            RoleName = roleName;
            TenantId = tenantId;
        }

        public int EventVersion { get; set; }

        public string GroupName { get; }

        public DateTime OccurredOn { get; set; }

        public string RoleName { get; }

        public TenantId TenantId { get; }
    }
}
