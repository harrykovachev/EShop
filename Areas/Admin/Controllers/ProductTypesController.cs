using EShop.Data;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;
        public ProductTypesController(ApplicationDbContext db) {
            _db = db; 
        }
        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(actionName: nameof(Index));
            }
            return View(productTypes);
        }
        public ActionResult Edit(int? id) 
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if(productType == null)
            {
                return NotFound();
            }
            return View(productType); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if(ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details (ProductTypes productTypes) 
        {
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductTypes productTypes)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            if(id != productTypes.Id)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if(productType == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productType);
        }
    }
}
