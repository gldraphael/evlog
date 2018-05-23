using System.Collections.Generic;
using Evlog.Domain;

namespace Evlog.Services
{
    public interface IEventsService
    {
        List<EventPost> Get();
        EventPost Get(int id);
        EventPost Get(string slug);
        List<EventPost> GetUpcomingEvents();
        List<EventPost> GetPastEvents();
    }
}
