using EventStore.ClientAPI;

namespace SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Mat
{
    public class EventStoreEvent
    {
        public EventStoreEvent(ResolvedEvent resolvedEvent)
        {
            ResolvedEvent = resolvedEvent;
        }

        public ResolvedEvent ResolvedEvent { get; }
    }
}
