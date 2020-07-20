namespace KnowledgeTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectAnswerRequired : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "AnswerId", c => c.Int());
            CreateIndex("dbo.Questions", "AnswerId");
            AddForeignKey("dbo.Questions", "AnswerId", "dbo.Answers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "AnswerId", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "AnswerId" });
            DropColumn("dbo.Questions", "AnswerId");
        }
    }
}
