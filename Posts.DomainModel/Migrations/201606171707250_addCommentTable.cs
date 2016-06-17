namespace Posts.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCommentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50),
                        AuthorName = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 300),
                        PostId = c.Int(nullable: false),
                        RegisterDate = c.DateTime(nullable: false, precision: 0, storeType: "datetime2"),
                        ParentCommentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.ParentCommentId)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.ParentCommentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Comments", "ParentCommentId", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "ParentCommentId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropTable("dbo.Comments");
        }
    }
}
