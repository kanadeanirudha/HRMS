using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeePHdGuideRecognisationDetailsViewModel
    {
        public EmployeePHdGuideRecognisationDetailsViewModel()
        {
            EmployeePHdGuideRecognisationDetailsDTO = new EmployeePHdGuideRecognisationDetails();
        }
        public EmployeePHdGuideRecognisationDetails EmployeePHdGuideRecognisationDetailsDTO
        {
            get;
            set;
        }

        //---------------------------------------   EmployeePHdGuideRecognisationDetails Properties  ------------------------------------------//
        public int ID
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.ID > 0) ? EmployeePHdGuideRecognisationDetailsDTO.ID : new int();
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.ID = value;
            }
        }
        public int EmployeeID
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.EmployeeID > 0) ? EmployeePHdGuideRecognisationDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.EmployeeID = value;
            }
        }
        [Display(Name = "DisplayName_GeneralBoardUniversityID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GeneralBoardUniversityIDRequired")]
        public int GeneralBoardUniversityID
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.GeneralBoardUniversityID > 0) ? EmployeePHdGuideRecognisationDetailsDTO.GeneralBoardUniversityID : new int();
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.GeneralBoardUniversityID = value;
            }
        }
        [Display(Name = "DisplayName_ApprovalSubjectName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ApprovalSubjectNameRequired")]
        public string ApprovalSubjectName
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.ApprovalSubjectName : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.ApprovalSubjectName = value;
            }
        }
        [Display(Name = "DisplayName_ApprovalFromDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ApprovalFromDateRequired")]
        public string ApprovalFromDate
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.ApprovalFromDate : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.ApprovalFromDate = value;
            }
        }
        [Display(Name = "DisplayName_ApprovalUptoDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ApprovalUptoDateRequired")]
        public string ApprovalUptoDate
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.ApprovalUptoDate : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.ApprovalUptoDate = value;
            }
        }
        [Display(Name = "DisplayName_UniversityApprovalNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityApprovalNumberRequired")]
        public string UniversityApprovalNumber
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.UniversityApprovalNumber : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.UniversityApprovalNumber = value;
            }
        }
        [Display(Name = "DisplayName_UniversityApprovalDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityApprovalDateRequired")]
        public string UniversityApprovalDate
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.UniversityApprovalDate : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.UniversityApprovalDate = value;
            }
        }
        [Display(Name = "DisplayName_NoOfCandidateCompletedPHd", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NoOfCandidateCompletedPHdRequired")]
        public int NoOfCandidateCompletedPHd
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.NoOfCandidateCompletedPHd > 0) ? EmployeePHdGuideRecognisationDetailsDTO.NoOfCandidateCompletedPHd : new int();
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.NoOfCandidateCompletedPHd = value;
            }
        }
        [Display(Name = "DisplayName_NumberOfCandidateRegistered", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NumberOfCandidateRegisteredRequired")]
        public int NumberOfCandidateRegistered
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.NumberOfCandidateRegistered > 0) ? EmployeePHdGuideRecognisationDetailsDTO.NumberOfCandidateRegistered : new int();
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.NumberOfCandidateRegistered = value;
            }
        }
        public string Remarks
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.Remarks : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.Remarks = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.CreatedBy > 0) ? EmployeePHdGuideRecognisationDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.ModifiedBy.HasValue) ? EmployeePHdGuideRecognisationDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.ModifiedDate.HasValue) ? EmployeePHdGuideRecognisationDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.DeletedBy.HasValue) ? EmployeePHdGuideRecognisationDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.DeletedDate.HasValue) ? EmployeePHdGuideRecognisationDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.DeletedDate = value;
            }
        }

        

        //---------------------------------------   EmployeePHdGuideStudentsDetails  Properties  ------------------------------------------//
        public int EmployeePHdGuideStudentsDetailsID
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null && EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsID > 0) ? EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsID : new int();
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsID = value;
            }
        }
        [Display(Name = "DisplayName_StudentName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StudentNameRequired")]
        public string StudentName
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.StudentName : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.StudentName = value;
            }
        }
        [Display(Name = "DisplayName_Synopsis", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SynopsisRequired")]
        public string Synopsis
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.Synopsis : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.Synopsis = value;
            }
        }
        [Display(Name = "DisplayName_PersuingFromDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PersuingFromDateRequired")]
        public string PersuingFromDate
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.PersuingFromDate : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.PersuingFromDate = value;
            }
        }
        [Display(Name = "DisplayName_PersuingUptoDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PersuingUptoDateRequired")]
        public string PersuingUptoDate
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.PersuingUptoDate : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.PersuingUptoDate = value;
            }
        }
        [Display(Name = "DisplayName_ApprovalStatus", ResourceType = typeof(AMS.Common.Resources))]
        public string ApprovalStatus
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.ApprovalStatus : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.ApprovalStatus = value;
            }
        }
        [Display(Name = "DisplayName_ApprovalDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ApprovalDateRequired")]
        public string ApprovalDate
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.ApprovalDate : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.ApprovalDate = value;
            }
        }

        [Display(Name = "DisplayName_EmployeePHdGuideStudentsDetailsRemarks", ResourceType = typeof(AMS.Common.Resources))]
        public string EmployeePHdGuideStudentsDetailsRemarks
        {
            get
            {
                return (EmployeePHdGuideRecognisationDetailsDTO != null) ? EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsRemarks : string.Empty;
            }
            set
            {
                EmployeePHdGuideRecognisationDetailsDTO.EmployeePHdGuideStudentsDetailsRemarks = value;
            }
        }
        public string errorMessage { get; set; }
      
    }
}
