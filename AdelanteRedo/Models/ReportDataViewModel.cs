using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models
{
    public class ReportDataViewModel
    {
        public ICollection<Student> StudentsAttendedList { get; set; }
        public int PercentageAttended { get; set; }
    }
}