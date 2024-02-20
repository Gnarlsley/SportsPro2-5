using SportsPro2_5.ViewModels;
using SportsPro.Models;

namespace SportsPro2_5.Models
{
    public class IncidentListViewModel : IncidentViewModel
    {
        public List<Incident> Incidents { get; set; }
        public List<Product> Products { get; set; }
        public List<Technician> Technicians { get; set; }
        public List<Customer> Customers { get; set; }

        public string action = string.Empty;


        //this code is not working

        /*        public string checkAction(string c) =>
                    c.ToLower() == Viewbag.Action.ToLower() ? "Add" : "Edit";
            */
    }
}
