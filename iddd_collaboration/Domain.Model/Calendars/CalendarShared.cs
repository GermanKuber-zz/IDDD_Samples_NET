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

        public Tenant Tenant { get; private set; }
        public CalendarId CalendarId { get; private set; }
        public string Name { get; private set; }
        public CalendarSharer SharedWith { get; private set; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
