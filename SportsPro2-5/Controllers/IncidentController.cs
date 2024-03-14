using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private readonly SportsProContext _context;

        public IncidentController(SportsProContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            var IncidentList = _context.Incidents.Include(i => i.Customer).Include(i => i.Product).ToList();
            return View(IncidentList);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Customers = _context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Products = _context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = _context.Technicians.OrderBy(t => t.Name).ToList();
            return View("Edit", new Incident());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Customers = _context.Customers.OrderBy(c => c.LastName).ToList();
            ViewBag.Products = _context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = _context.Technicians.OrderBy(t => t.Name).ToList();
            ViewBag.Action = "Edit";
            var incident = _context.Incidents.Find(id);
            if (incident == null)
            {
                return View();
            }
            else
            {
                ViewBag.Customer = _context.Customers.OrderBy(c => c.LastName).ToList();
                return View(incident);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentID == 0)
                {
                    _context.Incidents.Add(incident);
                    _context.SaveChanges();
                }
                else
                {
                    _context.Incidents.Update(incident);
                    _context.SaveChanges();
                }
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Customers = _context.Customers.OrderBy(c => c.LastName).ToList();
                ViewBag.Products = _context.Products.OrderBy(p => p.Name).ToList();
                ViewBag.Technicians = _context.Technicians.OrderBy(t => t.Name).ToList();
                ViewBag.Action = (incident.IncidentID == 0) ? "Add" : "Edit";
                return View(incident);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteProd = _context.Incidents.Find(id);
            return View(deleteProd);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteCust = _context.Incidents.Find(id);

            if (deleteCust == null)
            {
                return NotFound();
            }

            _context.Incidents.Remove(deleteCust);

            _context.SaveChanges();

            return RedirectToAction("List");
        }

        public RedirectToActionResult ListByTech()
        {
            return RedirectToAction("Index", "TechIncident");
        }
    }
}
