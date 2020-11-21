using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentCRUD;
using StudentCRUD.Models;

namespace StudentCRUD.Controllers
{
    public class StudentsController : Controller
    {
        private CRUD_OperationsEntities db = new CRUD_OperationsEntities();

        // GET: Students
        public ActionResult Index()
        {
            List<myStudents> myStudentsList = new List<myStudents>();
            var students = db.Students.Include(s => s.ClassInfo);
            foreach (var student in students)
            {
                myClassInfo myClassInfo = new myClassInfo()
                {
                    Class_Id = student.ClassInfo.Class_Id,
                    EndDate = student.ClassInfo.EndDate,
                    Standard = student.ClassInfo.Standard,
                    StartDate = student.ClassInfo.StartDate
                };

                myStudents myStudent = new myStudents()
                {
                    Student_Id = student.Student_Id,
                    Name = student.Name,
                    Address = student.Address,
                    ClassInfo = myClassInfo,
                    Class_Id = myClassInfo.Class_Id,

                };
                myStudentsList.Add(myStudent);
            }
            return View(myStudentsList.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            ViewBag.Class_Id = new SelectList(db.ClassInfoes, "Class_Id", "Standard");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_Id,Name,Address,Class_Id")] myStudents student)
        {
            if (ModelState.IsValid)
            {

                Student myStudent = new Student()
                {
                    Name = student.Name,
                    Address = student.Address,
                    Class_Id = student.Class_Id
                };

                db.Students.Add(myStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Class_Id = new SelectList(db.ClassInfoes, "Class_Id", "Standard", student.Class_Id);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

           
            myStudents myStudent = new myStudents()
            {
                Student_Id = student.Student_Id,
                Name = student.Name,
                Address = student.Address,
                Class_Id = student.Class_Id,

            };

            ViewBag.Class_Id = new SelectList(db.ClassInfoes, "Class_Id", "Standard", student.Class_Id);
            return View(myStudent);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_Id,Name,Address,Class_Id")] myStudents student)
        {
            if (ModelState.IsValid)
            {


                Student myStudent = new Student()
                {
                    Student_Id = student.Student_Id,
                    Name = student.Name,
                    Address = student.Address,
                    Class_Id = student.Class_Id

                };

                db.Entry(myStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Class_Id = new SelectList(db.ClassInfoes, "Class_Id", "Standard", student.Class_Id);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
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
