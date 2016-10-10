using AdelanteRedo.Models;
using reCAPTCHA.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace AdelanteRedo.Controllers
{
    public class HomeController : Controller
    {
      //  private AdelanteContext db = new AdelanteContext();
        public ActionResult Index()
        {
            return View();

        }
        
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
        [CaptchaValidator(
        PrivateKey = "",
        ErrorMessage = "Invalid input captcha.",
        RequiredMessage = "The captcha field is required.")]
        [HttpPost]
        public ActionResult Index(MailViewModel viewModel)
        {
            //Below is how to set up a contact form for GMAIL ONLY!.

            //If you receive an error on Line smtp.Send(mail) then you might need to log into that Gmail 
            //account you are trying to send the emails from and find the option to "Enable Less Secure Apps"
            //Google is being nice and disabling the Gmail account to be accessed by less secure applications.

            //See the referenced code for explanation of this example.
            //http://www.c-sharpcorner.com/uploadfile/sourabh_mishra1/sending-an-e-mail-using-asp-net-mvc/

            //TODO: Uncomment when pushing to production to enable reCaptcha validation.
            //if (ModelState.IsValid)
            //{
                MailMessage mail = new MailMessage();
                mail.To.Add("adelantehispanic@gmail.com");
                mail.From = new MailAddress(viewModel.Email);
                mail.Subject = "Contact Form Submission";
                string Body = viewModel.Message;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("adelantehispanic@gmail.com", "Adelante");// Enter senders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("Index");
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }
       
    }
}