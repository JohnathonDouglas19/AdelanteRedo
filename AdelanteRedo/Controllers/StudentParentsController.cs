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
    public class StudentParentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentParents
        public ActionResult Index()
        {
            var studentParent = db.StudentParent.Include(s => s.Parent).Include(s => s.Student);
            return View(studentParent.ToList());
        }

        // GET: StudentParents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentParent studentParent = db.StudentParent.Find(id);
            if (studentParent == null)
            {
                return HttpNotFound();
            }
            return View(studentParent);
        }

        // GET: StudentParents/Create
        public ActionResult Create()
        {
            ViewBag.ParentID = new SelectList(db.Parent, "ParentID", "Parent_FirstName");
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "LastName");
            return View();
        }

        // POST: StudentParents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentParentID,StudentID,ParentID")] StudentParent studentParent)
        {
            if (ModelState.IsValid)
            {
                db.StudentParent.Add(studentParent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentID = new SelectList(db.Parent, "ParentID", "Parent_FirstName", studentParent.ParentID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "LastName", studentParent.StudentID);
            return View(studentParent);
        }

        // GET: StudentParents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentParent studentParent = db.StudentParent.Find(id);
            if (studentParent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentID = new SelectList(db.Parent, "ParentID", "Parent_FirstName", studentParent.ParentID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "LastName", studentParent.StudentID);
            return View(studentParent);
        }

        // POST: StudentParents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentParentID,StudentID,ParentID")] StudentParent studentParent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentParent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentID = new SelectList(db.Parent, "ParentID", "Parent_FirstName", studentParent.ParentID);
            ViewBag.StudentID = new SelectList(db.Student, "StudentID", "LastName", studentParent.StudentID);
            return View(studentParent);
        }

        // GET: StudentParents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentParent studentParent = db.StudentParent.Find(id);
            if (studentParent == null)
            {
                return HttpNotFound();
            }
            return View(studentParent);
        }

        // POST: StudentParents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentParent studentParent = db.StudentParent.Find(id);
            db.StudentParent.Remove(studentParent);
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
