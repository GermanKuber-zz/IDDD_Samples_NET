namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class ChangeSecondaryTelephoneCommand
    {
        public ChangeSecondaryTelephoneCommand()
        {
        }

        public ChangeSecondaryTelephoneCommand(string tenantId, string userName, string telephone)
        {
            TenantId = tenantId;
            Username = userName;
            Telephone = telephone;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public string Telephone { get; set; }
    }
}
