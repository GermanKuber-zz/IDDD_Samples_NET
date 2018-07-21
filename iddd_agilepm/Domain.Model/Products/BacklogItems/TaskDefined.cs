using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
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

        public Tenants.TenantId TenantId { get; private set; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
        public BacklogItemId BacklogItemId { get; private set; }

        public TaskId TaskId { get; private set; }
        public string VolunteerMemberId { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }
    }
}
