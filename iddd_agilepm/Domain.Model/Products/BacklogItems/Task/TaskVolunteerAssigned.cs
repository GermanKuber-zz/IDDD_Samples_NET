using System;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.BacklogItem;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.Task
{
    public class TaskVolunteerAssigned : IDomainEvent
    {
        public TaskVolunteerAssigned(Tenants.TenantId tenantId, BacklogItemId backlogItemId, TaskId taskId, string volunteerMemberId)
        {
            TenantId = tenantId;
            BacklogItemId = backlogItemId;
            TaskId = taskId;
            VolunteerMemberId = volunteerMemberId;
        }

        public Tenants.TenantId TenantId { get; }
        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }

        public BacklogItemId BacklogItemId { get; }
        public TaskId TaskId { get; }
        public string VolunteerMemberId { get; }
    }
}
