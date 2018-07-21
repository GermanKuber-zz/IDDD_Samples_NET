using System;
using System.Collections.Generic;

namespace SaaSOvation.Common.Notifications
{
    public class NotificationLogId : Domain.Model.ValueObject
    {
        public static string GetEncoded(NotificationLogId notificationLogId)
        {
            if (notificationLogId != null) return notificationLogId.Encoded;
            else return null;
        }

        public static NotificationLogId First(int notificationsPerLog)
        {
            return new NotificationLogId(0, 0).Next(notificationsPerLog);
        }

        public NotificationLogId(long lowId, long highId)
        {
            Low = lowId;
            High = highId;
        }

        public NotificationLogId(string notificationlogId)
        {
            var pts = notificationlogId.Split(',');
            Low = long.Parse(pts[0]);
            High = long.Parse(pts[1]);
        }

        public long Low { get; private set; }
        public long High { get; private set; }

        public string Encoded
        {
            get { return Low + "," + High; }
        }

        public NotificationLogId Next(int notificationsPerLog)
        {
            var nextLow = High + 1;
            var nextHigh = nextLow + notificationsPerLog;
            var next = new NotificationLogId(nextLow, nextHigh);
            if (Equals(next))
                next = null;
            return next;
        }

        public NotificationLogId Previous(int notificationsPerLog)
        {
            var previousLow = Math.Max(Low - notificationsPerLog, 1);
            var previousHigh = previousLow + notificationsPerLog - 1;
            var previous = new NotificationLogId(previousLow, previousHigh);
            if (Equals(previous))
                previous = null;
            return previous;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Low;
            yield return High;
        }
    }
}
