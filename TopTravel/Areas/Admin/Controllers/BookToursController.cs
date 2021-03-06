﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TopTravel;
using TopTravel.Areas.Admin.FilterAuthentication;

namespace TopTravel.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    public class BookToursController : Controller
    {
        private BookingEntities db = new BookingEntities();

        // GET: Admin/BookTours
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var bookTours = from s in db.BookTours.Include(b => b.Tour).Include(b => b.User)
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                bookTours = bookTours.Where(s => s.Tour.TourName.Contains(searchString) || s.User.Name.Contains(searchString) || s.PaymentMethod.Contains(searchString) || s.User.UserID.ToString().Contains(searchString) || s.User.Email.ToString().Contains(searchString));
            }

            bookTours = bookTours.OrderBy(s => s.BookTourID);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(bookTours.ToPagedList(pageNumber, pageSize));

        }

        // GET: Admin/BookTours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTour bookTour = db.BookTours.Find(id);
            if (bookTour == null)
            {
                return HttpNotFound();
            }
            return View(bookTour);
        }

        // GET: Admin/BookTours/Create
        public ActionResult Create()
        {
            ViewBag.TourID = new SelectList(db.Tours, "TourID", "TourName");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name");
            return View();
        }

        // POST: Admin/BookTours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookTourID,UserID,TourID,NumberOfAdult,NumberOfChildrent,Amount,PaymentMethod,Status")] BookTour bookTour)
        {
            if (ModelState.IsValid)
            {
                db.BookTours.Add(bookTour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TourID = new SelectList(db.Tours, "TourID", "TourName", bookTour.TourID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", bookTour.UserID);
            return View(bookTour);
        }

        // GET: Admin/BookTours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTour bookTour = db.BookTours.Find(id);
            if (bookTour == null)
            {
                return HttpNotFound();
            }
            ViewBag.TourID = new SelectList(db.Tours, "TourID", "TourName", bookTour.TourID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email", bookTour.UserID);
            return View(bookTour);
        }

        // POST: Admin/BookTours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookTourID,UserID,TourID,NumberOfAdult,NumberOfChildrent,Amount,PaymentMethod,Status")] BookTour bookTour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookTour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TourID = new SelectList(db.Tours, "TourID", "TourName", bookTour.TourID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", bookTour.UserID);
            return View(bookTour);
        }

        // GET: Admin/BookTours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookTour bookTour = db.BookTours.Find(id);
            if (bookTour == null)
            {
                return HttpNotFound();
            }
            return View(bookTour);
        }

        // POST: Admin/BookTours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookTour bookTour = db.BookTours.Find(id);
            db.BookTours.Remove(bookTour);
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


        public ActionResult Payment(int id)
        {
            BookTour bookTour = db.BookTours.Find(id);
            bookTour.Status = 2;
            db.SaveChanges();
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
            m.From = new System.Net.Mail.MailAddress("xuanhung3296@gmail.com");
            m.To.Add(bookTour.User.Email);
            m.Subject = "Xác nhận thanh toán";
            m.Body = string.Format("Bạn đã thanh toán cho Tour {0} thành công. Chúc bạn có một chuyến đi vui vẻ", bookTour.Tour.TourName);
            m.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("xuanhung3296@gmail.com", "03021996");
            smtp.EnableSsl = true;
            smtp.Send(m);
            return RedirectToAction("Index");
        }
    }
}
