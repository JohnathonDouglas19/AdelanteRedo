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
    }
}