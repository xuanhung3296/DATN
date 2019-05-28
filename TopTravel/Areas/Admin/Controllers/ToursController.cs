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

namespace TopTravel.Areas.Admin.Controllers
{
    public class ToursController : Controller
    {
        private BookingEntities db = new BookingEntities();

        // GET: Admin/Tours
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

            var tours = from s in db.Tours.Include(t => t.TourLabel).Include(t => t.TourType)
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                tours = tours.Where(s => s.TourName.Contains(searchString) || s.TourLabel.TourLabelName.Contains(searchString) || s.Destination.Contains(searchString) || s.TourType.TourTypeName.Contains(searchString) || s.Destination.Contains(searchString));
            }

            tours=tours.OrderBy(s => s.TourID);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tours.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Tours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Admin/Tours/Create
        public ActionResult Create()
        {
            ViewBag.TourLabelID = new SelectList(db.TourLabels, "TourLabelID", "TourLabelName");
            ViewBag.TourTypeID = new SelectList(db.TourTypes, "TourTypeID", "TourTypeName");
            return View();
        }

        // POST: Admin/Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TourID,TourTypeID,TourLabelID,TourName,Departure,Destination,StartDate,Duration,Price,ListedPrice,TotalSeat,SeatAvailability,Image,TourProgram,TourDetail,Contact,DateCreated,IsHot,OnHomePage,Status")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TourLabelID = new SelectList(db.TourLabels, "TourLabelID", "TourLabelName", tour.TourLabelID);
            ViewBag.TourTypeID = new SelectList(db.TourTypes, "TourTypeID", "TourTypeName", tour.TourTypeID);
            return View(tour);
        }

        // GET: Admin/Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.TourLabelID = new SelectList(db.TourLabels, "TourLabelID", "TourLabelName", tour.TourLabelID);
            ViewBag.TourTypeID = new SelectList(db.TourTypes, "TourTypeID", "TourTypeName", tour.TourTypeID);
            return View(tour);
        }

        // POST: Admin/Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TourID,TourTypeID,TourLabelID,TourName,Departure,Destination,StartDate,Duration,Price,ListedPrice,TotalSeat,SeatAvailability,Image,TourProgram,TourDetail,Contact,DateCreated,IsHot,OnHomePage,Status")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TourLabelID = new SelectList(db.TourLabels, "TourLabelID", "TourLabelName", tour.TourLabelID);
            ViewBag.TourTypeID = new SelectList(db.TourTypes, "TourTypeID", "TourTypeName", tour.TourTypeID);
            return View(tour);
        }

        // GET: Admin/Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Admin/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
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
