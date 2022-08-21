using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeProjectWorksMasterViewModel : IEmployeeProjectWorksMasterViewModel
    {
        public EmployeeProjectWorksMasterViewModel()
        {
            EmployeeProjectWorksMasterDTO = new EmployeeProjectWorksMaster();
        }
        public EmployeeProjectWorksMaster EmployeeProjectWorksMasterDTO
        {
            get;
            set;
        }

        //---------------------------------------   EmployeeProjectWorksMaster Properties  ------------------------------------------//
        public int ID
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null && EmployeeProjectWorksMasterDTO.ID > 0) ? EmployeeProjectWorksMasterDTO.ID : new int();
            }
            set
            {
                EmployeeProjectWorksMasterDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_ProjectWorkDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ProjectWorkDateRequired")]
        public string ProjectWorkDate
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.ProjectWorkDate : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.ProjectWorkDate = value;
            }
        }
        [Display(Name = "DisplayName_ProjectWorkName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ProjectWorkNameRequired")]
        public string ProjectWorkName
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.ProjectWorkName : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.ProjectWorkName = value;
            }
        }
        [Display(Name = "DisplayName_ProjectCost", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ProjectCostRequired")]
        public decimal ProjectCost
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.ProjectCost : new decimal();
            }
            set
            {
                EmployeeProjectWorksMasterDTO.ProjectCost = value;
            }
        }
        [Display(Name = "DisplayName_FundingAgency", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FundingAgencyRequired")]
        public string FundingAgency
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.FundingAgency : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.FundingAgency = value;
            }
        }
        [Display(Name = "DisplayName_AssignmentFromDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AssignmentFromDateRequired")]
        public string AssignmentFromDate
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.AssignmentFromDate : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.AssignmentFromDate = value;
            }
        }
        [Display(Name = "DisplayName_AssignmentToDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AssignmentToDateRequired")]
        public string AssignmentToDate
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.AssignmentToDate : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.AssignmentToDate = value;
            }
        }
        [Display(Name = "DisplayName_Duration", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DurationRequired")]
        public Int16 Duration
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.Duration : new Int16();
            }
            set
            {
                EmployeeProjectWorksMasterDTO.Duration = value;
            }
        }
        [Display(Name = "DisplayName_DurationUnit", ResourceType = typeof(AMS.Common.Resources))]
        public string DurationUnit
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.DurationUnit : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.DurationUnit = value;
            }
        }
        [Display(Name = "DisplayName_ProjectStatus", ResourceType = typeof(AMS.Common.Resources))]
        public bool ProjectStatus
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.ProjectStatus : false;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.ProjectStatus = value;
            }
        }
        public string Remarks
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.Remarks : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.Remarks = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.IsActive : false;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.IsActive = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.IsDeleted : false;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.IsDeleted = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null && EmployeeProjectWorksMasterDTO.CreatedBy > 0) ? EmployeeProjectWorksMasterDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeProjectWorksMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        int? ModifiedBy
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null && EmployeeProjectWorksMasterDTO.ModifiedBy.HasValue) ? EmployeeProjectWorksMasterDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeProjectWorksMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null && EmployeeProjectWorksMasterDTO.ModifiedDate.HasValue) ? EmployeeProjectWorksMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null && EmployeeProjectWorksMasterDTO.DeletedBy.HasValue) ? EmployeeProjectWorksMasterDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeProjectWorksMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null && EmployeeProjectWorksMasterDTO.DeletedDate.HasValue) ? EmployeeProjectWorksMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }

        //---------------------------------------   EmployeeProjectWorksDetails Properties  ------------------------------------------//
        public int EmployeeProjectWorksDetailsID
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null && EmployeeProjectWorksMasterDTO.EmployeeProjectWorksDetailsID > 0) ? EmployeeProjectWorksMasterDTO.EmployeeProjectWorksDetailsID : new int();
            }
            set
            {
                EmployeeProjectWorksMasterDTO.EmployeeProjectWorksDetailsID = value;
            }
        }
        public int EmployeeProjectWorkMasterID
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null && EmployeeProjectWorksMasterDTO.EmployeeProjectWorkMasterID > 0) ? EmployeeProjectWorksMasterDTO.EmployeeProjectWorkMasterID : new int();
            }
            set
            {
                EmployeeProjectWorksMasterDTO.EmployeeProjectWorkMasterID = value;
            }
        }
        public int EmployeeID
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null && EmployeeProjectWorksMasterDTO.EmployeeID > 0) ? EmployeeProjectWorksMasterDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeProjectWorksMasterDTO.EmployeeID = value;
            }
        }
        [Display(Name = "DisplayName_ProjectWorkFromDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ProjectWorkFromDateRequired")]
        public string ProjectWorkFromDate
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.ProjectWorkFromDate : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.ProjectWorkFromDate = value;
            }
        }
        [Display(Name = "DisplayName_ProjectWorkToDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ProjectWorkToDateRequired")]
        public string ProjectWorkToDate
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.ProjectWorkToDate : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.ProjectWorkToDate = value;
            }
        }
        [Display(Name = "DisplayName_EmployeeRemark", ResourceType = typeof(AMS.Common.Resources))]
        public string EmployeeRemark
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.EmployeeRemark : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.EmployeeRemark = value;
            }
        }
        [Display(Name = "DisplayName_WorkAsDesignation", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_WorkAsDesignationRequired")]
        public string WorkAsDesignation
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.WorkAsDesignation : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.WorkAsDesignation = value;
            }
        }
        [Display(Name = "DisplayName_IndividualProjectStatus", ResourceType = typeof(AMS.Common.Resources))]
        public bool IndividualProjectStatus
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.IndividualProjectStatus : false;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.IndividualProjectStatus = value;
            }
        }
        public string InActiveReason
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.InActiveReason : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.InActiveReason = value;
            }
        }
        public string InActiveDate
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.InActiveDate : string.Empty;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.InActiveDate = value;
            }
        }
        public bool StatusFlag
        {
            get
            {
                return (EmployeeProjectWorksMasterDTO != null) ? EmployeeProjectWorksMasterDTO.StatusFlag : false;
            }
            set
            {
                EmployeeProjectWorksMasterDTO.StatusFlag = value;
            }
        }
    }
}
