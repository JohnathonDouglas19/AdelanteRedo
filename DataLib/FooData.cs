using DataLib;
using System.Collections.Generic;
using System.Linq;

namespace FoosGold
{
    public class FooData
    {
        public List<Foo> GetAllFoos() //Creating a list to grab data from DB
        {
            using (goyals420_troutEntities context = new goyals420_troutEntities()) //Using will close out the connection to the DB once complete
            {
                List<Foo> results = context.Foos.ToList(); //Grabs the data from the table and throws the info into results
                return results;
            }
        }
    }
}
