namespace AdelanteRedo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStartDateToMeetingTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meetings", "StartDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meetings", "StartDate");
        }
    }
}
