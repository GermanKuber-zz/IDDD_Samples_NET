namespace SaaSOvation.Collaboration.Domain.Model.Calendars
{
    public interface ICalendarRepository
    {
        Calendar Get(Tenants.Tenant tenant, CalendarId calendarId);
        CalendarId GetNextIdentity();
        void Save(Calendar calendar);
    }
}
