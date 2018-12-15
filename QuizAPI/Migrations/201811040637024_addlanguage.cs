namespace GTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addlanguage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "LanguageId", c => c.Int(nullable: true));
            AddColumn("dbo.Questions", "isDisplayOnly", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Questions", "LanguageId");
            AddForeignKey("dbo.Questions", "LanguageId", "dbo.LanguageMasters", "LanguageId", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Questions", "LanguageId", "dbo.LanguageMasters");
            DropIndex("dbo.Questions", new[] { "LanguageId" });
            DropColumn("dbo.Questions", "isDisplayOnly");
            DropColumn("dbo.Questions", "LanguageId");
            DropTable("dbo.LanguageMasters");
        }
    }
}
