namespace KnowledgeTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestingStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestingResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterviweeId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        AnswerId = c.Int(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("dbo.Interviwees", t => t.InterviweeId, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.InterviweeId)
                .Index(t => t.QuestionId)
                .Index(t => t.AnswerId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestingResults", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.TestingResults", "InterviweeId", "dbo.Interviwees");
            DropForeignKey("dbo.InterviweeTests", "TestId", "dbo.Tests");
            DropForeignKey("dbo.InterviweeTests", "InterviweeId", "dbo.Interviwees");
            DropForeignKey("dbo.TestingResults", "AnswerId", "dbo.Answers");
            DropIndex("dbo.InterviweeTests", new[] { "TestId" });
            DropIndex("dbo.InterviweeTests", new[] { "InterviweeId" });
            DropIndex("dbo.TestingResults", new[] { "AnswerId" });
            DropIndex("dbo.TestingResults", new[] { "QuestionId" });
            DropIndex("dbo.TestingResults", new[] { "InterviweeId" });
            DropTable("dbo.InterviweeTests");
            DropTable("dbo.Interviwees");
            DropTable("dbo.TestingResults");
        }
    }
}
