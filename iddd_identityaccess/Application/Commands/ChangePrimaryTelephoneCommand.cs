namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class ChangePrimaryTelephoneCommand
    {
        public ChangePrimaryTelephoneCommand()
        {
        }

        public ChangePrimaryTelephoneCommand(string tenantId, string userName, string telephone)
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
