using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAddressBook.ViewModels
{
    public class ContactAddressViewModel
    {
        public string Address { get; set; }        
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }                
    }
}