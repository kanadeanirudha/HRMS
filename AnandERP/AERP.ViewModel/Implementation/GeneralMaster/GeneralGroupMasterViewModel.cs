using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralGroupMasterViewModel : IGeneralGroupMasterViewModel
    {

        public GeneralGroupMasterViewModel()
        {

            GeneralGroupMasterDTO = new GeneralGroupMaster();
        }

        public GeneralGroupMaster GeneralGroupMasterDTO
        {
            get;
            set;
        }

        public List<GeneralGroupMaster> ListGeneralGroupMaster
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralGroupMasterDTO != null && GeneralGroupMasterDTO.ID > 0) ? GeneralGroupMasterDTO.ID : new int();
            }
            set
            {
                GeneralGroupMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_GroupName", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GroupNameRequired")]
        public string GroupName
        {
            get
            {
                return (GeneralGroupMasterDTO != null) ? GeneralGroupMasterDTO.GroupName : string.Empty;
            }
            set
            {
                GeneralGroupMasterDTO.GroupName = value;
            }
        }

        [Display(Name = "DisplayName_GroupDependentObject", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_GroupDependentObjectRequired")]
        public string GroupDependentObject
        {
            get
            {
                return (GeneralGroupMasterDTO != null) ? GeneralGroupMasterDTO.GroupDependentObject : string.Empty;
            }
            set
            {
                GeneralGroupMasterDTO.GroupDependentObject = value;
            }
        }

        [Display(Name = "DisplayName_JobProfileID", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_JobProfileIDRequired")]
        public int JobProfileID
        {
            get
            {
                return (GeneralGroupMasterDTO != null && GeneralGroupMasterDTO.JobProfileID > 0) ? GeneralGroupMasterDTO.JobProfileID : new int();
            }
            set
            {
                GeneralGroupMasterDTO.JobProfileID = value;
            }
        }

        [Display(Name = "DisplayName_JobProfileDescription", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_JobProfileDescriptionRequired")]
        public string JobProfileDescription
        {
            get
            {
                return (GeneralGroupMasterDTO != null) ? GeneralGroupMasterDTO.JobProfileDescription : string.Empty;
            }
            set
            {
                GeneralGroupMasterDTO.JobProfileDescription = value;
            }
        }

        [Display(Name = "Allocation Status")]
        public bool IsActive
        {
            get
            {
                return (GeneralGroupMasterDTO != null) ? GeneralGroupMasterDTO.IsActive : false;
            }
            set
            {
                GeneralGroupMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralGroupMasterDTO != null) ? GeneralGroupMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralGroupMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralGroupMasterDTO != null && GeneralGroupMasterDTO.CreatedBy > 0) ? GeneralGroupMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralGroupMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralGroupMasterDTO != null) ? GeneralGroupMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralGroupMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralGroupMasterDTO != null && GeneralGroupMasterDTO.ModifiedBy.HasValue) ? GeneralGroupMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralGroupMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralGroupMasterDTO != null && GeneralGroupMasterDTO.ModifiedDate.HasValue) ? GeneralGroupMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralGroupMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralGroupMasterDTO != null && GeneralGroupMasterDTO.DeletedBy.HasValue) ? GeneralGroupMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralGroupMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralGroupMasterDTO != null && GeneralGroupMasterDTO.DeletedDate.HasValue) ? GeneralGroupMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralGroupMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }

        public int EmployeeGroupDetailsID
        {
            get
            {
                return (GeneralGroupMasterDTO != null && GeneralGroupMasterDTO.EmployeeGroupDetailsID > 0) ? GeneralGroupMasterDTO.EmployeeGroupDetailsID : new int();
            }
            set
            {
                GeneralGroupMasterDTO.EmployeeGroupDetailsID = value;
            }
        }

        public int DependentObjectID
        {
            get
            {
                return (GeneralGroupMasterDTO != null && GeneralGroupMasterDTO.DependentObjectID > 0) ? GeneralGroupMasterDTO.DependentObjectID : new int();
            }
            set
            {
                GeneralGroupMasterDTO.DependentObjectID = value;
            }
        }

        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DepartmentRequired")]
        public string CentreCode
        {
            get
            {
                return (GeneralGroupMasterDTO != null) ? GeneralGroupMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                GeneralGroupMasterDTO.CentreCode = value;
            }
        }
        public int DepartmentID
        {
            get
            {
                return (GeneralGroupMasterDTO != null && GeneralGroupMasterDTO.DepartmentID > 0) ? GeneralGroupMasterDTO.DepartmentID : new int();
            }
            set
            {
                GeneralGroupMasterDTO.DepartmentID = value;
            }
        }

        [Display(Name = "DisplayName_DepartmentName", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DepartmentRequired")]
        public string Department
        {
            get
            {
                return (GeneralGroupMasterDTO != null) ? GeneralGroupMasterDTO.Department : string.Empty;
            }
            set
            {
                GeneralGroupMasterDTO.Department = value;
            }
        }

        [Display(Name = "DisplayName_Designation", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DesignationRequired")]
        public string Designation
        {
            get
            {
                return (GeneralGroupMasterDTO != null) ? GeneralGroupMasterDTO.Designation : string.Empty;
            }
            set
            {
                GeneralGroupMasterDTO.Designation = value;
            }
        }

        [Display(Name = "DisplayName_PayScaleMstID", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PayScaleRequired")]
        public string PayScale
        {
            get
            {
                return (GeneralGroupMasterDTO != null) ? GeneralGroupMasterDTO.PayScale : string.Empty;
            }
            set
            {
                GeneralGroupMasterDTO.PayScale = value;
            }
        }
    }
}
