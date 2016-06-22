namespace WorkSamples.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkSamplesAndCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkCategories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Slug = c.String(nullable: false, maxLength: 150),
                        Description = c.String(maxLength: 300),
                        KeyWord = c.String(maxLength: 400),
                        CategoryImage = c.String(maxLength: 400),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.WorkSamples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoTime = c.DateTime( precision: 0, storeType: "datetime2"),
                        Image = c.String(),
                        Content = c.String(),
                        Description = c.String(),
                        Slug = c.String(),
                        WorkCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WorkCategories", t => t.WorkCategoryId, cascadeDelete: true)
                .Index(t => t.WorkCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkSamples", "WorkCategoryId", "dbo.WorkCategories");
            DropForeignKey("dbo.WorkCategories", "ParentId", "dbo.WorkCategories");
            DropIndex("dbo.WorkSamples", new[] { "WorkCategoryId" });
            DropIndex("dbo.WorkCategories", new[] { "ParentId" });
            DropTable("dbo.WorkSamples");
            DropTable("dbo.WorkCategories");
        }
    }
}
