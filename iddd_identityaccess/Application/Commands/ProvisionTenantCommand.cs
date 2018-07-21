namespace SaaSOvation.IdentityAccess.Application.Commands
{
    public class ProvisionTenantCommand
    {
        public ProvisionTenantCommand()
        {
        }

        public ProvisionTenantCommand(string tenantName, string tenantDescription, string administorFirstName,
            string administorLastName, string emailAddress, string primaryTelephone, string secondaryTelephone,
            string addressStreetAddress, string addressCity, string addressStateProvince, string addressPostalCode,
            string addressCountryCode)
        {
            TenantName = tenantName;
            TenantDescription = tenantDescription;
            AdministorFirstName = administorFirstName;
            AdministorLastName = administorLastName;
            EmailAddress = emailAddress;
            PrimaryTelephone = primaryTelephone;
            SecondaryTelephone = secondaryTelephone;
            AddressStreetAddress = addressStreetAddress;
            AddressCity = addressCity;
            AddressStateProvince = addressStateProvince;
            AddressPostalCode = addressPostalCode;
            AddressCountryCode = addressCountryCode;
        }

        public string TenantName { get; set; }
        public string TenantDescription { get; set; }
        public string AdministorFirstName { get; set; }
        public string AdministorLastName { get; set; }
        public string EmailAddress { get; set; }
        public string PrimaryTelephone { get; set; }
        public string SecondaryTelephone { get; set; }
        public string AddressStreetAddress { get; set; }
        public string AddressCity { get; set; }
        public string AddressStateProvince { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressCountryCode { get; set; }
    }
}
