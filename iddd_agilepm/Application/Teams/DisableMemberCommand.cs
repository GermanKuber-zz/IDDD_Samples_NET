using System;

namespace SaaSOvation.AgilePM.Application.Teams
{
    public class DisableMemberCommand
    {
        public DisableMemberCommand()
        {
        }

        public DisableMemberCommand(string tenantId, string username, DateTime occurredOn)
        {
            TenantId = tenantId;
            Username = username;
            OccurredOn = occurredOn;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
