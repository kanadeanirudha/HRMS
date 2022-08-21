using AERP.Common;
using AERP.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AERP.ViewModel
{
    public class EmpDesignationMasterViewModel : IEmpDesignationMasterViewModel
    {
        public EmpDesignationMasterViewModel()
        {
            EmpDesignationMasterDTO = new EmpDesignationMaster();
            //EmpdesigTypeMasterList = new List<EmpDesignationMaster>();
        }

        public EmpDesignationMaster EmpDesignationMasterDTO
        {
            get;
            set;
        }
        // public List<EmpDesignationMaster> EmpdesigTypeMasterList { get; set; }

        //public IEnumerable<SelectListItem> EmpdesigtypeListItems 
        //{
        //    get
        //    {
        //        return new SelectList(EmpdesigTypeMasterList, "CurrencyCode", "CurrencyName");
        //    }
        //}



        //-------------------------------------------------------------------------------------------------------
        public int ID
        {
            get
            {
                return (EmpDesignationMasterDTO != null && EmpDesignationMasterDTO.ID > 0) ? EmpDesignationMasterDTO.ID : new int();
            }
            set
            {
                EmpDesignationMasterDTO.ID = value;
            }
        }
        [Display(Name = "Description")]
        [Required(ErrorMessage ="Description Required")]
        public string Description
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.Description : string.Empty;
            }
            set
            {
                EmpDesignationMasterDTO.Description = value;
            }
        }
        
        [Display(Name = "Designation Level")]
        [Required(ErrorMessage ="Designation Level Required")]
        public int DesignationLevel
        {
            get
            {
                return (EmpDesignationMasterDTO != null && EmpDesignationMasterDTO.DesignationLevel > 0) ? EmpDesignationMasterDTO.DesignationLevel : new int();
            }
            set
            {
                EmpDesignationMasterDTO.DesignationLevel = value;
            }
        }
        
        [Display(Name = "Grade")]
        [Required(ErrorMessage ="Grade Required")]
        public int Grade
        {
            get
            {
                return (EmpDesignationMasterDTO != null && EmpDesignationMasterDTO.Grade > 0) ? EmpDesignationMasterDTO.Grade : new int();
            }
            set
            {
                EmpDesignationMasterDTO.Grade = value;
            }
        }
        
        [Display(Name = "Short Code")]
        [Required(ErrorMessage ="Short Code Required")]
        public string ShortCode
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.ShortCode : string.Empty;
            }
            set
            {
                EmpDesignationMasterDTO.ShortCode = value;
            }
        }
        
        [Display(Name = "College ID")]
        [Required(ErrorMessage ="College Required")]
        public int CollegeID
        {
            get
            {
                return (EmpDesignationMasterDTO != null && EmpDesignationMasterDTO.CollegeID > 0) ? EmpDesignationMasterDTO.CollegeID : new int();
            }
            set
            {
                EmpDesignationMasterDTO.CollegeID = value;
            }
        }
        
        [Display(Name = "Employee Designation Type")]
        [Required(ErrorMessage ="Empployee Designation Type Required")]
        public string EmpDesigType
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.EmpDesigType : string.Empty;
            }
            set
            {
                EmpDesignationMasterDTO.EmpDesigType = value;
            }
        }
        [Display(Name = "Related With")]
        [Required(ErrorMessage ="Related With Required")]
        public string RelatedWith
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.RelatedWith : string.Empty;
            }
            set
            {
                EmpDesignationMasterDTO.RelatedWith = value;
            }
        }
        
        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.IsActive : false;
            }
            set
            {
                EmpDesignationMasterDTO.IsActive = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.IsDeleted : false;
            }
            set
            {
                EmpDesignationMasterDTO.IsDeleted = value;
            }
        }
        
        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmpDesignationMasterDTO != null && EmpDesignationMasterDTO.CreatedBy > 0) ? EmpDesignationMasterDTO.CreatedBy : new int();
            }
            set
            {
                EmpDesignationMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmpDesignationMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.ModifiedBy : new int();
            }
            set
            {
                EmpDesignationMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmpDesignationMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.DeletedBy : new int();
            }
            set
            {
                EmpDesignationMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (EmpDesignationMasterDTO != null) ? EmpDesignationMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmpDesignationMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

