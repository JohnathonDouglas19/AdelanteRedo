namespace AdelanteRedo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgramNameFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Programs", "ProgramNames", c => c.String());
            DropColumn("dbo.Programs", "ProgramsName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programs", "ProgramsName", c => c.String());
            DropColumn("dbo.Programs", "ProgramNames");
        }
    }
}
