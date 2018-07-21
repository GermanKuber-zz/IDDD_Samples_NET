using System;
using Newtonsoft.Json;
using SaaSOvation.Common.Domain.Model;

namespace SaaSOvation.Common.Events
{
    public class EventSerializer
    {
        private readonly static Lazy<EventSerializer> instance = new Lazy<EventSerializer>(() => new EventSerializer(), true);

        public static EventSerializer Instance
        {
            get { return instance.Value; }
        }

        public EventSerializer(bool isPretty = false)
        {
            this._isPretty = isPretty;
        }

        private readonly bool _isPretty;

        public T Deserialize<T>(string serialization)
        {
            return JsonConvert.DeserializeObject<T>(serialization);
        }

        public object Deserialize(string serialization, Type type)
        {
            return JsonConvert.DeserializeObject(serialization, type);
        }

        public string Serialize(IDomainEvent domainEvent)
        {
            return JsonConvert.SerializeObject(domainEvent, _isPretty ? Formatting.Indented : Formatting.None);
        }
    }
}
