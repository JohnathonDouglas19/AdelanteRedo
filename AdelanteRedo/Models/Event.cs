using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models
{
    public class Event
    {
        [Required]
        public int id { get; set; }

        public string text { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }
    }
}