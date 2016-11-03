namespace AdelanteRedo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminTitle = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Parent_ParentID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Parents", t => t.Parent_ParentID)
                .Index(t => t.Parent_ParentID);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        DonorID = c.Int(nullable: false, identity: true),
                        Donor_FirstName = c.String(),
                        Donor_LastName = c.String(),
                        Donor_Address = c.String(),
                        Donor_City = c.String(),
                        Donor_State = c.String(),
                        Donor_Zip = c.String(),
                        Donor_HomeTele = c.String(),
                        Donor_CellPhone = c.String(),
                        Donor_Email = c.String(),
                    })
                .PrimaryKey(t => t.DonorID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        start_date = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Location_name = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);

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
                "dbo.Meetings",
                c => new
                    {
                        MeetingID = c.Int(nullable: false, identity: true),
                        Meeting_Start = c.DateTime(nullable: false),
                        Meeting_End = c.DateTime(nullable: false),
                        Meeting_Type = c.String(),
                        Location_Name = c.String(),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.MeetingID)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.MeetingStaffAttendances",
                c => new
                    {
                        MeetingStaffAttendanceID = c.Int(nullable: false, identity: true),
                        StaffID = c.Int(nullable: false),
                        MeetingID = c.Int(nullable: false),
                        Attendance = c.Boolean(),
                    })
                .PrimaryKey(t => t.MeetingStaffAttendanceID)
                .ForeignKey("dbo.Meetings", t => t.MeetingID, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffID, cascadeDelete: true)
                .Index(t => t.StaffID)
                .Index(t => t.MeetingID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        Staff_FirstName = c.String(),
                        Staff_LastName = c.String(),
                        Staff_Address = c.String(),
                        Staff_City = c.String(),
                        Staff_State = c.String(),
                        Staff_Zip = c.String(),
                        Staff_HomeTele = c.String(),
                        Staff_CellPhone = c.String(),
                        Staff_Email = c.String(),
                        STARTDATE = c.DateTime(),
                        ENDDATE = c.DateTime(),
                    })
                .PrimaryKey(t => t.StaffID);
            
            CreateTable(
                "dbo.MeetingStudentAttendances",
                c => new
                    {
                        MeetingStudentAttendanceID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        MeetingID = c.Int(nullable: false),
                        Attendance = c.Boolean(),
                    })
                .PrimaryKey(t => t.MeetingStudentAttendanceID)
                .ForeignKey("dbo.Meetings", t => t.MeetingID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.MeetingID);
            
            CreateTable(
                "dbo.MeetingVolunteerAttendances",
                c => new
                    {
                        MeetingVolunteerAttendanceID = c.Int(nullable: false, identity: true),
                        VolunteerID = c.Int(nullable: false),
                        MeetingID = c.Int(nullable: false),
                        Attendance = c.Boolean(),
                        Volunteer_VolunteerID = c.Guid(),
                    })
                .PrimaryKey(t => t.MeetingVolunteerAttendanceID)
                .ForeignKey("dbo.Meetings", t => t.MeetingID, cascadeDelete: true)
                .ForeignKey("dbo.Volunteers", t => t.Volunteer_VolunteerID)
                .Index(t => t.MeetingID)
                .Index(t => t.Volunteer_VolunteerID);
            
            CreateTable(
                "dbo.Volunteers",
                c => new
                    {
                        VolunteerID = c.Guid(nullable: false),
                        Volunteer_FirstName = c.String(),
                        Volunteer_LastName = c.String(),
                        Volunteer_Address = c.String(),
                        Volunteer_City = c.String(),
                        Volunteer_State = c.String(),
                        Volunteer_Zip = c.String(),
                        Volunteer_HomeTele = c.String(),
                        Volunteer_CellPhone = c.String(),
                        Volunteer_Email = c.String(),
                        STARTDATE = c.DateTime(),
                        ENDDATE = c.DateTime(),
                    })
                .PrimaryKey(t => t.VolunteerID);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentID = c.Int(nullable: false, identity: true),
                        Parent_FirstName = c.String(),
                        Parent_LastName = c.String(),
                        Parent_Address = c.String(),
                        Parent_City = c.String(),
                        Parent_State = c.String(),
                        Parent_Zip = c.String(),
                        Parent_HomeTele = c.String(),
                        Parent_CellPhone = c.String(),
                        Parent_Email = c.String(),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.ParentID)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .Index(t => t.Student_StudentID);
            
            CreateTable(
                "dbo.StudentParents",
                c => new
                    {
                        StudentParentID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        ParentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentParentID)
                .ForeignKey("dbo.Parents", t => t.ParentID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.ParentID);
            
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.StudentParents", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentParents", "ParentID", "dbo.Parents");
            DropForeignKey("dbo.Students", "Parent_ParentID", "dbo.Parents");
            DropForeignKey("dbo.Parents", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.MeetingVolunteerAttendances", "Volunteer_VolunteerID", "dbo.Volunteers");
            DropForeignKey("dbo.MeetingVolunteerAttendances", "MeetingID", "dbo.Meetings");
            DropForeignKey("dbo.MeetingStudentAttendances", "StudentID", "dbo.Students");
            DropForeignKey("dbo.MeetingStudentAttendances", "MeetingID", "dbo.Meetings");
            DropForeignKey("dbo.MeetingStaffAttendances", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.MeetingStaffAttendances", "MeetingID", "dbo.Meetings");
            DropForeignKey("dbo.Meetings", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.StudentParents", new[] { "ParentID" });
            DropIndex("dbo.StudentParents", new[] { "StudentID" });
            DropIndex("dbo.Parents", new[] { "Student_StudentID" });
            DropIndex("dbo.MeetingVolunteerAttendances", new[] { "Volunteer_VolunteerID" });
            DropIndex("dbo.MeetingVolunteerAttendances", new[] { "MeetingID" });
            DropIndex("dbo.MeetingStudentAttendances", new[] { "MeetingID" });
            DropIndex("dbo.MeetingStudentAttendances", new[] { "StudentID" });
            DropIndex("dbo.MeetingStaffAttendances", new[] { "MeetingID" });
            DropIndex("dbo.MeetingStaffAttendances", new[] { "StaffID" });
            DropIndex("dbo.Meetings", new[] { "Location_LocationID" });
            DropIndex("dbo.Students", new[] { "Parent_ParentID" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropTable("dbo.StudentParents");
            DropTable("dbo.Parents");
            DropTable("dbo.Volunteers");
            DropTable("dbo.MeetingVolunteerAttendances");
            DropTable("dbo.MeetingStudentAttendances");
            DropTable("dbo.Staffs");
            DropTable("dbo.MeetingStaffAttendances");
            DropTable("dbo.Meetings");
            DropTable("dbo.Locations");
            DropTable("dbo.Events");
            DropTable("dbo.Donors");
            DropTable("dbo.Students");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Courses");
            DropTable("dbo.Admins");
        }
    }
}
