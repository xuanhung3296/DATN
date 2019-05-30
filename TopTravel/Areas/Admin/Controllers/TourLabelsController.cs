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
    public class TourLabelsController : Controller
    {
        private BookingEntities db = new BookingEntities();

        // GET: Admin/TourLabels
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var tourLabels = from s in db.TourLabels
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                tourLabels = tourLabels.Where(s => s.TourLabelName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    tourLabels = tourLabels.OrderByDescending(s => s.TourLabelName);
                    break;
                default:
                    tourLabels = tourLabels.OrderBy(s => s.TourLabelName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tourLabels.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TourLabels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourLabel tourLabel = db.TourLabels.Find(id);
            if (tourLabel == null)
            {
                return HttpNotFound();
            }
            return View(tourLabel);
        }

        // GET: Admin/TourLabels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TourLabels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TourLabelID,TourLabelName,Status")] TourLabel tourLabel)
        {
            if (ModelState.IsValid)
            {
                db.TourLabels.Add(tourLabel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tourLabel);
        }

        // GET: Admin/TourLabels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourLabel tourLabel = db.TourLabels.Find(id);
            if (tourLabel == null)
            {
                return HttpNotFound();
            }
            return View(tourLabel);
        }

        // POST: Admin/TourLabels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TourLabelID,TourLabelName,Status")] TourLabel tourLabel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourLabel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tourLabel);
        }

        // GET: Admin/TourLabels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourLabel tourLabel = db.TourLabels.Find(id);
            if (tourLabel == null)
            {
                return HttpNotFound();
            }
            return View(tourLabel);
        }

        // POST: Admin/TourLabels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourLabel tourLabel = db.TourLabels.Find(id);
            db.TourLabels.Remove(tourLabel);
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
