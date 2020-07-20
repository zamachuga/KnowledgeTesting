namespace KnowledgeTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CorrectAnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.CorrectAnswerId, cascadeDelete: true)
                .Index(t => t.CorrectAnswerId);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionAnswers",
                c => new
                    {
                        Question_Id = c.Int(nullable: false),
                        Answer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_Id, t.Answer_Id })
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .ForeignKey("dbo.Answers", t => t.Answer_Id, cascadeDelete: true)
                .Index(t => t.Question_Id)
                .Index(t => t.Answer_Id);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        Test_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_Id, t.Question_Id })
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Test_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestQuestions", "Question_Id", "dbo.Questions");
            DropForeignKey("dbo.TestQuestions", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Questions", "CorrectAnswerId", "dbo.Answers");
            DropForeignKey("dbo.QuestionAnswers", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.QuestionAnswers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.TestQuestions", new[] { "Question_Id" });
            DropIndex("dbo.TestQuestions", new[] { "Test_Id" });
            DropIndex("dbo.QuestionAnswers", new[] { "Answer_Id" });
            DropIndex("dbo.QuestionAnswers", new[] { "Question_Id" });
            DropIndex("dbo.Questions", new[] { "CorrectAnswerId" });
            DropTable("dbo.TestQuestions");
            DropTable("dbo.QuestionAnswers");
            DropTable("dbo.Tests");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
