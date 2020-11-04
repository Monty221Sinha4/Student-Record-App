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
    public class UniverisitesController : Controller
    {
        private StudentDB db = new StudentDB();

        // GET: Univerisites
        public ActionResult Index()
        {
            return View(db.Univerisites.ToList());
        }

        // GET: Univerisites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Univerisite univerisite = db.Univerisites.Find(id);
            if (univerisite == null)
            {
                return HttpNotFound();
            }
            return View(univerisite);
        }

        // GET: Univerisites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Univerisites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniID,University")] Univerisite univerisite)
        {
            if (ModelState.IsValid)
            {
                db.Univerisites.Add(univerisite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(univerisite);
        }

        // GET: Univerisites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Univerisite univerisite = db.Univerisites.Find(id);
            if (univerisite == null)
            {
                return HttpNotFound();
            }
            return View(univerisite);
        }

        // POST: Univerisites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniID,University")] Univerisite univerisite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(univerisite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(univerisite);
        }

        // GET: Univerisites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Univerisite univerisite = db.Univerisites.Find(id);
            if (univerisite == null)
            {
                return HttpNotFound();
            }
            return View(univerisite);
        }

        // POST: Univerisites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Univerisite univerisite = db.Univerisites.Find(id);
            db.Univerisites.Remove(univerisite);
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
