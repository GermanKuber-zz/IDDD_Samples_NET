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

        public Tenant Tenant { get; private set; }
        public CalendarId CalendarId { get; private set; }
        public string Name { get; private set; }
        public CalendarSharer UnsharedWith { get; private set; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
