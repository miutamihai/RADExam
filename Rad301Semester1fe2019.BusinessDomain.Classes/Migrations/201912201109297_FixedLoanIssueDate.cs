namespace Rad301Semester1fe2019.BusinessDomain.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedLoanIssueDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Loans", "LoanIssueDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Loans", "LoanIssueDate", c => c.Int(nullable: false));
        }
    }
}
