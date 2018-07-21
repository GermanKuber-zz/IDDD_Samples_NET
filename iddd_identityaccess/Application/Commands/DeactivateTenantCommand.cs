namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class DeactivateTenantCommand
    {
        public DeactivateTenantCommand()
        {
        }

        public DeactivateTenantCommand(string tenantId, string userName, string firstName, string lastName)
        {
            TenantId = tenantId;
            Username = userName;
            FirstName = firstName;
            LastName = lastName;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
