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
                    FormsAuthentication.SetAuthCookie(user.Email,Convert.ToBoolean(user.RememberMe));
                    return RedirectToAction("Index", "Rolls");
                }
                else
                {
                    ModelState.AddModelError("error", "Email or password is incorrect!");
                }
            }
            
            return View("Index",user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}
