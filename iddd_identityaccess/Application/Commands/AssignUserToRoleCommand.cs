namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class AssignUserToRoleCommand
    {
        public AssignUserToRoleCommand()
        {
        }

        public AssignUserToRoleCommand(string tenantId, string userName, string roleName)
        {
            TenantId = tenantId;
            Username = userName;
            RoleName = roleName;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
    }
}
