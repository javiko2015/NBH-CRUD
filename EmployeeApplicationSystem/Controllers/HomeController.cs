using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApplicationSystem.Controllers
{
    public class HomeController : MyBaseController
    {
        public ActionResult Index()
        {
            return View();
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


        public ActionResult ChangeLanguage(string language, string returnUrl)
        {
            new MultilanguageManager().SetLanguage(language);
            //if (Request.IsAuthenticated)
            //{
            //    var logic = new Logic();
            //    var user = logic.DecodeStringIntoLoginModel(User.Identity.Name);
            //    var loginData = logic.GetLoginModelByEmail(user.Email);
            //    FormsAuthentication.SignOut();
            //    FormsAuthentication.SetAuthCookie(loginData.ToString(), true);
            //}
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Redirect(returnUrl);
            }
        }
    }
}