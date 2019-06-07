using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopTravel.Controllers
{
    public class TourController : Controller
    {
        private BookingEntities db = new BookingEntities();
        // GET: Tour
        public ActionResult Index(int id)
        {
            var tour = db.Tours.FirstOrDefault(u => u.TourID.Equals(id));

            return View(tour);
        }
    }
}