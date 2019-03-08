using Microsoft.Azure.WebJobs.Host.Triggers;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Mat
{
    class EventStoreTriggerAttributeBindingProvider : ITriggerBindingProvider
    {
        private readonly Task<ITriggerBinding> _nullTriggerBindingTask = Task.FromResult<ITriggerBinding>(null);


        public Task<ITriggerBinding> TryCreateAsync(TriggerBindingProviderContext context)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            ParameterInfo parameter = context.Parameter;

            EventStoreTriggerAttribute triggerAttribute = parameter.GetCustomAttribute<EventStoreTriggerAttribute>(inherit: false);
            if (triggerAttribute is null)
            {
                return Task.FromResult<ITriggerBinding>(null);
            }

            return Task.FromResult<ITriggerBinding>(new EventStoreTriggerBinding());
        }
    }
}
