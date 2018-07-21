namespace SaaSOvation.Common.Notifications
{
    public class NotificationLogInfo
    {
        public NotificationLogInfo(NotificationLogId notificationLogId, long totalLogged)
        {
            this._notificationLogId = notificationLogId;
            this._totalLogged = totalLogged;
        }

        private readonly NotificationLogId _notificationLogId;

        public NotificationLogId NotificationLogId
        {
            get { return _notificationLogId; }
        }

        private readonly long _totalLogged;

        public long TotalLogged
        {
            get { return _totalLogged; }
        } 

    }
}
