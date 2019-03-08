using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Mat;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreTrigger
{
    [Extension("EventStore")]
    public class EventStoreTriggerConfigProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var triggerAttributeBindingRule = context.AddBindingRule<EventStoreTriggerAttribute>();
            triggerAttributeBindingRule.BindToTrigger<EventStoreEvent>(new EventStoreTriggerAttributeBindingProvider());
        }
    }
}
