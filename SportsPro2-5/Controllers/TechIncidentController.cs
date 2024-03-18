using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System.Linq;

namespace SportsPro2_5.Controllers
{
    public class TechIncidentController : Controller
    {
        private readonly SportsProContext _context;

        public TechIncidentController(SportsProContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            ViewBag.Technicians = _context.Technicians.OrderBy(t => t.Name).ToList();
            return View();
        }

        // Display form for editing an incident
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var incident = _context.Incidents.Include(i => i.Technician).Include(i => i.Customer).Include(i => i.Product).FirstOrDefault(i => i.IncidentID == id);

            if (incident == null)
            {
                return NotFound();
            }

            return View(incident);
        }

        // Handle submission of edited incident form
        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductID == incident.ProductID);
                var technician = _context.Technicians.FirstOrDefault(t => t.TechnicianID == incident.TechnicianID);
                var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == incident.CustomerID);

                // Populate navigation properties
                incident.Product = product;
                incident.Technician = technician;
                incident.Customer = customer;

                _context.Update(incident);
                _context.SaveChanges();
                return RedirectToAction("List", "TechIncident", new {TechnicianID = incident.TechnicianID});
            }
            else
            {
                var incidents = _context.Incidents.Include(i => i.Technician).Include(i => i.Customer).Include(i => i.Product).FirstOrDefault(i => i.IncidentID == incident.IncidentID);
                return View(incidents);
            }
        }

        public ActionResult List(int TechnicianId)
        {
            var technician = _context.Technicians.FirstOrDefault(t => t.TechnicianID == TechnicianId);

            if (technician != null)
            {
                ViewBag.Technican = technician.Name;
            }

            var incidents = _context.Incidents.Include(i => i.Technician).Where(i => i.TechnicianID == TechnicianId).ToList();

            return View(incidents);
        }


    }
}
