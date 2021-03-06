﻿using System;
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
    public class QuestionsController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: Questions
        public ActionResult Index()
        {
            var questions = db.Questions.Include(q => q.Certification).Include(q => q.KnowledgeArea).Include(q => q.LanguageMaster);
            return View(questions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            ViewBag.CertificationId = new SelectList(db.Certifications, "CertificationId", "CertificationName");
            ViewBag.KnowledgeAreaId = new SelectList(db.KnowledgeAreas, "KnowledgeAreaId", "KnowledgeAreaName");
            ViewBag.LanguageId = new SelectList(db.LanguageMasters, "LanguageId", "LanguageName");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionId,CertificationId,KnowledgeAreaId,LanguageId,FullQuestion,AnswerOption1,AnswerOption2,AnswerOption3,AnswerOption4,CorrectAnswerIndex,Mark,AreaofKnowledge,AnswerExplanation,isDisplayOnly")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CertificationId = new SelectList(db.Certifications, "CertificationId", "CertificationName", question.CertificationId);
            ViewBag.KnowledgeAreaId = new SelectList(db.KnowledgeAreas, "KnowledgeAreaId", "KnowledgeAreaName", question.KnowledgeAreaId);
            ViewBag.LanguageId = new SelectList(db.LanguageMasters, "LanguageId", "LanguageName", question.LanguageId);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.CertificationId = new SelectList(db.Certifications, "CertificationId", "CertificationName", question.CertificationId);
            ViewBag.KnowledgeAreaId = new SelectList(db.KnowledgeAreas, "KnowledgeAreaId", "KnowledgeAreaName", question.KnowledgeAreaId);
            ViewBag.LanguageId = new SelectList(db.LanguageMasters, "LanguageId", "LanguageName", question.LanguageId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionId,CertificationId,KnowledgeAreaId,LanguageId,FullQuestion,AnswerOption1,AnswerOption2,AnswerOption3,AnswerOption4,CorrectAnswerIndex,Mark,AreaofKnowledge,AnswerExplanation,isDisplayOnly")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CertificationId = new SelectList(db.Certifications, "CertificationId", "CertificationName", question.CertificationId);
            ViewBag.KnowledgeAreaId = new SelectList(db.KnowledgeAreas, "KnowledgeAreaId", "KnowledgeAreaName", question.KnowledgeAreaId);
            ViewBag.LanguageId = new SelectList(db.LanguageMasters, "LanguageId", "LanguageName", question.LanguageId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
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
