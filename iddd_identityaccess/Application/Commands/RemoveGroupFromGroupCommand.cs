using System;

namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class RemoveGroupFromGroupCommand
    {
        public RemoveGroupFromGroupCommand()
        {
        }

        public RemoveGroupFromGroupCommand(String tenantId, String parentGroupName, String childGroupName)
        {
            TenantId = tenantId;
            ParentGroupName = parentGroupName;
            ChildGroupName = childGroupName;
        }

        public string TenantId { get; set; }
        public string ChildGroupName { get; set; }
        public string ParentGroupName { get; set; }
    }
}
