using System;
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
    public class FeedbacksController : Controller
    {
        private BookingEntities db = new BookingEntities();

        // GET: Admin/Feedbacks
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

            var feedbacks = from s in db.Feedbacks.ToList()
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                feedbacks = feedbacks.Where(s => s.Name.Contains(searchString) || s.Email.ToString().Contains(searchString) || s.Phone.Contains(searchString)||s.Company.Contains(searchString)||s.Address.Contains(searchString)||s.InfomationType.Contains(searchString));
            }

            feedbacks = feedbacks.OrderBy(s => s.DateCreated);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(feedbacks.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Admin/Feedbacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeedbackID,InfomationType,Email,Name,Phone,Company,Address,Title,Feedback1,DateCreated,Status")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedback);
        }

        // GET: Admin/Feedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Admin/Feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeedbackID,InfomationType,Email,Name,Phone,Company,Address,Title,Feedback1,DateCreated,Status")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: Admin/Feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = db.Feedbacks.Find(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Admin/Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
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
