//New Code
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models
{
    public class Customer
    {
		public int CustomerID { get; set; }

		[Required (ErrorMessage = "Please insert a first name")]
		public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please insert a last name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please insert an address")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please insert a city")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please insert a state")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please insert a postal code")]
        public string PostalCode { get; set; } = string.Empty;
		public string? Phone { get; set; } 
        public string? Email { get; set; }

		[Required(ErrorMessage = "Please select a country")]
		public string CountryID { get; set; }  // foreign key property

		public Country? Country { get; set; }    // navigation property

        public string FullName => FirstName + " " + LastName;   // read-only property
	}
}