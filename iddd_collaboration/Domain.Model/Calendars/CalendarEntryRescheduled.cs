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

        public Tenant Tenant { get; }
        public CalendarId CalendarId { get; }
        public CalendarEntryId CalendarEntryId { get; }
        public DateRange TimeSpan { get; }
        public Repetition Repetition { get; }
        public Alarm Alarm { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
