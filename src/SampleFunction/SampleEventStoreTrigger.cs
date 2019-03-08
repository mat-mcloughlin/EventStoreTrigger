using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Mat;
using Microsoft.Azure.WebJobs.Description;

namespace SampleFunction
{
    [Extension("EventStore")]
    public static class SampleEventStoreTrigger
    {
        [FunctionName("SampleEventStoreTrigger")]
        public static void Run([EventStoreTrigger]EventStoreEvent events,
            ILogger log)
        {
            log.LogInformation(events.Something.OriginalEvent.EventType);
        }
    }
}
