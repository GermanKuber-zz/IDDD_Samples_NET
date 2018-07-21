using System;

namespace SaaSOvation.AgilePM.Application.Teams
{
    public class ChangeTeamMemberEmailAddressCommand
    {
        public ChangeTeamMemberEmailAddressCommand()
        {
        }

        public ChangeTeamMemberEmailAddressCommand(string tenantId, string username, string emailAddress, DateTime occurredOn)
        {
            TenantId = tenantId;
            Username = username;
            EmailAddress = emailAddress;
            OccurredOn = occurredOn;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
