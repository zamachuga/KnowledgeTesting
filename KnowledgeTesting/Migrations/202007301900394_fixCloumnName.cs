namespace KnowledgeTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCloumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Interviwees", "LastName", c => c.String());
            DropColumn("dbo.Interviwees", "LasName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Interviwees", "LasName", c => c.String());
            DropColumn("dbo.Interviwees", "LastName");
        }
    }
}
