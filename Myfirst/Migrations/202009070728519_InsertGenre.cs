namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Genres (GenreName) values('Suspense Thriller')");
            Sql("Insert Genres (GenreName) values('Adventuors')");
            Sql("Insert Genres (GenreName) values('Horror')");
            Sql("Insert Genres (GenreName) values('Romantic')");
            Sql("Insert Genres (GenreName) values('Comedy')");
            Sql("Insert Genres (GenreName) values('Action Thriller')");

        }

        public override void Down()
        {
        }
    }
}
