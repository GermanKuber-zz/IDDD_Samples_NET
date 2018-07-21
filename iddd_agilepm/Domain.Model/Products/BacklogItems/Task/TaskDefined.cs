using System;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.Task
{
    public class TaskDefined : IDomainEvent
    {
        public TaskDefined(Tenants.TenantId tenantId, BacklogItemId backlogItemId, TaskId taskId, string volunteerMemberId, string name, string description)
        {
            TenantId = tenantId;
            EventVersion = 1;
            OccurredOn = DateTime.UtcNow;
            BacklogItemId = backlogItemId;

            TaskId = taskId;
            VolunteerMemberId = volunteerMemberId;
            Name = name;
            Description = description;
        }

        public Tenants.TenantId TenantId { get; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; }

        public TaskId TaskId { get; }
        public string VolunteerMemberId { get; }
        public string Description { get; }
        public string Name { get; }
    }
}
