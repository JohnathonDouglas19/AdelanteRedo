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
        public ActionResult Index(DateTime Date)
        {
            var data = new ReportDataViewModel {
                StudentsAttendedList = GetStudentsThatAttended(Date),
                PercentageAttended = GetPercentOfStudentsThatAttended(Date)

            };
            return View(data);

        }

        public List<Student> GetStudentsThatAttended(DateTime Date)
        {
            var studentAttendanceList = db.StudentAttendance.Where(sa => sa.Meeting.Date == Date);
            var studentList = new List<Student>();

            foreach(var studentAttendance in studentAttendanceList)
            {
                var student = db.Student.Find(studentAttendance.StudentID);
                studentList.Add(student);
            }


            //return studentList as ICollection<Student>;
            return studentList.ToList();

        }

        public int GetPercentOfStudentsThatAttended(DateTime Date)
        {
            var numberOfAttended = db.StudentAttendance.Where(sa => sa.Attended == true && sa.Meeting.Date == Date).Count();
            var totalOfStudentsForThisMeeting = db.StudentAttendance.Count();

            //return numberOfAttended / totalOfStudentsForThisMeeting;
            return 10;
        }
        public List<DateTime> GetMeeting()
        {
            var Meetings = db.Meeting;
            var Dates = new List<DateTime>();
            foreach (var Meeting in Meetings)
            {
                Dates.Add(Meeting.Date);
            }
            return Dates;
        }
    }
}