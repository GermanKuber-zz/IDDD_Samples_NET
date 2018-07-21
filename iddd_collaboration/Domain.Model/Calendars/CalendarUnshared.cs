using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarUnshared : IDomainEvent
    {
        public CalendarUnshared(Tenant tenant, CalendarId calendarId, string name, CalendarSharer unsharedWith)
        {
            Tenant = tenant;
            CalendarId = calendarId;
            Name = name;
            UnsharedWith = unsharedWith;
        }

        public Tenant Tenant { get; }
        public CalendarId CalendarId { get; }
        public string Name { get; }
        public CalendarSharer UnsharedWith { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
