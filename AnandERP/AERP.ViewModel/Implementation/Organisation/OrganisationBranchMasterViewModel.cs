using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{


    public class OrganisationBranchMasterBaseViewModel : IOrganisationBranchMasterBaseViewModel
    {
        public OrganisationBranchMasterBaseViewModel()
        {
            ListOrganisationBranchMaster = new List<OrganisationBranchMaster>();

            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();

            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();

        }

        public List<OrganisationBranchMaster> ListOrganisationBranchMaster
        {
            get;
            set;
        }

        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }

        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }

        public string SelectedUniversityID
        {
            get;
            set;
        }

        public string SelectedDepartmentID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListOrganisationUniversityMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationUniversityMaster, "ID", "UniversityName");
            }
        }

    }

    public class OrganisationBranchMasterViewModel : IOrganisationBranchMasterViewModel
    {

        public OrganisationBranchMasterViewModel()
        {
            OrganisationBranchMasterDTO = new OrganisationBranchMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }

        public string SelectedCentreCode
        {
            get;
            set;
        }
        [Display(Name = "DisplayName_SelectedUniversityID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityIDRequired")]
        //[Required(ErrorMessage = "University must be selected")]
        public string SelectedUniversityID
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
        public IEnumerable<SelectListItem> ListOrganisationUnivesitytMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationUniversityMaster, "ID", "UniversityName");
            }

        }
        public OrganisationBranchMaster OrganisationBranchMasterDTO { get; set; }

        public int ID
        {
            get
            {
                return (OrganisationBranchMasterDTO != null && OrganisationBranchMasterDTO.ID > 0) ? OrganisationBranchMasterDTO.ID : new int();
            }
            set
            {
                OrganisationBranchMasterDTO.ID = value;
            }
        }

        public int UniversityID
        {
            get
            {
                return (OrganisationBranchMasterDTO != null && OrganisationBranchMasterDTO.UniversityID > 0) ? OrganisationBranchMasterDTO.UniversityID : new int();
            }
            set
            {
                OrganisationBranchMasterDTO.UniversityID = value;
            }
        }
        [Required(ErrorMessage = "Department should not be blank")]
        public int DepartmentID
        {
            get
            {
                return (OrganisationBranchMasterDTO != null && OrganisationBranchMasterDTO.DepartmentID > 0) ? OrganisationBranchMasterDTO.DepartmentID : new int();
            }
            set
            {
                OrganisationBranchMasterDTO.DepartmentID = value;
            }
        }

        public int DepartmentBranchID
        {
            get
            {
                return (OrganisationBranchMasterDTO != null && OrganisationBranchMasterDTO.DepartmentBranchID > 0) ? OrganisationBranchMasterDTO.DepartmentBranchID : new int();
            }
            set
            {
                OrganisationBranchMasterDTO.DepartmentBranchID = value;
            }
        }
        //[Required(ErrorMessage = "Duration In Days should not be blank")]
        [Display(Name = "DisplayName_DurationInDays", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DurationInDaysRequired")]
        public Int16 DurationInDays
        {
            get
            {
                return (OrganisationBranchMasterDTO != null && OrganisationBranchMasterDTO.DurationInDays > 0) ? OrganisationBranchMasterDTO.DurationInDays : new Int16();
            }
            set
            {
                OrganisationBranchMasterDTO.DurationInDays = value;
            }
        }

        [Display(Name = "DisplayName_BranchDescriptionCourseMaster", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BranchDescriptionCourseMasterRequired")]
        public string BranchDescription
        {
            get
            {
                return (OrganisationBranchMasterDTO != null) ? OrganisationBranchMasterDTO.BranchDescription : string.Empty;
            }
            set
            {
                OrganisationBranchMasterDTO.BranchDescription = value;
            }
        }

        [Display(Name = "DisplayName_BranchShortCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BranchShortCodeRequired")]
        public string BranchShortCode
        {
            get
            {
                return (OrganisationBranchMasterDTO != null) ? OrganisationBranchMasterDTO.BranchShortCode : string.Empty;
            }
            set
            {
                OrganisationBranchMasterDTO.BranchShortCode = value;
            }
        }

        [Display(Name = "DisplayName_PrintShortCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PrintShortCodeRequired")]
        public string PrintShortCode
        {
            get
            {
                return (OrganisationBranchMasterDTO != null) ? OrganisationBranchMasterDTO.PrintShortCode : string.Empty;
            }
            set
            {
                OrganisationBranchMasterDTO.PrintShortCode = value;
            }
        }

        [Display(Name = "DisplayName_CommonBranch", ResourceType = typeof(AMS.Common.Resources))]
        public bool CommonBranch
        {
            get
            {
                return (OrganisationBranchMasterDTO != null) ? OrganisationBranchMasterDTO.CommonBranch : false;
            }
            set
            {
                OrganisationBranchMasterDTO.CommonBranch = value;
            }
        }


        [Display(Name = "DisplayName_IsCommonBranchApplicable", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsCommonBranchApplicable
        {
            get
            {
                return (OrganisationBranchMasterDTO != null) ? OrganisationBranchMasterDTO.IsCommonBranchApplicable : false;
            }
            set
            {
                OrganisationBranchMasterDTO.IsCommonBranchApplicable = value;
            }
        }


        [Display(Name = "DisplayName_IntroductionYear", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_IntroductionYearRequired")]
        public int IntroductionYear
        {
            get
            {
                return (OrganisationBranchMasterDTO != null) ? OrganisationBranchMasterDTO.IntroductionYear : new int();
            }
            set
            {
                OrganisationBranchMasterDTO.IntroductionYear = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationBranchMasterDTO != null && OrganisationBranchMasterDTO.CreatedBy > 0) ? OrganisationBranchMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationBranchMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationBranchMasterDTO != null) ? OrganisationBranchMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationBranchMasterDTO.CreatedDate = value;
            }
        }

        public Nullable<int> ModifiedBy
        {
            get
            {
                return (OrganisationBranchMasterDTO != null && OrganisationBranchMasterDTO.ModifiedBy > 0) ? OrganisationBranchMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationBranchMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (OrganisationBranchMasterDTO != null) ? OrganisationBranchMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationBranchMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (OrganisationBranchMasterDTO != null && OrganisationBranchMasterDTO.DeletedBy > 0) ? OrganisationBranchMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationBranchMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Deleted Date")]
        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (OrganisationBranchMasterDTO != null) ? OrganisationBranchMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationBranchMasterDTO.DeletedDate = value;
            }
        }



        public bool IsDeleted
        {
            get
            {
                return (OrganisationBranchMasterDTO != null) ? OrganisationBranchMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationBranchMasterDTO.IsDeleted = value;
            }
        }


        public List<OrganisationDepartmentBranch> OrganisationDepartmentBranchDTO
        {
            get;
            set;
        }

        //[Display(Name = "DisplayName_SelectedUniversityID", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedUniversityIDRequired")]
        //public string SelectedUniversityID
        //{
        //    get;
        //    set;
        //}

        [Display(Name = "DisplayName_SelectedDepartmentID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedDepartmentIDRequired")]
        public string SelectedDepartmentID
        {
            get;
            set;
        }

    }

}
