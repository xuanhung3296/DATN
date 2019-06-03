using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace TopTravel.Controllers
{
    public class HomeController : Controller
    {
        private BookingEntities db = new BookingEntities();
        public ActionResult Index()
        {
            //----Bannners---------
            var banners = new List<string>();
            foreach (var item in db.Banners)
            {
                banners.Add(item.Image);
            }
            ViewBag.Banners = banners;

            //-------TourTypes---- 
            var tourTypes = new List<string>();
            foreach (var item in db.TourTypes)
            {
                tourTypes.Add(item.TourTypeName);
            }

            foreach(var item in db.TourLabels)
            {
                tourTypes.Add(item.TourLabelName);
            }

            ViewBag.TourTypes = tourTypes;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}