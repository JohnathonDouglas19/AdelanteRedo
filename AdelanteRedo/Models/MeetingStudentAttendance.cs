//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public partial class MeetingStudentAttendance
    {
        public int MeetingStudentAttendanceID { get; set; }
        public int StudentID { get; set; }
        public int MeetingID { get; set; }
        public Nullable<bool> Attendance { get; set; }
    
        public virtual Meeting Meeting { get; set; }
        public virtual Student Student { get; set; }
    }
}
