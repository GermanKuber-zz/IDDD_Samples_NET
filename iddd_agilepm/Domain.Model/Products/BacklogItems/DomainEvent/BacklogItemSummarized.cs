using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BacklogItemSummarized : IDomainEvent
    {
        public BacklogItemSummarized(Tenants.TenantId tenantId, BacklogItemId backlogItemId, string summary)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;
            Summary = summary;
        }

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; private set; }

        public string Summary { get; private set; }
    }
}
