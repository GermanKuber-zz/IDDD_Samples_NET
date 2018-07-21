using System;

namespace SaaSOvation.AgilePM.Application.Teams
{
    public class EnableMemberCommand
    {
        public EnableMemberCommand()
        {
        }

        public EnableMemberCommand(string tenantId, string username, string firstName, string lastName, string emailAddress, DateTime occurredOn)
        {
            TenantId = tenantId;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            OccurredOn = occurredOn;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
