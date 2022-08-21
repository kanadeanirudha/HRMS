using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class OrganisationCentrewiseDepartmentBaseViewModel : IOrganisationCentrewiseDepartmentBaseViewModel
    {
        public OrganisationCentrewiseDepartmentBaseViewModel()
        {
            ListOrganisationCentrewiseDepartment = new List<OrganisationCentrewiseDepartment>();

            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();

            ListOrgStudyCentreMaster = new List<OrganisationStudyCentreMaster>();

            ListOrganisationDepartmentMasterViewModel = new List<OrganisationDepartmentMasterViewModel>();
        }

        public List<OrganisationCentrewiseDepartment> ListOrganisationCentrewiseDepartment
        {
            get;
            set;
        }

        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }

        public List<OrganisationDepartmentMasterViewModel> ListOrganisationDepartmentMasterViewModel
        {
            get;
            set;
        }

        public List<OrganisationStudyCentreMaster> ListOrgStudyCentreMaster
        {
            get;
            set;
        }

        public string SelectedCentreCode
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListOrgStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrgStudyCentreMaster, "CentreCode", "CentreName");
            }
        }
    }

    public class OrganisationCentrewiseDepartmentViewModel : IOrganisationCentrewiseDepartmentViewModel
    {
        public OrganisationCentrewiseDepartmentViewModel()
        {
            OrganisationCentrewiseDepartmentDTO = new OrganisationCentrewiseDepartment();
            GetAdminRoleDomainList = new List<AdminRoleMaster>();
        }

        public List<AdminRoleMaster> GetAdminRoleDomainList { get; set; }

        public IEnumerable<SelectListItem> ListAdminRoleDomainItems
        {
            get
            {
                return new SelectList(GetAdminRoleDomainList, "AdminRoleDomainID", "AdminRoleDomainName");
            }
        }
        
        public OrganisationCentrewiseDepartment OrganisationCentrewiseDepartmentDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null && OrganisationCentrewiseDepartmentDTO.ID > 0) ? OrganisationCentrewiseDepartmentDTO.ID : new int();
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.ID = value;
            }
        }

        [Display(Name = "Department ID")]
        public Nullable<int> DepartmentID
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null && OrganisationCentrewiseDepartmentDTO.DepartmentID > 0) ? OrganisationCentrewiseDepartmentDTO.DepartmentID : new int();
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.DepartmentID = value;
            }
        }

        [Display(Name = "Code")]
        public string CentreCode
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null) ? OrganisationCentrewiseDepartmentDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.CentreCode = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null) ? OrganisationCentrewiseDepartmentDTO.DepartmentName : string.Empty;
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.DepartmentName = value;
            }
        }
        
        [Display(Name = "CentreName")]
        public string SelectedCentreName
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null) ? OrganisationCentrewiseDepartmentDTO.SelectedCentreName : string.Empty;
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.SelectedCentreName = value;
            }
        }

        [Display(Name = "Allocate Department to Centre")]
        public bool ActiveFlag
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null) ? OrganisationCentrewiseDepartmentDTO.ActiveFlag : false;
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.ActiveFlag = value;
            }
        }

        [Display(Name = "Sequence Number")]
        [Required(ErrorMessage ="Sequence Number Required")]
        public Nullable<int> DepartmentSeqNo
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null && OrganisationCentrewiseDepartmentDTO.DepartmentSeqNo > 0) ? OrganisationCentrewiseDepartmentDTO.DepartmentSeqNo : new int();
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.DepartmentSeqNo = value;
            }
        }

        [Display(Name = "xmlInsertUpdate")]
        public string xmlInsertUpdate
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null) ? OrganisationCentrewiseDepartmentDTO.xmlInsertUpdate : string.Empty;
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.xmlInsertUpdate = value;
            }
        }

        [Display(Name = "Created By")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null && OrganisationCentrewiseDepartmentDTO.CreatedBy > 0) ? OrganisationCentrewiseDepartmentDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null) ? OrganisationCentrewiseDepartmentDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.CreatedDate = value;
            }
        }

        public Nullable<int> ModifiedBy
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null && OrganisationCentrewiseDepartmentDTO.ModifiedBy > 0) ? OrganisationCentrewiseDepartmentDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null) ? OrganisationCentrewiseDepartmentDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null && OrganisationCentrewiseDepartmentDTO.DeletedBy > 0) ? OrganisationCentrewiseDepartmentDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Deleted Date")]
        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null) ? OrganisationCentrewiseDepartmentDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.DeletedDate = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (OrganisationCentrewiseDepartmentDTO != null) ? OrganisationCentrewiseDepartmentDTO.IsDeleted : false;
            }
            set
            {
                OrganisationCentrewiseDepartmentDTO.IsDeleted = value;
            }
        }

        public string CentreCodeWithName
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string SelectedDomainIDs { get; set; }
        
    }
}
