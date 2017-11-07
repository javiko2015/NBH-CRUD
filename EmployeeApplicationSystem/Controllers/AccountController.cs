using BusinessLogic;
using BusinessLogic.BusinessModels;
using EmployeeApplicationSystem.Models.InputModels;
using EmployeeApplicationSystem.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeApplicationSystem.Controllers
{
    public class AccountController : MyBaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterNewApplicant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNewApplicant(ApplicantInputModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //do something
                    var bm = new ApplicantBusinessModel
                    {
                        Email = model.Email,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        MobileNumber = model.MobileNumber,
                        Password = model.Password,
                        UserName = model.UserName
                    };
                    
                    var logic = new AccountLogic();

                    logic.RegisterNewApplicant(bm);

                    var authenticatedUser = logic.Login(bm.UserName, bm.Password);
                    if (!string.IsNullOrEmpty(authenticatedUser.UserName))
                    {
                        var vm = new LoginViewModel
                        {
                            CompanyName = authenticatedUser.CompanyName,
                            Email = authenticatedUser.Email,
                            FirstName = authenticatedUser.FirstName,
                            LastName = authenticatedUser.LastName,
                            MobileNumber = authenticatedUser.MobileNumber,
                            UserName = authenticatedUser.UserName,
                            UserType = authenticatedUser.UserType
                        };

                        FormsAuthentication.SetAuthCookie(JsonConvert.SerializeObject(vm), true);
                    }
                }
                else
                {
                    throw new Exception(Resource.FieldsNotValid);
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }

        public ActionResult RegisterNewManager()
        {
            return View();
        }

/*
        [HttpPost]
        public ActionResult ListApplications(long userid)
        {
            var s = new AccountLogic();

            var applicationsUser = s.ApplicationsList(userid);








            return View();
        }*/






        public ActionResult Authenticate()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginInputModel user)
        {
            if (ModelState.IsValid)
            {
                var s = new AccountLogic();
                var authenticatedUser = s.Login(user.Username, user.Password);
                if (!string.IsNullOrEmpty(authenticatedUser.UserName))
                {
                    var vm = new LoginViewModel
                    {
                        CompanyName = authenticatedUser.CompanyName,
                        Email = authenticatedUser.Email,
                        FirstName = authenticatedUser.FirstName,
                        LastName = authenticatedUser.LastName,
                        MobileNumber = authenticatedUser.MobileNumber,
                        UserName = authenticatedUser.UserName,
                        UserType = authenticatedUser.UserType
                    };

                    FormsAuthentication.SetAuthCookie(JsonConvert.SerializeObject(vm), user.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", Resource.UserOrPasswordIncorrect);
                }
            }
            return View(user);
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}