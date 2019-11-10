using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using PagedList;
using TopTravel.Models;

namespace TopTravel.Controllers
{
    public class UserLoginController : Controller
    {
        private BookingEntities db = new BookingEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var encryptPass = Common.Encrypt.Encode(password);
            var numb = db.Users.Count(u => u.Email.Equals(email) && u.Password.Equals(encryptPass) && u.Role.RoleName.Equals("User") && u.IsActive == true);
            if (numb > 0)
            {


                FormsAuthentication.SetAuthCookie(email, true);
                var user = db.Users.FirstOrDefault(u => u.Email.Equals(email));
                Session["Email"] = user.Email;
                Session["UserID"] = user.UserID;
                Session["Name"] = user.Name;
                Session["Address"] = user.Address;
                Session["Phone"] = user.Phone;
                
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string email, string password)
        {

            var check = db.Users.Where(m => m.Email.Equals(email)).FirstOrDefault();
            if (check == null)
            {
                var user = new User();
                user.Email = email;
                user.Password = Common.Encrypt.Encode(password);
                user.IsActive = false;
                user.ActiveCode = Common.RandomString.Generate(8);
                user.DateCreated = DateTime.Now;
                user.RoleID = 2;
                db.Users.Add(user);
                var result = db.SaveChanges();
                if (result == 1) ;
                {
                    System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
                    m.From = new System.Net.Mail.MailAddress("xuanhung3296@gmail.com");
                    m.To.Add(user.Email);
                    m.Subject = "Xác nhận đăng ký tài khoản";
                    m.Body = string.Format("Cảm ơn bạn đã đăng ký tài khoản trên TopTravel, Click vào link sau để hoàn thành đăng ký:<a href=\"{0}\"title =\"User Email Confirm\">Click here to Active your account</a>",
                        Url.Action("ConfirmEmail", "UserLogin",
                       new { Token = user.ActiveCode, Email = user.Email }, Request.Url.Scheme));
                    m.IsBodyHtml = true;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("xuanhung3296@gmail.com", "03021996");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    ViewData["Notification"] = "Bạn đã đăng ký thành công";
                    return RedirectToAction("Index", "Home", new { mess = ViewData["Notification"] });
                }
            }
            else
            {
                if (check != null)
                    ViewData["Notification"] = "Email đã được sử dụng! Vui lòng chọn email khác để đăng ký ";

            }


            // If we got this far, something failed, redisplay form
            return RedirectToAction("Index", "Home", new {mess= ViewData["Notification"] });
        }


        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string Token, string Email)
        {

            var user = db.Users.Where(a => a.Email.Equals(Email) && a.ActiveCode.Equals(Token)).FirstOrDefault();
            if (user != null)
            {
                if (user.Email == Email)
                {
                    user.IsActive = true;
                    db.SaveChanges();
                   
                }              
            }
            return RedirectToAction("Index", "Home");
        }



        public bool ResetPassword(string email)
        {
            var user = db.Users.FirstOrDefault(u => u.Email.Equals(email));
            user.Password = Common.RandomString.Generate(6);
            db.SaveChanges();
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
            m.From = new System.Net.Mail.MailAddress("xuanhung3296@gmail.com");
            m.To.Add(user.Email);
            m.Subject = "Xác nhận đặt lại mật khẩu";
            m.Body = string.Format("Đây là mật khẩu mới của bạn. Hãy thay đổi lại sau khi đăng nhập {0}",user.Password);
            m.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("xuanhung3296@gmail.com", "03021996");
            smtp.EnableSsl = true;
            smtp.Send(m);
            ViewData["Notification"] = "Bạn đã thực hiện đặt lại mật khẩu. Hãy check lại Email!";
            return true;
        }

        public ActionResult getProfile(string id, int? page, string mess="")
        {

            var convertID = Convert.ToInt32(id);
            var userID = db.Users.FirstOrDefault(u => u.UserID.Equals(convertID));
            var listBook = db.BookTours.Where(u => u.UserID == convertID).OrderByDescending(u=>u.DateCreated).ToList();
            List<ProfileViewModel> list = new List<ProfileViewModel>();
            foreach (var item in listBook)
            {
                ProfileViewModel newItem = new ProfileViewModel();
                newItem.BookTour = item;
                newItem.Tour = db.Tours.FirstOrDefault(u => u.TourID.Equals(item.TourID));
                list.Add(newItem);
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            if (mess!= "")
            {
                ViewData["Notification"] = mess;
            }
            return View("UserProfile", list.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult getDetail(string id)
        {
            var convertID = Convert.ToInt32(id);
            var bookTour = db.BookTours.FirstOrDefault(u => u.BookTourID.Equals(convertID));
            var listBook = db.BookTours.Where(u => u.UserID == convertID).ToList();
            FormSubmitViewModel detail = new FormSubmitViewModel();
            detail.User = db.Users.FirstOrDefault(u => u.UserID == bookTour.UserID);
            detail.ListTourist = db.Tourists.Where(u => u.BookTourID == convertID).ToList();
            var tour = db.Tours.FirstOrDefault(u => u.TourID == bookTour.TourID);
            ViewBag.AdultPrice = tour.ListedPrice;
            ViewBag.ChildrenPrice = tour.ListedPrice / 2;
            return View("Detail", detail);

        }

        public ActionResult changePassword (string newPass)
        {
            if (Session["Email"]!=null)
            {
                var email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(u => u.Email.Equals(email));
                user.Password = Common.Encrypt.Encode(newPass);
                db.SaveChanges();
            }
            ViewData["Notification"] = "Đổi Password thành công!";
            return RedirectToAction("Index", "Home", new { mess = ViewData["Notification"] });

        }

        public ActionResult changeInfo(string name, string address, string phone )
        {
            if (Session["Email"] != null)
            {
                var email = Session["Email"].ToString();
                var user = db.Users.FirstOrDefault(u => u.Email.Equals(email));
                user.Name = name;
                user.Address = address;
                user.Phone = phone;
                db.SaveChanges();
            }
            ViewData["Notification"] = "Đổi thông tin thành công!";
            return RedirectToAction("Index", "Home", new { mess = ViewData["Notification"] });

        }


        public ActionResult cancelBooking(string id)
        {
            var bookID = Convert.ToInt32(id);
            var book = db.BookTours.FirstOrDefault(u => u.BookTourID == bookID);
            book.Status = 3;
            db.SaveChanges();
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
            m.From = new System.Net.Mail.MailAddress("xuanhung3296@gmail.com");
            m.To.Add(Session["Email"].ToString());
            m.Subject = "Xác nhận hủy Tour";
            m.Body = string.Format("Bạn đã hủy Tour {0} thành công. Chúc bạn tìm được chuyến đi phù hợp hơn ", book.Tour.TourName);
            m.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("xuanhung3296@gmail.com", "03021996");
            smtp.EnableSsl = true;
            smtp.Send(m);
            ViewData["Notification"] = "Hủy Tour thành công!";
            return RedirectToAction("getProfile", "UserLogin", new { id = Session["UserID"], page= 1 , mess = ViewData["Notification"] });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Email"] = null;
            Session["Role"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
