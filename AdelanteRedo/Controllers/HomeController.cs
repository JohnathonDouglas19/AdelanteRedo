using AdelanteRedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoosGold;

namespace AdelanteRedo.Controllers
{
    public class HomeController : Controller
    {
      //  private AdelanteContext db = new AdelanteContext();
        public ActionResult Index()
        {
            // This is an example of manipuating data with Entity Framework.
            // Create a bar object. Add the bar object to a list of bars. 
            // Create a foo object that has that list of bars.
            // Add the foo to the Foos on the database.
            // Add the bar to the Bars on the database.
            // Save changes on the database. 

            //var bar = new Bar { Name = "testing"};
            //var barsList = new List<Bar>();
            //barsList.Add(bar);
            //var foo = new Foo { FooName = "testing", Bars = barsList };

            //db.Foos.Add(foo);
            //db.Bars.Add(bar);
            //db.SaveChanges();

            FooData fooData = new FooData(); //creating an instance of foodata

            List<DataLib.Foo> results = fooData.GetAllFoos(); //calls the method from foodata
            ViewBag.foosball = results; //pushes results from method into the view bag

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "“In Adelante everyone has a dream, everyone speaks the same language, and everyone is FAMILY” - Sabrina Lloret";

            return View();
        }

        public ActionResult Programs()
        {
            ViewBag.Message = "Your programs page.";

            return View();
        }

        public ActionResult Donate()
        {
            ViewBag.Message = "Your donate page.";

            return View();
        }

        public ActionResult Students()
        {
            ViewBag.Message = "Your students page.";

            return View();
        }

        public ActionResult Parents()
        {
            ViewBag.Message = "Your parents page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We’d love to hear from you!";

            return View();
        }

       
    }
}