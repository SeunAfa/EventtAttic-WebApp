using EventAttic.Data.Base;
using EventAttic.Data.ViewModels;
using EventAttic.Models;
using Microsoft.EntityFrameworkCore;


namespace EventAttic.Data.Services
{
    public class EventService : EntityBaseRepository<Event>, IEventService
    {
        private readonly ApplicationDbContext _context;
        public EventService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewEventAsync(NewEventVM data)
        {
            var NewEventItem = new Event()
            {
                Name = data.Name,
                Description = data.Description,
                AgeRestriction = data.AgeRestriction,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                TimeTill = data.TimeTill,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                EventGenereCategory = data.EventGenereCategory,
                OrganiserId = data.OrganiserId,
                EventLocationId = data.EventLocationId

            };
            await _context.AddAsync(NewEventItem);
            await _context.SaveChangesAsync();

            //Add The Event Artist from Multiple DropdownList 
            foreach (var artistId in data.ArtistIds)
            {
                var newArtistEvent = new Event_Artist()
                {
                    EventId = NewEventItem.Id,
                    ArtistId = artistId
                };
                await _context.Events_Artists.AddAsync(newArtistEvent);
            }
            await _context.SaveChangesAsync();

        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            var getEventItemDetails = await _context.Events
                .Include(u => u.EventLocation)
                .Include(u => u.Organiser)
                .Include(ea => ea.Events_Artists).ThenInclude(a => a.Artist)
                .FirstOrDefaultAsync(e => e.Id == id);
            return getEventItemDetails;
        }

        public async Task<NewEventDropdownsVM> GetNewEventDropdownsVM()
        {
            var response = new NewEventDropdownsVM()
            {
                Artists = await _context.Artists.OrderBy(n => n.ArtistName).ToListAsync(),
                Organisers = await _context.Organisers.OrderBy(n => n.EventOrganiserName).ToListAsync(),
                EventLocations = await _context.EventLocations.OrderBy(n => n.Venue).ToListAsync()
            };
            return response;

        }

        public async Task UpdateEventAsync(NewEventVM data)
        {
            var dbEvent = await _context.Events.FirstOrDefaultAsync(nameof => nameof.Id == data.Id);

            if (dbEvent != null)
            {

                dbEvent.Name = data.Name;
                dbEvent.Description = data.Description;
                dbEvent.AgeRestriction = data.AgeRestriction;
                dbEvent.Price = data.Price;
                dbEvent.ImageUrl = data.ImageUrl;
                dbEvent.TimeTill = data.TimeTill;
                dbEvent.StartDate = data.StartDate;
                dbEvent.EndDate = data.EndDate;
                dbEvent.EventGenereCategory = data.EventGenereCategory;
                dbEvent.OrganiserId = data.OrganiserId;
                dbEvent.EventLocationId = data.EventLocationId;
                await _context.SaveChangesAsync();
            }

            //Remove the Existing Artists
            var removeExisingArtistFromDb = _context.Events_Artists.Where(n => n.EventId == data.Id).ToList();
            _context.Events_Artists.RemoveRange(removeExisingArtistFromDb);
            await _context.SaveChangesAsync();

            //Add The Event Artist from Multiple DropdownList 
            foreach (var artistId in data.ArtistIds)
            {
                var newArtistEvent = new Event_Artist()
                {
                    EventId = data.Id,
                    ArtistId = artistId
                };
                await _context.Events_Artists.AddAsync(newArtistEvent);
            }
            await _context.SaveChangesAsync();
        }
    }
}
