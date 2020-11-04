using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentRecordApp;

namespace StudentRecordApp.Controllers
{
    public class SutdentTablesController : Controller
    {
        private StudentDB db = new StudentDB();

        // GET: SutdentTables
        public ActionResult Index()
        {
            var sutdentTables = db.SutdentTables.Include(s => s.City).Include(s => s.Class).Include(s => s.GenderInfo).Include(s => s.Univerisite);
            return View(sutdentTables.ToList());
        }

        // GET: SutdentTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SutdentTable sutdentTable = db.SutdentTables.Find(id);
            if (sutdentTable == null)
            {
                return HttpNotFound();
            }
            return View(sutdentTable);
        }

        // GET: SutdentTables/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.CitiesTbls, "CityID", "City");
            ViewBag.ClassID = new SelectList(db.ClassesTbls, "ClassID", "Class");
            ViewBag.GenderID = new SelectList(db.GenderInfoes, "GenderID", "Gender");
            ViewBag.UniID = new SelectList(db.Univerisites, "UniID", "University");
            return View();
        }

        // POST: SutdentTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Firstname,Lastname,DateOfBirth,GenderID,ClassID,UniID,CityID")] SutdentTable sutdentTable)
        {
            if (ModelState.IsValid)
            {
                db.SutdentTables.Add(sutdentTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.CitiesTbls, "CityID", "City", sutdentTable.CityID);
            ViewBag.ClassID = new SelectList(db.ClassesTbls, "ClassID", "Class", sutdentTable.ClassID);
            ViewBag.GenderID = new SelectList(db.GenderInfoes, "GenderID", "Gender", sutdentTable.GenderID);
            ViewBag.UniID = new SelectList(db.Univerisites, "UniID", "University", sutdentTable.UniID);
            return View(sutdentTable);
        }

        // GET: SutdentTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SutdentTable sutdentTable = db.SutdentTables.Find(id);
            if (sutdentTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.CitiesTbls, "CityID", "City", sutdentTable.CityID);
            ViewBag.ClassID = new SelectList(db.ClassesTbls, "ClassID", "Class", sutdentTable.ClassID);
            ViewBag.GenderID = new SelectList(db.GenderInfoes, "GenderID", "Gender", sutdentTable.GenderID);
            ViewBag.UniID = new SelectList(db.Univerisites, "UniID", "University", sutdentTable.UniID);
            return View(sutdentTable);
        }

        // POST: SutdentTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Firstname,Lastname,DateOfBirth,GenderID,ClassID,UniID,CityID")] SutdentTable sutdentTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sutdentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.CitiesTbls, "CityID", "City", sutdentTable.CityID);
            ViewBag.ClassID = new SelectList(db.ClassesTbls, "ClassID", "Class", sutdentTable.ClassID);
            ViewBag.GenderID = new SelectList(db.GenderInfoes, "GenderID", "Gender", sutdentTable.GenderID);
            ViewBag.UniID = new SelectList(db.Univerisites, "UniID", "University", sutdentTable.UniID);
            return View(sutdentTable);
        }

        // GET: SutdentTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SutdentTable sutdentTable = db.SutdentTables.Find(id);
            if (sutdentTable == null)
            {
                return HttpNotFound();
            }
            return View(sutdentTable);
        }

        // POST: SutdentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SutdentTable sutdentTable = db.SutdentTables.Find(id);
            db.SutdentTables.Remove(sutdentTable);
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
