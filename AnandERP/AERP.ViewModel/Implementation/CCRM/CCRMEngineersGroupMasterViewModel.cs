using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class CCRMEngineersGroupMasterViewModel
    {

        public CCRMEngineersGroupMasterViewModel()
        {
            CCRMEngineersGroupMasterDTO = new CCRMEngineersGroupMaster();

        }
        
        public CCRMEngineersGroupMaster CCRMEngineersGroupMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null && CCRMEngineersGroupMasterDTO.ID > 0) ? CCRMEngineersGroupMasterDTO.ID : new int();
            }
            set
            {
                CCRMEngineersGroupMasterDTO.ID = value;
            }
        }

        public int CCRMEngineersGroupDetailsID
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null && CCRMEngineersGroupMasterDTO.CCRMEngineersGroupDetailsID > 0) ? CCRMEngineersGroupMasterDTO.CCRMEngineersGroupDetailsID : new int();
            }
            set
            {
                CCRMEngineersGroupMasterDTO.CCRMEngineersGroupDetailsID = value;
            }
        }
        [Required(ErrorMessage = "Group Name should not be blank.")]
        [Display(Name = "Group Name")]
        public string GroupName
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null) ? CCRMEngineersGroupMasterDTO.GroupName : string.Empty;
            }
            set
            {
                CCRMEngineersGroupMasterDTO.GroupName = value;
            }
        }
        [Display(Name = "Employee Code")]
        public string EmployeeCode
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null) ? CCRMEngineersGroupMasterDTO.EmployeeCode : string.Empty;
            }
            set
            {
                CCRMEngineersGroupMasterDTO.EmployeeCode = value;
            }
        }
        [Required(ErrorMessage = "Employee Name should not be blank.")]
        [Display(Name = "Employee Name")]
        public string EmployeeName
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null) ? CCRMEngineersGroupMasterDTO.EmployeeName : string.Empty;
            }
            set
            {
                CCRMEngineersGroupMasterDTO.EmployeeName = value;
            }
        }
        [Required(ErrorMessage = "Employee Name should not be blank.")]
        public int EmployeeMasterID
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null && CCRMEngineersGroupMasterDTO.EmployeeMasterID > 0) ? CCRMEngineersGroupMasterDTO.EmployeeMasterID : new int();
            }
            set
            {
                CCRMEngineersGroupMasterDTO.EmployeeMasterID = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null) ? CCRMEngineersGroupMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMEngineersGroupMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null && CCRMEngineersGroupMasterDTO.CreatedBy > 0) ? CCRMEngineersGroupMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMEngineersGroupMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null) ? CCRMEngineersGroupMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMEngineersGroupMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null) ? CCRMEngineersGroupMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMEngineersGroupMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null) ? CCRMEngineersGroupMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMEngineersGroupMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null) ? CCRMEngineersGroupMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMEngineersGroupMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (CCRMEngineersGroupMasterDTO != null) ? CCRMEngineersGroupMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMEngineersGroupMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

