namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCustomers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        DateofBirth = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 100),
                        Gender = c.String(nullable: false),
                        MembershipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Memberships", t => t.MembershipId, cascadeDelete: true)
                .Index(t => t.MembershipId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipId", "dbo.Memberships");
            DropIndex("dbo.Customers", new[] { "MembershipId" });
            DropTable("dbo.Customers");
        }
    }
}
