namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTableCustomers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipId", "dbo.Memberships");
            DropIndex("dbo.Customers", new[] { "MembershipId" });
            DropTable("dbo.Customers");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Customers", "MembershipId");
            AddForeignKey("dbo.Customers", "MembershipId", "dbo.Memberships", "Id", cascadeDelete: true);
        }
    }
}
