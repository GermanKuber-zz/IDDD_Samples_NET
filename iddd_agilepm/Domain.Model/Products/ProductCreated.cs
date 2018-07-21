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
    using Discussions;
    using Teams;
    using Tenants;
    using Common.Domain.Model;

    public class ProductCreated : IDomainEvent
    {
        public ProductCreated(
            TenantId tenantId,
            ProductId productId,
            ProductOwnerId productOwnerId,
            string name,
            string description,
            DiscussionAvailability availability)
        {
            Availability = availability;
            Description = description;
            EventVersion = 1;
            Name = name;
            OccurredOn = DateTime.Now;
            ProductId = productId;
            ProductOwnerId = productOwnerId;
            TenantId = tenantId;
        }

        public DiscussionAvailability Availability { get; }

        public string Description { get; }

        public int EventVersion { get; set; }

        public string Name { get; }

        public DateTime OccurredOn { get; set; }

        public ProductId ProductId { get; }

        public ProductOwnerId ProductOwnerId { get; }

        public TenantId TenantId { get; }
    }
}
