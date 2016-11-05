using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models
{
    public class StudentProgram
    {
        public int StudentProgramID { get; set; }
        public int StudentID { get; set; }
        public int ProgramsID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Programs Programs { get; set; }
    }
}