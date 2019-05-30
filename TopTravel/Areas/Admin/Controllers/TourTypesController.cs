using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TopTravel;
using PagedList;
using TopTravel.Areas.Admin.FilterAuthentication;

namespace TopTravel.Areas.Admin.Controllers
{
    [CustomAuthenticationFilter]
    public class TourTypesController : Controller
    {
        private BookingEntities db = new BookingEntities();

        // GET: Admin/TourTypes
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

            var tourTypes = from s in db.TourTypes
                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                tourTypes = tourTypes.Where(s => s.TourTypeName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    tourTypes = tourTypes.OrderByDescending(s => s.TourTypeName);
                    break;
                default:
                    tourTypes = tourTypes.OrderBy(s => s.TourTypeName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tourTypes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/TourTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourType tourType = db.TourTypes.Find(id);
            if (tourType == null)
            {
                return HttpNotFound();
            }
            return View(tourType);
        }

        // GET: Admin/TourTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TourTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TourTypeID,TourTypeName,Status")] TourType tourType)
        {
            if (ModelState.IsValid)
            {
                db.TourTypes.Add(tourType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tourType);
        }

        // GET: Admin/TourTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourType tourType = db.TourTypes.Find(id);
            if (tourType == null)
            {
                return HttpNotFound();
            }
            return View(tourType);
        }

        // POST: Admin/TourTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TourTypeID,TourTypeName,Status")] TourType tourType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tourType);
        }

        // GET: Admin/TourTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourType tourType = db.TourTypes.Find(id);
            if (tourType == null)
            {
                return HttpNotFound();
            }
            return View(tourType);
        }

        // POST: Admin/TourTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourType tourType = db.TourTypes.Find(id);
            db.TourTypes.Remove(tourType);
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
