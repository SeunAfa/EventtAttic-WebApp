using EventAttic.Data.Services;
using EventAttic.Data.Static;
using EventAttic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventAttic.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ArtistController : Controller
    {
        //Get Db 
        private readonly IArtistService _service;

        public ArtistController(IArtistService service)
        {
            _service = service;
        }

        //Get Artist : Display Artist List
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllArtistsListData = await _service.GetAllAsync();
            return View(AllArtistsListData);
        }

        //Get Artist : Details/Id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var GetArtistBYId = await _service.GetByIdAsync(id);

            if (GetArtistBYId == null)
            {
                return View("Notfound");
            }

            return View(GetArtistBYId);
        }

        // GET Artist : Create

        public IActionResult Create()
        {
            return View();
        }

        //Post Artist : Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Artist artist)
        {
            if (artist.StagePictureURL == artist.ProfilePictureURL.ToString())
            {
                ModelState.AddModelError("StagePictureURL", "The StagePictureURL Url cannoot be the same as ProfilePictureURL");
            }

            if (ModelState.IsValid)
            {
                await _service.AddAsync(artist);
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        //Get Artist : Edit/Id

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

        //Post Artist : Edit/Id

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Artist objArtist)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, objArtist);
                return RedirectToAction("Index");
            }
            return View(objArtist);
        }

        //Get Artist : Delete/Id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var objArtistDeleteItem = await _service.GetByIdAsync(id);

            if (objArtistDeleteItem == null)
            {
                return View("NotFound");
            }
            return View(objArtistDeleteItem);
        }

        //Post Artist : Delete/Id
        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var objArtistDeleteItem = await _service.GetByIdAsync(id);
            if (objArtistDeleteItem == null)
            {
                return View("NotFound");
            }

            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
