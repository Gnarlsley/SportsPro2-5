using Microsoft.AspNetCore.Mvc;
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
            var incident = _context.Incidents.Find(id);

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
                _context.Update(incident);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incident);
        }


    }
}
