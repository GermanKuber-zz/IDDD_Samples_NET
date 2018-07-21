﻿// Copyright 2012,2013 Vaughn Vernon
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

namespace SaaSOvation.AgilePM.Domain.Model.Products.Releases
{
    using System;
    using Tenants;
    using Common.Domain.Model;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Release : Entity
    {
        public Release(
            TenantId tenantId,
            ProductId productId,
            ReleaseId releaseId,
            string name,
            string description,
            DateTime begins,
            DateTime ends)
        {
            if (ends.Ticks < begins.Ticks)
                throw new InvalidOperationException("Release must not end before it begins.");
            
            Begins = begins;
            Description = description;
            Ends = ends;
            Name = name;
            ProductId = productId;
            ReleaseId = releaseId;
            TenantId = tenantId;
            _backlogItems = new HashSet<ScheduledBacklogItem>();
        }

        public ProductId ProductId { get; }

        public ReleaseId ReleaseId { get; }

        public TenantId TenantId { get; }


        public DateTime Begins { get; }

        public string Description { get; }

        public DateTime Ends { get; }

        public string Name { get; }

        private readonly ISet<ScheduledBacklogItem> _backlogItems;

        public ICollection<ScheduledBacklogItem> AllScheduledBacklogItems()
        {
            return new ReadOnlyCollection<ScheduledBacklogItem>(new List<ScheduledBacklogItem>(_backlogItems));
        }
    }
}
