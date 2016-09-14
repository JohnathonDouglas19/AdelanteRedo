using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdelanteRedo.Models
{
    public class StudentController : Controller
    {
        public class Student
        {
            public int Id { get; set; }

            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Display(Name = "Enrollment Date")]
            public DateTime EnrollmentDate { get; set; }

            public virtual ICollection<Enrollment> Enrollments { get; set; }

        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
    }
}