using System.Collections.Generic;
using System.Linq;
using SaaSOvation.Common.Events;

namespace SaaSOvation.Common.Notifications
{
    public class NotificationLogFactory
    {
        public const int NotificationsPerLog = 20;

        public NotificationLogFactory(IEventStore eventStore)
        {
            this._eventStore = eventStore;
        }

        private readonly IEventStore _eventStore;

        public NotificationLog CreateNotificationLog(NotificationLogId notificationLogId)
        {
            var count = _eventStore.CountStoredEvents();
            return CreateNotificationLog(new NotificationLogInfo(notificationLogId, count));
        }

        public NotificationLog CreateCurrentNotificationLog()
        {
            return CreateNotificationLog(CalculateCurrentNotificationLogId());
        }

        private NotificationLogInfo CalculateCurrentNotificationLogId()
        {
            var count = _eventStore.CountStoredEvents();
            var remainder = count * NotificationsPerLog;
            if (remainder == 0)
            {
                remainder = NotificationsPerLog;
            }
            var low = count - remainder + 1;
            var high = low + NotificationsPerLog - 1;
            return new NotificationLogInfo(new NotificationLogId(low, high), count);
        }

        private NotificationLog CreateNotificationLog(NotificationLogInfo notificationLogInfo)
        {
            var storedEvents = _eventStore.GetAllStoredEventsBetween(notificationLogInfo.NotificationLogId.Low, notificationLogInfo.NotificationLogId.High);
            var isArchived = notificationLogInfo.NotificationLogId.High > notificationLogInfo.TotalLogged;
            var next = isArchived ? notificationLogInfo.NotificationLogId.Next(NotificationsPerLog) : null;
            var previous = notificationLogInfo.NotificationLogId.Previous(NotificationsPerLog);
            return new NotificationLog(
                notificationLogInfo.NotificationLogId.Encoded,
                NotificationLogId.GetEncoded(next),
                NotificationLogId.GetEncoded(previous),
                GetNotificationsFrom(storedEvents),
                isArchived);                
        }

        private IEnumerable<Notification> GetNotificationsFrom(IEnumerable<StoredEvent> storedEvents)
        {
            return storedEvents.Select(storedEvent => new Notification(storedEvent.EventId, storedEvent.ToDomainEvent()));
        }
    }
}
