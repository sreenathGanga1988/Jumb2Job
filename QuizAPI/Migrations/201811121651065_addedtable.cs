namespace QuizAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CountryMasters",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.JobVaccancies",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        CountryId = c.Int(nullable: false),
                        JobAreaId = c.Int(nullable: false),
                        JobLocation = c.String(),
                        CompanyName = c.String(),
                        EmploymentType = c.String(),
                        MonthlySalary = c.String(),
                        Benefits = c.String(),
                        MinimumWorkExperience = c.String(),
                        MinimumEducationLevel = c.String(),
                        ListedBy = c.String(),
                        CompanySize = c.String(),
                        CareerLevel = c.String(),
                        Description = c.String(),
                        Skills = c.String(),
                        EmailID = c.String(),
                        ContactPerson = c.String(),
                        PhoneNumber = c.String(),
                        Country = c.String(),
                        JobCategory = c.String(),
                        PostedDate = c.DateTime(nullable: false),
                        LasteDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.CountryMasters", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.JobFieldAreas", t => t.JobAreaId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.JobAreaId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobVaccancies", "JobAreaId", "dbo.JobFieldAreas");
            DropForeignKey("dbo.JobFieldAreas", "JobFieldId", "dbo.JobFields");
            DropForeignKey("dbo.JobVaccancies", "CountryId", "dbo.CountryMasters");
            DropIndex("dbo.JobFieldAreas", new[] { "JobFieldId" });
            DropIndex("dbo.JobVaccancies", new[] { "JobAreaId" });
            DropIndex("dbo.JobVaccancies", new[] { "CountryId" });
            DropTable("dbo.JobFields");
            DropTable("dbo.JobFieldAreas");
            DropTable("dbo.JobVaccancies");
            DropTable("dbo.CountryMasters");
        }
    }
}
