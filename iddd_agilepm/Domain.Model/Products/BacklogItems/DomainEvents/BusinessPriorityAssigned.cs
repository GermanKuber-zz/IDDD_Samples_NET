using System;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.DomainEvents
{
    public class BusinessPriorityAssigned : IDomainEvent
    {
        public BusinessPriorityAssigned(Tenants.TenantId tenantId, BacklogItemId backlogItemId, BusinessPriority businessPriority)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;

            BacklogItemId = backlogItemId;
            BusinessPriority = businessPriority;
        }

        public Tenants.TenantId TenantId { get; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }

        public BacklogItemId BacklogItemId { get; }
        public BusinessPriority BusinessPriority { get; }
    }
}
