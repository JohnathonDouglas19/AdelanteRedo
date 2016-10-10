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
    public class MeetingStaffAttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MeetingStaffAttendances
        public ActionResult Index()
        {
            var meetingStaffAttendance = db.MeetingStaffAttendance.Include(m => m.Meeting).Include(m => m.Staff);
            return View(meetingStaffAttendance.ToList());
        }

        // GET: MeetingStaffAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingStaffAttendance meetingStaffAttendance = db.MeetingStaffAttendance.Find(id);
            if (meetingStaffAttendance == null)
            {
                return HttpNotFound();
            }
            return View(meetingStaffAttendance);
        }

        // GET: MeetingStaffAttendances/Create
        public ActionResult Create()
        {
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type");
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "Staff_FirstName");
            return View();
        }

        // POST: MeetingStaffAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeetingStaffAttendanceID,StaffID,MeetingID,Attendance")] MeetingStaffAttendance meetingStaffAttendance)
        {
            if (ModelState.IsValid)
            {
                db.MeetingStaffAttendance.Add(meetingStaffAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingStaffAttendance.MeetingID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "Staff_FirstName", meetingStaffAttendance.StaffID);
            return View(meetingStaffAttendance);
        }

        // GET: MeetingStaffAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingStaffAttendance meetingStaffAttendance = db.MeetingStaffAttendance.Find(id);
            if (meetingStaffAttendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingStaffAttendance.MeetingID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "Staff_FirstName", meetingStaffAttendance.StaffID);
            return View(meetingStaffAttendance);
        }

        // POST: MeetingStaffAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeetingStaffAttendanceID,StaffID,MeetingID,Attendance")] MeetingStaffAttendance meetingStaffAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingStaffAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingStaffAttendance.MeetingID);
            ViewBag.StaffID = new SelectList(db.Staffs, "StaffID", "Staff_FirstName", meetingStaffAttendance.StaffID);
            return View(meetingStaffAttendance);
        }

        // GET: MeetingStaffAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingStaffAttendance meetingStaffAttendance = db.MeetingStaffAttendance.Find(id);
            if (meetingStaffAttendance == null)
            {
                return HttpNotFound();
            }
            return View(meetingStaffAttendance);
        }

        // POST: MeetingStaffAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeetingStaffAttendance meetingStaffAttendance = db.MeetingStaffAttendance.Find(id);
            db.MeetingStaffAttendance.Remove(meetingStaffAttendance);
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
