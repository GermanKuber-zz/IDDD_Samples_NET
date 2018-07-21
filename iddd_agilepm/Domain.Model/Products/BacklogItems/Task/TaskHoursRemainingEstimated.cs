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

        public Tenants.TenantId TenantId { get; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }

        public BacklogItemId BacklogItemId { get; }
        public TaskId TaskId { get; }
        public int HoursRemaining { get; }
    }
}
