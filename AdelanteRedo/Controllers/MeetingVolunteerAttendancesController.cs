using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdelanteRedo.Models;

namespace AdelanteRedo.Controllers
{
    public class MeetingVolunteerAttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MeetingVolunteerAttendances
        public ActionResult Index()
        {
            var meetingVolunteerAttendance = db.MeetingVolunteerAttendance.Include(m => m.Meeting);
            return View(meetingVolunteerAttendance.ToList());
        }

        // GET: MeetingVolunteerAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingVolunteerAttendance meetingVolunteerAttendance = db.MeetingVolunteerAttendance.Find(id);
            if (meetingVolunteerAttendance == null)
            {
                return HttpNotFound();
            }
            return View(meetingVolunteerAttendance);
        }

        // GET: MeetingVolunteerAttendances/Create
        public ActionResult Create()
        {
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type");
            return View();
        }

        // POST: MeetingVolunteerAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeetingVolunteerAttendanceID,VolunteerID,MeetingID,Attendance")] MeetingVolunteerAttendance meetingVolunteerAttendance)
        {
            if (ModelState.IsValid)
            {
                db.MeetingVolunteerAttendance.Add(meetingVolunteerAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingVolunteerAttendance.MeetingID);
            return View(meetingVolunteerAttendance);
        }

        // GET: MeetingVolunteerAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingVolunteerAttendance meetingVolunteerAttendance = db.MeetingVolunteerAttendance.Find(id);
            if (meetingVolunteerAttendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingVolunteerAttendance.MeetingID);
            return View(meetingVolunteerAttendance);
        }

        // POST: MeetingVolunteerAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeetingVolunteerAttendanceID,VolunteerID,MeetingID,Attendance")] MeetingVolunteerAttendance meetingVolunteerAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingVolunteerAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingVolunteerAttendance.MeetingID);
            return View(meetingVolunteerAttendance);
        }

        // GET: MeetingVolunteerAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingVolunteerAttendance meetingVolunteerAttendance = db.MeetingVolunteerAttendance.Find(id);
            if (meetingVolunteerAttendance == null)
            {
                return HttpNotFound();
            }
            return View(meetingVolunteerAttendance);
        }

        // POST: MeetingVolunteerAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingVolunteerAttendance meetingVolunteerAttendance = db.MeetingVolunteerAttendance.Find(id);
            db.MeetingVolunteerAttendance.Remove(meetingVolunteerAttendance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
