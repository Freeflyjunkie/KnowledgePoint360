namespace MyAddressBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressBookData1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressBookContact",
                c => new
                    {
                        AddressBookContactID = c.Int(nullable: false, identity: true),
                        ContactID = c.Int(nullable: false),
                        AddressBookID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressBookContactID)
                .ForeignKey("dbo.AddressBook", t => t.AddressBookID, cascadeDelete: true)
                .ForeignKey("dbo.Contact", t => t.ContactID, cascadeDelete: true)
                .Index(t => t.AddressBookID)
                .Index(t => t.ContactID);
            
            CreateTable(
                "dbo.AddressBook",
                c => new
                    {
                        AddressBookID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressBookID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Address = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        Postcode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 50),
                        PersonalImageUrl = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressBookContact", "ContactID", "dbo.Contact");
            DropForeignKey("dbo.AddressBookContact", "AddressBookID", "dbo.AddressBook");
            DropIndex("dbo.AddressBookContact", new[] { "ContactID" });
            DropIndex("dbo.AddressBookContact", new[] { "AddressBookID" });
            DropTable("dbo.Contact");
            DropTable("dbo.AddressBook");
            DropTable("dbo.AddressBookContact");
        }
    }
}
