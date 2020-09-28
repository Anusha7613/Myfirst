namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertToCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Customers(Name,DateofBirth,Address,Gender,MembershipId) Values('Nishitha',09/09/1998,'O.D.F','Female',1)");
            Sql("Insert Customers(Name,DateofBirth,Address,Gender,MembershipId) Values('Praneeth Reddy',23/02/2001,'O.D.F','Male',2)");
            Sql("Insert Customers(Name,DateofBirth,Address,Gender,MembershipId) Values('Manjula',15/11/1976,'O.D.F','Female',3)");
        }
        
        public override void Down()
        {
        }
    }
}
