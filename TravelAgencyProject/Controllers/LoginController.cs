using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgencyProject.Dal;
using TravelAgencyProject.Models;

namespace TravelAgencyProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SingUp()
        {
            return View("NewUser");
        }

        public ActionResult Success()
        {
            return View("Success");
        }
        public ActionResult Login()
        {

            Users user = new Users();
            user.Email = Request.Form["Email"];
            user.pass = Request.Form["pass"];
            var users = new UserDAL().Users;

            if (user.Email == "admin@gmail.com" && user.pass.Equals("admin"))
                return RedirectToAction("Index", "Flights");

            foreach (var u in users)
            {
                if (u.Email.Equals(user.Email) && u.pass.Equals(user.pass))
                    return RedirectToAction("SearchFlights", "Flights");
            }
            Session["currentuser"]=user;
            return View();
        }

        public ActionResult AddUser(Users user)
        {
            if (ModelState.IsValid)
            {
                var userDal = new UserDAL();
                userDal.Users.Add(user);
                userDal.SaveChanges();
                return RedirectToAction("Login", "Login");

            }

            return View();    
        }
    }
}
