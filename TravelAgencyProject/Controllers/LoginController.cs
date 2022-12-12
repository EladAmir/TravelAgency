using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelAgencyProject.Models;
using TravelAgencyProject.ViewModel;
using TravelAgencyProject.Dal;

namespace TravelAgencyProject.Controllers
{
    public class LoginController : Controller
    {

    public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowLoginPage()
        {
            return View("LoginPage");
        }

        public ActionResult AdminLogin()
        {

            return View("AddUser");
        }

        //public ActionResult EnterNewUser()
        //{
        //    UserDal dal = new UserDal();
        //    List<Users> objusers = dal.Users.ToList<Users>();
        //    UsersViewModel cvm = new UsersViewModel();
        //    cvm.user = new Users();
        //    cvm.users = objusers;
        //    return View(cvm);
        //}

        public ActionResult AddUser(Users user)
        {
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                //save user on DB
                dal.Users.Add(user);
                dal.SaveChanges();
                return View("LoginPage");

            }
            else
                return View("NewUser");

        }
        public ActionResult Submit(Users user)
        {
            UsersViewModel userVM = new UsersViewModel();
            UserDal dal = new UserDal();
            Users objuser = new Users();


            if (ModelState.IsValid)
            {
                objuser.Email = Request.Form["Email"].ToString();
                objuser.pass = Request.Form["pass"].ToString();
                //save user om DB
                dal.Users.Add(objuser);
                dal.SaveChanges();
                userVM.user = new Users();

            }
            else
                userVM.user = objuser;

            userVM.users = dal.Users.ToList<Users>();
            for( int i = 0; i < userVM.users.Count; i++)
            {
                if (user.Email == userVM.users[i].Email)
                {
                    if (user.pass == userVM.users[i].pass)
                        return View("Success", user);
                }

            }
            return View("LoginPage");
        }
        public Users GetUser()
        {
            Users objuser=new Users();
            //Console.WriteLine("wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww\n\n",objuser);
            ////objuser.FirstName = Request.Form["user.FirstName"].ToString();
            ////objuser.LastName = Request.Form["user.LastName"].ToString();
            objuser.Email = Request.Form["Email"].ToString();
            objuser.pass = Request.Form["pass"].ToString();
            return objuser;
        }

    }
}