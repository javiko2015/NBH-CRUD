using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace EmployeeApplicationSystem
{

    public class MultilanguageManager
    {
        public static List<Language> AvaliableLanguages = new List<Language>
        {
            new Language { FullLanguageName = "English",Culture= "en"},
            new Language { FullLanguageName = "Spanish", Culture = "es"}
        };

        public static bool IsLanguageAvaliable(string language)
        {
            return AvaliableLanguages.Where(a => a.Culture == language).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvaliableLanguages[0].Culture;
        }

        public void SetLanguage(string language)
        {
            try
            {
                if (!IsLanguageAvaliable(language))
                {
                    language = GetDefaultLanguage();
                }

                var cultureInfo = new CultureInfo(language);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);

                var langCookie = new HttpCookie("culture", language);
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);
            }
            catch (Exception)
            {
            }
        }
    }

    public class Language
    {
        public string FullLanguageName { get; set; }
        public string Culture { get; set; }
    }
}