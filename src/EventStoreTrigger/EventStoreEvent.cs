using EventStore.ClientAPI;

namespace SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Mat
{
    public class EventStoreEvent
    {
        public EventStoreEvent(ResolvedEvent something)
        {
            Something = something;
        }

        public ResolvedEvent Something { get; }
    }
}
