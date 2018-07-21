using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    public class Telephone : ValueObject
    {
        public Telephone(string number)
        {
            Number = number;
        }

        public Telephone(Telephone telephone)
            : this(telephone.Number)
        {
        }

        protected Telephone() { }

        private string _number;

        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "Telephone number is required.");
                AssertionConcern.AssertArgumentLength(value, 5, 20, "Telephone number may not be more than 20 characters.");
                AssertionConcern.AssertArgumentMatches(
                        "((\\(\\d{3}\\))|(\\d{3}-))\\d{3}-\\d{4}",
                        value,
                        "Telephone number or its format is invalid.");

                _number = value;
            }
        }

        public override string ToString()
        {
            return "Telephone [number=" + Number + "]";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}
