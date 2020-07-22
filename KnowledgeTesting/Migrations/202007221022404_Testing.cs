namespace KnowledgeTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestingResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterviweeTestsId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.InterviweeTests", t => t.InterviweeTestsId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.InterviweeTestsId)
                .Index(t => t.QuestionId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.InterviweeTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterviweeId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Interviwees", t => t.InterviweeId, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.InterviweeId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.Interviwees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LasName = c.String(),
                        FirstName = c.String(),
                        SecondName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestingResults", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.TestingResults", "InterviweeTestsId", "dbo.InterviweeTests");
            DropForeignKey("dbo.InterviweeTests", "TestId", "dbo.Tests");
            DropForeignKey("dbo.InterviweeTests", "InterviweeId", "dbo.Interviwees");
            DropForeignKey("dbo.TestingResults", "AnswerId", "dbo.Answers");
            DropIndex("dbo.InterviweeTests", new[] { "TestId" });
            DropIndex("dbo.InterviweeTests", new[] { "InterviweeId" });
            DropIndex("dbo.TestingResults", new[] { "AnswerId" });
            DropIndex("dbo.TestingResults", new[] { "QuestionId" });
            DropIndex("dbo.TestingResults", new[] { "InterviweeTestsId" });
            DropTable("dbo.Interviwees");
            DropTable("dbo.InterviweeTests");
            DropTable("dbo.TestingResults");
        }
    }
}
