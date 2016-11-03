using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        internal static List<Student> GetUsers()
        {
            throw new NotImplementedException();
        }

        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

    }
}