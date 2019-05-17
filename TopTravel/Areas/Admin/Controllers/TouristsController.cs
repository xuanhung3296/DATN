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
    public class TouristsController : Controller
    {
        private BookingEntities db = new BookingEntities();

        // GET: Admin/Tourists
        public ActionResult Index()
        {
            var tourists = db.Tourists.Include(t => t.BookTour);
            return View(tourists.ToList());
        }

        // GET: Admin/Tourists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tourist tourist = db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }
            return View(tourist);
        }

        // GET: Admin/Tourists/Create
        public ActionResult Create()
        {
            ViewBag.BookTourID = new SelectList(db.BookTours, "BookTourID", "PaymentMethod");
            return View();
        }

        // POST: Admin/Tourists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TouristID,BookTourID,Name,Birthday,Gender,TouristType,Nationality,Passport,ExpiredDate,Status")] Tourist tourist)
        {
            if (ModelState.IsValid)
            {
                db.Tourists.Add(tourist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookTourID = new SelectList(db.BookTours, "BookTourID", "PaymentMethod", tourist.BookTourID);
            return View(tourist);
        }

        // GET: Admin/Tourists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tourist tourist = db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookTourID = new SelectList(db.BookTours, "BookTourID", "PaymentMethod", tourist.BookTourID);
            return View(tourist);
        }

        // POST: Admin/Tourists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TouristID,BookTourID,Name,Birthday,Gender,TouristType,Nationality,Passport,ExpiredDate,Status")] Tourist tourist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookTourID = new SelectList(db.BookTours, "BookTourID", "PaymentMethod", tourist.BookTourID);
            return View(tourist);
        }

        // GET: Admin/Tourists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tourist tourist = db.Tourists.Find(id);
            if (tourist == null)
            {
                return HttpNotFound();
            }
            return View(tourist);
        }

        // POST: Admin/Tourists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tourist tourist = db.Tourists.Find(id);
            db.Tourists.Remove(tourist);
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
