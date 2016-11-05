using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models
{
    public class Programs
    {
        public int ProgramsID { get; set; }
        [Display(Name = "Program Name")]
        public string ProgramName { get; set; }
        [Display(Name = "Day Of The Week")]
        public string DayofTheWeek { get; set; }
        public virtual List<Meeting> Meeting { get; set; }

    }
}