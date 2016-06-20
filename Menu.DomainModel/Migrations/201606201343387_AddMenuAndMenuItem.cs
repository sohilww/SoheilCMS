namespace Menu.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenuAndMenuItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiteMenus",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        Slug = c.String(nullable: false, maxLength: 100),
                        OrderShow = c.Int(nullable: false),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SiteMenus", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiteMenus", "ParentId", "dbo.SiteMenus");
            DropIndex("dbo.SiteMenus", new[] { "ParentId" });
            DropTable("dbo.SiteMenus");
        }
    }
}
