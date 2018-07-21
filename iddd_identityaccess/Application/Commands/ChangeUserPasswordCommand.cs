namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class ChangeUserPasswordCommand
    {
        public ChangeUserPasswordCommand()
        {
        }

        public ChangeUserPasswordCommand(string tenantId, string userName, string currentPassword, string changedPassword)
        {
            TenantId = tenantId;
            Username = userName;
            CurrentPassword = currentPassword;
            ChangedPassword = changedPassword;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public string CurrentPassword { get; set; }
        public string ChangedPassword { get; set; }
    }
}
