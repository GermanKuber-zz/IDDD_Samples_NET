using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarEntryDescriptionChanged : IDomainEvent
    {
        public CalendarEntryDescriptionChanged(
            Tenant tenant,
            CalendarId calendarId,
            CalendarEntryId calendarEntryId,
            string description)
        {
            Tenant = tenant;
            CalendarId = calendarId;
            CalendarEntryId = calendarEntryId;
            Description = description;
        }

        public Tenant Tenant { get; }
        public CalendarId CalendarId { get; }
        public CalendarEntryId CalendarEntryId { get; }
        public string Description { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
