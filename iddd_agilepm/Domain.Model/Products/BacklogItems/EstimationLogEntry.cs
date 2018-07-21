using System;
using System.Collections.Generic;
using SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems.Task;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.AgilePM.Domain.Model.Products.BacklogItems
{
    public class EstimationLogEntry : EntityWithCompositeId
    {
        public EstimationLogEntry(Tenants.TenantId tenantId, TaskId taskId, DateTime date, int hoursRemaining)
        {
            AssertionConcern.AssertArgumentNotNull(tenantId, "The tenant id must be provided.");
            AssertionConcern.AssertArgumentNotNull(taskId, "The task id must be provided.");

            TenantId = tenantId;
            TaskId = taskId;
            Date = date.Date;
            HoursRemaining = hoursRemaining;
        }

        public static DateTime CurrentLogDate
        {
            get { return DateTime.UtcNow.Date; }
        }

        public Tenants.TenantId TenantId { get; set; }
        public TaskId TaskId { get; private set; }

        public DateTime Date { get; private set; }
        public int HoursRemaining { get; private set; }

        internal bool IsMatching(DateTime date)
        {
            return Date.Equals(date);
        }

        internal bool UpdateHoursRemainingWhenDateMatches(int hoursRemaining, DateTime date)
        {
            if (IsMatching(date))
            {
                HoursRemaining = hoursRemaining;
                return true;
            }
            return false;
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return TenantId;
            yield return TaskId;
            yield return Date;
            yield return HoursRemaining;
        }        
    }
}
    