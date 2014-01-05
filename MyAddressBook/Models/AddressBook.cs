using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAddressBook.Models
{
    public class AddressBook
    {
        [Key]
        public int AddressBookID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Description { get; set; }

        public virtual ICollection<AddressBookContact> AddressBookContacts { get; set; }
    }
}