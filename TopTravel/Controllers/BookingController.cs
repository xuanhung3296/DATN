using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopTravel.Controllers
{
    public class BookingController : Controller
    {
        private BookingEntities db = new BookingEntities();
        // GET: Booking
        public ActionResult Index(int id)
        {
            var tour = db.Tours.FirstOrDefault(x => x.TourID == id);
            var nguoiLonPrice = tour.ListedPrice;
            var treEmPrice = tour.ListedPrice/2;
            var treNhoPrice = tour.ListedPrice/3;
            var emBePrice = tour.ListedPrice/4;
            var phuThu = 100000;

            ViewBag.AdultPrice = nguoiLonPrice;
            ViewBag.ChildPrice = treEmPrice;
            ViewBag.BabyPrice = treNhoPrice;
            ViewBag.BabePrice = emBePrice;
            ViewBag.Bonus = phuThu;
            return View(tour);
        }

        public string AddUser(string Name, string Phone, string Address, string )
        {

            return "success";
        }

        public ActionResult Form()
        {
            return View("Form");
        }
    }
}