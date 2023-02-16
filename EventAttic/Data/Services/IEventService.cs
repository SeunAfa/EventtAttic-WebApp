using EventAttic.Data.Base;
using EventAttic.Data.ViewModels;
using EventAttic.Models;

namespace EventAttic.Data.Services
{
    public interface IEventService : IEntityBaseRepository<Event>
    {
        Task<Event> GetEventByIdAsync(int id);
        Task<NewEventDropdownsVM> GetNewEventDropdownsVM();
        Task AddNewEventAsync(NewEventVM data);
        Task UpdateEventAsync(NewEventVM data);

    }
}
