using System;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarRenamed : IDomainEvent
    {
        public CalendarRenamed(Tenant tenant, CalendarId calendarId, string name, string description)
        {
            Tenant = tenant;
            CalendarId = calendarId;
            Name = name;
            Description = description;
        }

        public Tenant Tenant { get; }

        public CalendarId CalendarId { get; }

        public string Name { get; }

        public string Description { get; }

        public int EventVersion { get; set; }

        public DateTime OccurredOn { get; set; }
    }
}
