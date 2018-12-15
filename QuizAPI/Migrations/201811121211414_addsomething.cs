namespace GTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsomething : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobVaccancies", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobVaccancies", "IsActive");
        }
    }
}
