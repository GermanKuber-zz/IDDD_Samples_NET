using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class EmailAddress : ValueObject
    {
        public EmailAddress(string address)
        {
            Address = address;
        }

        public EmailAddress(EmailAddress emailAddress)
            : this(emailAddress.Address)
        {
        }

        protected EmailAddress() { }

        private string _address;

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The email address is required.");
                AssertionConcern.AssertArgumentLength(value, 1, 100, "Email address must be 100 characters or less.");
                AssertionConcern.AssertArgumentMatches(
                        "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*",
                        value,
                        "Email address format is invalid.");

                _address = value;
            }
        }

        public override string ToString()
        {
            return "EmailAddress [address=" + Address + "]";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _address.ToUpper();
        }
    }
}
