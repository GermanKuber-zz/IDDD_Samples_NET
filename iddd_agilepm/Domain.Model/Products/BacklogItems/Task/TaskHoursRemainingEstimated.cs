using System;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.Task
{
    public class TaskHoursRemainingEstimated : IDomainEvent
    {
        public TaskHoursRemainingEstimated(Tenants.TenantId tenantId, BacklogItemId backlogItemId, TaskId taskId, int hoursRemaining)
        {
            TenantId = tenantId;
            BacklogItemId = backlogItemId;
            TaskId = taskId;
            HoursRemaining = hoursRemaining;
        }

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }

        public BacklogItemId BacklogItemId { get; private set; }
        public TaskId TaskId { get; private set; }
        public int HoursRemaining { get; private set; }
    }
}
