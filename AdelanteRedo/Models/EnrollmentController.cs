using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdelanteRedo.Models
{
    public class EnrollmentController : Controller
    {
        public class Enrollment
        {
            public int Id { get; set; }
            public int CourseId { get; set; }
            public int StudentId { get; set; }
            public Grade Grade { get; set; }

            public virtual CourseController Course { get; set; }
            public virtual StudentController Student { get; set; }

        }

        public enum Grade
        {
            A, B, C, D, F
        }
        // GET: Enrollment
        public ActionResult Index()
        {
            return View();
        }
    }
}