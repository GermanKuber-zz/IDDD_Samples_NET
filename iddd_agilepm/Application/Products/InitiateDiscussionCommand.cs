namespace SaaSOvation.AgilePM.Application.Products
{
    public class InitiateDiscussionCommand
    {
        public InitiateDiscussionCommand()
        {
        }

        public InitiateDiscussionCommand(string tenantId, string discussionId, string productId)
        {
            TenantId = tenantId;
            DiscussionId = discussionId;
            ProductId = productId;
        }

        public string TenantId { get; set; }

        public string DiscussionId { get; set; }

        public string ProductId { get; set; }
    }
}
