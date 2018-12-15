namespace GTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsiteurl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteUrls",
                c => new
                    {
                        SiteUrlId = c.Int(nullable: false, identity: true),
                        PageUrlAddress = c.String(nullable: false),
                        PageTittle = c.String(nullable: false),
                        PageDescription = c.String(nullable: false),
                        PageKeywords = c.String(nullable: false),
                        PageSlugName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SiteUrlId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SiteUrls");
        }
    }
}
