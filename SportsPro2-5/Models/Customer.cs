//New Code
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsPro.Models
{
    public class Customer
    {
		public int CustomerID { get; set; }

		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string State { get; set; } = string.Empty;
		public string PostalCode { get; set; } = string.Empty;
		public string? Phone { get; set; } 
        public string? Email { get; set; }

		[Required(ErrorMessage = "THIS IS MY ERROR MESSAGE FOR COUNTRY ID")]
		public string CountryID { get; set; }  // foreign key property

		public Country? Country { get; set; }    // navigation property

        public string FullName => FirstName + " " + LastName;   // read-only property
	}
}