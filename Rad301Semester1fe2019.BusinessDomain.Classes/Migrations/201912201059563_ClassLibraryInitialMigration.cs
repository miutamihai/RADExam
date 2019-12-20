namespace Rad301Semester1fe2019.BusinessDomain.Classes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassLibraryInitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ISBN = c.String(),
                        Author = c.String(),
                        LoanType = c.String(),
                        LoanDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanID = c.Int(nullable: false, identity: true),
                        MemberID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        LoanIssueDate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoanID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberID, cascadeDelete: true)
                .Index(t => t.MemberID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateJoined = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Loans", "BookID", "dbo.Books");
            DropIndex("dbo.Loans", new[] { "BookID" });
            DropIndex("dbo.Loans", new[] { "MemberID" });
            DropTable("dbo.Members");
            DropTable("dbo.Loans");
            DropTable("dbo.Books");
        }
    }
}
