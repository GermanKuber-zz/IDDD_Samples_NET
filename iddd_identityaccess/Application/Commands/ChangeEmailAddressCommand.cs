namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class ChangeEmailAddressCommand
    {
        public ChangeEmailAddressCommand()
        {
        }

        public ChangeEmailAddressCommand(string tenantId, string userName, string emailAddress)
        {
            TenantId = tenantId;
            Username = userName;
            EmailAddress = emailAddress;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
    }
}
