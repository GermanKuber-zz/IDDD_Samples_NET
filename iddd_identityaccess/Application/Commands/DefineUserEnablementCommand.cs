using System;

namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class DefineUserEnablementCommand
    {
        public DefineUserEnablementCommand()
        {
        }

        public DefineUserEnablementCommand(string tenantId, string userName, string enabled, DateTime startDate, DateTime endDate)
        {
            TenantId = tenantId;
            Username = userName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public bool Enabled { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
