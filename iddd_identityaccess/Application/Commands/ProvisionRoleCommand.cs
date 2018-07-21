namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class ProvisionRoleCommand
    {
        public ProvisionRoleCommand()
        {
        }

        public ProvisionRoleCommand(string tenantId, string roleName, string description, bool supportsNesting)
        {
            TenantId = tenantId;
            RoleName = roleName;
            Description = description;
            SupportsNesting = supportsNesting;
        }

        public string TenantId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool SupportsNesting { get; set; }
    }
}
