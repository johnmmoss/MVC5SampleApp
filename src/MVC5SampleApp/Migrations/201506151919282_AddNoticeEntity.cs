namespace MVC5SampleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoticeEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Headline = c.String(maxLength: 300),
                        Body = c.String(nullable: false, maxLength: 1000),
                        PublishDate = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notices");
        }
    }
}
