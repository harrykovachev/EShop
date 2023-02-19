using EShop.Data;
using EShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _he;
        public ProductController(ApplicationDbContext db, Microsoft.AspNetCore.Hosting.IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            return View(_db.Products.Include(c => c.ProductTypes).ToList());
        }
        public IActionResult Create()
        {
            ViewData["productTypeId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create (Products products, IFormFile image)
        {

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Image = "Images/" + image.FileName;
                }
                _db.Products.Add(products);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        public ActionResult Edit(int? id)
        {
            ViewData["productTypeId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
            if (!id.HasValue)
            {
                return NotFound();
            }
            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Products products, IFormFile? image)
        {

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Image = "Images/" + image.FileName;
                }
                if(image == null)
                {
                    products.Image = "Images/no-image.png";
                }
                _db.Products.Update(products);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            var product = _db.Products.Include(c => c.ProductTypes).Where(c => c.Id == id).FirstOrDefault();
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if(!id.HasValue)
            {
                return NotFound();
            }
            var product = _db.Products.FirstOrDefault(c => c.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
