using System;

namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class RemoveUserFromGroupCommand
    {
        public RemoveUserFromGroupCommand()
        {
        }

        public RemoveUserFromGroupCommand(String tenantId, String groupName, String username)
        {
            TenantId = tenantId;
            GroupName = groupName;
            Username = username;
        }

        public string TenantId { get; set; }
        public string GroupName { get; set; }
        public string Username { get; set; }
    }
}
