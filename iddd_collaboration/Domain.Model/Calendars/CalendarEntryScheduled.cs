using System;
using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarEntryScheduled : IDomainEvent
    {
        public CalendarEntryScheduled(
            Tenant tenant, 
            CalendarId calendarId, 
            CalendarEntryId calendarEntryId, 
            string description, 
            string location, 
            Owner owner, 
            DateRange timeSpan, 
            Repetition repetition,
            Alarm alarm,
            IEnumerable<Participant> invitees)
        {
            Tenant = tenant;
            CalendarId = calendarId;
            CalendarEntryId = calendarEntryId;
            Description = description;
            Location = location;
            Owner = owner;
            TimeSpan = timeSpan;
            Repetition = repetition;
            Alarm = alarm;
            Invitees = invitees;
        }

        public Tenant Tenant { get; }
        public CalendarId CalendarId { get; }
        public CalendarEntryId CalendarEntryId { get; }
        public string Description { get; }
        public string Location { get; }
        public Owner Owner { get; }
        public DateRange TimeSpan { get; }
        public Repetition Repetition { get; }
        public Alarm Alarm { get; }
        public IEnumerable<Participant> Invitees { get; }


        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
