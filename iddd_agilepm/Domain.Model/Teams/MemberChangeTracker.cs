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

    using Common.Domain.Model;

    public class MemberChangeTracker : ValueObject
    {
        internal MemberChangeTracker(DateTime enablingOn, DateTime nameChangedOn, DateTime emailAddressChangedOn)
        {
            _emailAddressChangedOnDate = emailAddressChangedOn;
            _enablingOnDate = enablingOn;
            _nameChangedOnDate = nameChangedOn;
        }

        private readonly DateTime _enablingOnDate;
        private readonly DateTime _nameChangedOnDate;
        private readonly DateTime _emailAddressChangedOnDate;

        public bool CanChangeEmailAddress(DateTime asOfDateTime)
        {
            return _emailAddressChangedOnDate < asOfDateTime;
        }

        public bool CanChangeName(DateTime asOfDateTime)
        {
            return _nameChangedOnDate < asOfDateTime;
        }

        public bool CanToggleEnabling(DateTime asOfDateTime)
        {
            return _enablingOnDate < asOfDateTime;
        }

        public MemberChangeTracker EmailAddressChangedOn(DateTime asOfDateTime)
        {
            return new MemberChangeTracker(_enablingOnDate, _nameChangedOnDate, asOfDateTime);
        }

        public MemberChangeTracker EnablingOn(DateTime asOfDateTime)
        {
            return new MemberChangeTracker(asOfDateTime, _nameChangedOnDate, _emailAddressChangedOnDate);
        }

        public MemberChangeTracker NameChangedOn(DateTime asOfDateTime)
        {
            return new MemberChangeTracker(_enablingOnDate, asOfDateTime, _emailAddressChangedOnDate);
        }

        protected override System.Collections.Generic.IEnumerable<object> GetEqualityComponents()
        {
            yield return _enablingOnDate;
            yield return _nameChangedOnDate;
            yield return _emailAddressChangedOnDate;
        }
    }
}
