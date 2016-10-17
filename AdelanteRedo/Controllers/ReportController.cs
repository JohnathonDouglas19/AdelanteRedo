using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdelanteRedo.Controllers
{
    public class ReportController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            // this method should returns list of students
            List<Models.Student> objList = Models.Student.GetUsers();
            return View("users", objList);
        }
    }
}