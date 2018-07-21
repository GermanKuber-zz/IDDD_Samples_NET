using System;

namespace SaaSOvation.AgilePM.Application.Products
{
    public class TimeOutProductDiscussionRequestCommand
    {
        public TimeOutProductDiscussionRequestCommand()
        {
        }

        public TimeOutProductDiscussionRequestCommand(string tenantId, string processId, DateTime timeOutDate)
        {
            TenantId = tenantId;
            ProcessId = processId;
            TimeOutDate = timeOutDate;
        }

        public string TenantId { get; set; }

        public string ProcessId { get; set; }

        public DateTime TimeOutDate { get; set; }
    }
}
