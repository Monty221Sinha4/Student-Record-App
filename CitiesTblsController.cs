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
    public class CitiesTblsController : Controller
    {
        private StudentDB db = new StudentDB();

        // GET: CitiesTbls
        public ActionResult Index()
        {
            return View(db.CitiesTbls.ToList());
        }

        // GET: CitiesTbls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitiesTbl citiesTbl = db.CitiesTbls.Find(id);
            if (citiesTbl == null)
            {
                return HttpNotFound();
            }
            return View(citiesTbl);
        }

        // GET: CitiesTbls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CitiesTbls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityID,City")] CitiesTbl citiesTbl)
        {
            if (ModelState.IsValid)
            {
                db.CitiesTbls.Add(citiesTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(citiesTbl);
        }

        // GET: CitiesTbls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitiesTbl citiesTbl = db.CitiesTbls.Find(id);
            if (citiesTbl == null)
            {
                return HttpNotFound();
            }
            return View(citiesTbl);
        }

        // POST: CitiesTbls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityID,City")] CitiesTbl citiesTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citiesTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citiesTbl);
        }

        // GET: CitiesTbls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitiesTbl citiesTbl = db.CitiesTbls.Find(id);
            if (citiesTbl == null)
            {
                return HttpNotFound();
            }
            return View(citiesTbl);
        }

        // POST: CitiesTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CitiesTbl citiesTbl = db.CitiesTbls.Find(id);
            db.CitiesTbls.Remove(citiesTbl);
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
