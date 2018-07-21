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
    using System;

    public class RegistrationInvitation
    {
        public RegistrationInvitation(
            TenantId tenantId,
            string invitationId,
            string description,
            DateTime startingOn,
            DateTime until)
        {
            Description = description;
            InvitationId = invitationId;
            StartingOn = startingOn;
            TenantId = tenantId;
            Until = until;
        }

        public RegistrationInvitation(TenantId tenantId, string invitationId, string description)
            : this(tenantId, invitationId, description, DateTime.MinValue, DateTime.MinValue)
        {
        }

        public string Description { get; private set; }

        public string InvitationId { get; private set; }

        public DateTime StartingOn { get; private set; }

        public TenantId TenantId { get; private set; }

        public DateTime Until { get; private set; }

        public bool IsAvailable()
        {
            var isAvailable = false;

            if (StartingOn == DateTime.MinValue && Until == DateTime.MinValue)
            {
                isAvailable = true;
            }
            else
            {
                var time = (DateTime.Now).Ticks;
                if (time >= StartingOn.Ticks && time <= Until.Ticks)
                {
                    isAvailable = true;
                }
            }

            return isAvailable;
        }

        public bool IsIdentifiedBy(string invitationIdentifier)
        {
            var isIdentified = InvitationId.Equals(invitationIdentifier);

            if (!isIdentified && Description != null)
            {
                isIdentified = Description.Equals(invitationIdentifier);
            }

            return isIdentified;
        }

        public RegistrationInvitation OpenEnded()
        {
            StartingOn = DateTime.MinValue;
            Until = DateTime.MinValue;
            return this;
        }

        public RegistrationInvitation RedefineAs()
        {
            StartingOn = DateTime.MinValue;
            Until = DateTime.MinValue;
            return this;
        }

        public InvitationDescriptor ToDescriptor()
        {
            return new InvitationDescriptor(
                TenantId,
                InvitationId,
                Description,
                StartingOn,
                Until);
        }

        public RegistrationInvitation WillStartOn(DateTime date)
        {
            if (Until != DateTime.MinValue)
            {
                throw new InvalidOperationException("Cannot set starting-on date after until date.");
            }

            StartingOn = date;

            // temporary if Until set properly follows, but
            // prevents illegal state if Until set doesn't follow
            Until = new DateTime(date.Ticks + 86400000);

            return this;
        }

        public RegistrationInvitation LastingUntil(DateTime date)
        {
            if (StartingOn == DateTime.MinValue)
            {
                throw new InvalidOperationException("Cannot set until date before setting starting-on date.");
            }

            Until = date;

            return this;
        }

        public override bool Equals(object anotherObject)
        {
            var equalObjects = false;

            if (anotherObject != null && GetType() == anotherObject.GetType())
            {
                var typedObject = (RegistrationInvitation) anotherObject;
                equalObjects =
                    TenantId.Equals(typedObject.TenantId) &&
                    InvitationId.Equals(typedObject.InvitationId);
            }

            return equalObjects;
        }

        public override int GetHashCode()
        {
            return
                + (6325 * 233)
                + TenantId.GetHashCode()
                + InvitationId.GetHashCode();
        }

        public override string ToString()
        {
            return "RegistrationInvitation ["
                    + "tenantId=" + TenantId
                    + ", description=" + Description
                    + ", invitationId=" + InvitationId
                    + ", startingOn=" + StartingOn
                    + ", until=" + Until + "]";
        }
    }
}
