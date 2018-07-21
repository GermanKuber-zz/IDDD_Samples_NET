using SaaSOvation.Common.Notifications;
using SaaSOvation.Common.Events;

namespace SaaSOvation.IdentityAccess.Application
{
    public class NotificationApplicationService
    {
        public NotificationApplicationService(IEventStore eventStore, INotificationPublisher notificationPublisher)
        {
            this._eventStore = eventStore;
            this._notificationPublisher = notificationPublisher;
        }

        private readonly IEventStore _eventStore;
        private readonly INotificationPublisher _notificationPublisher;

        public NotificationLog GetCurrentNotificationLog()
        {
            return new NotificationLogFactory(_eventStore)
                .CreateCurrentNotificationLog();
        }

        public NotificationLog GetNotificationLog(string notificationLogId)
        {
            return new NotificationLogFactory(_eventStore)
                .CreateNotificationLog(new NotificationLogId(notificationLogId));
        }

        public void PublishNotifications()
        {
            _notificationPublisher.PublishNotifications();
        }
    }
}
