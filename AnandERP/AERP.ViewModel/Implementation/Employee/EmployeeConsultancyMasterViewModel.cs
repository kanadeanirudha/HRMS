using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeConsultancyMasterViewModel : IEmployeeConsultancyMasterViewModel
    {
        public EmployeeConsultancyMasterViewModel()
        {
            EmployeeConsultancyMasterDTO = new EmployeeConsultancyMaster();
        }
        public EmployeeConsultancyMaster EmployeeConsultancyMasterDTO
        {
            get;
            set;
        }



       
        //---------------------------------------   EmployeeConsultancyMaster Properties  ------------------------------------------//
        public int ID
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null && EmployeeConsultancyMasterDTO.ID > 0) ? EmployeeConsultancyMasterDTO.ID : new int();
            }
            set
            {
                EmployeeConsultancyMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_ConsultancyDate", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ConsultancyDateRequired")]
        public string ConsultancyDate
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.ConsultancyDate : string.Empty;
            }
            set
            {
                EmployeeConsultancyMasterDTO.ConsultancyDate = value;
            }
        }

        [Display(Name = "DisplayName_ConsultancyName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ConsultancyNameRequired")]
        public string ConsultancyName
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.ConsultancyName : string.Empty;
            }
            set
            {
                EmployeeConsultancyMasterDTO.ConsultancyName = value;
            }
        }

        [Display(Name = "DisplayName_TitleOfAssignment", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_TitleOfAssignmentRequired")]
        public string TitleOfAssignment
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.TitleOfAssignment : string.Empty;
            }
            set
            {
                EmployeeConsultancyMasterDTO.TitleOfAssignment = value;
            }
        }

        [Display(Name = "DisplayName_ConsultancyCost", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ConsultancyCostRequired")]
        public decimal ConsultancyCost
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.ConsultancyCost : new decimal();
            }
            set
            {
                EmployeeConsultancyMasterDTO.ConsultancyCost = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeShare", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeShareRequired")]
        public decimal EmployeeShare
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.EmployeeShare : new decimal();
            }
            set
            {
                EmployeeConsultancyMasterDTO.EmployeeShare = value;
            }
        }


        [Display(Name = "DisplayName_AssignmentFromDate", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_AssignmentFromDateRequired")]
        public string AssignmentFromDate
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.AssignmentFromDate : string.Empty;
            }
            set
            {
                EmployeeConsultancyMasterDTO.AssignmentFromDate = value;
            }
        }

        [Display(Name = "DisplayName_AssignmentToDate", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_AssignmentToDateRequired")]
        public string AssignmentToDate
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.AssignmentToDate : string.Empty;
            }
            set
            {
                EmployeeConsultancyMasterDTO.AssignmentToDate = value;
            }
        }
        [Display(Name = "DisplayName_Remarks", ResourceType = typeof(Resources))]
        public string Remarks
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.Remarks : string.Empty;
            }
            set
            {
                EmployeeConsultancyMasterDTO.Remarks = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeConsultancyMasterDTO.CentreCode = value;
            }
        }
       [Display(Name = "DisplayName_IsActive", ResourceType = typeof(Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.IsActive : false;
            }
            set
            {
                EmployeeConsultancyMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.IsDeleted : false;
            }
            set
            {
                EmployeeConsultancyMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null && EmployeeConsultancyMasterDTO.CreatedBy > 0) ? EmployeeConsultancyMasterDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeConsultancyMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeConsultancyMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        int? ModifiedBy
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null && EmployeeConsultancyMasterDTO.ModifiedBy.HasValue) ? EmployeeConsultancyMasterDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeConsultancyMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null && EmployeeConsultancyMasterDTO.ModifiedDate.HasValue) ? EmployeeConsultancyMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeConsultancyMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null && EmployeeConsultancyMasterDTO.DeletedBy.HasValue) ? EmployeeConsultancyMasterDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeConsultancyMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null && EmployeeConsultancyMasterDTO.DeletedDate.HasValue) ? EmployeeConsultancyMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeConsultancyMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }

        //---------------------------------------   EmployeeConsultancyDetails Properties  ------------------------------------------//
        public int EmpConsultancyDetID
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null && EmployeeConsultancyMasterDTO.EmpConsultancyDetID > 0) ? EmployeeConsultancyMasterDTO.EmpConsultancyDetID : new int();
            }
            set
            {
                EmployeeConsultancyMasterDTO.EmpConsultancyDetID = value;
            }
        }
        public int EmployeeConsultancyMasterID
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null && EmployeeConsultancyMasterDTO.EmployeeConsultancyMasterID > 0) ? EmployeeConsultancyMasterDTO.EmployeeConsultancyMasterID : new int();
            }
            set
            {
                EmployeeConsultancyMasterDTO.EmployeeConsultancyMasterID = value;
            }
        }
        public int EmployeeID
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null && EmployeeConsultancyMasterDTO.EmployeeID > 0) ? EmployeeConsultancyMasterDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeConsultancyMasterDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_ConsultingFromDate", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ConsultingFromDateRequired")]
        public string ConsultingFromDate
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.ConsultingFromDate : string.Empty;
            }
            set
            {
                EmployeeConsultancyMasterDTO.ConsultingFromDate = value;
            }
        }

        [Display(Name = "DisplayName_ConsultingToDate", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ConsultingToDateRequired")]
        public string ConsultingToDate
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.ConsultingToDate : string.Empty;
            }
            set
            {
                EmployeeConsultancyMasterDTO.ConsultingToDate = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeRemark", ResourceType = typeof(Resources))]
        public string EmployeeRemark
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.EmployeeRemark : string.Empty;
            }
            set
            {
                EmployeeConsultancyMasterDTO.EmployeeRemark = value;
            }
        }

        public bool StatusFlag
        {
            get
            {
                return (EmployeeConsultancyMasterDTO != null) ? EmployeeConsultancyMasterDTO.StatusFlag : false;
            }
            set
            {
                EmployeeConsultancyMasterDTO.StatusFlag = value;
            }
        }
    }
}
