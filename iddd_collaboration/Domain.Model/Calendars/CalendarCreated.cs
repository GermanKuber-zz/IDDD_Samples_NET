using System;
using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarCreated : IDomainEvent
    {
        public CalendarCreated(Tenant tenant, CalendarId calendarId, string name, string description, Owner owner, IEnumerable<CalendarSharer> sharedWith)
        {
            Tenant = tenant;
            CalendarId = calendarId;
            Name = name;
            Description = description;
            Owner = owner;
            SharedWith = sharedWith;
        }

        public Tenant Tenant { get; }

        public CalendarId CalendarId { get; }

        public string Name { get; }

        public string Description { get; }

        public Owner Owner { get; }

        public IEnumerable<CalendarSharer> SharedWith { get; }

        public int EventVersion { get; set; }
        public DateTime OccurredOn { get; set; }
    }
}
