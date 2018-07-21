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

namespace SaaSOvation.AgilePM.Domain.Model.Products.Sprints
{
    using System;
    using Tenants;
    using BacklogItems;
    using Common.Domain.Model;

    public class CommittedBacklogItem : Entity, IEquatable<CommittedBacklogItem>
    {
        public CommittedBacklogItem(TenantId tenantId, SprintId sprintId, BacklogItemId backlogItemId, int ordering = 0)
        {
            TenantId = tenantId;
            SprintId = sprintId;
            BacklogItemId = backlogItemId;
            Ordering = ordering;
        }

        public TenantId TenantId { get; private set; }

        public SprintId SprintId { get; private set; }

        public BacklogItemId BacklogItemId { get; private set; }

        public int Ordering { get; private set; }

        public void ReOrderFrom(BacklogItemId id, int orderOfPriority)
        {
            if (BacklogItemId.Equals(id))
            {
                Ordering = orderOfPriority;
            }
            else if (Ordering >= orderOfPriority)
            {
                Ordering = Ordering + 1;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CommittedBacklogItem);
        }

        public bool Equals(CommittedBacklogItem other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;

            return TenantId.Equals(other.TenantId)
                && SprintId.Equals(other.SprintId)
                && BacklogItemId.Equals(other.BacklogItemId);
        }

        public override int GetHashCode()
        {
            return
                + (282891 * 53)
                + TenantId.GetHashCode()
                + SprintId.GetHashCode()
                + BacklogItemId.GetHashCode();
        }
    }
}
