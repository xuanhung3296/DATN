using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace TopTravel.Controllers
{
    public class HomeController : Controller
    {
        private BookingEntities db = new BookingEntities();
        public ActionResult Index(string mess="")
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


            ViewData["Notification"] = mess;
            return View();
        }

        public string GetContact(string colunm)
        {
            switch (colunm)
            {
                case "Address":
                    return db.Contacts.FirstOrDefault().Address;
                break;
                case "Email":
                    return db.Contacts.FirstOrDefault().Email;
                    break;
                case "Phone":
                    return db.Contacts.FirstOrDefault().Phone;
                    break;
                case "Fax":
                    return db.Contacts.FirstOrDefault().Fax;
                    break;
                case "Hotline":
                    return db.Contacts.FirstOrDefault().HotLine;
                    break;
                default:
                    return "";
                    break;

            }
          
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public bool CheckTour()
        {
            //status MoiTao=1, SapHetNgay=2, Dong=3 , HetCho = 4


            var listFulll = db.Tours.Where(u => u.SeatAvailability == 0 && u.Status !=3).ToList();
            foreach (var item in listFulll)
            {
                item.Status = 4;
            }

            var listClosed = db.Tours.Where(u => u.StartDate < DateTime.Now.AddDays(7) && u.Status==2).ToList();
            foreach (var item in listClosed)
            {
                item.Status = 3;
            }

            var list = db.Tours.Where(u => u.StartDate < DateTime.Now.AddDays(14) && u.Status == 1).ToList();
            foreach (var item in list)
            {
                item.Status = 2;
            }
            return true;
      
        }

        public bool checkUser()
        {
            var listUser = db.Users.Where(u => u.DateCreated < DateTime.Now.AddDays(-7) && u.IsActive == false && u.RoleID==2).ToList();
            foreach (var item in listUser)
            {
                db.Users.Remove(item);
            }
            db.SaveChanges();
            return true;
        }



        public bool checkBookTour()
        {
            var listBookTour = db.BookTours.Where(u => u.DateCreated < DateTime.Now.AddDays(-7) && u.Status == 1).ToList();
            foreach (var item in listBookTour)
            {
                item.Status = 3;
            }
            db.SaveChanges();
            return true;
        }
        public JsonResult GetList(string name)
        {
            var list = db.Tours.Select(x => x.Departure).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}