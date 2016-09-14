using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models
{
    public class Bar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BarID { get; set; }
        public string Name { get; set; }

        public int FooId { get; set; }
        public virtual Foo Foo { get; set; }

    }
}