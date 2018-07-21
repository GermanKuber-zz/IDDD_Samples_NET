using System;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.Task
{
    public class TaskDescribed : IDomainEvent
    {
        public TaskDescribed(Tenants.TenantId tenantId, BacklogItemId backlogItemId, TaskId taskId, string description)
        {
            TenantId = tenantId;
            BacklogItemId = backlogItemId;
            TaskId = taskId;
            Description = description;
        }

        public Tenants.TenantId TenantId { get; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }

        public BacklogItemId BacklogItemId { get; }
        public TaskId TaskId { get; }
        public string Description { get; }
    }
}
