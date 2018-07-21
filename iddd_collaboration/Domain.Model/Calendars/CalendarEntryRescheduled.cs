using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarEntryRescheduled : IDomainEvent
    {
        public CalendarEntryRescheduled(
            Tenant tenant,
            CalendarId calendarId,
            CalendarEntryId calendarEntryId,
            DateRange timeSpan,
            Repetition repetition,
            Alarm alarm)
        {
            Tenant = tenant;
            CalendarId = calendarId;
            CalendarEntryId = calendarEntryId;
            TimeSpan = timeSpan;
            Repetition = repetition;
            Alarm = alarm;
        }

        public Tenant Tenant { get; private set; }
        public CalendarId CalendarId { get; private set; }
        public CalendarEntryId CalendarEntryId { get; private set; }
        public DateRange TimeSpan { get; private set; }
        public Repetition Repetition { get; private set; }
        public Alarm Alarm { get; private set; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
