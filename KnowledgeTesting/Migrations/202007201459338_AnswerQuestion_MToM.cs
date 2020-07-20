namespace KnowledgeTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswerQuestion_MToM : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionAnswers", "Answer_Id", "dbo.Answers");
            DropForeignKey("dbo.QuestionAnswers", "Question_Id", "dbo.Questions");
            DropIndex("dbo.QuestionAnswers", new[] { "Answer_Id" });
            DropIndex("dbo.QuestionAnswers", new[] { "Question_Id" });
            DropTable("dbo.QuestionAnswers");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
