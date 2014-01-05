namespace MyAddressBook.Migrations
{
    using MyAddressBook.Models;
    using System.Collections.Generic;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyAddressBook.DAL.AddressBookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyAddressBook.DAL.AddressBookContext context)
        {
           var contacts = new List<Contact>
            {
                new Contact { FirstName = "Ricky",   LastName = "Martin", 
                    Address = "56 Congressional Blvd", City="Washington", Country="USA", Postcode="07882", PersonalImageUrl="http://imag.lecturalia.com/img/autor/ricky-martin-9579.jpg"},
                new Contact { FirstName = "Helen",   LastName = "Hunt", 
                    Address = "54 Congressional Blvd", City="Washington", Country="USA", Postcode="07882" , PersonalImageUrl="http://ia.media-imdb.com/images/M/MV5BMTM1OTk1ODIwMV5BMl5BanBnXkFtZTcwMTA0MTIwOQ@@._V1._SX100_SY131_.jpg"},
                new Contact { FirstName = "Jodie",   LastName = "Foster", 
                    Address = "57 Congressional Blvd", City="Washington", Country="USA", Postcode="07882" , PersonalImageUrl="http://www.gralon.net/cinema/acteur/photo-jodie-foster-1065.gif"},
                new Contact { FirstName = "Sally",   LastName = "Field", 
                    Address = "43 Main Street", City="Clinton", Country="USA", Postcode="07198" , PersonalImageUrl="http://www.pathe.nl/thumb/120x160/gfx_content/profiel/sallyfield120.jpg"},
                new Contact { FirstName = "Brad",   LastName = "Pitt", 
                    Address = "187 Main Street", City="Clinton", Country="USA", Postcode="07198" , PersonalImageUrl="http://www.moviepilot.de/files/images/0487/1903/Brad_Pitt_B4051_poster_large.JPG"},
                new Contact { FirstName = "Sandra",   LastName = "Bullock", 
                    Address = "90 Main Street", City="Clinton", Country="USA", Postcode="07198" , PersonalImageUrl="http://www.ellemagazin.hu/Root/Shared/Pictures/2013/08/01/sandra-bullock(148x195).png"},
                new Contact { FirstName = "Bill",   LastName = "Nye", 
                    Address = "478 Grove Street", City="Elizabeth", Country="USA", Postcode="08765" , PersonalImageUrl="http://ts4.explicit.bing.net/th?id=H.4999502046168627&pid=1.7"},
                new Contact { FirstName = "Jack",   LastName = "Nicholson", 
                    Address = "49 Grove Street", City="Elizabeth", Country="USA", Postcode="08765" , PersonalImageUrl="http://image.gala.de/v1/cms/uP/jack-nicholson_4748574-portrait-standardPortraitTeaser_2.jpg?v=6787873"},
            };
            contacts.ForEach(s => context.Contacts.AddOrUpdate(p => p.FirstName, s));
            context.SaveChanges();

            var addressbooks = new List<AddressBook>
            {
                new AddressBook { Description="Family" },
                new AddressBook { Description="Friends" },
            };
            addressbooks.ForEach(s => context.AddressBooks.AddOrUpdate(p => p.Description, s));
            context.SaveChanges();

            var addressbookcontacts = new List<AddressBookContact>
            {
                new AddressBookContact { 
                    ContactID  = contacts.Single(s => s.FirstName == "Ricky").ContactID , 
                    AddressBookID = addressbooks.Single(c => c.Description == "Family" ).AddressBookID                    
                },
                 new AddressBookContact { 
                    ContactID  = contacts.Single(s => s.FirstName == "Helen").ContactID , 
                    AddressBookID = addressbooks.Single(c => c.Description == "Family" ).AddressBookID     
                 },                            
                 new AddressBookContact { 
                     ContactID  = contacts.Single(s => s.FirstName == "Jodie").ContactID , 
                    AddressBookID = addressbooks.Single(c => c.Description == "Family" ).AddressBookID     
                 },
                 new AddressBookContact { 
                      ContactID  = contacts.Single(s => s.FirstName == "Sally").ContactID , 
                    AddressBookID = addressbooks.Single(c => c.Description == "Family" ).AddressBookID     
                 },
                 new AddressBookContact { 
                  ContactID  = contacts.Single(s => s.FirstName == "Brad").ContactID , 
                    AddressBookID = addressbooks.Single(c => c.Description == "Family" ).AddressBookID     
                 },
                 new AddressBookContact {
                     ContactID  = contacts.Single(s => s.FirstName == "Sandra").ContactID , 
                    AddressBookID = addressbooks.Single(c => c.Description == "Family" ).AddressBookID     
                 },
                 new AddressBookContact { 
                     ContactID  = contacts.Single(s => s.FirstName == "Bill").ContactID , 
                    AddressBookID = addressbooks.Single(c => c.Description == "Friends" ).AddressBookID     
                 },
                 new AddressBookContact { 
                     ContactID  = contacts.Single(s => s.FirstName == "Jack").ContactID , 
                    AddressBookID = addressbooks.Single(c => c.Description == "Friends" ).AddressBookID     
                 }            
            };

            addressbookcontacts.ForEach(s => context.AddressBookContacts.AddOrUpdate(p => p.ContactID, s));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
