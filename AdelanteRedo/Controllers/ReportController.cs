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
            var studentList = db.StudentAttendance.Where(sa => sa.Meeting.Date.Date == startDate);

            //return studentList as ICollection<Student>;
            return db.Student.ToList();

        }

        public int GetPercentOfStudentsThatAttended(DateTime startDate)
        {
            var numberOfAttended = db.StudentAttendance.Where(sa => sa.Attended == true && sa.Meeting.Date.Date == startDate).Count();
            var totalOfStudentsForThisMeeting = db.StudentAttendance.Count();

            //return numberOfAttended / totalOfStudentsForThisMeeting;
            return 10;
        }
    }
}