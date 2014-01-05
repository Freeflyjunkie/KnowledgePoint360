using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAddressBook.ViewModels
{
    public class ContactViewModel
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalImageUrl { get; set; }
    }
}