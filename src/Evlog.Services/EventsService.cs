using System;
using System.Collections.Generic;
using Evlog.Domain;

namespace Evlog.Services
{
    public class EventsService : IEventsService
    {
        public List<Event> Get()
        {
            return new List<Event>(new Event[]{
                new Event
                {
                    Title = "Vacation",
                    Body = "One of my earliest memories (─‿─)",
                    TimeStamp = new DateTime(1983, 10, 10)
                },
                new Event
                {
                    Title = "First day at school",
                    Body = "Apparently I cried so much the first day, the teachers felt bad.",
                    TimeStamp = new DateTime(1983, 8, 20)
                },
                new Event
                {
                    Title = "Hello World!",
                    TimeStamp = new DateTime(1980, 10, 10)
                }
            });
        }
    }
}
