using System.Collections.Generic;
using Evlog.Domain;

namespace Evlog.Services
{
    public interface IEventsService
    {
         List<EventPost> Get();
        List<EventPost> GetUpcomingEvents();
        List<EventPost> GetPastEvents();
    }
}
