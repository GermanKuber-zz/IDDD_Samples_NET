using System;
using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class Repetition : ValueObject
    {
        public static Repetition DoesNotRepeat(DateTime ends)
        {
            return new Repetition(RepeatType.DoesNotRepeat, ends);
        }

        public static Repetition RepeatsIndefinitely(RepeatType repeatType)
        {
            return new Repetition(repeatType, DateTime.MaxValue);
        }

        public Repetition(RepeatType repeats, DateTime ends)
        {
            Repeats = repeats;
            Ends = ends;
        }

        public RepeatType Repeats { get; }

        public DateTime Ends { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Repeats;
            yield return Ends;
        }
    }
}
