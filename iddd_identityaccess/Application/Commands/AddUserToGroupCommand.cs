namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class AddUserToGroupCommand
    {
        public AddUserToGroupCommand()
        {
        }

        public AddUserToGroupCommand(string tenantId, string groupName, string userNmae)
        {
            TenantId = tenantId;
            GroupName = groupName;
            Username = userNmae;
        }

        public string TenantId { get; set; }
        public string GroupName { get; set; }
        public string Username { get; set; }
    }
}
