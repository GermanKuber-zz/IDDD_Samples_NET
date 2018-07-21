namespace SaaSOvation.AgilePM.Application.Products
{
    public class RetryProductDiscussionRequestCommand
    {
        public RetryProductDiscussionRequestCommand()
        {
        }

        public RetryProductDiscussionRequestCommand(string tenantId, string processId)
        {
            TenantId = tenantId;
            ProcessId = processId;
        }

        public string TenantId { get; set; }

        public string ProcessId { get; set; }
    }
}
