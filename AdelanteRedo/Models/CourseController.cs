using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdelanteRedo.Models
{
    public class CourseController : Controller
    {
        public class Course
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Credits { get; set; }

            public virtual ICollection<EnrollmentController> Enrollments { get; set; }
        }

        // GET: Course
        public ActionResult Index()
        {
            return View();
        }
    }
}