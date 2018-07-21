using System;
using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class DateRange : ValueObject
    {
        public DateRange(DateTime begins, DateTime ends)
        {
            if (begins > ends)
                throw new ArgumentException("Time span must not end before it begins.");

            this._begins = begins;
            this._ends = ends;
        }

        private readonly DateTime _begins;
        private readonly DateTime _ends;

        public DateTime Begins
        {
            get { return _begins; }
        }

        public DateTime Ends
        {
            get { return _ends; }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _begins;
            yield return _ends;
        }
    }
}
