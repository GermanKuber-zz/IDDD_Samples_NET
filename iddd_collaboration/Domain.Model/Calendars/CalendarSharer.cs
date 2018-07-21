using System;
using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarSharer : ValueObject, IComparable<CalendarSharer>
    {
        public CalendarSharer(Participant participant)
        {
            AssertionConcern.AssertArgumentNotNull(participant, "Participant must be provided.");
            this._participant = participant;
        }

        private readonly Participant _participant;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _participant;
        }

        public int CompareTo(CalendarSharer other)
        {
            return _participant.CompareTo(other._participant);
        }
    }
}
