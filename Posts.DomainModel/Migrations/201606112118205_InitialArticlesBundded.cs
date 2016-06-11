namespace Posts.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialArticlesBundded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Slug = c.String(),
                        IsParent = c.Boolean(nullable: false),
                        LineAge = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 256),
                        SendDate = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        PublishedDate = c.DateTime(precision: 0, storeType: "datetime2"),
                        VisitCount = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 256),
                        PostImage = c.String(maxLength: 256),
                        Slug = c.String(nullable: false, maxLength: 256),
                        AuthorId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 90),
                        LastName = c.String(nullable: false, maxLength: 150),
                        UserName = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropTable("dbo.Authors");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
