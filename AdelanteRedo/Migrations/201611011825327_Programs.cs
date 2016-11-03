namespace AdelanteRedo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Programs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramsID = c.Int(nullable: false, identity: true),
                        ProgramNames = c.String(),
                        DayOfTheWeek = c.String(),
                    })
                .PrimaryKey(t => t.ProgramsID);
            
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        WeekID = c.Int(nullable: false, identity: true),
                        DayOfTheWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeekID);
            
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "ProgramName", c => c.String());
            AddColumn("dbo.Students", "Programs_ProgramsID", c => c.Int());
            CreateIndex("dbo.Students", "Programs_ProgramsID");
            AddForeignKey("dbo.Students", "Programs_ProgramsID", "dbo.Programs", "ProgramsID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Programs_ProgramsID", "dbo.Programs");
            DropIndex("dbo.Students", new[] { "Programs_ProgramsID" });
            DropColumn("dbo.Students", "Programs_ProgramsID");
            DropColumn("dbo.Students", "ProgramName");
            DropColumn("dbo.Students", "Email");
            DropTable("dbo.Weeks");
            DropTable("dbo.Programs");
        }
    }
}
