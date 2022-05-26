using FoursquareTest.Data;
using FoursquareTest.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace FoursquareTest.Controllers
{
    public class PlaceController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PlaceController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Place> objPlaceList = _db.Places;
            return View(objPlaceList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Place obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Places.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Place created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var PlaceFromDb = _db.Places.Find(id);
            //var PlaceFromDbFirst = _db.Places.FirstOrDefault(u=>u.Id==id);
            //var PlaceFromDbSingle = _db.Places.SingleOrDefault(u => u.Id == id);

            if (PlaceFromDb == null)
            {
                return NotFound();
            }

            return View(PlaceFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Place obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Places.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Place updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var PlaceFromDb = _db.Places.Find(id);
            //var PlaceFromDbFirst = _db.Places.FirstOrDefault(u=>u.Id==id);
            //var PlaceFromDbSingle = _db.Places.SingleOrDefault(u => u.Id == id);

            if (PlaceFromDb == null)
            {
                return NotFound();
            }

            return View(PlaceFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Places.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Places.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Place deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
