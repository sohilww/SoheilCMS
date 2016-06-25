namespace WorkSamples.DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkSampleChangedToSampleWork : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.WorkSamples", newName: "SampleWorks");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SampleWorks", newName: "WorkSamples");
        }
    }
}
