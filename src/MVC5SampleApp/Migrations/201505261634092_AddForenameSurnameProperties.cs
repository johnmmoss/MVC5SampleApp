namespace MVC5SampleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForenameSurnameProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 120));
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String(nullable: false, maxLength: 120));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
