namespace AdelanteRedo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttendanceRestructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Meetings", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.MeetingStaffAttendances", "MeetingID", "dbo.Meetings");
            DropForeignKey("dbo.MeetingStaffAttendances", "StaffID", "dbo.Staffs");
            DropForeignKey("dbo.MeetingStudentAttendances", "MeetingID", "dbo.Meetings");
            DropForeignKey("dbo.MeetingStudentAttendances", "StudentID", "dbo.Students");
            DropForeignKey("dbo.MeetingVolunteerAttendances", "MeetingID", "dbo.Meetings");
            DropForeignKey("dbo.MeetingVolunteerAttendances", "Volunteer_VolunteerID", "dbo.Volunteers");
            DropForeignKey("dbo.Parents", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.Students", "Parent_ParentID", "dbo.Parents");
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "Parent_ParentID" });
            DropIndex("dbo.Meetings", new[] { "Location_LocationID" });
            DropIndex("dbo.MeetingStaffAttendances", new[] { "StaffID" });
            DropIndex("dbo.MeetingStaffAttendances", new[] { "MeetingID" });
            DropIndex("dbo.MeetingStudentAttendances", new[] { "StudentID" });
            DropIndex("dbo.MeetingStudentAttendances", new[] { "MeetingID" });
            DropIndex("dbo.MeetingVolunteerAttendances", new[] { "MeetingID" });
            DropIndex("dbo.MeetingVolunteerAttendances", new[] { "Volunteer_VolunteerID" });
            DropIndex("dbo.Parents", new[] { "Student_StudentID" });
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramsID = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(),
                        DayofTheWeek = c.String(),
                    })
                .PrimaryKey(t => t.ProgramsID);
            
            CreateTable(
                "dbo.StudentAttendances",
                c => new
                    {
                        StudentAttendanceID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        MeetingID = c.Int(nullable: false),
                        Attended = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentAttendanceID)
                .ForeignKey("dbo.Meetings", t => t.MeetingID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.MeetingID);
            
            CreateTable(
                "dbo.StudentPrograms",
                c => new
                    {
                        StudentProgramID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        ProgramsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentProgramID)
                .ForeignKey("dbo.Programs", t => t.ProgramsID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID)
                .Index(t => t.ProgramsID);
            
            AddColumn("dbo.Students", "Address", c => c.String());
            AddColumn("dbo.Students", "State", c => c.String());
            AddColumn("dbo.Students", "ZipCode", c => c.String());
            AddColumn("dbo.Students", "PhoneNumber", c => c.String());
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "Meeting_MeetingID", c => c.Int());
            AddColumn("dbo.Meetings", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Meetings", "Hour", c => c.Int(nullable: false));
            AddColumn("dbo.Meetings", "Minute", c => c.Int(nullable: false));
            AddColumn("dbo.Meetings", "ProgramsID", c => c.Int(nullable: false));
            AddColumn("dbo.Staffs", "FirstName", c => c.String());
            AddColumn("dbo.Staffs", "LastName", c => c.String());
            AddColumn("dbo.Staffs", "Address", c => c.String());
            AddColumn("dbo.Staffs", "State", c => c.String());
            AddColumn("dbo.Staffs", "ZipCode", c => c.String());
            AddColumn("dbo.Staffs", "PhoneNumber", c => c.String());
            AddColumn("dbo.Staffs", "EmailAddress", c => c.String());
            AddColumn("dbo.Parents", "FirstName", c => c.String());
            AddColumn("dbo.Parents", "LastName", c => c.String());
            AddColumn("dbo.Parents", "Address", c => c.String());
            AddColumn("dbo.Parents", "State", c => c.String());
            AddColumn("dbo.Parents", "ZipCode", c => c.String());
            AddColumn("dbo.Parents", "PhoneNumber", c => c.String());
            AddColumn("dbo.Parents", "EmailAddress", c => c.String());
            CreateIndex("dbo.Meetings", "ProgramsID");
            CreateIndex("dbo.Students", "Meeting_MeetingID");
         //   AddForeignKey("dbo.Meetings", "ProgramsID", "dbo.Programs", "ProgramsID", cascadeDelete: true);
            AddForeignKey("dbo.Students", "Meeting_MeetingID", "dbo.Meetings", "MeetingID");
            DropColumn("dbo.Students", "Parent_ParentID");
            DropColumn("dbo.Meetings", "Meeting_Start");
            DropColumn("dbo.Meetings", "Meeting_End");
            DropColumn("dbo.Meetings", "Meeting_Type");
            DropColumn("dbo.Meetings", "Location_Name");
            DropColumn("dbo.Meetings", "Location_LocationID");
            DropColumn("dbo.Staffs", "Staff_FirstName");
            DropColumn("dbo.Staffs", "Staff_LastName");
            DropColumn("dbo.Staffs", "Staff_Address");
            DropColumn("dbo.Staffs", "Staff_City");
            DropColumn("dbo.Staffs", "Staff_State");
            DropColumn("dbo.Staffs", "Staff_Zip");
            DropColumn("dbo.Staffs", "Staff_HomeTele");
            DropColumn("dbo.Staffs", "Staff_CellPhone");
            DropColumn("dbo.Staffs", "Staff_Email");
            DropColumn("dbo.Parents", "Parent_FirstName");
            DropColumn("dbo.Parents", "Parent_LastName");
            DropColumn("dbo.Parents", "Parent_Address");
            DropColumn("dbo.Parents", "Parent_City");
            DropColumn("dbo.Parents", "Parent_State");
            DropColumn("dbo.Parents", "Parent_Zip");
            DropColumn("dbo.Parents", "Parent_HomeTele");
            DropColumn("dbo.Parents", "Parent_CellPhone");
            DropColumn("dbo.Parents", "Parent_Email");
            DropColumn("dbo.Parents", "Student_StudentID");
            DropTable("dbo.Courses");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Events");
            DropTable("dbo.Locations");
            DropTable("dbo.MeetingStaffAttendances");
            DropTable("dbo.MeetingStudentAttendances");
            DropTable("dbo.MeetingVolunteerAttendances");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.MeetingVolunteerAttendanceID);
            
            CreateTable(
                "dbo.MeetingStudentAttendances",
                c => new
                    {
                        MeetingStudentAttendanceID = c.Int(nullable: false, identity: true),
                        StudentID = c.Int(nullable: false),
                        MeetingID = c.Int(nullable: false),
                        Attendance = c.Boolean(),
                    })
                .PrimaryKey(t => t.MeetingStudentAttendanceID);
            
            CreateTable(
                "dbo.MeetingStaffAttendances",
                c => new
                    {
                        MeetingStaffAttendanceID = c.Int(nullable: false, identity: true),
                        StaffID = c.Int(nullable: false),
                        MeetingID = c.Int(nullable: false),
                        Attendance = c.Boolean(),
                    })
                .PrimaryKey(t => t.MeetingStaffAttendanceID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Location_name = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
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
                "dbo.Enrollments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Parents", "Student_StudentID", c => c.Int());
            AddColumn("dbo.Parents", "Parent_Email", c => c.String());
            AddColumn("dbo.Parents", "Parent_CellPhone", c => c.String());
            AddColumn("dbo.Parents", "Parent_HomeTele", c => c.String());
            AddColumn("dbo.Parents", "Parent_Zip", c => c.String());
            AddColumn("dbo.Parents", "Parent_State", c => c.String());
            AddColumn("dbo.Parents", "Parent_City", c => c.String());
            AddColumn("dbo.Parents", "Parent_Address", c => c.String());
            AddColumn("dbo.Parents", "Parent_LastName", c => c.String());
            AddColumn("dbo.Parents", "Parent_FirstName", c => c.String());
            AddColumn("dbo.Staffs", "Staff_Email", c => c.String());
            AddColumn("dbo.Staffs", "Staff_CellPhone", c => c.String());
            AddColumn("dbo.Staffs", "Staff_HomeTele", c => c.String());
            AddColumn("dbo.Staffs", "Staff_Zip", c => c.String());
            AddColumn("dbo.Staffs", "Staff_State", c => c.String());
            AddColumn("dbo.Staffs", "Staff_City", c => c.String());
            AddColumn("dbo.Staffs", "Staff_Address", c => c.String());
            AddColumn("dbo.Staffs", "Staff_LastName", c => c.String());
            AddColumn("dbo.Staffs", "Staff_FirstName", c => c.String());
            AddColumn("dbo.Meetings", "Location_LocationID", c => c.Int());
            AddColumn("dbo.Meetings", "Location_Name", c => c.String());
            AddColumn("dbo.Meetings", "Meeting_Type", c => c.String());
            AddColumn("dbo.Meetings", "Meeting_End", c => c.DateTime(nullable: false));
            AddColumn("dbo.Meetings", "Meeting_Start", c => c.DateTime(nullable: false));
            AddColumn("dbo.Students", "Parent_ParentID", c => c.Int());
            DropForeignKey("dbo.StudentPrograms", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentPrograms", "ProgramsID", "dbo.Programs");
            DropForeignKey("dbo.StudentAttendances", "StudentID", "dbo.Students");
            DropForeignKey("dbo.StudentAttendances", "MeetingID", "dbo.Meetings");
            DropForeignKey("dbo.Students", "Meeting_MeetingID", "dbo.Meetings");
            DropForeignKey("dbo.Meetings", "ProgramsID", "dbo.Programs");
            DropIndex("dbo.StudentPrograms", new[] { "ProgramsID" });
            DropIndex("dbo.StudentPrograms", new[] { "StudentID" });
            DropIndex("dbo.StudentAttendances", new[] { "MeetingID" });
            DropIndex("dbo.StudentAttendances", new[] { "StudentID" });
            DropIndex("dbo.Students", new[] { "Meeting_MeetingID" });
            DropIndex("dbo.Meetings", new[] { "ProgramsID" });
            DropColumn("dbo.Parents", "EmailAddress");
            DropColumn("dbo.Parents", "PhoneNumber");
            DropColumn("dbo.Parents", "ZipCode");
            DropColumn("dbo.Parents", "State");
            DropColumn("dbo.Parents", "Address");
            DropColumn("dbo.Parents", "LastName");
            DropColumn("dbo.Parents", "FirstName");
            DropColumn("dbo.Staffs", "EmailAddress");
            DropColumn("dbo.Staffs", "PhoneNumber");
            DropColumn("dbo.Staffs", "ZipCode");
            DropColumn("dbo.Staffs", "State");
            DropColumn("dbo.Staffs", "Address");
            DropColumn("dbo.Staffs", "LastName");
            DropColumn("dbo.Staffs", "FirstName");
            DropColumn("dbo.Meetings", "ProgramsID");
            DropColumn("dbo.Meetings", "Minute");
            DropColumn("dbo.Meetings", "Hour");
            DropColumn("dbo.Meetings", "Date");
            DropColumn("dbo.Students", "Meeting_MeetingID");
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Students", "PhoneNumber");
            DropColumn("dbo.Students", "ZipCode");
            DropColumn("dbo.Students", "State");
            DropColumn("dbo.Students", "Address");
            DropTable("dbo.StudentPrograms");
            DropTable("dbo.StudentAttendances");
            DropTable("dbo.Programs");
            CreateIndex("dbo.Parents", "Student_StudentID");
            CreateIndex("dbo.MeetingVolunteerAttendances", "Volunteer_VolunteerID");
            CreateIndex("dbo.MeetingVolunteerAttendances", "MeetingID");
            CreateIndex("dbo.MeetingStudentAttendances", "MeetingID");
            CreateIndex("dbo.MeetingStudentAttendances", "StudentID");
            CreateIndex("dbo.MeetingStaffAttendances", "MeetingID");
            CreateIndex("dbo.MeetingStaffAttendances", "StaffID");
            CreateIndex("dbo.Meetings", "Location_LocationID");
            CreateIndex("dbo.Students", "Parent_ParentID");
            CreateIndex("dbo.Enrollments", "StudentId");
            CreateIndex("dbo.Enrollments", "CourseId");
            AddForeignKey("dbo.Students", "Parent_ParentID", "dbo.Parents", "ParentID");
            AddForeignKey("dbo.Parents", "Student_StudentID", "dbo.Students", "StudentID");
            AddForeignKey("dbo.MeetingVolunteerAttendances", "Volunteer_VolunteerID", "dbo.Volunteers", "VolunteerID");
            AddForeignKey("dbo.MeetingVolunteerAttendances", "MeetingID", "dbo.Meetings", "MeetingID", cascadeDelete: true);
            AddForeignKey("dbo.MeetingStudentAttendances", "StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
            AddForeignKey("dbo.MeetingStudentAttendances", "MeetingID", "dbo.Meetings", "MeetingID", cascadeDelete: true);
            AddForeignKey("dbo.MeetingStaffAttendances", "StaffID", "dbo.Staffs", "StaffID", cascadeDelete: true);
            AddForeignKey("dbo.MeetingStaffAttendances", "MeetingID", "dbo.Meetings", "MeetingID", cascadeDelete: true);
            AddForeignKey("dbo.Meetings", "Location_LocationID", "dbo.Locations", "LocationID");
            AddForeignKey("dbo.Enrollments", "StudentId", "dbo.Students", "StudentID", cascadeDelete: true);
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
