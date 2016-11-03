namespace AdelanteRedo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedStudentv1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ProgramNames", c => c.String());
            DropColumn("dbo.Students", "ProgramName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ProgramName", c => c.String());
            DropColumn("dbo.Students", "ProgramNames");
        }
    }
}
