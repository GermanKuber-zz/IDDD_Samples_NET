using SaaSOvation.Common.Events;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.IdentityAccess.Application
{
    public class IdentityAccessEventProcessor
    {
        public IdentityAccessEventProcessor(IEventStore eventStore)
        {
            this._eventStore = eventStore;
        }

        private readonly IEventStore _eventStore;

        public void Listen()
        {
            DomainEventPublisher.Instance.Subscribe(domainEvent => _eventStore.Append(domainEvent));
        }
    }
}
