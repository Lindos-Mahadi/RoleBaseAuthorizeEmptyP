using ConfigureIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ConfigureIdentity.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MemberShip memberShip)
        {
            using(var context = new BizzNTekEntities1())
            {
                bool isValid = context.Users.Any(x => x.UserName == memberShip.UserName && x.Password == memberShip.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(memberShip.UserName, false);
                    return RedirectToAction("Index", "Employee");
                }
                ModelState.AddModelError("", "Invalid UserName or Password");
                return View();
            }
            
        }

        // GET: Account
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User model)
        {
            using (var context = new BizzNTekEntities1())
            {
                context.Users.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}