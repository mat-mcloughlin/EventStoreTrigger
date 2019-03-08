using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Triggers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Mat
{
    class EventStoreTriggerBinding : ITriggerBinding
    {
        private readonly Task<ITriggerData> _emptyBindingDataTask =
     Task.FromResult<ITriggerData>(new TriggerData(null, new Dictionary<string, object>()));

        public Type TriggerValueType => typeof(EventStoreEvent);

        public IReadOnlyDictionary<string, Type> BindingDataContract => new Dictionary<string, Type>();

        public Task<ITriggerData> BindAsync(object value, ValueBindingContext context)
        {
            return _emptyBindingDataTask;
        }

        public Task<IListener> CreateListenerAsync(ListenerFactoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return Task.FromResult<IListener>(new EventStoreTriggerListener(context.Executor));
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new EventStoreTriggerParameterDescriptor();
        }
    }
}
