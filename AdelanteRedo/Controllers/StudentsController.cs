using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLib;
using AdelanteRedo.Models;

namespace AdelanteRedo.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.ToList();
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.Parent_NUM = new SelectList(db.Set<Parent>(), "Parent_NUM", "Parent_FirstName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_NUM,Student_FirstName,Student_LastName,Student_MInitial,Student_Gender,Student_Address,Student_City,Student_State,Student_Zip,Student_HomeTele,Student_CellPhone,Student_Email,Student_Picture_path,Student_PimaryLang,Student_SecondLang,Parent_NUM,STARTDATE,ENDDATE")] Models.Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.Parent_NUM = new SelectList(db.Set<Parent>(), "Parent_NUM", "Parent_FirstName", student.Parent_NUM);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Student student = db.Set<Models.Student>().Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            //TODO: Update
            //ViewBag.Parent_NUM = new SelectList(db.Set<Parent>(), "Parent_NUM", "Parent_FirstName", student.Parent_NUM);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_NUM,Student_FirstName,Student_LastName,Student_MInitial,Student_Gender,Student_Address,Student_City,Student_State,Student_Zip,Student_HomeTele,Student_CellPhone,Student_Email,Student_Picture_path,Student_PimaryLang,Student_SecondLang,Parent_NUM,STARTDATE,ENDDATE")] Models.Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           // ViewBag.Parent_NUM = new SelectList(db.Set<Parent>(), "Parent_NUM", "Parent_FirstName", student.Parent_NUM);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Models.Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
