using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class Alarm : ValueObject
    {
        public Alarm(AlarmUnitsType alarmUnitsType, int alarmUnits)
        {
            this._alarmUnitsType = alarmUnitsType;
            this._alarmUnits = alarmUnits;
        }

        private readonly int _alarmUnits;
        private readonly AlarmUnitsType _alarmUnitsType;

        public AlarmUnitsType AlarmUnitsType
        {
            get { return _alarmUnitsType; }
        }

        public int AlarmUnits
        {
            get { return _alarmUnits; }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _alarmUnits;
            yield return _alarmUnitsType;
        }
    }
}
