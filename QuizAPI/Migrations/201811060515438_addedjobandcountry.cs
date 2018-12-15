namespace GTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedjobandcountry : DbMigration
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
                        IsActive = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.CountryMasters", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobVaccancies", "CountryId", "dbo.CountryMasters");
            DropIndex("dbo.JobVaccancies", new[] { "CountryId" });
            DropTable("dbo.JobVaccancies");
            DropTable("dbo.CountryMasters");
        }
    }
}
