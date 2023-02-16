using EventAttic.Data.Base;
using EventAttic.Models;

namespace EventAttic.Data.Services
{
    public class EventLocationService : EntityBaseRepository<EventLocation>, IEventLocationService
    {
        public EventLocationService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
