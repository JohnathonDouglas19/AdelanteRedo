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
    public class StudentProgramsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentPrograms
        public ActionResult Index()
        {
            var studentProgram = db.StudentProgram.Include(s => s.Programs).Include(s => s.Student);
            return View(studentProgram.ToList());
        }

        // GET: StudentPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentProgram studentProgram = db.StudentProgram.Find(id);
            if (studentProgram == null)
            {
                return HttpNotFound();
            }
            return View(studentProgram);
        }

        // GET: StudentPrograms/Create
        public ActionResult Create()
        {
            ViewBag.ProgramsID = new SelectList(db.Programs, "ProgramsID", "ProgramName");
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "FirstName");
            return View();
        }

        // POST: StudentPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentProgramID,StudentID,ProgramsID")] StudentProgram studentProgram)
        {
            if (ModelState.IsValid)
            {
                db.StudentProgram.Add(studentProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProgramsID = new SelectList(db.Programs, "ProgramsID", "ProgramName", studentProgram.ProgramsID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "FirstName", studentProgram.StudentID);
            return View(studentProgram);
        }

        // GET: StudentPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentProgram studentProgram = db.StudentProgram.Find(id);
            if (studentProgram == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramsID = new SelectList(db.Programs, "ProgramsID", "ProgramName", studentProgram.ProgramsID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "FirstName", studentProgram.StudentID);
            return View(studentProgram);
        }

        // POST: StudentPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentProgramID,StudentID,ProgramsID")] StudentProgram studentProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProgramsID = new SelectList(db.Programs, "ProgramsID", "ProgramName", studentProgram.ProgramsID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "FirstName", studentProgram.StudentID);
            return View(studentProgram);
        }

        // GET: StudentPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentProgram studentProgram = db.StudentProgram.Find(id);
            if (studentProgram == null)
            {
                return HttpNotFound();
            }
            return View(studentProgram);
        }

        // POST: StudentPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentProgram studentProgram = db.StudentProgram.Find(id);
            db.StudentProgram.Remove(studentProgram);
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
