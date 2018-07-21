// Copyright 2012,2013 Vaughn Vernon
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace SaaSOvation.IdentityAccess.Domain.Model.Identity
{
    using Common.Domain.Model;

    public class ContactInformation : ValueObject
    {
        public ContactInformation(
                EmailAddress emailAddress,
                PostalAddress postalAddress,
                Telephone primaryTelephone,
                Telephone secondaryTelephone)
        {
            EmailAddress = emailAddress;
            PostalAddress = postalAddress;
            PrimaryTelephone = primaryTelephone;
            SecondaryTelephone = secondaryTelephone;
        }

        public ContactInformation(ContactInformation contactInformation)
            : this(contactInformation.EmailAddress,
                   contactInformation.PostalAddress,
                   contactInformation.PrimaryTelephone,
                   contactInformation.SecondaryTelephone)
        {
        }

        internal ContactInformation()
        {
        }

        public EmailAddress EmailAddress { get; private set; }

        public PostalAddress PostalAddress { get; private set; }

        public Telephone PrimaryTelephone { get; private set; }

        public Telephone SecondaryTelephone { get; private set; }

        public ContactInformation ChangeEmailAddress(EmailAddress emailAddress)
        {
            return new ContactInformation(
                    emailAddress,
                    PostalAddress,
                    PrimaryTelephone,
                    SecondaryTelephone);
        }

        public ContactInformation ChangePostalAddress(PostalAddress postalAddress)
        {
            return new ContactInformation(
                   EmailAddress,
                   postalAddress,
                   PrimaryTelephone,
                   SecondaryTelephone);
        }

        public ContactInformation ChangePrimaryTelephone(Telephone telephone)
        {
            return new ContactInformation(
                   EmailAddress,
                   PostalAddress,
                   telephone,
                   SecondaryTelephone);
        }

        public ContactInformation ChangeSecondaryTelephone(Telephone telephone)
        {
            return new ContactInformation(
                   EmailAddress,
                   PostalAddress,
                   PrimaryTelephone,
                   telephone);
        }

        public override string ToString()
        {
            return "ContactInformation [emailAddress=" + EmailAddress
                    + ", postalAddress=" + PostalAddress
                    + ", primaryTelephone=" + PrimaryTelephone
                    + ", secondaryTelephone=" + SecondaryTelephone + "]";
        }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailAddress;
            yield return PostalAddress;
            yield return PrimaryTelephone;
            yield return SecondaryTelephone;
        }
    }
}
