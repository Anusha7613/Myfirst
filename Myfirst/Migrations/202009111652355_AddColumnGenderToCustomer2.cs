namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnGenderToCustomer2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Gender", c => c.String(nullable: false));
        }
    }
}
