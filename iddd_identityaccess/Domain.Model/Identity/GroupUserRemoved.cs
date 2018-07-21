using System;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class GroupUserRemoved : Common.Domain.Model.IDomainEvent
    {
        public GroupUserRemoved(TenantId tenantId, string groupName, string username)
        {
            EventVersion = 1;
            GroupName = groupName;
            OccurredOn = DateTime.Now;
            TenantId = tenantId.Id;
            Username = username;
        }

        public int EventVersion { get; set; }

        public string GroupName { get; private set; }

        public DateTime OccurredOn { get; set; }

        public string TenantId { get; private set; }

        public string Username { get; private set; }
    }
}
