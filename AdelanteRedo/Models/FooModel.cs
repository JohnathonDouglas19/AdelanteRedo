using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AdelanteRedo.Models
{
    public class Foo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FooId { get; set; }
        public string FooName { get; set; }

        public virtual List<Bar> Bars { get; set; }
    }
}