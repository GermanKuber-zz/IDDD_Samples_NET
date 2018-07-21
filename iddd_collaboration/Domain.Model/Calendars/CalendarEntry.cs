using System.Collections.Generic;
using System.Linq;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Tenants;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarEntry : EventSourcedRootEntity
    {
        public CalendarEntry(
            Tenant tenant,
            CalendarId calendarId,
            CalendarEntryId calendarEntryId,
            string description,
            string location,
            Owner owner,
            DateRange timeSpan,
            Repetition repetition,
            Alarm alarm,
            IEnumerable<Participant> invitees = null)
        {
            AssertionConcern.AssertArgumentNotNull(tenant, "The tenant must be provided.");
            AssertionConcern.AssertArgumentNotNull(calendarId, "The calendar id must be provided.");
            AssertionConcern.AssertArgumentNotNull(calendarEntryId, "The calendar entry id must be provided.");
            AssertionConcern.AssertArgumentNotEmpty(description, "The description must be provided.");
            AssertionConcern.AssertArgumentNotEmpty(location, "The location must be provided.");
            AssertionConcern.AssertArgumentNotNull(owner, "The owner must be provided.");
            AssertionConcern.AssertArgumentNotNull(timeSpan, "The time span must be provided.");
            AssertionConcern.AssertArgumentNotNull(repetition, "The repetition must be provided.");
            AssertionConcern.AssertArgumentNotNull(alarm, "The alarm must be provided.");

            if (repetition.Repeats == RepeatType.DoesNotRepeat)
                repetition = Repetition.DoesNotRepeat(timeSpan.Ends);

            AssertTimeSpans(repetition, timeSpan);

            Apply(new CalendarEntryScheduled(tenant, calendarId, calendarEntryId, description, location, owner, timeSpan, repetition, alarm, invitees));
        }

        private Tenant _tenant;
        private CalendarId _calendarId;
        private CalendarEntryId _calendarEntryId;
        private string _description;
        private string _location;
        private Owner _owner;
        private DateRange _timeSpan;
        private Repetition _repetition;
        private Alarm _alarm;
        private HashSet<Participant> _invitees;

        public CalendarEntryId CalendarEntryId
        {
            get { return CalendarEntryId; }
        }

        private void AssertTimeSpans(Repetition repetition, DateRange timeSpan)
        {
            if (repetition.Repeats == RepeatType.DoesNotRepeat)
            {
                AssertionConcern.AssertArgumentEquals(repetition.Ends, timeSpan.Ends, "Non-repeating entry must end with time span end.");
            }
            else
            {
                AssertionConcern.AssertArgumentFalse(timeSpan.Ends > repetition.Ends, "Time span must end when or before repetition ends.");
            }
        }

        private void When(CalendarEntryScheduled e)
        {
            _tenant = e.Tenant;
            _calendarId = e.CalendarId;
            _calendarEntryId = e.CalendarEntryId;
            _description = e.Description;
            _location = e.Location;
            _owner = e.Owner;
            _timeSpan = e.TimeSpan;
            _repetition = e.Repetition;
            _alarm = e.Alarm;
            _invitees = new HashSet<Participant>(e.Invitees ?? Enumerable.Empty<Participant>());
        }


        public void ChangeDescription(string description)
        {
            if (description == null)
            {
                // TODO: consider
            }

            description = description.Trim();

            if (!string.IsNullOrEmpty(description) && !this._description.Equals(description))
            {
                Apply(new CalendarEntryDescriptionChanged(_tenant, _calendarId, _calendarEntryId, description));
            }
        }

        private void When(CalendarEntryDescriptionChanged e)
        {
            _description = e.Description;
        }
        

        public void Invite(Participant participant)
        {
            AssertionConcern.AssertArgumentNotNull(participant, "The participant must be provided.");
            if (!_invitees.Contains(participant))
            {
                Apply(new CalendarEntryParticipantInvited(_tenant, _calendarId, _calendarEntryId, participant));
            }
        }

        private void When(CalendarEntryParticipantInvited e)
        {
            _invitees.Add(e.Participant);
        }


        public void Relocate(string location)
        {
            if (location == null)
            {
                // TODO: consider
            }

            location = location.Trim();
            if (!string.IsNullOrEmpty(location) && !this._location.Equals(location))
            {
                Apply(new CalendarEntryRelocated(_tenant, _calendarId, _calendarEntryId, location));
            }
        }

        private void When(CalendarEntryRelocated e)
        {
            _location = e.Location;
        }


        public void Reschedule(string description, string location, DateRange timeSpan, Repetition repetition, Alarm alarm)
        {
            AssertionConcern.AssertArgumentNotNull(timeSpan, "The time span must be provided.");
            AssertionConcern.AssertArgumentNotNull(repetition, "The repetition must be provided.");
            AssertionConcern.AssertArgumentNotNull(alarm, "The alarm must be provided.");

            if (repetition.Repeats == RepeatType.DoesNotRepeat)
                repetition = Repetition.DoesNotRepeat(timeSpan.Ends);

            AssertTimeSpans(repetition, timeSpan);

            ChangeDescription(description);
            Relocate(location);

            Apply(new CalendarEntryRescheduled(_tenant, _calendarId, _calendarEntryId, timeSpan, repetition, alarm));
        }

        private void When(CalendarEntryRescheduled e)
        {
            _timeSpan = e.TimeSpan;
            _repetition = e.Repetition;
            _alarm = e.Alarm;
        }


        public void Uninvite(Participant participant)
        {
            AssertionConcern.AssertArgumentNotNull(participant, "The participant must be provided.");

            if (_invitees.Contains(participant))
            {
                Apply(new CalendarEntryParticipantUninvited(_tenant, _calendarId, _calendarEntryId, participant));
            }
        }

        private void When(CalendarEntryParticipantUninvited e)
        {
            _invitees.Remove(e.Participant);
        }

        protected override IEnumerable<object> GetIdentityComponents()
        {
            yield return _tenant;
            yield return _calendarId;
            yield return _calendarEntryId;
        }
    }
}
