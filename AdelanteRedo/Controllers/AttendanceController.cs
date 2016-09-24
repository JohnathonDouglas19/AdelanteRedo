using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLib;

namespace AdelanteRedo.Controllers
{
    public class AttendanceController : Controller
    {
        private goyals420_troutEntities db = new goyals420_troutEntities();

        // GET: Attendance
        public ActionResult Index()
        {
            var meetingStudentAttendances = db.MeetingStudentAttendances.Include(m => m.Meeting).Include(m => m.Student);
            return View(meetingStudentAttendances.ToList());
        }

        // GET: Attendance/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingStudentAttendance meetingStudentAttendance = db.MeetingStudentAttendances.Find(id);
            if (meetingStudentAttendance == null)
            {
                return HttpNotFound();
            }
            return View(meetingStudentAttendance);
        }

        // GET: Attendance/Create
        public ActionResult Create()
        {
            ViewBag.Meeting_NUM = new SelectList(db.Meetings, "Meeting_NUM", "Meeting_Type");
            ViewBag.Student_NUM = new SelectList(db.Students, "Student_NUM", "Student_FirstName");
            return View();
        }

        // POST: Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_NUM,Meeting_NUM,Attendance")] MeetingStudentAttendance meetingStudentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.MeetingStudentAttendances.Add(meetingStudentAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Meeting_NUM = new SelectList(db.Meetings, "Meeting_NUM", "Meeting_Type", meetingStudentAttendance.Meeting_NUM);
            ViewBag.Student_NUM = new SelectList(db.Students, "Student_NUM", "Student_FirstName", meetingStudentAttendance.Student_NUM);
            return View(meetingStudentAttendance);
        }

        // GET: Attendance/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingStudentAttendance meetingStudentAttendance = db.MeetingStudentAttendances.Find(id);
            if (meetingStudentAttendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Meeting_NUM = new SelectList(db.Meetings, "Meeting_NUM", "Meeting_Type", meetingStudentAttendance.Meeting_NUM);
            ViewBag.Student_NUM = new SelectList(db.Students, "Student_NUM", "Student_FirstName", meetingStudentAttendance.Student_NUM);
            return View(meetingStudentAttendance);
        }

        // POST: Attendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_NUM,Meeting_NUM,Attendance")] MeetingStudentAttendance meetingStudentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingStudentAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Meeting_NUM = new SelectList(db.Meetings, "Meeting_NUM", "Meeting_Type", meetingStudentAttendance.Meeting_NUM);
            ViewBag.Student_NUM = new SelectList(db.Students, "Student_NUM", "Student_FirstName", meetingStudentAttendance.Student_NUM);
            return View(meetingStudentAttendance);
        }

        // GET: Attendance/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeetingStudentAttendance meetingStudentAttendance = db.MeetingStudentAttendances.Find(id);
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
            MeetingStudentAttendance meetingStudentAttendance = db.MeetingStudentAttendances.Find(id);
            db.MeetingStudentAttendances.Remove(meetingStudentAttendance);
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
