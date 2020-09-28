namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnGenderToMembership : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memberships", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Memberships", "Gender");
        }
    }
}
