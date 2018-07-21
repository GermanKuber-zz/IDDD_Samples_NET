using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class Calendar : EventSourcedRootEntity
    {
        public Calendar(Tenant tenant, CalendarId calendarId, string name, string description, Owner owner, IEnumerable<CalendarSharer> sharedWith = null)
        {
            AssertionConcern.AssertArgumentNotNull(tenant, "The tenant must be provided.");
            AssertionConcern.AssertArgumentNotNull(calendarId, "The calendar id must be provided.");
            AssertionConcern.AssertArgumentNotEmpty(name, "The name must be provided.");
            AssertionConcern.AssertArgumentNotEmpty(description, "The description must be provided.");
            AssertionConcern.AssertArgumentNotNull(owner, "The owner must be provided.");
            Apply(new CalendarCreated(tenant, calendarId, name, description, owner, sharedWith));
        }

        private void When(CalendarCreated e)
        {
            _tenant = e.Tenant;
            _calendarId = e.CalendarId;
            _name = e.Name;
            _description = e.Description;
            _sharedWith = new HashSet<CalendarSharer>(e.SharedWith ?? Enumerable.Empty<CalendarSharer>());
        }

        public Calendar(IEnumerable<IDomainEvent> eventStream, int streamVersion)
            : base(eventStream, streamVersion)
        {
        }

        private Tenant _tenant;
        private CalendarId _calendarId;
        private string _name;
        private string _description;
        private HashSet<CalendarSharer> _sharedWith;

        public CalendarId CalendarId
        {
            get { return _calendarId; }
        }

        public ReadOnlyCollection<CalendarSharer> AllSharedWith
        {
            get { return new ReadOnlyCollection<CalendarSharer>(_sharedWith.ToArray()); }
        }

        public void ChangeDescription(string description)
        {
            AssertionConcern.AssertArgumentNotEmpty(description, "The description must be provided.");
            Apply(new CalendarDescriptionChanged(_tenant, _calendarId, _name, description));
        }

        private void When(CalendarDescriptionChanged e)
        {
            _description = e.Description;
        }

        public void Rename(string name)
        {
            AssertionConcern.AssertArgumentNotEmpty(name, "The name must be provided.");
            Apply(new CalendarRenamed(_tenant, _calendarId, name, _description));
        }

        private void When(CalendarRenamed e)
        {
            _name = e.Name;
        }


        public CalendarEntry ScheduleCalendarEntry(
            CalendarIdentityService calendarIdService,
            string description,
            string location,
            Owner owner,
            DateRange timeSpan,
            Repetition repetition,
            Alarm alarm,
            IEnumerable<Participant> invitees = null)
        {
            return new CalendarEntry(
                _tenant,
                _calendarId,
                calendarIdService.GetNextCalendarEntryId(),
                description,
                location,
                owner,
                timeSpan,
                repetition,
                alarm,
                invitees);
        }

        public void ShareCalendarWith(CalendarSharer calendarSharer)
        {
            AssertionConcern.AssertArgumentNotNull(calendarSharer, "The calendar sharer must be provided.");
            if (!_sharedWith.Contains(calendarSharer))
            {
                Apply(new CalendarShared(_tenant, _calendarId, _name, calendarSharer));
            }
        }

        private void When(CalendarShared e)
        {
            _sharedWith.Add(e.SharedWith);
        }


        public void UnshareCalendarWith(CalendarSharer calendarSharer)
        {
            AssertionConcern.AssertArgumentNotNull(calendarSharer, "The calendar sharer must be provided.");
            if (_sharedWith.Contains(calendarSharer))
            {
                Apply(new CalendarUnshared(_tenant, _calendarId, _name, calendarSharer));
            }
        }

        private void When(CalendarUnshared e)
        {
            _sharedWith.Remove(e.UnsharedWith);
        }


        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return _tenant;
            yield return _calendarId;
        }
    }
}
