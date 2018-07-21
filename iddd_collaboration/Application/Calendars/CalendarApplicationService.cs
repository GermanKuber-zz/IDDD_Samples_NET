using System;
using System.Collections.Generic;
using SaaSOvation.Collaboration.Domain.Model.Calendars;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

using SaaSOvation.Collaboration.Application.Calendars.Data;

namespace SaaSOvation.Collaboration.Application.Calendars
{
    public class CalendarApplicationService
    {
        public CalendarApplicationService(ICalendarRepository calendarRepository, ICalendarEntryRepository calendarEntryRepository, CalendarIdentityService calendarIdentityService, ICollaboratorService collaboratorService)
        {
            this._calendarRepository = calendarRepository;
            this._calendarEntryRepository = calendarEntryRepository;
            this._calendarIdentityService = calendarIdentityService;
            this._collaboratorService = collaboratorService;
        }

        private readonly ICalendarRepository _calendarRepository;
        private readonly ICalendarEntryRepository _calendarEntryRepository;
        private readonly CalendarIdentityService _calendarIdentityService;
        private readonly ICollaboratorService _collaboratorService;

        public void ChangeCalendarDescription(string tenantId, string calendarId, string description)
        {
            var calendar = _calendarRepository.Get(new Tenant(tenantId), new CalendarId(calendarId));

            calendar.ChangeDescription(description);

            _calendarRepository.Save(calendar);
        }

        public void CreateCalendar(string tenantId, string name, string description, string ownerId, ISet<string> participantsToShareWith, ICalendarCommandResult calendarCommandResult)
        {
            var tenant = new Tenant(tenantId);
            var owner = _collaboratorService.GetOwnerFrom(tenant, ownerId);
            var sharers = GetSharersFrom(tenant, participantsToShareWith);

            var calendar = new Calendar(tenant, _calendarRepository.GetNextIdentity(), name, description, owner, sharers);

            _calendarRepository.Save(calendar);

            calendarCommandResult.SetResultingCalendarId(calendar.CalendarId.Id);
        }

        public void RenameCalendar(string tenantId, string calendarId, string name)
        {
            var calendar = _calendarRepository.Get(new Tenant(tenantId), new CalendarId(calendarId));

            calendar.Rename(name);

            _calendarRepository.Save(calendar);
        }

        public void ScheduleCalendarEntry(string tenantId, string calendarId, string description, string location, string ownerId, DateTime timeSpanBegins, DateTime timeSpanEnds,
            string repeatType, DateTime repeatEndsOn, string alarmType, int alarmUnits, ISet<string> participantsToInvite, ICalendarCommandResult calendarCommandResult)
        {
            var tenant = new Tenant(tenantId);

            var calendar = _calendarRepository.Get(tenant, new CalendarId(calendarId));

            var calendarEntry = calendar.ScheduleCalendarEntry(
                _calendarIdentityService,
                description,
                location,
                _collaboratorService.GetOwnerFrom(tenant, ownerId),
                new DateRange(timeSpanBegins, timeSpanEnds),
                new Repetition((RepeatType)Enum.Parse(typeof(RepeatType), repeatType), repeatEndsOn),
                new Alarm((AlarmUnitsType)Enum.Parse(typeof(AlarmUnitsType), alarmType), alarmUnits),
                GetInviteesFrom(tenant, participantsToInvite));

            _calendarEntryRepository.Save(calendarEntry);

            calendarCommandResult.SetResultingCalendarId(calendar.CalendarId.Id);
            calendarCommandResult.SetResultingCalendarEntryId(calendarEntry.CalendarEntryId.Id);
        }

        public void ShareCalendarWith(string tenantId, string calendarId, ISet<string> participantsToShareWith)
        {
            var tenant = new Tenant(tenantId);
            var calendar = _calendarRepository.Get(tenant, new CalendarId(calendarId));

            foreach (var sharer in GetSharersFrom(tenant, participantsToShareWith))
            {
                calendar.ShareCalendarWith(sharer);
            }

            _calendarRepository.Save(calendar);
        }

        public void UnshareCalendarWith(string tenantId, string calendarId, ISet<string> participantsToShareWith)
        {
            var tenant = new Tenant(tenantId);
            var calendar = _calendarRepository.Get(tenant, new CalendarId(calendarId));

            foreach (var sharer in GetSharersFrom(tenant, participantsToShareWith))
            {
                calendar.UnshareCalendarWith(sharer);
            }

            _calendarRepository.Save(calendar);
        }

        private ISet<Participant> GetInviteesFrom(Tenant tenant, ISet<string> participantsToInvite)
        {
            var invitees = new HashSet<Participant>();
            foreach (string participatnId in participantsToInvite)
            {
                var participant = _collaboratorService.GetParticipantFrom(tenant, participatnId);
                invitees.Add(participant);
            }
            return invitees;
        }

        private ISet<CalendarSharer> GetSharersFrom(Tenant tenant, ISet<string> participantsToShareWith)
        {
            var sharers = new HashSet<CalendarSharer>();
            foreach (var participatnId in participantsToShareWith)
            {
                var participant = _collaboratorService.GetParticipantFrom(tenant, participatnId);
                sharers.Add(new CalendarSharer(participant));
            }
            return sharers;
        }
    }
}
