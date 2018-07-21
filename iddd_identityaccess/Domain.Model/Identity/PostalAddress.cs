using System;
using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class PostalAddress : ValueObject
    {
        public PostalAddress(
                String streetAddress,
                String city,
                String stateProvince,
                String postalCode,
                String countryCode)
        {
            City = city;
            CountryCode = countryCode;
            PostalCode = postalCode;
            StateProvince = stateProvince;
            StreetAddress = streetAddress;
        }

        public PostalAddress(PostalAddress postalAddress)
            : this(postalAddress.StreetAddress,
                   postalAddress.City,
                   postalAddress.StateProvince,
                   postalAddress.PostalCode,
                   postalAddress.CountryCode)
        {
        }

        protected PostalAddress() { }

        public string City { get; private set; }

        public string CountryCode { get; private set; }

        public string PostalCode { get; private set; }

        public string StateProvince { get; private set; }

        public string StreetAddress { get; private set; }

        public override string ToString()
        {
            return "PostalAddress [streetAddress=" + StreetAddress
                    + ", city=" + City + ", stateProvince=" + StateProvince
                    + ", postalCode=" + PostalCode
                    + ", countryCode=" + CountryCode + "]";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StreetAddress;
            yield return City;
            yield return StateProvince;
            yield return PostalCode;
            yield return CountryCode;
        }
    }
}
