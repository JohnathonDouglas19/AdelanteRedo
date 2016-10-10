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
    public class AttendanceController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attendance
        public ActionResult Index()
        {
            var meetingStudentAttendance = db.MeetingStudentAttendance.Include(m => m.Meeting).Include(m => m.Student);
            return View(meetingStudentAttendance.ToList());
        }

        // GET: Attendance/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingStudentAttendance meetingStudentAttendance = db.MeetingStudentAttendance.Find(id);
            if (meetingStudentAttendance == null)
            {
                return HttpNotFound();
            }
            return View(meetingStudentAttendance);
        }

        // GET: Attendance/Create
        public ActionResult Create()
        {
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Student_FirstName");
            return View();
        }

        // POST: Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,MeetingID,Attendance")] MeetingStudentAttendance meetingStudentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.MeetingStudentAttendance.Add(meetingStudentAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingStudentAttendance.MeetingID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Student_FirstName", meetingStudentAttendance.StudentID);
            return View(meetingStudentAttendance);
        }

        // GET: Attendance/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingStudentAttendance meetingStudentAttendance = db.MeetingStudentAttendance.Find(id);
            if (meetingStudentAttendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingStudentAttendance.MeetingID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Student_FirstName", meetingStudentAttendance.StudentID);
            return View(meetingStudentAttendance);
        }

        // POST: Attendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,MeetingID,Attendance")] MeetingStudentAttendance meetingStudentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingStudentAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingStudentAttendance.MeetingID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "Student_FirstName", meetingStudentAttendance.StudentID);
            return View(meetingStudentAttendance);
        }

        // GET: Attendance/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingStudentAttendance meetingStudentAttendance = db.MeetingStudentAttendance.Find(id);
            if (meetingStudentAttendance == null)
            {
                return HttpNotFound();
            }
            return View(meetingStudentAttendance);
        }

        // POST: Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MeetingStudentAttendance meetingStudentAttendance = db.MeetingStudentAttendance.Find(id);
            db.MeetingStudentAttendance.Remove(meetingStudentAttendance);
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
