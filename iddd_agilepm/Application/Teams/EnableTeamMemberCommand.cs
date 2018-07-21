using System;

namespace SaaSOvation.AgilePM.Application.Teams
{
    public class EnableTeamMemberCommand : EnableMemberCommand
    {
        public EnableTeamMemberCommand()
        {
        }

        public EnableTeamMemberCommand(string tenantId, string username, string firstName, string lastName, string emailAddress, DateTime occurredOn)
            : base(tenantId, username, firstName, lastName, emailAddress, occurredOn)
        {
        }
    }
}
