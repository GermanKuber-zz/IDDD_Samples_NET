namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class ProvisionGroupCommand
    {
        public ProvisionGroupCommand()
        {
        }

        public ProvisionGroupCommand(string tenantId, string groupName, string description)
        {
            TenantId = tenantId;
            GroupName = groupName;
            Description = description;
        }

        public string TenantId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
    }
}
