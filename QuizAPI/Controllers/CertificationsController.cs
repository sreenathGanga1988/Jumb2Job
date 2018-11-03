using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    public class CertificationsController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: Certifications
        public ActionResult Index()
        {
            return View(db.Certifications.ToList());
        }

        // GET: Certifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // GET: Certifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Certifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CertificationId,CertificationName")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                db.Certifications.Add(certification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(certification);
        }

        // GET: Certifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // POST: Certifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CertificationId,CertificationName")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(certification);
        }

        // GET: Certifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certification certification = db.Certifications.Find(id);
            if (certification == null)
            {
                return HttpNotFound();
            }
            return View(certification);
        }

        // POST: Certifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Certification certification = db.Certifications.Find(id);
            db.Certifications.Remove(certification);
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
