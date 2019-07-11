using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopTravel.Models;

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

        public ActionResult AddUser(string name, string phone, string address, string birthday, string email,string numberAdult, string numberChildren, string numberBaby, string numberBabe, string guests, string id)
        {
            User user = new User();
            user.Name = name;
            user.Phone = phone;
            user.Address = address;
            user.Email = email;
            ViewBag.NumberAdult = numberAdult;
            ViewBag.NumberChildren = numberChildren;
            ViewBag.NumberBaby = numberBaby;
            ViewBag.NumberBabe = numberBabe;
            ViewBag.Guest = guests;
            var ID = Convert.ToInt32(id);
            var tour = db.Tours.FirstOrDefault(x => x.TourID == ID);


            var touristList = new List<Tourist>();
            // Another one is using for loop
            for (int i = 0; i < Convert.ToInt32(guests); i++)
            {
                touristList.Add(new Tourist());
            }

            FormSubmitViewModel form = new FormSubmitViewModel();
            form.User = user;
            form.ListTourist = touristList;
            ViewBag.AdultPrice = tour.ListedPrice;
            ViewBag.ChildrenPrice = tour.ListedPrice/2;         
            return View("Form", form);
        }

        public ActionResult BookTour(User user, List<Tourist> list, string  checkRule , string payMethod, string total )
        {

            return View("Error");
        }


        public ActionResult Form()
        {
            return View("Form");
        }
    }
}