using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models
{
    public class Incident
    {
		public int IncidentID { get; set; }

        [Required(ErrorMessage = "Please insert a title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please insert a description")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a start date")]
        public DateTime DateOpened { get; set; } = DateTime.Now;

        public DateTime? DateClosed { get; set; } = null;

        [Required(ErrorMessage = "Please select a customer")]
        public int CustomerID { get; set; }                   // foreign key property
		public Customer? Customer { get; set; }       // navigation property

        [Required(ErrorMessage = "Please select a product")]
        public int ProductID { get; set; }                    // foreign key property
		public Product? Product { get; set; }        // navigation property

        [Required(ErrorMessage = "Please select a technician")]
        public int TechnicianID { get; set; }                 // foreign key property 
		public Technician? Technician { get; set; }  // navigation property

		
	}
}