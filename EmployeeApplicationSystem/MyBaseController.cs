using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApplicationSystem
{
    public class MyBaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            var lang = string.Empty;
            var langCookie = Request.Cookies["culture"];
            if (langCookie != null)
            {
                lang = langCookie.Value;
            }
            else
            {
                var userLanguaje = Request.UserLanguages;
                var userLang = userLanguaje != null ? userLanguaje[0] : string.Empty;
                if (!string.IsNullOrEmpty(userLang))
                {
                    lang = userLang;
                }
                else
                {
                    lang = MultilanguageManager.GetDefaultLanguage();
                }
            }

            new MultilanguageManager().SetLanguage(lang);

            //Assigning roles for authentication
            //if (Request.IsAuthenticated)
            //{
            //    var logic = new Logic();
            //    var user = logic.DecodeStringIntoLoginModel(User.Identity.Name);
            //    string[] roles = { user.Role };
            //    HttpContext.User = new GenericPrincipal(User.Identity, roles);
            //}

            return base.BeginExecuteCore(callback, state);
        }
    }
}