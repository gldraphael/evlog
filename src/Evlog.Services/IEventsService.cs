using System.Collections.Generic;
using Evlog.Domain;

namespace Evlog.Services
{
    public interface IEventsService
    {
         List<Event> Get();
    }
}
