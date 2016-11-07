namespace AdelanteRedo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolsetnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudentAttendances", "Attended", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudentAttendances", "Attended", c => c.Boolean(nullable: false));
        }
    }
}
