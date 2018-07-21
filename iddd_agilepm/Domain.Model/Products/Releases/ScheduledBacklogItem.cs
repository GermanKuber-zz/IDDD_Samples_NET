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

using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;

namespace SaaSOvation.AgilePM.Domain.Model.Products.Releases
{
    using System;
    using Tenants;
    using Common.Domain.Model;

    public class ScheduledBacklogItem : Entity, IEquatable<ScheduledBacklogItem>
    {
        public ScheduledBacklogItem(TenantId tenantId, ReleaseId releaseId, BacklogItemId backlogItemId, int ordering = 0)
        {
            TenantId = tenantId;
            ReleaseId = releaseId;
            BacklogItemId = backlogItemId;
            Ordering = ordering;
        }

        public TenantId TenantId { get; }
        public ReleaseId ReleaseId { get; }
        public BacklogItemId BacklogItemId { get; }
        public int Ordering { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ScheduledBacklogItem);
        }

        public bool Equals(ScheduledBacklogItem other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;

            return TenantId.Equals(other.TenantId)
                && ReleaseId.Equals(other.ReleaseId)
                && BacklogItemId.Equals(other.BacklogItemId);
        }

        public override int GetHashCode()
        {
            return
                +(73281 * 47)
                + TenantId.GetHashCode()
                + ReleaseId.GetHashCode()
                + BacklogItemId.GetHashCode();
        }
    }
}
