namespace KnowledgeTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String()
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassInterviewees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassTesting_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassTestings", t => t.ClassTesting_Id)
                .Index(t => t.ClassTesting_Id);
            
            CreateTable(
                "dbo.ClassQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        CorrectAnswer_Id = c.Int(),
                        ClassTesting_Id = c.Int(),
                        ClassTest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassAnswers", t => t.CorrectAnswer_Id)
                .ForeignKey("dbo.ClassTestings", t => t.ClassTesting_Id)
                .ForeignKey("dbo.ClassTests", t => t.ClassTest_Id)
                .Index(t => t.CorrectAnswer_Id)
                .Index(t => t.ClassTesting_Id)
                .Index(t => t.ClassTest_Id);
            
            CreateTable(
                "dbo.ClassTestings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassTests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClassQuestions", "ClassTest_Id", "dbo.ClassTests");
            DropForeignKey("dbo.ClassQuestions", "ClassTesting_Id", "dbo.ClassTestings");
            DropForeignKey("dbo.ClassInterviewees", "ClassTesting_Id", "dbo.ClassTestings");
            DropForeignKey("dbo.ClassQuestions", "CorrectAnswer_Id", "dbo.ClassAnswers");
            DropForeignKey("dbo.ClassAnswers", "ClassQuestion_Id", "dbo.ClassQuestions");
            DropIndex("dbo.ClassQuestions", new[] { "ClassTest_Id" });
            DropIndex("dbo.ClassQuestions", new[] { "ClassTesting_Id" });
            DropIndex("dbo.ClassQuestions", new[] { "CorrectAnswer_Id" });
            DropIndex("dbo.ClassInterviewees", new[] { "ClassTesting_Id" });
            DropIndex("dbo.ClassAnswers", new[] { "ClassQuestion_Id" });
            DropTable("dbo.ClassTests");
            DropTable("dbo.ClassTestings");
            DropTable("dbo.ClassQuestions");
            DropTable("dbo.ClassInterviewees");
            DropTable("dbo.ClassAnswers");
        }
    }
}
