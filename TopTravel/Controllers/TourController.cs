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


        private static readonly string[] VietNamChar = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static string utf8Convert1(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
                    str = str.Replace(" ","");
            }
            return str;
        }


        public ActionResult Index(int id)
        {
            var tour = db.Tours.FirstOrDefault(u => u.TourID.Equals(id));

            ViewBag.Departure = utf8Convert1(tour.Departure);
            ViewBag.Destination = utf8Convert1(tour.Destination);
            ViewBag.Relate = db.Tours.Where(u => u.SeatAvailability != 0).OrderByDescending(u => u.StartDate).Take(2);
            return View(tour);
        }
    }
}