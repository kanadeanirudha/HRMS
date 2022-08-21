using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
    public class OrganisationDepartmentMasterBaseViewModel : IOrganisationDepartmentMasterBaseViewModel
    {
        public OrganisationDepartmentMasterBaseViewModel()
        {
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
        }

        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }
      
    }
    public class OrganisationDepartmentMasterViewModel : IOrganisationDepartmentMasterViewModel
    {
        public OrganisationDepartmentMasterViewModel()
        {
            OrganisationDepartmentMasterDTO = new OrganisationDepartmentMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();       
        }

        public OrganisationDepartmentMaster OrganisationDepartmentMasterDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null && OrganisationDepartmentMasterDTO.ID > 0) ? OrganisationDepartmentMasterDTO.ID : new int();
            }
            set
            {
                OrganisationDepartmentMasterDTO.ID = value;
            }
        }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage ="Department Name Required")]
        public string DepartmentName
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null) ? OrganisationDepartmentMasterDTO.DepartmentName : string.Empty;
            }
            set
            {
                OrganisationDepartmentMasterDTO.DepartmentName = value;
            }
        }

        [Display(Name = "Department Short Code")]
        [Required(ErrorMessage ="Department Short Code Required")]
        public string DeptShortCode
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null) ? OrganisationDepartmentMasterDTO.DeptShortCode : string.Empty;
            }
            set
            {
                OrganisationDepartmentMasterDTO.DeptShortCode = value;
            }
        }

        [Display(Name = "Print Short Description")]
        [Required(ErrorMessage ="Print Short Description Required")]
        public string PrintShortDesc
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null) ? OrganisationDepartmentMasterDTO.PrintShortDesc : string.Empty;
            }
            set
            {
                OrganisationDepartmentMasterDTO.PrintShortDesc = value;
            }
        }

        public int DepartmentSeqNo
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null && OrganisationDepartmentMasterDTO.DepartmentSeqNo > 0) ? OrganisationDepartmentMasterDTO.DepartmentSeqNo : new int();
            }
            set
            {
                OrganisationDepartmentMasterDTO.DepartmentSeqNo = value;
            }
        }

        [Display(Name = "Academic Nonacademic")]
        public string AcademicNonacademic
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null) ? OrganisationDepartmentMasterDTO.AcademicNonacademic : string.Empty;
            }
            set
            {
                OrganisationDepartmentMasterDTO.AcademicNonacademic = value;
            }
        }

        [Display(Name = "Teaching Activity")]
        public bool TeachingActivity
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null) ? OrganisationDepartmentMasterDTO.TeachingActivity : false;
            }
            set
            {
                OrganisationDepartmentMasterDTO.TeachingActivity = value;
            }
        }

       
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null) ? OrganisationDepartmentMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationDepartmentMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null && OrganisationDepartmentMasterDTO.CreatedBy > 0) ? OrganisationDepartmentMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationDepartmentMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null) ? OrganisationDepartmentMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationDepartmentMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null && OrganisationDepartmentMasterDTO.ModifiedBy.HasValue) ? OrganisationDepartmentMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationDepartmentMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null && OrganisationDepartmentMasterDTO.ModifiedDate.HasValue) ? OrganisationDepartmentMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationDepartmentMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null && OrganisationDepartmentMasterDTO.DeletedBy.HasValue) ? OrganisationDepartmentMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationDepartmentMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null && OrganisationDepartmentMasterDTO.DeletedDate.HasValue) ? OrganisationDepartmentMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationDepartmentMasterDTO.DeletedDate = value;
            }
        }

        #region properties for organisation centrewise department
        public int CentrewiseDepartmentID
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null && OrganisationDepartmentMasterDTO.CentrewiseDepartmentID > 0) ? OrganisationDepartmentMasterDTO.CentrewiseDepartmentID : new int();
            }
            set
            {
                OrganisationDepartmentMasterDTO.CentrewiseDepartmentID = value;
            }
        }

        public bool CentrewiseDepartmentStatus
        {
            get
            {
                return (OrganisationDepartmentMasterDTO != null) ? Convert.ToBoolean(OrganisationDepartmentMasterDTO.CentrewiseDepartmentStatus) : false;
            }
            set
            {
                OrganisationDepartmentMasterDTO.CentrewiseDepartmentStatus = value;
            }
        }
        #endregion


    }
}
