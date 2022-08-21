using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AdminRoleApplicableDetailsBaseViewModel : IAdminRoleApplicableDetailsBaseViewModel
    {
        public AdminRoleApplicableDetailsBaseViewModel()
        {
            ListAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            ListEmpDesignationMaster = new List<EmpDesignationMaster>();
            RoleList = new List<AdminRoleApplicableDetails>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public List<AdminRoleApplicableDetails> ListAdminRoleApplicableDetails
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

        public List<AdminRoleApplicableDetails> RoleList
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

        public string SelectedCentreCode
        {
            get;
            set;
        }

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

        public IEnumerable<SelectListItem> ListAdminRoleApplicableDetailsItems
        {
            get
            {

                return new SelectList(ListAdminRoleApplicableDetails, "AdminRoleApplicableDetailsID", "SactionedPostDescription");

            }
        }


        public string EmployeeName
        {
            get;
            set;

        }

        public IEnumerable<SelectListItem> RoleListItems
        {
            get
            {

                return new SelectList(RoleList, "AdminRoleMasterID", "AdminRoleCode");
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


    public class AdminRoleApplicableDetailsViewModel : IAdminRoleApplicableDetailsViewModel
    {
        public AdminRoleApplicableDetailsViewModel()
        {
            AdminRoleApplicableDetailsDTO = new AdminRoleApplicableDetails();
            AdminRegularList = new List<AdminRoleApplicableDetailsViewModel>();
            AdminAdditionalList = new List<AdminRoleApplicableDetailsViewModel>();
            ListAdminRoleApplicableDetails = new List<AdminRoleApplicableDetailsViewModel>();
        }


        public List<AdminRoleApplicableDetailsViewModel> ListAdminRoleApplicableDetails
        {
            get;
            set;
        }

        public List<AdminRoleApplicableDetailsViewModel> AdminRegularList
        {
            get;
            set;
        }

        public List<AdminRoleApplicableDetailsViewModel> AdminAdditionalList
        {
            get;
            set;
        }

        public AdminRoleApplicableDetails AdminRoleApplicableDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.ID > 0) ? AdminRoleApplicableDetailsDTO.ID : new int();
            }
            set
            {
                AdminRoleApplicableDetailsDTO.ID = value;
            }
        }

        public int RoleApplicableID
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.RoleApplicableID > 0) ? AdminRoleApplicableDetailsDTO.RoleApplicableID : new int();
            }
            set
            {
                AdminRoleApplicableDetailsDTO.RoleApplicableID = value;
            }
        }
        

        [Display(Name = "Admin Role Master ID")]
        public int AdminRoleMasterID
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.AdminRoleMasterID > 0) ? AdminRoleApplicableDetailsDTO.AdminRoleMasterID : new int();
            }
            set
            {
                AdminRoleApplicableDetailsDTO.AdminRoleMasterID = value;
            }
        }



        [Display(Name = "Admin Role Master ID Old")]
        public int AdminRoleMasterIDOld
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.AdminRoleMasterIDOld > 0) ? AdminRoleApplicableDetailsDTO.AdminRoleMasterIDOld : new int();
            }
            set
            {
                AdminRoleApplicableDetailsDTO.AdminRoleMasterIDOld = value;
            }
        }

        [Display(Name = "Centre Code")]
        [Required(ErrorMessage = "Centre Code is required")]
        public string CentreCode
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.CentreCode = value;
            }
        }

        public string SelectedIDs
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.SelectedIDs : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.SelectedIDs = value;
            }
        }


        //[Required(ErrorMessage = "AdminRoleCode")]
        [Display(Name = "Regular Role")]     
        public string AdminRoleCode
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.AdminRoleCode : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.AdminRoleCode = value;
            }
        }

        [Display(Name = "Employee ID")]
        public int EmployeeID
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.EmployeeID > 0) ? AdminRoleApplicableDetailsDTO.EmployeeID : new int();
            }
            set
            {
                AdminRoleApplicableDetailsDTO.EmployeeID = value;
            }
        }

      
        public int DesignationID
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.DesignationID > 0) ? AdminRoleApplicableDetailsDTO.DesignationID : new int();
            }
            set
            {
                AdminRoleApplicableDetailsDTO.DesignationID = value;
            }
        }



        [Display(Name = "Work From Date")]        
        [Required(ErrorMessage ="Work From Date Required")]
        public string WorkFromDate
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.WorkFromDate : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.WorkFromDate = value;
            }
        }

        [Display(Name = "Work To Date")]  
        public string WorkToDate
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.WorkToDate : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.WorkToDate = value;
            }
        }

       // [Required(ErrorMessage = "Please Select Role Type")]
        public string RoleType
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.RoleType : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.RoleType = value;
            }
        }

        [Display(Name = "Reason")]
        [Required(ErrorMessage ="Reason Required")]
        public string Reason
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.Reason : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.Reason = value;
            }
        }

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.IsActive : false;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "Is Deleted?")]
        public bool IsDeleted
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.IsDeleted : false;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created by")]
        public int CreatedBy
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.CreatedBy > 0) ? AdminRoleApplicableDetailsDTO.CreatedBy : new int();
            }
            set
            {
                AdminRoleApplicableDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created date")]
        public DateTime CreatedDate
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified by")]
        public int? ModifiedBy
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.ModifiedBy.HasValue) ? AdminRoleApplicableDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                AdminRoleApplicableDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.ModifiedDate.HasValue) ? AdminRoleApplicableDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted by")]
        public int? DeletedBy
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.DeletedBy.HasValue) ? AdminRoleApplicableDetailsDTO.DeletedBy : new int();
            }
            set
            {
                AdminRoleApplicableDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Deleted date")]
        public DateTime? DeletedDate
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.DeletedDate.HasValue) ? AdminRoleApplicableDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.DeletedDate = value;
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


        [Display(Name = "Employee Name")]     
        public string EmployeeName
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.EmployeeName : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.EmployeeName = value;
            }
        }

        public string EmployeeLastName
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.EmployeeLastName : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.EmployeeLastName = value;
            }
        }

        public string EmployeeMiddleName
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.EmployeeMiddleName : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.EmployeeMiddleName = value;
            }
        }

        // [Display(Name = "Created by")]
        public int AdminSnPostsID
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null && AdminRoleApplicableDetailsDTO.AdminSnPostsID > 0) ? AdminRoleApplicableDetailsDTO.AdminSnPostsID : new int();
            }
            set
            {
                AdminRoleApplicableDetailsDTO.AdminSnPostsID = value;
            }
        }
        
               
        public string SactionedPostDescription
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.SactionedPostDescription : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.SactionedPostDescription = value;
            }
        }

        public string EmployeeFirstName
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.EmployeeFirstName : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.EmployeeFirstName = value;
            }
        }

        public string DesignationName
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.DesignationName : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.DesignationName = value;
            }
        }

        public IEnumerable<SelectListItem> AdminRegularListItems
        {
            get
            {

                return new SelectList(AdminRegularList,"AdminRoleMasterID","AdminRoleCode");

            }
        }

        [Display(Name = "Centre")]
        public string CentreName
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.CentreName : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.CentreName = value;
            }
        }
      
        public bool StatusFlag
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.StatusFlag : false;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.StatusFlag = value;
            }
        }
       
        public string DepartmentIdWithName
        {
            get
            {
                return (AdminRoleApplicableDetailsDTO != null) ? AdminRoleApplicableDetailsDTO.DepartmentIdWithName : string.Empty;
            }
            set
            {
                AdminRoleApplicableDetailsDTO.DepartmentIdWithName = value;
            }
        }
    }
}
