namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class AuthenticateUserCommand
    {
        public AuthenticateUserCommand()
        {
        }

        public AuthenticateUserCommand(string tenantId, string userName, string password)
        {
            TenantId = tenantId;
            Username = userName;
            Password = password;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
