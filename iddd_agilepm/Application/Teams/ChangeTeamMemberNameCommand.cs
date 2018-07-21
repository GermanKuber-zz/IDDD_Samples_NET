using System;

namespace SaaSOvation.AgilePM.Application.Teams
{
    public class ChangeTeamMemberNameCommand
    {
        public ChangeTeamMemberNameCommand()
        {
        }

        public ChangeTeamMemberNameCommand(string tenantId, string username, string firstName, string lastName, DateTime occurredOn)
        {
            TenantId = tenantId;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            OccurredOn = occurredOn;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
