namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public class CalendarIdentityService
    {
        public CalendarIdentityService(ICalendarRepository calendarRepository, ICalendarEntryRepository calendarEntryRepository)
        {
            this._calendarRepository = calendarRepository;
            this._calendarEntryRepository = calendarEntryRepository;
        }

        private readonly ICalendarRepository _calendarRepository;
        private readonly ICalendarEntryRepository _calendarEntryRepository;

        public CalendarId GetNextCalendarId()
        {
            return _calendarRepository.GetNextIdentity();
        }

        public CalendarEntryId GetNextCalendarEntryId()
        {
            return _calendarEntryRepository.GetNextIdentity();
        }
    }
}
