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

namespace SaaSOvation.AgilePM.Domain.Model.Teams
{
    using System;
    using Tenants;
    using Common.Domain.Model;

    public abstract class Member : EntityWithCompositeId
    {
        public Member(
            TenantId tenantId,
            string userName,
            string firstName,
            string lastName,
            string emailAddress,
            DateTime initializedOn)
        {
            AssertionConcern.AssertArgumentNotNull(tenantId, "The tenant id must be provided.");

            TenantId = tenantId;
            EmailAddress = emailAddress;
            Enabled = true;
            FirstName = firstName;
            LastName = lastName;
            _changeTracker = new MemberChangeTracker(initializedOn, initializedOn, initializedOn);
        }

        private string _userName;
        private string _emailAddress;
        private string _firstName;
        private string _lastName;

        public TenantId TenantId { get; private set; }

        public string Username
        {
            get { return _userName; }
            private set
            {
                AssertionConcern.AssertArgumentNotEmpty(value, "The username must be provided.");
                AssertionConcern.AssertArgumentLength(value, 250, "The username must be 250 characters or less.");
                _userName = value;
            }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            private set
            {
                if (value != null)
                    AssertionConcern.AssertArgumentLength(_emailAddress, 100, "Email address must be 100 characters or less.");
                _emailAddress = value;
            }
        }        

        public string FirstName
        {
            get { return _firstName; }
            private set
            {
                if (value != null)
                    AssertionConcern.AssertArgumentLength(value, 50, "First name must be 50 characters or less.");
                _firstName = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            private set
            {
                if (value != null)
                    AssertionConcern.AssertArgumentLength(value, 50, "Last name must be 50 characters or less.");
                _lastName = value;
            }
        }

        public bool Enabled { get; private set; }

        private MemberChangeTracker _changeTracker;

        public void ChangeEmailAddress(string emailAddress, DateTime asOfDate)
        {
            if (_changeTracker.CanChangeEmailAddress(asOfDate) 
                && !EmailAddress.Equals(emailAddress))
            {
                EmailAddress = emailAddress;
                _changeTracker = _changeTracker.EmailAddressChangedOn(asOfDate);
            }
        }

        public void ChangeName(string firstName, string lastName, DateTime asOfDate)
        {
            if (_changeTracker.CanChangeName(asOfDate))
            {
                FirstName = firstName;
                LastName = lastName;
                _changeTracker = _changeTracker.NameChangedOn(asOfDate);
            }
        }

        public void Disable(DateTime asOfDate)
        {
            if (_changeTracker.CanToggleEnabling(asOfDate))
            {
                Enabled = false;
                _changeTracker = _changeTracker.EnablingOn(asOfDate);
            }
        }

        public void Enable(DateTime asOfDate)
        {
            if (_changeTracker.CanToggleEnabling(asOfDate))
            {
                Enabled = true;
                _changeTracker = _changeTracker.EnablingOn(asOfDate);
            }
        }
    }
}
