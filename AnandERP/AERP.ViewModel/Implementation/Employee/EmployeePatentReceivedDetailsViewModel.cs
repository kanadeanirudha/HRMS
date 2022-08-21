using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeePatentReceivedDetailsViewModel : IEmployeePatentReceivedDetailsViewModel
    {

        public EmployeePatentReceivedDetailsViewModel()
        {
            EmployeePatentReceivedDetailsDTO = new EmployeePatentReceivedDetails();
        }

        public EmployeePatentReceivedDetails EmployeePatentReceivedDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null && EmployeePatentReceivedDetailsDTO.ID > 0) ? EmployeePatentReceivedDetailsDTO.ID : new int();
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null) ? EmployeePatentReceivedDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.EmployeeID = value;
            }
        }


        [Display(Name = "DisplayName_SubjectOfPatent", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_SubjectOfPatentRequired")]
        public string SubjectOfPatent
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null) ? EmployeePatentReceivedDetailsDTO.SubjectOfPatent : string.Empty;
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.SubjectOfPatent = value;
            }
        }


        [Display(Name = "DisplayName_DateOfApplication", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DateOfApplicationRequired")]
        public string DateOfApplication
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null) ? EmployeePatentReceivedDetailsDTO.DateOfApplication : string.Empty;
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.DateOfApplication = value;
            }
        }


        [Display(Name = "DisplayName_PatentApprovalStatus", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PatentApprovalStatusRequired")]
        public string PatentApprovalStatus
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null) ? EmployeePatentReceivedDetailsDTO.PatentApprovalStatus : string.Empty;
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.PatentApprovalStatus = value;
            }
        }


        [Display(Name = "DisplayName_DateOfApproval", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DateOfApprovalRequired")]
        public string DateOfApproval
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null) ? EmployeePatentReceivedDetailsDTO.DateOfApproval : string.Empty;
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.DateOfApproval = value;
            }
        }

        [Display(Name = "DisplayName_Remarks", ResourceType = typeof(Resources))]
        public string Remarks
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null) ? EmployeePatentReceivedDetailsDTO.Remarks : string.Empty;
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.Remarks = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
      //  [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null) ? EmployeePatentReceivedDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.IsActive = value;
            }
        }



        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null) ? EmployeePatentReceivedDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null && EmployeePatentReceivedDetailsDTO.CreatedBy > 0) ? EmployeePatentReceivedDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null) ? EmployeePatentReceivedDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null && EmployeePatentReceivedDetailsDTO.ModifiedBy.HasValue) ? EmployeePatentReceivedDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null && EmployeePatentReceivedDetailsDTO.ModifiedDate.HasValue) ? EmployeePatentReceivedDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null && EmployeePatentReceivedDetailsDTO.DeletedBy.HasValue) ? EmployeePatentReceivedDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeePatentReceivedDetailsDTO != null && EmployeePatentReceivedDetailsDTO.DeletedDate.HasValue) ? EmployeePatentReceivedDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeePatentReceivedDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

