using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;

namespace TopTravel.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private BookingEntities db = new BookingEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.userIsValid(user))
                {
                    user = db.Users.First(u => u.Email.Equals(user.Email));
                    FormsAuthentication.SetAuthCookie(user.Email,true);
                    Session["Email"] = user.Email;
                    Session["Role"] = user.Role.RoleName;
                    return RedirectToAction("Index", "Roles");
                }
                else
                {
                    ModelState.AddModelError("error", "Email or password is incorrect!");
                }
            }
            
            return View("Index",user);
        }

        public string getAvarta()
        {
            var email = Convert.ToString(HttpContext.Session["Email"]);
            var user = db.Users.First(u => u.Email.Equals(email));
            return user.Avarta;


        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Email"] = null;
            Session["Role"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}
