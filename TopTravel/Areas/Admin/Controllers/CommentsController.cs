﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TopTravel;

namespace TopTravel.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        private BookingEntities db = new BookingEntities();

        // GET: Admin/Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Tour).Include(c => c.User);
            return View(comments.ToList());
        }

        // GET: Admin/Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Admin/Comments/Create
        public ActionResult Create()
        {
            ViewBag.TourID = new SelectList(db.Tours, "TourID", "TourName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name");
            return View();
        }

        // POST: Admin/Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TourID,UserID,Comment1,DateCreated,Status")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TourID = new SelectList(db.Tours, "TourID", "TourName", comment.TourID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", comment.UserID);
            return View(comment);
        }

        // GET: Admin/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.TourID = new SelectList(db.Tours, "TourID", "TourName", comment.TourID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", comment.UserID);
            return View(comment);
        }

        // POST: Admin/Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TourID,UserID,Comment1,DateCreated,Status")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TourID = new SelectList(db.Tours, "TourID", "TourName", comment.TourID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", comment.UserID);
            return View(comment);
        }

        // GET: Admin/Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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