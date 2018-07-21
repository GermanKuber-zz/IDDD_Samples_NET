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

        public Tenant Tenant { get; }
        public CalendarId CalendarId { get; }
        public CalendarEntryId CalendarEntryId { get; }
        public string Location { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
