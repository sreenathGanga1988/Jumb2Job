namespace GTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedisactive : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.JobVaccancies", "IsActive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobVaccancies", "IsActive", c => c.DateTime(nullable: false));
        }
    }
}
