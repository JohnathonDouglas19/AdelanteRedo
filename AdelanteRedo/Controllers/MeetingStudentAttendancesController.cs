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
    public class MeetingStudentAttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MeetingStudentAttendances
        public ActionResult Index()
        {
            var meetingStudentAttendance = db.MeetingStudentAttendance.Include(m => m.Meeting).Include(m => m.Student);
            return View(meetingStudentAttendance.ToList());
        }

        // GET: MeetingStudentAttendances/Details/5
        public ActionResult Details(int? id)
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

        // GET: MeetingStudentAttendances/Create
        public ActionResult Create()
        {
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName");
            return View();
        }

        // POST: MeetingStudentAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeetingStudentAttendanceID,StudentID,MeetingID,Attendance")] MeetingStudentAttendance meetingStudentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.MeetingStudentAttendance.Add(meetingStudentAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingStudentAttendance.MeetingID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", meetingStudentAttendance.StudentID);
            return View(meetingStudentAttendance);
        }

        // GET: MeetingStudentAttendances/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", meetingStudentAttendance.StudentID);
            return View(meetingStudentAttendance);
        }

        // POST: MeetingStudentAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeetingStudentAttendanceID,StudentID,MeetingID,Attendance")] MeetingStudentAttendance meetingStudentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meetingStudentAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "Meeting_Type", meetingStudentAttendance.MeetingID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "LastName", meetingStudentAttendance.StudentID);
            return View(meetingStudentAttendance);
        }

        // GET: MeetingStudentAttendances/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: MeetingStudentAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
