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
    public class GenderInfoesController : Controller
    {
        private StudentDB db = new StudentDB();

        // GET: GenderInfoes
        public ActionResult Index()
        {
            return View(db.GenderInfoes.ToList());
        }

        // GET: GenderInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderInfo genderInfo = db.GenderInfoes.Find(id);
            if (genderInfo == null)
            {
                return HttpNotFound();
            }
            return View(genderInfo);
        }

        // GET: GenderInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenderInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenderID,Gender")] GenderInfo genderInfo)
        {
            if (ModelState.IsValid)
            {
                db.GenderInfoes.Add(genderInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genderInfo);
        }

        // GET: GenderInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderInfo genderInfo = db.GenderInfoes.Find(id);
            if (genderInfo == null)
            {
                return HttpNotFound();
            }
            return View(genderInfo);
        }

        // POST: GenderInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenderID,Gender")] GenderInfo genderInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genderInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genderInfo);
        }

        // GET: GenderInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenderInfo genderInfo = db.GenderInfoes.Find(id);
            if (genderInfo == null)
            {
                return HttpNotFound();
            }
            return View(genderInfo);
        }

        // POST: GenderInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenderInfo genderInfo = db.GenderInfoes.Find(id);
            db.GenderInfoes.Remove(genderInfo);
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
