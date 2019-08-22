using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evlog.Domain.EventAggregate
{
    public interface IEventPostRepository
    {
        Task<IEnumerable<EventPost>> GetAll();
        Task<IEnumerable<EventPost>> GetUpcoming();
        Task<IEnumerable<EventPost>> GetPast();
    }
}
