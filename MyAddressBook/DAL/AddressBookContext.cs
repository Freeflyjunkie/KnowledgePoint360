﻿using MyAddressBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MyAddressBook.DAL
{
    public class AddressBookContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AddressBook> AddressBooks { get; set; }
        public DbSet<AddressBookContact> AddressBookContacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}