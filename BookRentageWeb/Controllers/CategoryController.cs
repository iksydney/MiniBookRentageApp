using BookRentageWeb.Data;
using BookRentageWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookRentageWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Categories> objcategoryList = _db.Categories;
            return View(objcategoryList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categories obj)
        {
            if(obj.CategoryName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("categoryName", "The Display Order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var dbCategory = _db.Categories.Find(id);
            //var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categorySingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if(dbCategory == null)
            {
                return NotFound();
            }
            return View(dbCategory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categories obj)
        {
            if (obj.CategoryName == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("categoryName", "The Display Order cannot exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
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
            var dbCategory = _db.Categories.Find(id);
            //var category = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categorySingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if (dbCategory == null)
            {
                return NotFound();
            }
            return View(dbCategory);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var dbObject = _db.Categories.Find(id);
            if (dbObject == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(dbObject);
                _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
