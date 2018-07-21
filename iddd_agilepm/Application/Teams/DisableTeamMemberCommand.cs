using System;

namespace SaaSOvation.AgilePM.Application.Teams
{
    public class DisableTeamMemberCommand : DisableMemberCommand
    {
        public DisableTeamMemberCommand()
        {
        }

        public DisableTeamMemberCommand(string tenantId, string username, DateTime occurredOn)
            : base(tenantId, username, occurredOn)
        {
        }
    }
}
