using Food_Collection_And_Supply.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services.Description;

namespace Food_Collection_And_Supply.Database
{
    public class CommonRepo
    {
        private FoodCollectionDBEntities _db = new FoodCollectionDBEntities();


        public string SaveUser(RegisterViewModel newUser)
        {
            try
            {
                var u = _db.Users.FirstOrDefault(x => x.Email == newUser.Email);
                if (u == null)
                {
                    User user = new User();
                    user.Email = newUser.Email;
                    user.FirstName = newUser.FirstName;
                    user.LastName = newUser.LastName;

                    user.PhoneNo = newUser.PhoneNo;
                    user.Address = newUser.Address;
                    user.City = newUser.City;

                    user.PasswordHash = Base64Encode(newUser.Password);
                    user.Type = newUser.Type;

                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return "true";
                }
                else
                {
                    return "Email Already Exist";
                }
            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }

        }
        public string UpdateUser(RegisterViewModel newUser)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(x => x.Id == newUser.Id);
                if (user != null)
                {

                    user.FirstName = newUser.FirstName;
                    user.LastName = newUser.LastName;

                    user.PhoneNo = newUser.PhoneNo;
                    user.Address = newUser.Address;
                    user.City = newUser.City;


                    user.Type = newUser.Type;
                    _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return "true";
                }
                else
                {
                    return "Not Found";
                }
            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }

        }

        public LoginViewModel Login(string email, string password)
        {
            var x = new LoginViewModel();
            try
            {

                var user = _db.Users.FirstOrDefault(z => z.Email == email);
                if (user != null)
                {
                    if (user.PasswordHash == Base64Encode(password))
                    {
                        x.Status = "true";
                        x.Email = user.Email;
                        x.Role = user.Type;
                    }
                    else
                    {
                        x.Status = "Invalid Password";
                    }
                }
                else
                {
                    x.Status = "User Not Exist";
                }
            }
            catch (Exception ex)
            {
                x.Status = "Something went wrong";
            }

            return x;
        }
        public string ChangePassword(string newpassword, string oldpassword,string email)
        {
            string  x = "";
            try
            {

                var user = _db.Users.FirstOrDefault(z => z.Email == email);
                if (user != null)
                {
                    if (user.PasswordHash == Base64Encode(oldpassword))
                    {
                        user.PasswordHash= Base64Encode(newpassword);

                        _db.Entry(user).State = EntityState.Modified;
                        _db.SaveChanges();
                        x= "true";
                    }
                    else
                    {
                        x = "Invalid Old Password";
                    }
                }
                else
                {
                    x = "User Not Exist";
                }
            }
            catch (Exception ex)
            {
                x = "Something went wrong";
            }

            return x;
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string ForgetPassword(string email)
        {
            try
            {
                var u = _db.Users.FirstOrDefault(x => x.Email == email);
                if (u != null)
                {
                    u.PasswordHash = Base64Encode("136");
                    _db.Entry(u).State = EntityState.Modified;
                    _db.SaveChanges();
                    return "true";
                }
                else
                {
                    return "Invalid User";
                }
            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }

        }
        public List<User> GetDonaiters()
        {
            return _db.Users.Where(x => x.Type == "Donator").ToList();
        }
        public List<User> GetNeedy()
        {
            return _db.Users.Where(x => x.Type == "Needy").ToList();
        }
        public string DeleteUser(int Id)
        {
            bool status = false;
            try
            {

                var cpt = _db.Users.FirstOrDefault(x => x.Id == Id);
                _db.Users.Remove(cpt);
                _db.SaveChanges();
                status = true;

            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }
            return status == true ? "Deleted" : "false";

        }
        public string SaveFood(FoodViewModel fwm)
        {
            try
            {
                if (fwm.Id == 0)
                {
                    var user = _db.Users.FirstOrDefault(x => x.Email == fwm.DonatedUserEmail);
                    DonatedFood df = new DonatedFood();
                    df.Quantity = fwm.Quantity;
                    df.FoodName = fwm.FoodName;
                    df.Status = "Saved";
                    df.ManufacturedDate = Convert.ToDateTime(fwm.ManufacturedDate);
                    df.ExpiryDate = Convert.ToDateTime(fwm.ExpiryDate);
                    df.DonatedBy = fwm.DonatedBy;
                    df.City = fwm.City;
                    df.DonatedBy = user.Id;
                    _db.DonatedFoods.Add(df);
                    _db.SaveChanges();
                    return "true";
                }
                else
                {
                    var user = _db.Users.FirstOrDefault(x => x.Email == fwm.DonatedUserEmail);
                    DonatedFood df = _db.DonatedFoods.FirstOrDefault(x => x.Id == fwm.Id);
                    df.Quantity = fwm.Quantity;
                    df.FoodName = fwm.FoodName;
                    df.Status = "Saved";
                    df.ManufacturedDate = Convert.ToDateTime(fwm.ManufacturedDate);
                    df.ExpiryDate = Convert.ToDateTime(fwm.ExpiryDate);
                    df.DonatedBy = fwm.DonatedBy;
                    df.City = fwm.City;
                    df.DonatedBy = user.Id;
                    _db.Entry(df).State = EntityState.Modified;
                    _db.SaveChanges();
                    return "true";
                }

            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }

        }
        public List<DonatedFood> GetMyDonatedFoods(string email)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == email);

            return _db.DonatedFoods.Where(x => x.DonatedBy == user.Id).ToList();
        }
        public List<DonatedFood> GetAllDonatedFoods()
        {
            return _db.DonatedFoods.Where(x => x.Status == "Delivery in Progress").ToList();
        }
        public List<DonatedFood> GeCollectionCenterFoods()
        {
            return _db.DonatedFoods.Where(x => x.Status == "Reached at Collection Center").ToList();
        }
        public List<DonatedFood> GetAllAvailableFoods()
        {
            return _db.DonatedFoods.Where(x => x.Status == "Reached at Collection Center").ToList();
        }
        public User GetUserByEmail(string email)
        {
            try
            {
                var u = _db.Users.FirstOrDefault(x => x.Email == email);
                if (u == null)
                {

                    return null;
                }
                else
                {
                    return u;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public User GetUserById(int Id)
        {
            try
            {
                var u = _db.Users.FirstOrDefault(x => x.Id == Id);
                if (u == null)
                {
                    return null;
                }
                else
                {
                    return u;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public string UpateUser(RegisterViewModel newUser)
        {
            try
            {
                var u = _db.Users.FirstOrDefault(x => x.Email == newUser.Email);
                if (u != null)
                {

                    u.Email = newUser.Email;
                    u.FirstName = newUser.FirstName;
                    u.LastName = newUser.LastName;

                    u.PhoneNo = newUser.PhoneNo;
                    u.Address = newUser.Address;
                    u.City = newUser.City;

                    _db.Entry(u).State = EntityState.Modified;
                    _db.SaveChanges();
                    return "true";
                }
                else
                {
                    return "Invalid User";
                }
            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }

        }
        public string SendFood(int Id)
        {
            bool status = false;
            try
            {

                var cpt = _db.DonatedFoods.FirstOrDefault(x => x.Id == Id);
                cpt.Status = "Delivery in Progress";
                _db.Entry(cpt).State = EntityState.Modified;
                _db.SaveChanges();
                status = true;

            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }
            return status == true ? "send" : "false";

        }
        public string AddToStock(int Id)
        {
            bool status = false;
            try
            {

                var cpt = _db.DonatedFoods.FirstOrDefault(x => x.Id == Id);
                cpt.Status = "Reached at Collection Center";
                _db.Entry(cpt).State = EntityState.Modified;
                _db.SaveChanges();
                status = true;

            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }
            return status == true ? "send" : "false";

        }
        public string RequestFood(int Id, string Name, string Discription, string email,int FamilyMember)
        {
            try
            {
                if (Id == 0)
                {
                    var user = _db.Users.FirstOrDefault(x => x.Email == email);
                    FoodRequest df = new FoodRequest();
                    df.FoodName = Name;
                    df.FkUser = user.Id;
                    df.Discription = Discription;
                    df.City = user.City;
                    df.Status = "initiated";
                    df.FamilyMember =FamilyMember;
                    _db.FoodRequests.Add(df);
                    _db.SaveChanges();
                    return "true";
                }
                else
                {
                    var user = _db.Users.FirstOrDefault(x => x.Email == email);
                    FoodRequest df = _db.FoodRequests.FirstOrDefault(x => x.Id==Id);
                    df.FoodName = Name;
                    df.FkUser = user.Id;
                    df.Status = "initiated";
                    df.Discription = Discription;
                    df.City = user.City;
                    df.FamilyMember = FamilyMember;
                    _db.Entry(df).State = EntityState.Modified;
                    _db.SaveChanges();
                    return "true";
                }

            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }

        }
        public List<FoodRequest> GetFoodRequest(string email)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(x => x.Email == email);

                return _db.FoodRequests.Where(x => x.FkUser==user.Id).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<FoodRequest> GetAllFoodRequest()
        {
            try
            {
               

                return _db.FoodRequests.Where(x => x.Status != "initiated").ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public List<FoodRequest> GetAcceptedFoodRequest()
        {
            try
            {


                return _db.FoodRequests.Where(x => x.Status == "Accepted").ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string SendFoodRequest(int Id)
        {
            bool status = false;
            try
            {

                var cpt = _db.FoodRequests.FirstOrDefault(x => x.Id == Id);
                cpt.Status = "Request Sent To Collection Center";
                _db.Entry(cpt).State = EntityState.Modified;
                _db.SaveChanges();
                status = true;

            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }
            return status == true ? "send" : "false";

        }
        public string UpdateRequest(int Id,string statuss)
        {
            bool status = false;
            try
            {

                var cpt = _db.FoodRequests.FirstOrDefault(x => x.Id == Id);
                cpt.Status =statuss;
                _db.Entry(cpt).State = EntityState.Modified;
                _db.SaveChanges();
                status = true;

            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }
            return status == true ? "send" : "false";

        }

        public string SendFoodToNeedy(int requestId,int foodId)
        {
            bool status = false;
            try
            {

                var cpt = _db.FoodRequests.FirstOrDefault(x => x.Id == requestId);
                cpt.Status = "Sent - Done";
                _db.Entry(cpt).State = EntityState.Modified;
                _db.SaveChanges();

                var cpt1 = _db.DonatedFoods.FirstOrDefault(x => x.Id == foodId);
                cpt1.Status = "Sent To Needy - Done";
                _db.Entry(cpt1).State = EntityState.Modified;
                _db.SaveChanges();
                status = true;

            }
            catch (Exception ex)
            {
                return "Something went wrong";
            }
            return status == true ? "send" : "false";

        }

    }
}