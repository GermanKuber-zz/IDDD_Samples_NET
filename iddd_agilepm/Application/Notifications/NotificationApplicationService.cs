using System;
using SaaSOvation.Common.Notifications;

namespace SaaSOvation.AgilePM.Application.Notifications
{
    public class NotificationApplicationService
    {
        public NotificationApplicationService(INotificationPublisher notificationPublisher)
        {
            this._notificationPublisher = notificationPublisher;
        }

        private readonly INotificationPublisher _notificationPublisher;

        public void PublishNotifications()
        {
            ApplicationServiceLifeCycle.Begin(false);
            try
            {
                _notificationPublisher.PublishNotifications();
                ApplicationServiceLifeCycle.Success();
            }
            catch (Exception ex)
            {
                ApplicationServiceLifeCycle.Fail(ex);
            }
        }
    }
}
