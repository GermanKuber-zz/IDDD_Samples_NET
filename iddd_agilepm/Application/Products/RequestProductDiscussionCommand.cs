namespace SaaSOvation.AgilePM.Application.Products
{
    public class RequestProductDiscussionCommand
    {
        public RequestProductDiscussionCommand()
        {
        }

        public RequestProductDiscussionCommand(string tenantId, string productId)
        {
            TenantId = tenantId;
            ProductId = productId;
        }

        public string TenantId { get; set; }

        public string ProductId { get; set; }
    }
}
