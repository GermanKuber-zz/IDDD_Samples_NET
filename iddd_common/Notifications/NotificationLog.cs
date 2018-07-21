using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SaaSOvation.Common.Notifications
{
    public class NotificationLog
    {
        public NotificationLog(string notificationLogId, string nextNotificationLogId, string previousNotificationLogId, 
            IEnumerable<Notification> notifications, bool isArchived)
        {            
            this._notificationLogId = notificationLogId;
            this._nextNotificationLogId = nextNotificationLogId;
            this._previousNotificationLogId = previousNotificationLogId;
            this._notifications = new ReadOnlyCollection<Notification>(notifications.ToArray());
            this._isArchived = isArchived;
        }

        private readonly string _notificationLogId;
        private readonly string _nextNotificationLogId;
        private readonly string _previousNotificationLogId;
        private readonly ReadOnlyCollection<Notification> _notifications;
        private readonly bool _isArchived;

        public bool IsArchived
        {
            get { return _isArchived; }
        }

        public ReadOnlyCollection<Notification> Notifications
        {
            get { return _notifications; }
        }

        public int TotalNotifications
        {
            get { return _notifications.Count; }
        }

        public NotificationLogId DecodedNotificationLogId
        {
            get { return new NotificationLogId(_notificationLogId); }
        }

        public string NotificationLogId
        {
            get { return _notificationLogId; }
        }

        public NotificationLogId DecodedNextNotificationLogId
        {
            get { return new NotificationLogId(_nextNotificationLogId); }
        }

        public string NextNotificationLogId
        {
            get { return _nextNotificationLogId; }
        }

        public bool HasNextNotificationLog
        {
            get { return _nextNotificationLogId != null; }
        }

        public NotificationLogId DecodedPreviousNotificationLogId
        {
            get { return new NotificationLogId(_previousNotificationLogId); }
        }

        public string PreviousNotificationLogId
        {
            get { return _previousNotificationLogId; }
        }

        public bool HasPreviousNotificationLog
        {
            get { return _previousNotificationLogId != null; }
        }
    }
}
