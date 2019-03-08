using EventStore.ClientAPI;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Mat
{
    class EventStoreTriggerListener : IListener
    {
        private ITriggeredFunctionExecutor executor;
        private Task listenerTask;

        public EventStoreTriggerListener(ITriggeredFunctionExecutor executor)
        {
            this.executor = executor;
        }

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.listenerTask = ListenAsync(new CancellationToken());
            return this.listenerTask.IsCompleted ? this.listenerTask : Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private async Task ListenAsync(CancellationToken listenerStoppingToken)
        {
            var client = await GetEventStoreConnection();

            client.SubscribeToAllFrom(
                Position.Start, 
                CatchUpSubscriptionSettings.Default, 
                async (s, e) =>
            {
                await this.executor.TryExecuteAsync(new TriggeredFunctionData() { TriggerValue = new EventStoreEvent(e) }, CancellationToken.None);
            });
        }

        static async Task<IEventStoreConnection> GetEventStoreConnection()
        {
            var eventStoreConnection =
                EventStoreConnection.Create("ConnectTo=tcp://admin:changeit@eventstore.local:1113;HeartBeatTimeout=500");

            await eventStoreConnection.ConnectAsync();
            return eventStoreConnection;
        }
    }
}
