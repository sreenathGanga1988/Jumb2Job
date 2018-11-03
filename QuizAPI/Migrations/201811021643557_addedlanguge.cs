namespace QuizAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlanguge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LanguageMasters",
                c => new
                    {
                        LanguageId = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            AddColumn("dbo.Questions", "LanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "isDisplayOnly", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Questions", "LanguageId");
            AddForeignKey("dbo.Questions", "LanguageId", "dbo.LanguageMasters", "LanguageId", cascadeDelete: true);
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
