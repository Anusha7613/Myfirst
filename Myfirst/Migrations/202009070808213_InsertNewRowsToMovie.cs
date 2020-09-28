namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertNewRowsToMovie : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Movies(Name,Releasedate,Hero,DirectorName,GenreId) Values('V',05/09/2020,'Nani','Indraganti',1)");
            Sql("Insert Movies(Name,Releasedate,Hero,DirectorName,GenreId) Values('Sahasam',25/10/2014,'GopiChand','Chandra Shekar',2)");
            Sql("Insert Movies(Name,Releasedate,Hero,DirectorName,GenreId) Values('Chandramukhi','05/04/2007','RajaniKanth','Vasu',3)");
            Sql("Insert Movies(Name,Releasedate,Hero,DirectorName,GenreId) Values('Romance',10/07/2006,'Prince','Maruthi',4)");
            Sql("Insert Movies(Name,Releasedate,Hero,DirectorName,GenreId) Values('Lovers','05/09/2014','Sumanth','Maruthi',5)");
            Sql("Insert Movies(Name,Releasedate,Hero,DirectorName,GenreId) Values('Simha',23/03/2006,'BalaKrishna','Sreenu',6)");

        }

        public override void Down()
        {
        }
    }
}
