using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BacklogItemCommitted : IDomainEvent
    {
        public BacklogItemCommitted(Tenants.TenantId tenantId, BacklogItemId backlogItemId, Sprints.SprintId sprintId)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;

            SprintId = sprintId;
        }

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; private set; }

        public Sprints.SprintId SprintId { get; private set; }
    }
}
