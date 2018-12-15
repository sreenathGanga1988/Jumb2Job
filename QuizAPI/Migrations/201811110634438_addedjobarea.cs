namespace GTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedjobarea : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobFieldAreas",
                c => new
                    {
                        JobAreaId = c.Int(nullable: false, identity: true),
                        JobAreaName = c.String(nullable: false),
                        JobFieldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobAreaId)
                .ForeignKey("dbo.JobFields", t => t.JobFieldId, cascadeDelete: true)
                .Index(t => t.JobFieldId);
            
            CreateTable(
                "dbo.JobFields",
                c => new
                    {
                        JobFieldId = c.Int(nullable: false, identity: true),
                        JobFieldName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.JobFieldId);
            
            AddColumn("dbo.JobVaccancies", "JobAreaId", c => c.Int(nullable: false));
            CreateIndex("dbo.JobVaccancies", "JobAreaId");
            AddForeignKey("dbo.JobVaccancies", "JobAreaId", "dbo.JobFieldAreas", "JobAreaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobVaccancies", "JobAreaId", "dbo.JobFieldAreas");
            DropForeignKey("dbo.JobFieldAreas", "JobFieldId", "dbo.JobFields");
            DropIndex("dbo.JobVaccancies", new[] { "JobAreaId" });
            DropIndex("dbo.JobFieldAreas", new[] { "JobFieldId" });
            DropColumn("dbo.JobVaccancies", "JobAreaId");
            DropTable("dbo.JobFields");
            DropTable("dbo.JobFieldAreas");
        }
    }
}
