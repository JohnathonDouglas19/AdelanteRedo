//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.MeetingStudentAttendances = new HashSet<MeetingStudentAttendance>();
        }
    
        public string Student_NUM { get; set; }
        public string Student_FirstName { get; set; }
        public string Student_LastName { get; set; }
        public string Student_MInitial { get; set; }
        public string Student_Gender { get; set; }
        public string Student_Address { get; set; }
        public string Student_City { get; set; }
        public string Student_State { get; set; }
        public string Student_Zip { get; set; }
        public string Student_HomeTele { get; set; }
        public string Student_CellPhone { get; set; }
        public string Student_Email { get; set; }
        public string Student_Picture_path { get; set; }
        public string Student_PimaryLang { get; set; }
        public string Student_SecondLang { get; set; }
        public string Parent_NUM { get; set; }
        public Nullable<System.DateTime> STARTDATE { get; set; }
        public Nullable<System.DateTime> ENDDATE { get; set; }
    
        public virtual Parent Parent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MeetingStudentAttendance> MeetingStudentAttendances { get; set; }
    }
}