namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class ActivateTenantCommand
    {
        public ActivateTenantCommand() { }

        public ActivateTenantCommand(string tenantId)
        {
            TenantId = tenantId;
        }

        public string TenantId { get; set; }
    }
}
