namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullToReleaseDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Releasedate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Releasedate", c => c.DateTime(nullable: false));
        }
    }
}
