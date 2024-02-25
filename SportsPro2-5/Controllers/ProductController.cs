using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System;
using System.Linq;

namespace SportsPro.Controllers
{
    //Ethan log for Assissgment 8-1 this is where a lot of the code going change.
    public class ProductController : Controller
    {
        private readonly SportsProContext _context;

        public ProductController(SportsProContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            var productsList = _context.Products.ToList();
            return View(productsList);
        }

        //Ethan log: All the ActionResult got changed which includes the Add, edit, delte, and deleteconfirmed
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Action = "Add";
                return View(new Product());
            }

            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Action = "Edit";
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Products.Update(product);
                    _context.SaveChanges();
                }

                //Ethan log: Adding a TempData Message to show the store was succesful

                TempData["SuccessMessage"] = "Operation successful";

                return RedirectToAction(nameof(List));

            

            }
            else
            {
                ViewBag.Action = (product.ProductID == 0) ? "Add" : "Edit";
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deleteProd = _context.Products.Find(id);
            return View(deleteProd);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deleteProd = _context.Products.Find(id);

            if (deleteProd == null)
            {
                return NotFound();
            }

            _context.Products.Remove(deleteProd);

            _context.SaveChanges();

            //Ethan log: Adding a TempData Message to show the store was succesful

            TempData["DeletionMessage"] = "Delete operation successful!";

            return RedirectToAction("List");
        }
    }
}
