using System;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.Common.Events
{
    public class StoredEvent : IEquatable<StoredEvent>
    {
        public StoredEvent(string typeName, DateTime occurredOn, string eventBody, long eventId = -1L)
        {
            AssertionConcern.AssertArgumentNotEmpty(typeName, "The event type name is required.");
            AssertionConcern.AssertArgumentLength(typeName, 100, "The event type name must be 100 characters or less.");

            AssertionConcern.AssertArgumentNotEmpty(eventBody, "The event body is required.");
            AssertionConcern.AssertArgumentLength(eventBody, 65000, "The event body must be 65000 characters or less.");

            this._typeName = typeName;
            this._occurredOn = occurredOn;
            this._eventBody = eventBody;
            this._eventId = eventId;
        }

        private readonly string _typeName;

        public string TypeName
        {
            get { return _typeName; }
        }

        private readonly DateTime _occurredOn;

        public DateTime OccurredOn
        {
            get { return _occurredOn; }
        }

        private readonly string _eventBody;

        public string EventBody
        {
            get { return _eventBody; }
        }

        private readonly long _eventId;

        public long EventId
        {
            get { return _eventId; }
        }

        public IDomainEvent ToDomainEvent()
        {
            return ToDomainEvent<IDomainEvent>();
        }

        public TEvent ToDomainEvent<TEvent>()
            where TEvent : IDomainEvent
        {
            var eventType = default(Type);
            try
            {
                eventType = Type.GetType(_typeName);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    string.Format("Class load error, because: {0}", ex));
            }
            return (TEvent)EventSerializer.Instance.Deserialize(_eventBody, eventType);
        }

        public bool Equals(StoredEvent other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            return _eventId.Equals(other._eventId);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StoredEvent);
        }

        public override int GetHashCode()
        {
            return _eventId.GetHashCode();
        }
    }
}
