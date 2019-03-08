using Microsoft.Azure.WebJobs;
using System;

namespace EventStoreTrigger
{
    public static class EvemtStoreTriggerBuilderExtensions
    {
        public static IWebJobsBuilder AddEventStoreTrigger(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<EventStoreTriggerConfigProvider>();
            return builder;
        }
    }
}
