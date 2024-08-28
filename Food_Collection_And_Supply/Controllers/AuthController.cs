using Food_Collection_And_Supply.Database;
using Food_Collection_And_Supply.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Food_Collection_And_Supply.Controllers
{
    public class AuthController : Controller
    {
        private CommonRepo _repo = new CommonRepo();
        public ActionResult Register()
        {
            return View();
        }
        public string SaveUser(RegisterViewModel user)
        {
            return _repo.SaveUser(user);
        }
        public ActionResult Login()
        {
            return View();
        }
        public string LoginUser(RegisterViewModel user)
        {
            var res = _repo.Login(user.Email, user.Password);
            if (res.Status == "true")
            {
                Session["email"] = res.Email;
                Session["Role"] = res.Role;
                
            }

            return res.Status;
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        public string ResetPassword(string Email)
        {

            return _repo.ForgetPassword(Email);
        }
        public ActionResult Logout()
        {
            Session["email"] = null;
            Session["Role"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult UserDetails()
        {
            if (Session["email"] != null)
            {
                return View(_repo.GetUserByEmail(Session["email"].ToString()));
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
           
        }
        public string UpdateUser(RegisterViewModel user)
        {
            if (Session["email"] != null)
            {
                user.Email = Session["email"].ToString();
                return _repo.UpateUser(user);
            }
            else
            {
                return null;
            }
            
        }
    
    }
}