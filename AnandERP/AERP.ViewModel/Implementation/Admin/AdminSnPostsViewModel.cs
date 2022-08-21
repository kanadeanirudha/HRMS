using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AERP.ViewModel
{
    public class AdminSnPostsBaseViewModel : IAdminSnPostsBaseViewModel
    {
        public AdminSnPostsBaseViewModel()
        {
            ListAdminSnPosts = new List<AdminSnPosts>();

            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            ListEmpDesignationMaster = new List<EmpDesignationMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public List<AdminSnPosts> ListAdminSnPosts
        {
            get;
            set;
        }

        //[Required(ErrorMessage = "Centre name is required")]
        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Department name is required")]
        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Designation is required")]
        public List<EmpDesignationMaster> ListEmpDesignationMaster
        {
            get;
            set;
        }

        [Display(Name = "Centre")]
        public string SelectedCentreCode
        {
            get;
            set;
        }
        [Display(Name = "Department")]
        public string SelectedDepartmentID
        {
            get;
            set;
        }

        public string SelectedDesignationID
        {
            get;
            set;
        }

        public string SelectedCentreName
        {
            get;
            set;
        }

        public string SelectedDepartmentName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListOrganisationStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListOrganisationDepartmentMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationDepartmentMaster, "DeptID", "DepartmentName");
            }

        }

        public IEnumerable<SelectListItem> ListEmpDesignationMasterItems
        {
            get
            {

                return new SelectList(ListEmpDesignationMaster, "DesignationID", "Description");
            }

        }

        public IEnumerable<SelectListItem> ListAdminSnPostsItems
        {
            get
            {

                return new SelectList(ListAdminSnPosts, "AdminSnPostsID", "SactionedPostDescription");

            }
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

    }


    public class AdminSnPostsViewModel : IAdminSnPostsViewModel
    {
        public AdminSnPostsViewModel()
        {
            AdminSnPostsDTO = new AdminSnPosts();
        }

        public AdminSnPosts AdminSnPostsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (AdminSnPostsDTO != null && AdminSnPostsDTO.ID > 0) ? AdminSnPostsDTO.ID : new int();
            }
            set
            {
                AdminSnPostsDTO.ID = value;
            }
        }


        [Required(ErrorMessage = "Designation Required")]
        [Display(Name = "Designation")]
        public int DesignationID
        {
            get
            {
                return (AdminSnPostsDTO != null && AdminSnPostsDTO.DesignationID > 0) ? AdminSnPostsDTO.DesignationID : new int();
            }
            set
            {
                AdminSnPostsDTO.DesignationID = value;
            }
        }

        [Display(Name = "Number Of Posts")]
        public int NoOfPosts
        {
            get
            {
                return (AdminSnPostsDTO != null && AdminSnPostsDTO.NoOfPosts > 0) ? AdminSnPostsDTO.NoOfPosts : new int();
            }
            set
            {
                AdminSnPostsDTO.NoOfPosts = value;
            }
        }

        [Required(ErrorMessage = "Department Required")]
        [Display(Name = "Department Name")]
        public int DepartmentID
        {
            get
            {
                return (AdminSnPostsDTO != null && AdminSnPostsDTO.DepartmentID > 0) ? AdminSnPostsDTO.DepartmentID : new int();
            }
            set
            {
                AdminSnPostsDTO.DepartmentID = value;
            }
        }

        [Required(ErrorMessage = "Centre Code Required")]
        [Display(Name = "Centre Name")]
        public string CentreCode
        {
            get
            {
                return (AdminSnPostsDTO != null) ? AdminSnPostsDTO.CentreCode : string.Empty;
            }
            set
            {
                AdminSnPostsDTO.CentreCode = value;
            }
        }

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (AdminSnPostsDTO != null) ? AdminSnPostsDTO.IsActive : false;
            }
            set
            {
                AdminSnPostsDTO.IsActive = value;
            }
        }

        [Required(ErrorMessage = "Designation Type Required")]
        [Display(Name = "Designation Type")]
        public string DesignationType
        {
            get
            {
                return (AdminSnPostsDTO != null) ? AdminSnPostsDTO.DesignationType : string.Empty;
            }
            set
            {
                AdminSnPostsDTO.DesignationType = value;
            }
        }

        [Display(Name = "Admin role code")]
        public string NomenAdminRoleCode
        {
            get
            {
                return (AdminSnPostsDTO != null) ? AdminSnPostsDTO.NomenAdminRoleCode : string.Empty;
            }
            set
            {
                AdminSnPostsDTO.NomenAdminRoleCode = value;
            }
        }

        [Required(ErrorMessage = "Post Type Required")]
        [Display(Name = "Post Type")]
        public string PostType
        {
            get
            {
                return (AdminSnPostsDTO != null) ? AdminSnPostsDTO.PostType : string.Empty;
            }
            set
            {
                AdminSnPostsDTO.PostType = value;
            }
        }

        [Display(Name = "Sactioned Post Description")]
        public string SactionedPostDescription
        {
            get
            {
                return (AdminSnPostsDTO != null) ? AdminSnPostsDTO.SactionedPostDescription : string.Empty;
            }
            set
            {
                AdminSnPostsDTO.SactionedPostDescription = value;
            }
        }



        [Display(Name = "Is Deleted?")]
        public bool IsDeleted
        {
            get
            {
                return (AdminSnPostsDTO != null) ? AdminSnPostsDTO.IsActive : false;
            }
            set
            {
                AdminSnPostsDTO.IsActive = value;
            }
        }

        [Display(Name = "Created by")]
        public int CreatedBy
        {
            get
            {
                return (AdminSnPostsDTO != null && AdminSnPostsDTO.CreatedBy > 0) ? AdminSnPostsDTO.CreatedBy : new int();
            }
            set
            {
                AdminSnPostsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created date")]
        public DateTime CreatedDate
        {
            get
            {
                return (AdminSnPostsDTO != null) ? AdminSnPostsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AdminSnPostsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified by")]
        public int? ModifiedBy
        {
            get
            {
                return (AdminSnPostsDTO != null && AdminSnPostsDTO.ModifiedBy.HasValue) ? AdminSnPostsDTO.ModifiedBy : new int();
            }
            set
            {
                AdminSnPostsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (AdminSnPostsDTO != null && AdminSnPostsDTO.ModifiedDate.HasValue) ? AdminSnPostsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AdminSnPostsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted by")]
        public int? DeletedBy
        {
            get
            {
                return (AdminSnPostsDTO != null && AdminSnPostsDTO.DeletedBy.HasValue) ? AdminSnPostsDTO.DeletedBy : new int();
            }
            set
            {
                AdminSnPostsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Deleted date")]
        public DateTime? DeletedDate
        {
            get
            {
                return (AdminSnPostsDTO != null && AdminSnPostsDTO.DeletedDate.HasValue) ? AdminSnPostsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AdminSnPostsDTO.DeletedDate = value;
            }
        }


        public string SelectedDesignation
        {
            get;
            set;
        }

        public string CentreCodeWithName
        {
            get;
            set;
        }

        public string DepartmentIdWithName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Designation With Name Required")]
        public string DesignationIdWithName
        {
            get;
            set;
        }

        public string CentreCodewithDeptID
        {
            get;
            set;
        }
    }
}
