namespace KnowledgeTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionCorrectAnswer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "AnswerId", c => c.Int());
            AddColumn("dbo.Questions", "CorrectAnswer_Id", c => c.Int());
            CreateIndex("dbo.Questions", "CorrectAnswer_Id");
            AddForeignKey("dbo.Questions", "CorrectAnswer_Id", "dbo.Answers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "CorrectAnswer_Id", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "CorrectAnswer_Id" });
            DropColumn("dbo.Questions", "CorrectAnswer_Id");
            DropColumn("dbo.Questions", "AnswerId");
        }
    }
}
