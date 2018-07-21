namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public interface ICalendarEntryRepository
    {
        CalendarEntry Get(Tenants.Tenant tenant, CalendarEntryId calendarId);
        CalendarEntryId GetNextIdentity();
        void Save(CalendarEntry calendarEntry);
    }
}
