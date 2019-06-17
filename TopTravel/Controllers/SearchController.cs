using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopTravel.Controllers
{
    public class SearchController : Controller
    {

        private BookingEntities db = new BookingEntities();
        // GET: Search
        public ActionResult Index()
        {
           var result = db.Tours.ToList();
            return View(result);
        }

        public ActionResult SearchTour(string label , string destination , string departure , string price , string startDate)
        {
            DateTime startDateTemp = Convert.ToDateTime(startDate);
            var result = new List<Tour>();
            if (!String.IsNullOrEmpty(label))
            {
                var tempTours = db.Tours.Where(u => u.TourLabel.TourLabelName.Equals(label));
                if (!String.IsNullOrEmpty(destination))
                {
                     tempTours = tempTours.Where(u => u.Destination.Contains(destination));
                    if (!String.IsNullOrEmpty(departure))
                    {
                        tempTours = tempTours.Where(u => u.Departure.Contains(departure));
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u =>u.Price.ToString().Contains(price));
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
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
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
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
                        tempTours = tempTours.Where(u => u.Departure.Contains(departure));
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
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
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
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
                   var tempTours = db.Tours.Where(u => u.Destination.Contains(destination));
                    if (!String.IsNullOrEmpty(departure))
                    {
                        tempTours = tempTours.Where(u => u.Departure.Contains(departure));
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
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
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
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
                       var tempTours = db.Tours.Where(u => u.Departure.Contains(departure));
                        if (!String.IsNullOrEmpty(startDate))
                        {
                            tempTours = tempTours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
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
                           var tempTours = db.Tours.Where(u => Equals(u.StartDate, startDateTemp) == true);
                            if (!String.IsNullOrEmpty(price))
                            {
                                tempTours = tempTours.Where(u => u.Price.ToString().Contains(price));
                                result = tempTours.ToList();
                            }
                            else
                            {
                                result = tempTours.ToList();
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(price))
                            {
                               var tempTours = db.Tours.Where(u => u.Price.ToString().Contains(price));
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
            
            return View("Index", result);
        }
    }
}