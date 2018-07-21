namespace SaaSOvation.AgilePM.Application.Products
{
    public class NewProductCommand
    {
        public NewProductCommand()
        {
        }

        public NewProductCommand(string tenantId, string productOwnerId, string name, string description)
        {
            TenantId = tenantId;
            ProductOwnerId = productOwnerId;
            Name = name;
            Description = description;
        }

        public string TenantId { get; set; }

        public string ProductOwnerId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
