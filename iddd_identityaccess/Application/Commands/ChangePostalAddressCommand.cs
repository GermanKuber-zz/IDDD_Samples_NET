namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class ChangePostalAddressCommand
    {
        public ChangePostalAddressCommand(string tenantId, string username,
            string addressStreetAddress, string addressCity, string addressStateProvince, string addressPostalCode, string addressCountryCode)
        {
            TenantId = tenantId;
            Username = username;
            AddressStreetAddress = addressStreetAddress;
            AddressCity = addressCity;
            AddressStateProvince = addressStateProvince;
            AddressPostalCode = addressPostalCode;
            AddressCountryCode = addressCountryCode;
        }

        public string TenantId { get; set; }
        public string Username { get; set; }
        public string AddressStreetAddress { get; set; }
        public string AddressCity { get; set; }
        public string AddressStateProvince { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressCountryCode { get; set; }
    }
}
