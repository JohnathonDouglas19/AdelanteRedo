using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace AdelanteRedo.Models
{
    public class AdelanteContext : DbContext
    {
        public AdelanteContext()
                        : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<AdelanteRedo.Models.StudentAttendance> StudentAttendances { get; set; }

        public System.Data.Entity.DbSet<AdelanteRedo.Models.Meeting> Meetings { get; set; }

        public System.Data.Entity.DbSet<AdelanteRedo.Models.Student> Students { get; set; }
    }
}