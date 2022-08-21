using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Text.RegularExpressions;
namespace AMS.ViewModel
{
    public class OrganisationUniversityMasterBaseViewModel : IOrganisationUniversityMasterBaseViewModel
    {
        public OrganisationUniversityMasterBaseViewModel()
        {
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();

            ListGeneralCityMaster = new List<GeneralCityMaster>();

        }

        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }

        public List<GeneralCityMaster> ListGeneralCityMaster
        {
            get;
            set;
        }

        public string SelectedCityID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGeneralCityMasterItems
        {
            get
            {
                return new SelectList(ListGeneralCityMaster, "CityID", "Description");
            }
        }

    }

    public class CustomEmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();

                if (Regex.IsMatch(email, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.IgnoreCase))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(Resources.ValidationMessage_EmailIDValid);
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
    public class OrganisationUniversityMasterViewModel : IOrganisationUniversityMasterViewModel
    {

        public OrganisationUniversityMasterViewModel()
        {
            OrganisationUniversityMasterDTO = new OrganisationUniversityMaster();
        }

        public OrganisationUniversityMaster OrganisationUniversityMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null && OrganisationUniversityMasterDTO.ID > 0) ? OrganisationUniversityMasterDTO.ID : new int();
            }
            set
            {
                OrganisationUniversityMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_CityID", ResourceType = typeof(AMS.Common.Resources))]
        public int CityID
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null && OrganisationUniversityMasterDTO.CityID > 0) ? OrganisationUniversityMasterDTO.CityID : new int();
            }
            set
            {
                OrganisationUniversityMasterDTO.CityID = value;
            }
        }
      
      
  
        //[Required(ErrorMessage="University name should not be blank")]
        //[Display(Name = "University Name")]
        [Display(Name = "DisplayName_UniversityName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityNameRequired")]
        public string UniversityName
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.UniversityName : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.UniversityName = value;
            }
        }

        //[Required(ErrorMessage = "Establishment code should not be blank")]
        //[Display(Name = "Establishment Code")]
        [Display(Name = "DisplayName_EstablishmentCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EstablishmentCodeRequired")]
        public string EstablishmentCode
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.EstablishmentCode : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.EstablishmentCode = value;
            }
        }

        //[Required(ErrorMessage = "Foundation date should not be blank")]
        //[Display(Name = "University Foundation Datetime")]
        [Display(Name = "DisplayName_UniversityFoundationDatetime", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityFoundationDatetimeRequired")]
        public string UniversityFoundationDatetime
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.UniversityFoundationDatetime : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.UniversityFoundationDatetime = value;
            }
        }

       // [Required(ErrorMessage = "Foundation member should not be blank")]
        [Display(Name = "DisplayName_FounderMember", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FounderMemberRequired")]
        public string UniversityFounderMember
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.UniversityFounderMember : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.UniversityFounderMember = value;
            }
        }

       // [Required(ErrorMessage = "Address should not be blank")]
        [Display(Name = "DisplayName_Address1", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_Address1Required")]
        public string UniversityAddress1
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.UniversityAddress1 : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.UniversityAddress1 = value;
            }
        }

        [Display(Name = "DisplayName_UniversityAddress2", ResourceType = typeof(AMS.Common.Resources))]
        public string UniversityAddress2
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.UniversityAddress2 : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.UniversityAddress2 = value;
            }
        }

       // [Required(ErrorMessage = "Plot number should not be blank")]
        [Display(Name = "DisplayName_PlotNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PlotNumberRequired")]
        public string PlotNumber
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.PlotNumber : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.PlotNumber = value;
            }
        }

        //[Required(ErrorMessage = "Street Name should not be blank")]
        [Display(Name = "DisplayName_StreetNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StreetNumberRequired")]
        public string StreetNumber
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.StreetNumber : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.StreetNumber = value;
            }
        }

        //[Required(ErrorMessage = "Pin code should not be blank")]
        [Display(Name = "DisplayName_Pincode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PincodeRequired")]
        public string Pincode
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.Pincode : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.Pincode = value;
            }
        }

        //[Required(ErrorMessage = "Fax number should not be blank")]
        [Display(Name = "DisplayName_FaxNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FaxNumberRequired")]
        public string FaxNumber
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.FaxNumber : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.FaxNumber = value;
            }
        }

       // [Required(ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "DisplayName_PhoneNumberOffice", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PhoneNumberOfficeRequired")]
        public string PhoneNumberOffice
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.PhoneNumberOffice : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.PhoneNumberOffice = value;
            }
        }

      //  [Required(ErrorMessage = "Extention should not be blank")]
        [Display(Name = "DisplayName_Extention", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExtentionRequired")]
        public string Extention
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.Extention : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.Extention = value;
            }
        }

      //  [Required(ErrorMessage = "Please enter a valid mobile number.")]
        [Display(Name = "DisplayName_MobileNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MobileNumberRequired")]
        public string CellPhone
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.CellPhone : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.CellPhone = value;
            }
        }

        [Display(Name = "DisplayName_EmailId", ResourceType = typeof(AMS.Common.Resources))]
        [CustomEmailValidator]  
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmailIDRequired")]
        //[EmailAddress(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmailIDValid")]
       //[Display(Name = "Email ID")]
        //[Required(ErrorMessage = " Email ID should not be blank. ")]
        public string EmailID
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.EmailID : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.EmailID = value;
            }
        }

       // [Required(ErrorMessage = "Please enter university url.")]
        [Display(Name = "DisplayName_UniversityUrl", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityUrlRequired")]
        public string Url
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.Url : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.Url = value;
            }
        }


       [Display(Name = "DisplayName_OfficeComment", ResourceType = typeof(AMS.Common.Resources))]
        public string OfficeComment
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.OfficeComment : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.OfficeComment = value;
            }
        }


        [Display(Name = "DisplayName_MissionStatement", ResourceType = typeof(AMS.Common.Resources))]
        public string MissionStatement
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.MissionStatement : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.MissionStatement = value;
            }
        }


      [Display(Name = "DisplayName_UniversityReportPath", ResourceType = typeof(AMS.Common.Resources))]
        public string UniversityReportPath
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.UniversityReportPath : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.UniversityReportPath = value;
            }
        }


          [Display(Name = "DisplayName_UniversityShortName", ResourceType = typeof(AMS.Common.Resources))]
        public string UniversityShortName
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.UniversityShortName : string.Empty;
            }
            set
            {
                OrganisationUniversityMasterDTO.UniversityShortName = value;
            }
        }
        

        
          [Display(Name = "DisplayName_DefaultFlag", ResourceType = typeof(AMS.Common.Resources))]
        public bool DefaultFlag
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.DefaultFlag : false;
            }
            set
            {
                OrganisationUniversityMasterDTO.DefaultFlag = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationUniversityMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null && OrganisationUniversityMasterDTO.CreatedBy > 0) ? OrganisationUniversityMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationUniversityMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null) ? OrganisationUniversityMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationUniversityMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null && OrganisationUniversityMasterDTO.ModifiedBy.HasValue) ? OrganisationUniversityMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationUniversityMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null && OrganisationUniversityMasterDTO.ModifiedDate.HasValue) ? OrganisationUniversityMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationUniversityMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null && OrganisationUniversityMasterDTO.DeletedBy.HasValue) ? OrganisationUniversityMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationUniversityMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationUniversityMasterDTO != null && OrganisationUniversityMasterDTO.DeletedDate.HasValue) ? OrganisationUniversityMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationUniversityMasterDTO.DeletedDate = value;
            }
        }
       // [Required(ErrorMessage = "City name must be selected")]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CityIDRequired")]
        public string SelectedCityID
        {
            get;
            set;
        }
    }
}
