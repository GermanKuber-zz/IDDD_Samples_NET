using System;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.Task
{
    public class TaskStatusChanged : IDomainEvent
    {
        public TaskStatusChanged(Tenants.TenantId tenantId, BacklogItemId backlogItemId, TaskId taskId, TaskStatus status)
        {
            TenantId = tenantId;
            BacklogItemId = backlogItemId;
            TaskId = taskId;
            Status = status;
        }

        public Tenants.TenantId TenantId { get; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }

        public BacklogItemId BacklogItemId { get; }
        public TaskId TaskId { get; }
        public TaskStatus Status { get; }
    }
}
