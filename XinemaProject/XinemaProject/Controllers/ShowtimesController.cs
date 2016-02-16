using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XinemaProject.Models;

namespace XinemaProject.Controllers
{
    public class ShowtimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Showtimes
        public ActionResult Index()
        {
            return View(db.Showtimes.ToList());
        }

        // GET: Showtimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtimes showtimes = db.Showtimes.Find(id);
            if (showtimes == null)
            {
                return HttpNotFound();
            }
            return View(showtimes);
        }

        // GET: Showtimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Showtimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "showtimesID,showtimesStartTime,showtimesDate")] Showtimes showtimes)
        {
            if (ModelState.IsValid)
            {
                db.Showtimes.Add(showtimes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(showtimes);
        }

        // GET: Showtimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtimes showtimes = db.Showtimes.Find(id);
            if (showtimes == null)
            {
                return HttpNotFound();
            }
            return View(showtimes);
        }

        // POST: Showtimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "showtimesID,showtimesStartTime,showtimesDate")] Showtimes showtimes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showtimes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(showtimes);
        }

        // GET: Showtimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtimes showtimes = db.Showtimes.Find(id);
            if (showtimes == null)
            {
                return HttpNotFound();
            }
            return View(showtimes);
        }

        // POST: Showtimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Showtimes showtimes = db.Showtimes.Find(id);
            db.Showtimes.Remove(showtimes);
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
