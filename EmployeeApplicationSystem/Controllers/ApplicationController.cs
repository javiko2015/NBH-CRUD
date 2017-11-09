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
        private EmployeeApplicationConnectionString db = new EmployeeApplicationConnectionString();


        [HttpGet]
        public ActionResult RegisterNewApplication()
        {
            var im = new AplicationInputModel();
            var logic = new AccountLogic();

            im.ListPositionsHired = logic.GetListPositions();

            return View(im);
        }
        

        [HttpPost]
        public ActionResult RegisterNewApplication(AplicationInputModel model)
        {
            try
            {
                var logic = new AccountLogic();

                if (ModelState.IsValid)
                {
                    var user = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginViewModel>(User.Identity.Name);
                    //do something
                    var bm = new ApplicationBusinessModel
                    {
                        TodayDate = model.TodayDate,
                        EmailManager = model.EmailManager,
                        FullName = model.FullName,
                        PositionHired = model.SelectedPositionHired.ToString(), //Selected radiobtn
                        Email = model.Email,
                        MobileNumber = model.MobileNumber,
                        StartDate = model.StartDate,
                        AdittionalServices = model.AdittionalServices,
                        AdittionalInformation = model.AdittionalInformation,
                        Buildings = model.Buildings,
                        RestrictedAccess = model.RestrictedAccess,
                        CompanyName=model.CompanyName,
                        Services=model.Services,
                        AccesLevel=model.AccesLevel,
                        UserId = user.UserId
                    };
                    
                    logic.RegisterNewApplication(bm);
                }
                else
                {
                    throw new Exception(Resource.FieldsNotValid);
                }


                model.ListPositionsHired = logic.GetListPositions();

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        

        // GET: Application
        public ActionResult Index()
        {
            var applications = db.Applications.Include(a => a.Applicant);
            return View(applications.ToList());
        }

        // GET: Application/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

      
        // GET: Application/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Applicants, "UserId", "MobileNumber", application.UserId);
            return View(application);
        }

        // POST: Application/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationId,UserId,TodayDate,EmailManager,PositionHired,StartDate,AditionalServices,AccessLevel,AditionalInformation,Building,RestrictedAccess")] Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Applicants, "UserId", "MobileNumber", application.UserId);
            return View(application);
        }

        // GET: Application/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: Application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
