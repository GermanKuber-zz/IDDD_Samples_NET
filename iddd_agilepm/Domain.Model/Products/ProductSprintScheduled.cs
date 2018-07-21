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

namespace SaaSOvation.AgilePM.Domain.Model.Products
{
    using System;
    using Tenants;
    using Common.Domain.Model;
    using Sprints;

    public class ProductSprintScheduled : IDomainEvent
    {
        public ProductSprintScheduled(
            TenantId tenantId,
            ProductId productId,
            SprintId sprintId,
            string name,
            string goals,
            DateTime starts,
            DateTime ends)
        {
            Ends = ends;
            EventVersion = 1;
            Goals = goals;
            Name = name;
            OccurredOn = DateTime.Now;
            ProductId = productId;
            SprintId = sprintId;
            Starts = starts;
            TenantId = tenantId;
        }

        public DateTime Ends { get; }

        public int EventVersion { get; set; }

        public string Goals { get; }

        public string Name { get; }

        public DateTime OccurredOn { get; set; }

        public ProductId ProductId { get; }

        public SprintId SprintId { get; }

        public DateTime Starts { get; }

        public TenantId TenantId { get; }
    }
}
