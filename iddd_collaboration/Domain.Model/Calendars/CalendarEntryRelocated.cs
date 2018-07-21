using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarEntryRelocated : IDomainEvent
    {
        public CalendarEntryRelocated(
            Tenant tenant,
            CalendarId calendarId,
            CalendarEntryId calendarEntryId,
            string location)
        {
            Tenant = tenant;
            CalendarId = calendarId;
            CalendarEntryId = calendarEntryId;
            Location = location;
        }

        public Tenant Tenant { get; private set; }
        public CalendarId CalendarId { get; private set; }
        public CalendarEntryId CalendarEntryId { get; private set; }
        public string Location { get; private set; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
