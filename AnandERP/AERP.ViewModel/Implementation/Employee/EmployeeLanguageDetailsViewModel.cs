using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeLanguageDetailsViewModel
    {

        public EmployeeLanguageDetailsViewModel()
        {
            EmployeeLanguageDetailsDTO = new EmployeeLanguageDetails();
        }

        public EmployeeLanguageDetails EmployeeLanguageDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null && EmployeeLanguageDetailsDTO.ID > 0) ? EmployeeLanguageDetailsDTO.ID : new int();
            }
            set
            {
                EmployeeLanguageDetailsDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null && EmployeeLanguageDetailsDTO.EmployeeID > 0) ? EmployeeLanguageDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeLanguageDetailsDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string EmployeeName
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null) ? EmployeeLanguageDetailsDTO.EmployeeName : string.Empty;
            }
            set
            {
                EmployeeLanguageDetailsDTO.EmployeeName = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeCodeRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string EmployeeCode
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null) ? EmployeeLanguageDetailsDTO.EmployeeCode : string.Empty;
            }
            set
            {
                EmployeeLanguageDetailsDTO.EmployeeCode = value;
            }
        }

        public int LanguageID
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null && EmployeeLanguageDetailsDTO.LanguageID > 0) ? EmployeeLanguageDetailsDTO.LanguageID : new int();
            }
            set
            {
                EmployeeLanguageDetailsDTO.LanguageID = value;
            }
        }


        [Display(Name = "DisplayName_LanguageName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LanguageNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string LanguageName
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null) ? EmployeeLanguageDetailsDTO.LanguageName : string.Empty;
            }
            set
            {
                EmployeeLanguageDetailsDTO.LanguageName = value;
            }
        }


        [Display(Name = "DisplayName_CanRead", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CanReadRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string CanRead
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null) ? EmployeeLanguageDetailsDTO.CanRead : string.Empty;
            }
            set
            {
                EmployeeLanguageDetailsDTO.CanRead = value;
            }
        }

        [Display(Name = "DisplayName_CanWrite", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CanWriteRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string CanWrite
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null) ? EmployeeLanguageDetailsDTO.CanWrite : string.Empty;
            }
            set
            {
                EmployeeLanguageDetailsDTO.CanWrite = value;
            }
        }

        [Display(Name = "DisplayName_CanSpeak", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CanSpeakRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string CanSpeak
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null) ? EmployeeLanguageDetailsDTO.CanSpeak : string.Empty;
            }
            set
            {
                EmployeeLanguageDetailsDTO.CanSpeak = value;
            }
        }

        public string SelectedIDs
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null) ? EmployeeLanguageDetailsDTO.SelectedIDs : string.Empty;
            }
            set
            {
                EmployeeLanguageDetailsDTO.SelectedIDs = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null) ? EmployeeLanguageDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeeLanguageDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null) ? EmployeeLanguageDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeeLanguageDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null && EmployeeLanguageDetailsDTO.CreatedBy > 0) ? EmployeeLanguageDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeLanguageDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null) ? EmployeeLanguageDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeLanguageDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null && EmployeeLanguageDetailsDTO.ModifiedBy.HasValue) ? EmployeeLanguageDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeLanguageDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null && EmployeeLanguageDetailsDTO.ModifiedDate.HasValue) ? EmployeeLanguageDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeLanguageDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null && EmployeeLanguageDetailsDTO.DeletedBy.HasValue) ? EmployeeLanguageDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeLanguageDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeLanguageDetailsDTO != null && EmployeeLanguageDetailsDTO.DeletedDate.HasValue) ? EmployeeLanguageDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeLanguageDetailsDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}
