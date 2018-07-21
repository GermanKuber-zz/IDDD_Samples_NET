using System;
using System.Collections.Generic;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.Common.Notifications
{
    [Serializable]
    public class Notification : ValueObject
    {
        public Notification(long notificationId, IDomainEvent domainEvent)
        {
            AssertionConcern.AssertArgumentNotNull(domainEvent, "The event is required.");

            this._notificationId = notificationId;
            this._domainEvent = domainEvent;
            _occurredOn = domainEvent.OccurredOn;
            _version = domainEvent.EventVersion;
            _typeName = domainEvent.GetType().FullName;
        }

        private readonly long _notificationId;
        private readonly IDomainEvent _domainEvent;
        private readonly DateTime _occurredOn;
        private readonly string _typeName;
        private readonly int _version;

        public TEvent GetEvent<TEvent>() where TEvent : IDomainEvent
        {
            return (TEvent)_domainEvent;
        }

        public long NotificationId
        {
            get { return _notificationId; }
        }

        public DateTime OccurredOn
        {
            get { return _occurredOn; }
        }

        public int Version
        {
            get { return _version; }
        }

        public string TypeName
        {
            get { return _typeName; }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _notificationId;
        }
    }
}
