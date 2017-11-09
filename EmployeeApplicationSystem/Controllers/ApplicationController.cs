using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using BusinessLogic;
using BusinessLogic.BusinessModels;
using EmployeeApplicationSystem.Models.InputModels;
using EmployeeApplicationSystem.Models.ViewModels;
using Newtonsoft.Json;

namespace EmployeeApplicationSystem.Controllers
{
    [Authorize]
    public class ApplicationController : MyBaseController
    {      

        // GET: Register new application
        [HttpGet]
        public ActionResult RegisterNewApplication()
        {
            var im = new AplicationInputModel();
            var logic = new AccountLogic();

            im.ListPositionsHired = logic.GetListPositions();
            im.ListServices = logic.GetListServices();
            im.ListCompanies = logic.GetListCompanies();
            im.ListBuilds = logic.GetBuilds();

            return View(im);
        }

        // POST: Register new application
        [HttpPost]
        public ActionResult RegisterNewApplication(AplicationInputModel model)
        {
            try
            {
                var logic = new AccountLogic();

                    var user = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginViewModel>(User.Identity.Name);
                    //do something
                    var bm = new ApplicationBusinessModel
                    {
                        TodayDate = model.TodayDate,
                        EmailManager = model.EmailManager,
                        FullName = model.FullName,
                        PositionHired = logic.GetPositionName(logic.GetListPositions(), model.SelectedPositionHired), 
                        Email = model.Email,
                        MobileNumber = model.MobileNumber,
                        StartDate = model.StartDate,
                        AdittionalServices = model.AdittionalServices,
                        AdittionalInformation = model.AdittionalInformation,
                        Buildings = logic.ConcatBuilds(model.ListBuilds),
                        RestrictedAccess = model.RestrictedAccess,
                        CompanyName= logic.GetCompanyName(logic.GetListCompanies(), model.SelectedCompany),
                        Services = logic.ConcatServices(model.ListServices),                    
                        UserId = user.UserId
                    };
                    
                model.ListPositionsHired = logic.GetListPositions();
                return  RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }        

        // GET: List applications
        public ActionResult Index()
        {
            var user = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginViewModel>(User.Identity.Name);
            var logic = new AccountLogic();
            List<ApplicationBusinessModel> aplications = new List<ApplicationBusinessModel>();
            aplications = logic.ApplicationsList(user.UserId);

            return View(aplications.AsEnumerable());
        }

        // GET:  Details application
        public ActionResult Details(long? id)
        {
            var logic = new AccountLogic();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationBusinessModel application = logic.GetOneApplication(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }            

        // GET: Delete application
        public ActionResult Delete(long? id)
        {
            var logic = new AccountLogic();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationBusinessModel application = logic.GetOneApplication(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST:  Delete application
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var logic = new AccountLogic();
            ApplicationBusinessModel application = logic.GetOneApplication(id);
            logic.DeleteApplication(application);
          
            return RedirectToAction("Index");
        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
