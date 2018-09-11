using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FiladelfiaKyrkan.Models;
using Microsoft.AspNet.Identity;

namespace FiladelfiaKyrkan.Controllers
{
    public class SubmissionFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubmissionForms
        public ActionResult Index()
        {
            return View(db.SubmissionForms.ToList());
        }

        // GET: SubmissionForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubmissionForm submissionForm = db.SubmissionForms.Find(id);
            if (submissionForm == null)
            {
                return HttpNotFound();
            }
            return View(submissionForm);
        }

        // GET: SubmissionForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubmissionForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Message")] SubmissionForm submissionForm)
        {
            if (ModelState.IsValid)
            {
                submissionForm.User = db.Users.Find(User.Identity.GetUserId());
                db.SubmissionForms.Add(submissionForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(submissionForm);
        }

        // GET: SubmissionForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubmissionForm submissionForm = db.SubmissionForms.Find(id);
            if (submissionForm == null)
            {
                return HttpNotFound();
            }
            return View(submissionForm);
        }

        // POST: SubmissionForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Message")] SubmissionForm submissionForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(submissionForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(submissionForm);
        }

        // GET: SubmissionForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubmissionForm submissionForm = db.SubmissionForms.Find(id);
            if (submissionForm == null)
            {
                return HttpNotFound();
            }
            return View(submissionForm);
        }

        // POST: SubmissionForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubmissionForm submissionForm = db.SubmissionForms.Find(id);
            db.SubmissionForms.Remove(submissionForm);
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
