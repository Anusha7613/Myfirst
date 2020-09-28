namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGenderFromMembership : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Memberships", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Memberships", "Gender", c => c.String());
        }
    }
}
