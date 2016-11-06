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
    public class StudentAttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentAttendances
        public ActionResult Index()
        {
            var studentAttendances = db.StudentAttendance.Include(s => s.Meeting).Include(s => s.Student);
            return View(studentAttendances.ToList());
        }

        // GET: StudentAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendance studentAttendance = db.StudentAttendance.Find(id);
            if (studentAttendance == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendance);
        }

        // GET: StudentAttendances/Create
        public ActionResult Create()
        {
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "MeetingID");
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "FirstName");
            return View();
        }

        // POST: StudentAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentAttendanceID,StudentID,MeetingID,Attended")] StudentAttendance studentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.StudentAttendance.Add(studentAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "MeetingID", studentAttendance.MeetingID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "FirstName", studentAttendance.StudentID);
            return View(studentAttendance);
        }

        // GET: StudentAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendance studentAttendance = db.StudentAttendance.Find(id);
            if (studentAttendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "MeetingID", studentAttendance.MeetingID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "FirstName", studentAttendance.StudentID);
            return View(studentAttendance);
        }

        // POST: StudentAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentAttendanceID,StudentID,MeetingID,Attended")] StudentAttendance studentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetingID = new SelectList(db.Meeting, "MeetingID", "MeetingID", studentAttendance.MeetingID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "FirstName", studentAttendance.StudentID);
            return View(studentAttendance);
        }

        // GET: StudentAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendance studentAttendance = db.StudentAttendance.Find(id);
            if (studentAttendance == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendance);
        }

        // POST: StudentAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAttendance studentAttendance = db.StudentAttendance.Find(id);
            db.StudentAttendance.Remove(studentAttendance);
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
