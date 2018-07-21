using System;

namespace SaaSOvation.AgilePM.Application.Teams
{
    public class EnableProductOwnerCommand : EnableMemberCommand
    {
        public EnableProductOwnerCommand()
        {
        }

        public EnableProductOwnerCommand(string tenantId, string username, string firstName, string lastName, string emailAddress, DateTime occurredOn)
            : base(tenantId, username, firstName, lastName, emailAddress, occurredOn)
        {
        }
    }
}
