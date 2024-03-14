using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;

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
    }
}
