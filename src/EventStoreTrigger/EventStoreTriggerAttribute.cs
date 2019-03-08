using Microsoft.Azure.WebJobs.Description;
using System;

namespace SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Mat
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter)]
    public class EventStoreTriggerAttribute : Attribute
    {
        public string ConnectionString { get; set; }
    }
}
