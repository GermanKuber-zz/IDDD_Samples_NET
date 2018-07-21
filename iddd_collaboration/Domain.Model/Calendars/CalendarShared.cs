using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarShared : IDomainEvent
    {
        public CalendarShared(Tenant tenant, CalendarId calendarId, string name, CalendarSharer sharedWith)
        {
            Tenant = tenant;
            CalendarId = calendarId;
            Name = name;
            SharedWith = sharedWith;
        }

        public Tenant Tenant { get; }
        public CalendarId CalendarId { get; }
        public string Name { get; }
        public CalendarSharer SharedWith { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
