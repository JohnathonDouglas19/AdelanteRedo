using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models
{
    public class File
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public int VersionNumber { get; set; }
    }
}