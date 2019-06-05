﻿using System;
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


            var listDestination = db.Tours.OrderBy(t => t.StartDate).Where(t => t.OnHomePage == true).Take(3);

            ViewBag.listDestination = listDestination;

            var listTour = db.Tours.OrderBy(t => t.StartDate).Where(t => t.IsHot == true).Take(4);

            ViewBag.listTour = listTour;

            var listFeedback = db.Feedbacks.Where(t => t.InfomationType.Equals("Khen"));

            ViewBag.listFeedback = listFeedback;

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