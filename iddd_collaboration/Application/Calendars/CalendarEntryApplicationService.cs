using System;
using System.Collections.Generic;
using SaaSOvation.Collaboration.Domain.Model.Calendars;
using SaaSOvation.Collaboration.Domain.Model.Collaborators;
using SaaSOvation.Collaboration.Domain.Model.Tenants;

namespace SaaSOvation.Collaboration.Application.Calendars
{
    public class CalendarEntryApplicationService
    {
        public CalendarEntryApplicationService(ICalendarEntryRepository calendarEntryRepository, ICollaboratorService collaboratorService)
        {
            this._calendarEntryRepository = calendarEntryRepository;
            this._collaboratorService = collaboratorService;
        }

        private readonly ICalendarEntryRepository _calendarEntryRepository;
        private readonly ICollaboratorService _collaboratorService;

        public void ChangeCalendarEntryDescription(string tenantId, string calendarEntryId, string description)
        {
            var calendarEntry = _calendarEntryRepository.Get(new Tenant(tenantId), new CalendarEntryId(calendarEntryId));

            calendarEntry.ChangeDescription(description);

            _calendarEntryRepository.Save(calendarEntry);
        }

        public void InviteCalendarEntryParticipant(string tenantId, string calendarEntryId, ISet<string> participantsToInvite)
        {
            var tenant = new Tenant(tenantId);
            var calendarEntry = _calendarEntryRepository.Get(tenant, new CalendarEntryId(calendarEntryId));

            foreach (var participant in GetInviteesFrom(tenant, participantsToInvite))
            {
                calendarEntry.Invite(participant);
            }

            _calendarEntryRepository.Save(calendarEntry);
        }

        public void RelocateCalendarEntry(string tenantId, string calendarEntryId, string location)
        {
            var calendarEntry = _calendarEntryRepository.Get(new Tenant(tenantId), new CalendarEntryId(calendarEntryId));

            calendarEntry.Relocate(location);

            _calendarEntryRepository.Save(calendarEntry);
        }

        public void RescheduleCalendarEntry(string tenantId, string calendarEntryId, string description, string location, DateTime timeSpanBegins, DateTime timeSpanEnds,
            string repeatType, DateTime repeatEndsOn, string alarmType, int alarmUnits)
        {
            var calendarEntry = _calendarEntryRepository.Get(new Tenant(tenantId), new CalendarEntryId(calendarEntryId));

            calendarEntry.Reschedule(
                description, 
                location, 
                new DateRange(timeSpanBegins, timeSpanEnds), 
                new Repetition((RepeatType)Enum.Parse(typeof(RepeatType), repeatType), repeatEndsOn),
                new Alarm((AlarmUnitsType)Enum.Parse(typeof(AlarmUnitsType), alarmType), alarmUnits));

            _calendarEntryRepository.Save(calendarEntry);
        }

        public void UninviteCalendarEntryParticipant(string tenantId, string calendarEntryId, ISet<string> participantsToUninvite)
        {
            var tenant = new Tenant(tenantId);
            var calendarEntry = _calendarEntryRepository.Get(tenant, new CalendarEntryId(calendarEntryId));

            foreach (var participant in GetInviteesFrom(tenant, participantsToUninvite))
            {
                calendarEntry.Uninvite(participant);
            }

            _calendarEntryRepository.Save(calendarEntry);
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
    }
}
