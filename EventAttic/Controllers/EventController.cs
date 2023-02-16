using EventAttic.Data.Services;
using EventAttic.Data.Static;
using EventAttic.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventAttic.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class EventController : Controller
    {
        //Get Db 
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }


        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllEventList = await _service.GetAllAsync(n => n.EventLocation);
            return View(AllEventList);
        }

        //Serach 
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var AllEventList = await _service.GetAllAsync(n => n.EventLocation);

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filterResult = AllEventList.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filterResultNew = AllEventList.Where(n => string.Equals(n.Name, searchString,
                    StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString,
                    StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filterResultNew);
            }
            return View("Index", AllEventList);
        }

        //Get Event : Details/Id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var getEventItemDetails = await _service.GetEventByIdAsync(id);
            return View(getEventItemDetails);
        }

        //Get Event : Create
        public async Task<IActionResult> Create()
        {
            var eventDropdownList = await _service.GetNewEventDropdownsVM();

            ViewBag.EventLocationId = new SelectList(eventDropdownList.EventLocations, "Id", "Venue");
            ViewBag.OrganiserId = new SelectList(eventDropdownList.Organisers, "Id", "EventOrganiserName");
            ViewBag.ArtistId = new SelectList(eventDropdownList.Artists, "Id", "ArtistName");

            return View();
        }

        //Post Event : Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewEventVM eventVM)
        {
            if (!ModelState.IsValid)
            {
                var eventDropdownList = await _service.GetNewEventDropdownsVM();

                ViewBag.EventLocationId = new SelectList(eventDropdownList.EventLocations, "Id", "Venue");
                ViewBag.OrganiserId = new SelectList(eventDropdownList.Organisers, "Id", "EventOrganiserName");
                ViewBag.ArtistId = new SelectList(eventDropdownList.Artists, "Id", "ArtistName");
                return View(eventVM);
            }

            await _service.AddNewEventAsync(eventVM);
            return RedirectToAction("Index");

        }


        //Get Event : Edit
        public async Task<IActionResult> Edit(int id)
        {
            var eventItemDetail = await _service.GetEventByIdAsync(id);
            if (eventItemDetail == null)
            {
                return View("NotFound");
            }

            var response = new NewEventVM()
            {
                Id = eventItemDetail.Id,
                Name = eventItemDetail.Name,
                AgeRestriction = eventItemDetail.AgeRestriction,
                Price = eventItemDetail.Price,
                ImageUrl = eventItemDetail.ImageUrl,
                TimeTill = eventItemDetail.TimeTill,
                StartDate = eventItemDetail.StartDate,
                EndDate = eventItemDetail.EndDate,
                Description = eventItemDetail.Description,
                EventGenereCategory = eventItemDetail.EventGenereCategory,
                OrganiserId = eventItemDetail.OrganiserId,
                EventLocationId = eventItemDetail.EventLocationId,
                ArtistIds = eventItemDetail.Events_Artists.Select(n => n.ArtistId).ToList(),
            };

            var eventDropdownList = await _service.GetNewEventDropdownsVM();

            ViewBag.EventLocationId = new SelectList(eventDropdownList.EventLocations, "Id", "Venue");
            ViewBag.OrganiserId = new SelectList(eventDropdownList.Organisers, "Id", "EventOrganiserName");
            ViewBag.ArtistId = new SelectList(eventDropdownList.Artists, "Id", "ArtistName");

            return View(response);
        }


        //Post Event : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewEventVM eventVM)
        {
            if (id != eventVM.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var eventDropdownList = await _service.GetNewEventDropdownsVM();

                ViewBag.EventLocationId = new SelectList(eventDropdownList.EventLocations, "Id", "Venue");
                ViewBag.OrganiserId = new SelectList(eventDropdownList.Organisers, "Id", "EventOrganiserName");
                ViewBag.ArtistId = new SelectList(eventDropdownList.Artists, "Id", "ArtistName");
                return View(eventVM);
            }

            await _service.UpdateEventAsync(eventVM);
            return RedirectToAction("Index");

        }
    }
}
