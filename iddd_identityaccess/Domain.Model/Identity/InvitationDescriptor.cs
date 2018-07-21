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

    public class InvitationDescriptor
    {
        public InvitationDescriptor(TenantId tenantId, string invitationId, string description, DateTime startingOn, DateTime until)
        {
            Description = description;
            InvitationId = invitationId;
            StartingOn = startingOn;
            TenantId = tenantId.Id;
            Until = until;
        }

        public string Description { get; }

        public string InvitationId { get; }

        public DateTime StartingOn;

        public string TenantId { get; }

        public DateTime Until { get; }
    }
}
