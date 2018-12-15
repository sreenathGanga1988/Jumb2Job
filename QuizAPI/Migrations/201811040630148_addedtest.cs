namespace GTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addedtest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "KnowledgeAreaId", c => c.Int(nullable: true));
            CreateIndex("dbo.Questions", "KnowledgeAreaId");
            AddForeignKey("dbo.Questions", "KnowledgeAreaId", "dbo.KnowledgeAreas", "KnowledgeAreaId", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Questions", "KnowledgeAreaId", "dbo.KnowledgeAreas");
            DropIndex("dbo.Questions", new[] { "KnowledgeAreaId" });
            DropColumn("dbo.Questions", "KnowledgeAreaId");
        }
    }
}
