using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models
{
    public class StudentAttendance
    {
        public int StudentAttendanceID { get; set; }
        public int StudentID { get; set; }
        public int MeetingID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Meeting Meeting { get; set; }
        public bool Attended { get; set; }
    }
}