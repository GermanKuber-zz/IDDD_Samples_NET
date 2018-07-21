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
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    using Common.Domain.Model;

    using Tenants;
    using BacklogItems;

    public class Sprint : Entity, IEquatable<Sprint>
    {
        public Sprint(
            TenantId tenantId,
            ProductId productId,
            SprintId sprintId,
            string name,
            string goals,
            DateTime begins,
            DateTime ends)
        {
            if (ends.Ticks < begins.Ticks)
            {
                throw new InvalidOperationException("Sprint must not end before it begins.");
            }
            
            Begins = begins;
            Goals = goals;
            Ends = ends;
            Name = name;
            ProductId = productId;
            SprintId = sprintId;
            TenantId = tenantId;
            _backlogItems = new HashSet<CommittedBacklogItem>();
        }

        private readonly ISet<CommittedBacklogItem> _backlogItems;

        public DateTime Begins { get; private set; }

        public DateTime Ends { get; private set; }

        public string Goals { get; private set; }

        public string Name { get; private set; }

        public string Retrospective { get; private set; }

        public ProductId ProductId { get; private set; }

        public SprintId SprintId { get; private set; }

        public TenantId TenantId { get; private set; }

        public ICollection<CommittedBacklogItem> AllCommittedBacklogItems()
        {
            return new ReadOnlyCollection<CommittedBacklogItem>(new List<CommittedBacklogItem>(_backlogItems));
        }

        public void AdjustGoals(string goals)
        {
            Goals = goals;

            // TODO: publish event / student assignment
        }

        public void CaptureRetrospectiveMeetinResults(string retrospective)
        {
            Retrospective = retrospective;

            // TODO: publish event / student assignment
        }

        public void Commit(BacklogItem backlogItem)
        {
            var ordering = _backlogItems.Count + 1;

            var committedBacklogItem = new CommittedBacklogItem(
                TenantId,
                SprintId,
                backlogItem.BacklogItemId,
                ordering);

            _backlogItems.Add(committedBacklogItem);
        }

        public void NowBeginsOn(DateTime dt)
        {
            Begins = dt;
        }

        public void NowEndsOn(DateTime dt)
        {
            Ends = dt;
        }

        public void Rename(string name)
        {
            Name = name;

            // TODO: publish event
        }

        public void ReOrderFrom(BacklogItemId id, int orderOfPriority)
        {
            foreach (var committedBacklogItem in _backlogItems)
            {
                committedBacklogItem.ReOrderFrom(id, orderOfPriority);
            }
        }

        public void UnCommit(BacklogItem backlogItem)
        {
            var committedBacklogItem = new CommittedBacklogItem(
                TenantId,
                SprintId,
                backlogItem.BacklogItemId);

            _backlogItems.Remove(committedBacklogItem);
        }

        public bool Equals(Sprint other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;

            return TenantId.Equals(other.TenantId)
                && ProductId.Equals(other.ProductId)
                && SprintId.Equals(other.SprintId);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Sprint);
        }

        public override int GetHashCode()
        {
            return (11873 * 53)
            + TenantId.GetHashCode()
            + ProductId.GetHashCode()
            + SprintId.GetHashCode();
        }
    }
}
