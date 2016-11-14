using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int ProgramsID { get; set; }
        public DateTime StartDate { get; set; }
        public virtual Programs Programs { get; set; }
        public virtual List<Student> Student { get; set; }
    }
}