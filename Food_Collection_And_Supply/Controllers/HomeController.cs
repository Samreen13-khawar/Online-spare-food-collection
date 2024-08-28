using Food_Collection_And_Supply.Database;
using Food_Collection_And_Supply.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Food_Collection_And_Supply.Controllers
{
    public class HomeController : Controller
    {
        private CommonRepo _repo = new CommonRepo();
        public ActionResult Index()
        {
            if (Session["email"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult AddDonaiters()
        {
            if (Session["email"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult AddNeedy()
        {
            if (Session["email"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult UpdateUser(int Id)
        {
            if (Session["email"] != null)
            {
                var user = _repo.GetUserById(Id);
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public string SaveUser(RegisterViewModel user)
        {
            return _repo.UpdateUser(user);
        }
        public ActionResult GetDonaiters()
        {
            if (Session["email"] != null)
            {
                return View(_repo.GetDonaiters());
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult GetNeedy()
        {
            if (Session["email"] != null)
            {
                return View(_repo.GetNeedy());
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public string DeleteUser(int id)
        {
            return _repo.DeleteUser(id);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AddFood(int Id)
        {
            if (Session["email"] != null)
            {
                DonatedFood food = _repo.GetMyDonatedFoods(Session["email"].ToString()).FirstOrDefault(x => x.Id == Id);
                if (food == null) { food = new DonatedFood(); food.ManufacturedDate = DateTime.Now; food.ExpiryDate = DateTime.Now; }

                return View(food);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public string SaveFood(FoodViewModel food)
        {
            if (Session["email"] != null)
            {
                food.DonatedUserEmail = Session["email"].ToString();
                return _repo.SaveFood(food);
            }
            return "";

        }
        public ActionResult GetmyDonatedFoods()
        {
            if (Session["email"] != null)
            {
                return View(_repo.GetMyDonatedFoods(Session["email"].ToString()));
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult GetAllDonatedFoods()
        {
            if (Session["email"] != null)
            {
                return View(_repo.GetAllDonatedFoods());
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public ActionResult GetAllAvailableFoods()
        {
            if (Session["email"] != null)
            {
                return View(_repo.GetAllAvailableFoods());
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public string SendFood(int id)
        {
            return _repo.SendFood(id);
        }
        public string SendToStock(int id)
        {
            return _repo.AddToStock(id);
        }

        public ActionResult RequestFood(int Id)
        {
            var foodRequest = _repo.GetFoodRequest(Session["email"].ToString()).FirstOrDefault(x => x.Id == Id);
            if (foodRequest == null) { foodRequest = new FoodRequest(); }
            return View(foodRequest);
        }
        public string RequestForFood(int Id,string Name,string Discription,int FamilyMember)
        {
            if (Session["email"] != null)
            {
                return _repo.RequestFood(Id,Name,Discription, Session["email"].ToString(), FamilyMember);
            }
            return "";

        }
        public ActionResult GetFoodRequests()
        {
            if (Session["email"] != null)
            {
                return View(_repo.GetFoodRequest(Session["email"].ToString()));
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public string SendFoodRequest(int id)
        {
            return _repo.SendFoodRequest(id);
        }

        public ActionResult NeedyRequests()
        {
            if (Session["email"] != null)
            {
                return View(_repo.GetAllFoodRequest());
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public string EvaluateRequest(int id,string Status)
        {
            return _repo.UpdateRequest(id,Status);
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            if (Session["email"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public string ChangePassword(string NewPassword, string OldPassword)
        {
            return _repo.ChangePassword(NewPassword,OldPassword, Session["email"].ToString());
        }
        public ActionResult SendFoodToNeedy()
        {
            if (Session["email"] != null)
            {   var food= _repo.GeCollectionCenterFoods();
                var request= _repo.GetAcceptedFoodRequest();
                ViewBag.request = request;
                ViewBag.food = food;

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }

        public string Sent(int RequestId, int FoodId)
        {
           return _repo.SendFoodToNeedy(RequestId, FoodId);

        }
    }
}