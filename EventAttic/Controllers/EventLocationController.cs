using EventAttic.Data.Services;
using EventAttic.Data.Static;
using EventAttic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventAttic.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class EventLocationController : Controller
    {
        //Get Db 
        private readonly IEventLocationService _service;

        public EventLocationController(IEventLocationService service)
        {
            _service = service;
        }

        //Get EventLocation : Display Artist List

        public async Task<IActionResult> Index()
        {
            var AllEventLocationList = await _service.GetAllAsync();
            return View(AllEventLocationList);
        }

        //Get EventLocation : Details/Id

        public async Task<IActionResult> Details(int id)
        {
            var GetEventLocationDetails = await _service.GetByIdAsync(id);
            if (GetEventLocationDetails == null)
            {
                return NotFound("NotFound");
            }

            return View(GetEventLocationDetails);
        }

        //Get EventLocation : Create

        public IActionResult Create()
        {
            return View();
        }

        //Post EventLocation : Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventLocation eventLocation)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(eventLocation);
                return RedirectToAction("Index");
            }
            return View(eventLocation);
        }

        //Get EventLocation : Edit/Id

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var GetEventLocationBYId = await _service.GetByIdAsync(id);

            if (GetEventLocationBYId == null)
            {
                return View("NotFound");
            }

            return View(GetEventLocationBYId);
        }

        //Post EventLocation : Edit/Id

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, EventLocation eventLocation)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, eventLocation);
                return RedirectToAction("Index");
            }
            return View(eventLocation);
        }

        //Get EventLocation : Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objEventLocationDeleteItem = await _service.GetByIdAsync(id);

            if (objEventLocationDeleteItem == null)
            {
                return View("NotFound");
            }
            return View(objEventLocationDeleteItem);
        }

        //Post EventLocation : Delete/Id

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var objEventLocationDeleteItem = await _service.GetByIdAsync(id);
            if (objEventLocationDeleteItem == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
