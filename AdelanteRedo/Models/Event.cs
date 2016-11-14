using System;
using System.ComponentModel.DataAnnotations;

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