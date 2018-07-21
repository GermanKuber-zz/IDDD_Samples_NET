namespace SaaSOvation.AgilePM.Application.Products
{
    public class StartDiscussionInitiationCommand
    {
        public StartDiscussionInitiationCommand()
        {
        }

        public StartDiscussionInitiationCommand(string tenantId, string productId)
        {
            TenantId = tenantId;
            ProductId = productId;
        }

        public string TenantId { get; set; }

        public string ProductId { get; set; }
    }
}
