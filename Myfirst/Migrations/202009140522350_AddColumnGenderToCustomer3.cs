namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnGenderToCustomer3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Gender");
        }
    }
}
