using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DataAccess;
using BusinessLogic.BusinessModels;

namespace EmployeeApplicationSystem.Models.ViewModels
{
    public class ApplicationViewModel
    {


        [Display(Name = "TodayDate", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        public DateTime TodayDate { get; set; }


        [Display(Name = "EmailManager", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldNotValid")]
        public string EmailManager { get; set; }


        [Display(Name = "FullName", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        public string FullName { get; set; }


        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldNotValid")]
        public string Email { get; set; }

        [Display(Name = "Mobile", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        [Phone(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldNotValid")]
        public string MobileNumber { get; set; }


        [Display(Name = "StartDate", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        public DateTime StartDate { get; set; }


        [Display(Name = "Services", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        public string Services { get; set; }


        [Display(Name = "AdittionalServices", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        public string AdittionalServices { get; set; }


        [Display(Name = "CompanyName", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        public string CompanyName { get; set; }


        [Display(Name = "AdittionalInformation", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        public string AdittionalInformation { get; set; }


        [Display(Name = "Buildings", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        public string Buildings { get; set; }

        [Display(Name = "RestrictedAccess", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        public string RestrictedAccess { get; set; }

        [Display(Name = "AccesLevel", ResourceType = typeof(Resource))]
        [StringLength(100, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "LengthError")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "RequiredErrorMsg")]
        public string AccesLevel { get; set; }

        [Display(Name = "PositionHired", ResourceType = typeof(Resource))]
        [Required]
        public int? SelectedPositionHired { set; get; }

        public List<PositionBusinessModel> ListPositionsHired { set; get; }



    }
}