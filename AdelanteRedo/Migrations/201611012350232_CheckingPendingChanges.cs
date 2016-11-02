namespace AdelanteRedo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckingPendingChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Programs_ProgramsID", "dbo.Programs");
            DropIndex("dbo.Students", new[] { "Programs_ProgramsID" });
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Students", "ProgramNames");
            DropColumn("dbo.Students", "Programs_ProgramsID");
            DropTable("dbo.Programs");
            DropTable("dbo.Weeks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        WeekID = c.Int(nullable: false, identity: true),
                        DayOfTheWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeekID);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramsID = c.Int(nullable: false, identity: true),
                        ProgramNames = c.String(),
                        DayOfTheWeek = c.String(),
                    })
                .PrimaryKey(t => t.ProgramsID);
            
            AddColumn("dbo.Students", "Programs_ProgramsID", c => c.Int());
            AddColumn("dbo.Students", "ProgramNames", c => c.String());
            AddColumn("dbo.Students", "Email", c => c.String());
            CreateIndex("dbo.Students", "Programs_ProgramsID");
            AddForeignKey("dbo.Students", "Programs_ProgramsID", "dbo.Programs", "ProgramsID");
        }
    }
}
