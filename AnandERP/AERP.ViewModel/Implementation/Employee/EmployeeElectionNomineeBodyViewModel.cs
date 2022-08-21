using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeElectionNomineeBodyViewModel : IEmployeeElectionNomineeBodyViewModel
    {

        public EmployeeElectionNomineeBodyViewModel()
        {
            EmployeeElectionNomineeBodyDTO = new EmployeeElectionNomineeBody();
        }

        public EmployeeElectionNomineeBody EmployeeElectionNomineeBodyDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null && EmployeeElectionNomineeBodyDTO.ID > 0) ? EmployeeElectionNomineeBodyDTO.ID : new int();
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_GeneralBoardUniversityID", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_GeneralBoardUniversityIDRequired")]
        public int GeneralBoardUniversityID
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.GeneralBoardUniversityID : new int();
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.GeneralBoardUniversityID = value;
            }
        }

        [Display(Name = "DisplayName_NameOfBoardBody", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_NameOfBoardBodyRequired")]
        public string NameOfBoardBody
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.NameOfBoardBody : string.Empty;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.NameOfBoardBody = value;
            }
        }


        [Display(Name = "DisplayName_PostHeld", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PostHeldRequired")]
        public string PostHeld
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.PostHeld : string.Empty;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.PostHeld = value;
            }
        }

        [Display(Name = "DisplayName_FromDate", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_FromDateRequired")]
        public string FromDate
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.FromDate : string.Empty;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.FromDate = value;
            }
        }

        [Display(Name = "DisplayName_ToDate", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ToDateRequired")]
        public string ToDate
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.ToDate : string.Empty;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.ToDate = value;
            }
        }

        [Display(Name = "DisplayName_Remarks", ResourceType = typeof(Resources))]
        public string Remarks
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.Remarks : string.Empty;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.Remarks = value;
            }
        }
        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.IsActive : false;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.IsActive = value;
            }
        }

        public string InActiveReason
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.InActiveReason : string.Empty;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.InActiveReason = value;
            }
        }
        public string InActiveDate
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.InActiveDate : string.Empty;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.InActiveDate = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.IsDeleted : false;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null && EmployeeElectionNomineeBodyDTO.CreatedBy > 0) ? EmployeeElectionNomineeBodyDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null) ? EmployeeElectionNomineeBodyDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null && EmployeeElectionNomineeBodyDTO.ModifiedBy.HasValue) ? EmployeeElectionNomineeBodyDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null && EmployeeElectionNomineeBodyDTO.ModifiedDate.HasValue) ? EmployeeElectionNomineeBodyDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null && EmployeeElectionNomineeBodyDTO.DeletedBy.HasValue) ? EmployeeElectionNomineeBodyDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeElectionNomineeBodyDTO != null && EmployeeElectionNomineeBodyDTO.DeletedDate.HasValue) ? EmployeeElectionNomineeBodyDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeElectionNomineeBodyDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

