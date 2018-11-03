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
    public class LanguageMastersController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: LanguageMasters
        public ActionResult Index()
        {
            return View(db.LanguageMasters.ToList());
        }

        // GET: LanguageMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageMaster languageMaster = db.LanguageMasters.Find(id);
            if (languageMaster == null)
            {
                return HttpNotFound();
            }
            return View(languageMaster);
        }

        // GET: LanguageMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguageMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LanguageId,LanguageName")] LanguageMaster languageMaster)
        {
            if (ModelState.IsValid)
            {
                db.LanguageMasters.Add(languageMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(languageMaster);
        }

        // GET: LanguageMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageMaster languageMaster = db.LanguageMasters.Find(id);
            if (languageMaster == null)
            {
                return HttpNotFound();
            }
            return View(languageMaster);
        }

        // POST: LanguageMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanguageId,LanguageName")] LanguageMaster languageMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(languageMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(languageMaster);
        }

        // GET: LanguageMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageMaster languageMaster = db.LanguageMasters.Find(id);
            if (languageMaster == null)
            {
                return HttpNotFound();
            }
            return View(languageMaster);
        }

        // POST: LanguageMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LanguageMaster languageMaster = db.LanguageMasters.Find(id);
            db.LanguageMasters.Remove(languageMaster);
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
