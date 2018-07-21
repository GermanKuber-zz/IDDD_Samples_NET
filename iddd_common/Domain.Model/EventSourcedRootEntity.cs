using System.Collections.Generic;

namespace SaaSOvation.Common.Domain.Model
{
    public abstract class EventSourcedRootEntity : EntityWithCompositeId
    {
        public EventSourcedRootEntity()
        {
            _mutatingEvents = new List<IDomainEvent>();
        }

        public EventSourcedRootEntity(IEnumerable<IDomainEvent> eventStream, int streamVersion)
            : this()
        {
            foreach (var e in eventStream)
                When(e);
            _unmutatedVersion = streamVersion;
        }

        private readonly List<IDomainEvent> _mutatingEvents;
        private readonly int _unmutatedVersion;

        protected int MutatedVersion
        {
            get { return _unmutatedVersion + 1; }
        }

        protected int UnmutatedVersion
        {
            get { return _unmutatedVersion; }
        }

        public IList<IDomainEvent> GetMutatingEvents()
        {
            return _mutatingEvents.ToArray();
        }

        private void When(IDomainEvent e)
        {
            (this as dynamic).Apply(e);
        }

        protected void Apply(IDomainEvent e)
        {
            _mutatingEvents.Add(e);
            When(e);
        }
    }
}
