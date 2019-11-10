using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace TopTravel.Controllers
{
    public class SearchController : Controller
    {

        private BookingEntities db = new BookingEntities();
        // GET: Search
        public ActionResult Index(int? page)
        {

            var tourTypes = new List<string>();
            foreach (var item in db.TourTypes)
            {
                tourTypes.Add(item.TourTypeName);
            }

            foreach (var item in db.TourLabels)
            {
                tourTypes.Add(item.TourLabelName);
            }

            ViewBag.TourTypes = tourTypes;
            var result = db.Tours.ToList();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var lastResult = result.AsQueryable();
            return View(lastResult.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult SearchTour(string label , string destination , string departure , string seat , string startDate, int? page)
        {

            var tourTypes = new List<string>();
            foreach (var item in db.TourTypes)
            {
                tourTypes.Add(item.TourTypeName);
            }

            foreach (var item in db.TourLabels)
            {
                tourTypes.Add(item.TourLabelName);
            }

            ViewBag.TourTypes = tourTypes;

            ViewBag.Label = label;
            ViewBag.Destination = destination;
            ViewBag.Departure = departure;
            ViewBag.StartDate = startDate;
            ViewBag.Price = seat;
            var seatInt = 0;
            if (!String.IsNullOrEmpty(seat))
            {
                seatInt = Convert.ToInt32(seat);
            }
          
            var result = new List<Tour>();
            if (!String.IsNullOrEmpty(label))
            {
                var tempTours = db.Tours.Where(u => u.TourLabel.TourLabelName.ToLower().Contains(label.ToLower())|| u.TourType.TourTypeName.Contains(label.ToLower()));
                if (!String.IsNullOrEmpty(destination))
                {
                     tempTours = tempTours.Where(u => u.Destination.ToLower().Contains(destination.ToLower()));
                    if (!String.IsNullOrEmpty(departure))
                    {
                        tempTours = tempTours.Where(u => u.Departure.ToLower().Contains(departure.ToLower()));
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            DateTime startDateTemp = Convert.ToDateTime(startDate);
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u =>u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            DateTime startDateTemp = Convert.ToDateTime(startDate);
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(departure))
                    {
                        tempTours = tempTours.Where(u => u.Departure.ToLower().Contains(departure.ToLower()));
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            DateTime startDateTemp = Convert.ToDateTime(startDate);
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            DateTime startDateTemp = Convert.ToDateTime(startDate);
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                    }
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(destination))
                {
                   var tempTours = db.Tours.Where(u => u.Destination.ToLower().Contains(destination.ToLower()));
                    if (!String.IsNullOrEmpty(departure))
                    {
                        tempTours = tempTours.Where(u => u.Departure.ToLower().Contains(departure.ToLower()));
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            DateTime startDateTemp = Convert.ToDateTime(startDate);
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            DateTime startDateTemp = Convert.ToDateTime(startDate);
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(departure))
                    {
                       var tempTours = db.Tours.Where(u => u.Departure.ToLower().Contains(departure.ToLower()));
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            DateTime startDateTemp = Convert.ToDateTime(startDate);
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            DateTime startDateTemp = Convert.ToDateTime(startDate);
                            var tempTours = db.Tours.Where(u => DbFunctions.TruncateTime(u.StartDate) == startDateTemp);
                            if (!String.IsNullOrEmpty(seat))
                            {
                                tempTours = tempTours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(seat))
                            {
                               var tempTours = db.Tours.Where(u => u.SeatAvailability >=  seatInt);
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = db.Tours.ToList();
                            }
                        }
                    }
                }

            }

            var lastResult = result.AsQueryable();
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View("Index", lastResult.ToPagedList(pageNumber, pageSize));
        }


        public class City
        {
            public int Id { get; set; }
            public string CityName { get; set; }

        }
    }
}