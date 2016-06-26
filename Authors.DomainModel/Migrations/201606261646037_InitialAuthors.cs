namespace Authors.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialAuthors : DbMigration
    {
        public override void Up()
        {


            AddColumn("dbo.Authors", "Email", a => a.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Authors", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Authors", "Password",c=> c.String(nullable: false, maxLength: 480));

            CreateIndex("dbo.Authors", "UserName", unique: true);
            CreateIndex("dbo.Authors", "Email", unique: true);

            //AddColumn(
            //   "dbo.Authors",
            //   c => new
            //   {
            //       Id = c.Int(nullable: false),
            //       Name = c.String(nullable: false, maxLength: 90),
            //       LastName = c.String(nullable: false, maxLength: 150),
            //       UserName = c.String(nullable: false, maxLength: 150),
            //       Email = c.String(nullable: false, maxLength: 150),
            //       RoleId = c.Int(nullable: false),
            //       Password = c.String(nullable: false, maxLength: 480),
            //   })
            //   .PrimaryKey(t => t.Id)
            //   .Index(t => t.UserName, unique: true)
            //   .Index(t => t.Email, unique: true);



        }
        
        public override void Down()
        {
            DropIndex("dbo.Authors", new[] { "Email" });
            DropIndex("dbo.Authors", new[] { "UserName" });

            DropColumn("dbo.Authors", "Email");
            DropColumn("dbo.Authors", "RoleId");
            DropColumn("dbo.Authors", "Password");
            
        }
    }
}
