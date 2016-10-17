using System;
using System.Linq;
using System.Web.Mvc;
using AdelanteRedo.Models;
using DHTMLX.Common;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;

namespace AdelanteRedo.Controllers
{
    public class EventController : Controller
    {
        //Refer to this link in order to set up the Calendar.
        //http://scheduler-net.com/docs/simple-.net-mvc-application-with-scheduler.html#step_2_add_the_scheduler_reference

        public readonly ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this); //initializes dhtmlxScheduler
            scheduler.LoadData = true;// allows loading data
            scheduler.EnableDataprocessor = true;// enables DataProcessor in order to enable implementation CRUD operations
            return View(scheduler);
        }

        public ActionResult Data()
        {
            //events for loading to scheduler
            return new SchedulerAjaxData(_db.Events);
        }

        public ActionResult Save(Event updatedEvent, FormCollection formData)
        {
            var action = new DataAction(formData);

            try
            {
                switch (action.Type)
                {
                    case DataActionTypes.Insert: // your Insert logic
                        _db.Events.Add(updatedEvent);
                        break;
                    case DataActionTypes.Delete: // your Delete logic
                        updatedEvent = _db.Events.SingleOrDefault(ev => ev.id == updatedEvent.id);
                        _db.Events.Remove(updatedEvent);
                        break;
                    default:// "update" // your Update logic
                        updatedEvent = _db.Events.SingleOrDefault(
                        ev => ev.id == updatedEvent.id);
                        UpdateModel(updatedEvent);
                        break;
                }
                _db.SaveChanges();
                action.TargetId = updatedEvent.id;
            }
            catch (Exception e)
            {
                action.Type = DataActionTypes.Error;
            }
            return (new AjaxSaveResponse(action));
        }
    }
}