using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeOtherCollegeSpecialLectureDetailsViewModel : IEmployeeOtherCollegeSpecialLectureDetailsViewModel
    {

        public EmployeeOtherCollegeSpecialLectureDetailsViewModel()
        {
            EmployeeOtherCollegeSpecialLectureDetailsDTO = new EmployeeOtherCollegeSpecialLectureDetails();
        }

        public EmployeeOtherCollegeSpecialLectureDetails EmployeeOtherCollegeSpecialLectureDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null && EmployeeOtherCollegeSpecialLectureDetailsDTO.ID > 0) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.ID : new int();
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_InstituteName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_InstituteNameRequired")]
        public string InstituteName
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.InstituteName : string.Empty;
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.InstituteName = value;
            }
        }

        [Display(Name = "DisplayName_InstituteAddress", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_InstituteAddressRequired")]
        public string InstituteAddress
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.InstituteAddress : string.Empty;
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.InstituteAddress = value;
            }
        }

        [Display(Name = "DisplayName_TopicOfLecture", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_TopicOfLectureRequired")]
        public string TopicOfLecture
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.TopicOfLecture : string.Empty;
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.TopicOfLecture = value;
            }
        }

        [Display(Name = "DisplayName_DateOfLectureDelivered", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DateOfLectureDeliveredRequired")]
        public string DateOfLectureDelivered
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.DateOfLectureDelivered : string.Empty;
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.DateOfLectureDelivered = value;
            }
        }

        [Display(Name = "DisplayName_Remarks", ResourceType = typeof(Resources))]
        public string Remarks
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.Remarks : string.Empty;
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.Remarks = value;
            }
        }
     
        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null && EmployeeOtherCollegeSpecialLectureDetailsDTO.CreatedBy > 0) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null && EmployeeOtherCollegeSpecialLectureDetailsDTO.ModifiedBy.HasValue) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null && EmployeeOtherCollegeSpecialLectureDetailsDTO.ModifiedDate.HasValue) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null && EmployeeOtherCollegeSpecialLectureDetailsDTO.DeletedBy.HasValue) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeOtherCollegeSpecialLectureDetailsDTO != null && EmployeeOtherCollegeSpecialLectureDetailsDTO.DeletedDate.HasValue) ? EmployeeOtherCollegeSpecialLectureDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeOtherCollegeSpecialLectureDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

