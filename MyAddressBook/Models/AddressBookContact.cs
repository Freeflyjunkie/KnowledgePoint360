using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAddressBook.Models
{
    public class AddressBookContact
    {
        public int AddressBookContactID { get; set; }
        public int ContactID { get; set; }
        public int AddressBookID { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual AddressBook AddressBook { get; set; }
    }
}