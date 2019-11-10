using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopTravel.Common;
using TopTravel.Models;

namespace TopTravel.Controllers
{
    public class BookingController : Controller
    {
        private BookingEntities db = new BookingEntities();
        // GET: Booking
        public ActionResult Index(int id , string mess="")
        {


            if (Session["Email"]!= null)
            {
                var userid = Convert.ToInt32(Session["UserID"]);
                var user = db.Users.FirstOrDefault(u => u.UserID.Equals(userid));
                ViewBag.Name = user.Name;
                ViewBag.Phone = user.Phone;
                ViewBag.Email = user.Email;
                ViewBag.Address = user.Address;
                ViewBag.Birthday = DateTime.Now;
               
            }
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
            ViewData["Notification"] = mess;
            return View(tour);
        }

        public ActionResult AddUser(string name, string phone, string address, string birthday, string email,string numberAdult, string numberChildren, string numberBaby, string numberBabe, string guests, string id)
        {
            var ID = Convert.ToInt32(id);
            var tour = db.Tours.FirstOrDefault(x => x.TourID == ID);
            if (Convert.ToInt32(guests) < tour.SeatAvailability)
            {

            User user = new User();
            user.Name = name;
            user.Phone = phone;
            user.Address = address;
            user.Email = email;
            user.BookingCode = RandomString.Generate(8);
            ViewBag.NumberAdult = numberAdult;
            ViewBag.NumberChildren = numberChildren;
            ViewBag.NumberBaby = numberBaby;
            ViewBag.NumberBabe = numberBabe;
            ViewBag.Guest = guests;
            ViewBag.ID = id;
            ////string check = EmailAction.SendMail(user.Email, user.BookingCode);
           
            //if (check.Equals("Success") != true)
            //{
            //    return View("Error");
            //}
         
            ViewBag.TourType = tour.TourType.TourTypeName;

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
            else
            {
                ViewData["Notification"] = "Quá số chỗ còn lại!";
                return RedirectToAction("Index", new { id = ID  , mess = ViewData["Notification"] });
            }
           
        }

        public bool CheckUser(string email)
        {

            var numb = db.Users.Where(u => u.Email.Equals(email)).Count();
            if (numb > 0 )
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public ActionResult BookTour(FormSubmitViewModel form, string  checkRule , string payMethod, string total , string id, string numberAdult, string numberChildren, string numberBaby, string numberBabe, string bookingCode)
        {
            if ( checkRule== "true" && form.User.BookingCode.Equals(bookingCode))
            {
              
                if (CheckUser(form.User.Email))
                {
                    var pass = Common.RandomString.Generate(6);
                    form.User.Password = Common.Encrypt.Encode(pass);
                    form.User.RoleID = 2;
                    db.Users.Add(form.User);
                    var result = db.SaveChanges();
                    if (result == 1) 
                    {
                        System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
                        m.From = new System.Net.Mail.MailAddress("xuanhung3296@gmail.com");
                        m.To.Add(form.User.Email);
                        m.Subject = "Xác nhận đăng ký ";
                        m.Body = string.Format("Cảm ơn bạn đã đến với TopTravel, Mật khẩu cho lần đầu đăng nhập của bạn là : {1} </BR> " +
                            "Hãy thay đổi sau khi đăng nhập.</BR> Click vào link để Active cho tài khoản của bạn:<a href=\"{0}\"title =\"User Email Confirm\">Click here to Active your account</a>",
                            Url.Action("ConfirmEmail", "UserLogin",
                           new { Token = form.User.ActiveCode, Email = form.User.Email }, Request.Url.Scheme), pass);
                        m.IsBodyHtml = true;
                        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("xuanhung3296@gmail.com", "03021996");
                        smtp.EnableSsl = true;
                        smtp.Send(m);
                        
                    }
                }

                var user = db.Users.FirstOrDefault(u => u.Email.Equals(form.User.Email));
                user.Name = form.User.Name;
                user.Phone = form.User.Phone;
                user.Address = form.User.Address;
                BookTour newBooking = new BookTour();
                newBooking.Amount = float.Parse(total);
                newBooking.UserID = db.Users.FirstOrDefault(x => x.Email.Equals(form.User.Email)).UserID;
                newBooking.TourID = Convert.ToInt32(id);             
                newBooking.PaymentMethod = payMethod;
                newBooking.NumberOfAdult =Convert.ToInt32(numberAdult);
                newBooking.NumberOfChildrent = Convert.ToInt32(numberChildren);
                newBooking.PaymentCode = RandomString.Generate(8);
                newBooking.Status = 1;
                newBooking.DateCreated = DateTime.Now.Date;
                db.BookTours.Add(newBooking);
                db.SaveChanges();
                EmailAction.SendMailPaymentCode(form.User.Email,id,newBooking.PaymentCode);


                var tour = db.Tours.FirstOrDefault(u => u.TourID.Equals(newBooking.TourID));
                tour.SeatAvailability = tour.SeatAvailability - newBooking.NumberOfAdult - newBooking.NumberOfChildrent;
                db.SaveChanges();
                
                int bookTourID = newBooking.BookTourID; // Your Identity column ID
                foreach (var item in form.ListTourist)
                {
                    item.BookTour= newBooking;
                    item.BookTourID = bookTourID;
                    db.Tourists.Add(item);
                    
                }
                db.SaveChanges();
                ViewData["Notification"] = "Bạn đã book Tour thành công! <BR/> Hãy check mã thanh toán ở Email";
                return RedirectToAction("Index", "Home", new { mess= ViewData["Notification"]});
            }
            return View("Error");
        }


        public ActionResult Form()
        {
            return View("Form");
        }
    }
}