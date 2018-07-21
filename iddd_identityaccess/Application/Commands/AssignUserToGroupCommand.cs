namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class AssignUserToGroupCommand
    {
        public AssignUserToGroupCommand()
        {
        }

        public AssignUserToGroupCommand(string tenantId, string groupName, string userName)
        {
            TenantId = tenantId;
            GroupName = groupName;
            Username = userName;
        }

        public string TenantId { get; set; }
        public string GroupName { get; set; }
        public string Username { get; set; }
    }
}
