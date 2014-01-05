using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAddressBook.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(100, MinimumLength = 1)]
        public string Address { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string City { get; set; }

        [StringLength(10, MinimumLength = 1)]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip Code")]
        public string Postcode { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Country { get; set; }

        [StringLength(500, MinimumLength = 1)]
        public string PersonalImageUrl { get; set; }

        public virtual ICollection<AddressBookContact> AddressBookContacts { get; set; }

    }
}