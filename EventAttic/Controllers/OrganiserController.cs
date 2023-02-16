using EventAttic.Data.Enums;
using EventAttic.Data.Services;
using EventAttic.Data.Static;
using EventAttic.Data.ViewModels;
using EventAttic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventAttic.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class OrganiserController : Controller
    {
        //Get Db 
        private readonly IOrganiserService _service;

        public OrganiserController(IOrganiserService service)
        {
            _service = service;
        }

        //Get Organiser : Display Artist List
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllOrganisersList = await _service.GetAllAsync();
            return View(AllOrganisersList);
        }

        //Get Organiser : Details/Id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var GetOrganisersDetails = await _service.GetByIdAsync(id);
            if (GetOrganisersDetails == null)
            {
                return NotFound("NotFound");
            }

            return View(GetOrganisersDetails);
        }

        //Get Organiser : OrganiserEventDetails/Id
        public ActionResult ItemCommentDisplay()
        {
            //OrganisationViewModel IBCM = new OrganisationViewModel();
            //IBCM.item = GetItemDetails();
            //IBCM.comments = GetCommentList();
            //return View(IBCM);
            return View();
        }



        //Get Organiser : Create

        public IActionResult Create()
        {
            return View();
        }

        //Post Organiser : Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Organiser organiser)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(organiser);
                return RedirectToAction("Index");
            }
            return View(organiser);
        }

        //Get Organiser : Edit/Id

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var GetArtistBYId = await _service.GetByIdAsync(id);

            if (GetArtistBYId == null)
            {
                return View("NotFound");
            }

            return View(GetArtistBYId);
        }

        //Post Organiser : Edit/Id

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Organiser organiser)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, organiser);
                return RedirectToAction("Index");
            }
            return View(organiser);
        }

        //Get Organiser : Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objOrganiserDeleteItem = await _service.GetByIdAsync(id);

            if (objOrganiserDeleteItem == null)
            {
                return View("NotFound");
            }
            return View(objOrganiserDeleteItem);
        }

        //Post Organiser : Delete/Id

        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var objOrganiserDeleteItem = await _service.GetByIdAsync(id);
            if (objOrganiserDeleteItem == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
