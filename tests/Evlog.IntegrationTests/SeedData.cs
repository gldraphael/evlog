using System;
using System.Collections.Generic;
using Evlog.Infrastructure.Data.DataModels;

namespace Evlog.IntegrationTests
{
    public static class SeedData
    {
        internal static IList<EventPostDM> Events =>
            new List<EventPostDM> {
                new EventPostDM {
                    StartTimeUtc = new DateTime(2020, 10, 10),
                    Title = "XYZ is happening again!",
                    Body = "Celery quandong swiss chard chicory earthnut pea potato. Salsify taro catsear garlic gram celery bitterleaf wattle seed collard greens nori. Grape wattle seed kombu beetroot horseradish carrot squash brussels sprout chard.",
                    Description = "Celery quandong swiss chard chicory earthnut pea potato.",
                    Slug = "xyz-is-happening-again"
                }
            };
    }
}
