using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Triggers;
using System;
using System.Collections.Generic;

namespace SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Mat
{
    class EventStoreTriggerData : ITriggerData
    {
        public IValueProvider ValueProvider => throw new NotImplementedException();

        public IReadOnlyDictionary<string, object> BindingData => throw new NotImplementedException();
    }
}
