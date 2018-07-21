using System;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class GroupGroupRemoved : Common.Domain.Model.IDomainEvent
    {
        public GroupGroupRemoved(TenantId tenantId, string groupName, string nestedGroupName)
        {
            EventVersion = 1;
            GroupName = groupName;
            NestedGroupName = nestedGroupName;
            OccurredOn = DateTime.Now;
            TenantId = tenantId.Id;
        }

        public int EventVersion { get; set; }

        public string GroupName { get; private set; }

        public string NestedGroupName { get; private set; }

        public DateTime OccurredOn { get; set; }

        public string TenantId { get; private set; }
    }

}
