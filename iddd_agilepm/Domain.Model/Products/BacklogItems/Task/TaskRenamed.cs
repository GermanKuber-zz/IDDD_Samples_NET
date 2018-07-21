using System;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.Task
{
    public class TaskRenamed : IDomainEvent
    {
        public TaskRenamed(Tenants.TenantId tenantId, BacklogItemId backlogItemId, TaskId taskId, string name)
        {
            TenantId = tenantId;
            BacklogItemId = backlogItemId;
            TaskId = taskId;
            Name = name;
        }

        public Tenants.TenantId TenantId { get; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }

        public BacklogItemId BacklogItemId { get; }
        public TaskId TaskId { get; }
        public string Name { get; }
    }
}
