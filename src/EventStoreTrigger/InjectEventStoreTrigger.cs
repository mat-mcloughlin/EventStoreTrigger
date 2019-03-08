using EventStoreTrigger;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: WebJobsStartup(typeof(InjectEventStoreTrigger))]

namespace EventStoreTrigger
{
    public class InjectEventStoreTrigger : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddEventStoreTrigger();
        }
    }

}
