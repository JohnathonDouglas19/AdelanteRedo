using AdelanteRedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdelanteRedo.Controllers
{
    public class ReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            var data = new ReportDataViewModel
            {
                StudentsAttendedList = GetStudentsThatAttended(DateTime.Today),
                PercentageAttended = GetPercentOfStudentsThatAttended(DateTime.Today)
            };
            return View(data);
        }


        [HttpPost]
        public ActionResult Index(DateTime startDate)
        {
            var data = new ReportDataViewModel {
                StudentsAttendedList = GetStudentsThatAttended(startDate),
                PercentageAttended = GetPercentOfStudentsThatAttended(startDate)

            };
            return View(data);

        }

        public ICollection<Student> GetStudentsThatAttended(DateTime startDate)
        {
            var studentList = db.MeetingStudentAttendance.Where(sa => sa.Meeting.Meeting_Start.Date == startDate);

            //return studentList as ICollection<Student>;
            return db.Students.ToList();

        }

        public int GetPercentOfStudentsThatAttended(DateTime startDate)
        {
            var numberOfAttended = db.MeetingStudentAttendance.Where(sa => sa.Attendance.Value == true && sa.Meeting.Meeting_Start == startDate).Count();
            var totalOfStudentsForThisMeeting = db.MeetingStudentAttendance.Count();

            //return numberOfAttended / totalOfStudentsForThisMeeting;
            return 10;
        }
    }
}