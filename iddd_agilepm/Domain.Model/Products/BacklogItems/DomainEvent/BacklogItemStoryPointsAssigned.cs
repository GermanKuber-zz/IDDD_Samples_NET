using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class BacklogItemStoryPointsAssigned : IDomainEvent
    {
        public BacklogItemStoryPointsAssigned(Tenants.TenantId tenantId, BacklogItemId backlogItemId, StoryPoints storyPoints)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;

            BacklogItemId = backlogItemId;
            StoryPoints = storyPoints;
        }

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }

        public BacklogItemId BacklogItemId { get; private set; }
        public StoryPoints StoryPoints { get; private set; }
    }
}
