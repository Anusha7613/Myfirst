namespace Myfirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertMembership : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Memberships(MembershipType,SignUpFee,Duration,Discount) Values('PayAsYouGo',0,0,0)");
            Sql("Insert Memberships(MembershipType,SignUpFee,Duration,Discount) Values('Monthly',100,1,10)");
            Sql("Insert Memberships(MembershipType,SignUpFee,Duration,Discount) Values('Quarterly',300,3,15)");
            Sql("Insert Memberships(MembershipType,SignUpFee,Duration,Discount) Values('HalfYearly',600,6,20)");
            Sql("Insert Memberships(MembershipType,SignUpFee,Duration,Discount) Values('Yearly',1200,12,25)");
         }

        public override void Down()
        {
        }
    }
}
