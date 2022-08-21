using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
  public  class OrganisationSessionCryrAllocationBaseViewModel : IOrganisationSessionCryrAllocationBaseViewModel
    {
        public OrganisationSessionCryrAllocationBaseViewModel()
        {
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrgStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        }
        public string SessionName { get; set; }
        public int SessionID { get; set; }
        public OrganisationSessionCryrAllocation OrganisationSessionCryrAllocationDTO
        {
            get;
            set;
        }
        public List<OrganisationStudyCentreMaster> ListOrgStudyCentreMaster
        {
            get;
            set;
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
        public string SelectedCentreName
        {
            get;
            set;
        }
        public string SelectedUniversityID
        {
            get;
            set;
        }
        public string BranchDescription
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
        public IEnumerable<SelectListItem> ListOrgStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrgStudyCentreMaster, "CentreCode", "CentreName");
            }
        }
       
        public IEnumerable<SelectListItem> ListOrganisationUnivesitytMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationUniversityMaster, "ID", "UniversityName");
            }

        }


  }
  public class OrganisationSessionCryrAllocationViewModel : IOrganisationSessionCryrAllocationViewModel
    {

     public OrganisationSessionCryrAllocationViewModel()
        {
           OrganisationSessionCryrAllocationDTO = new OrganisationSessionCryrAllocation();
        }

        public OrganisationSessionCryrAllocation OrganisationSessionCryrAllocationDTO { get; set; }



        public int ID
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null && OrganisationSessionCryrAllocationDTO.ID > 0) ? OrganisationSessionCryrAllocationDTO.ID : new int();
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.ID = value;
            }
        }
        public int SessionID
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.SessionID : new int();
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.SessionID = value;
            }
        }

    
        public int SemesterMasterID
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.SemesterMasterID : new int();
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.SemesterMasterID = value;
            }
        }
    

      public string SemesterType
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.SemesterType : string.Empty;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.SemesterType = value;
            }
        }

        
      public int CourseYearSemesterID
          {
              get
              {
                  return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.CourseYearSemesterID : new int();
              }
              set
              {
                  OrganisationSessionCryrAllocationDTO.CourseYearSemesterID = value;
              }
          }

      [Display(Name = "DisplayName_SemesterFromDate", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SemesterFromDateRequired")]
      public string SemesterFromDate
      {
          get
          {
              return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.SemesterFromDate : string.Empty;
          }
          set
          {
              OrganisationSessionCryrAllocationDTO.SemesterFromDate = value;
          }
      }

      [Display(Name = "DisplayName_SemesterUptoDate", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SemesterUptoDateRequired")]
      public string SemesterUptoDate
      {
          get
          {
              return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.SemesterUptoDate : string.Empty;
          }
          set
          {
              OrganisationSessionCryrAllocationDTO.SemesterUptoDate = value;
          }
      }

      [Display(Name = "DisplayName_CurrentActiveSemesterFlag", ResourceType = typeof(AMS.Common.Resources))]
      public bool CurrentActiveSemesterFlag
      {
          get
          {
              return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.CurrentActiveSemesterFlag : false;
          }
          set
          {
              OrganisationSessionCryrAllocationDTO.CurrentActiveSemesterFlag = value;
          }
      }

      [Display(Name = "DisplayName_TotalExpectedWeeks", ResourceType = typeof(AMS.Common.Resources))]
     // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TotalExpectedWeeksRequired")]
      public int TotalExpectedWeeks
      {
          get
          {
              return (OrganisationSessionCryrAllocationDTO != null ) ? OrganisationSessionCryrAllocationDTO.TotalExpectedWeeks : new int();
          }
          set
          {
              OrganisationSessionCryrAllocationDTO.TotalExpectedWeeks = value;
          }
      }

      [Display(Name = "DisplayName_PeriodStartDate", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PeriodStartDateRequired")]
      public string PeriodStartDate
      {
          get
          {
              return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.PeriodStartDate : string.Empty; 
          }
          set
          {
              OrganisationSessionCryrAllocationDTO.PeriodStartDate = value;
          }
      }

      [Display(Name = "DisplayName_PeriodEndDate", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PeriodEndDateRequired")]
      public string PeriodEndDate
      {
          get
          {
              return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.PeriodEndDate : string.Empty;
          }
          set
          {
              OrganisationSessionCryrAllocationDTO.PeriodEndDate = value;
          }
      }

      

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.IsDeleted: false;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.IsDeleted= value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null && OrganisationSessionCryrAllocationDTO.CreatedBy > 0) ? OrganisationSessionCryrAllocationDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null && OrganisationSessionCryrAllocationDTO.ModifiedBy.HasValue) ? OrganisationSessionCryrAllocationDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null && OrganisationSessionCryrAllocationDTO.ModifiedDate.HasValue) ? OrganisationSessionCryrAllocationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null && OrganisationSessionCryrAllocationDTO.DeletedBy.HasValue) ? OrganisationSessionCryrAllocationDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null && OrganisationSessionCryrAllocationDTO.DeletedDate.HasValue) ? OrganisationSessionCryrAllocationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.DeletedDate = value;
            }
        }
        public string SelectedCategoryID
        {
            get;
            set;
        }

        public string CentreCodeWithName
        {
            get;
            set;
        }

        public string UniversityIDWithName
        {
            get;
            set;
        }

        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.CentreCode = value;
            }
        }
        [Display(Name = "Centre Name")]
        public string CentreName
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.CentreName : string.Empty;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.CentreName = value;
            }
        }

        public string CourseYearCode
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.CourseYearCode : string.Empty;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.CourseYearCode = value;
            }
        }
        public string BranchDescription 
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.BranchDescription : string.Empty;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.BranchDescription = value;
            }
        }
        public string SemesterName 
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.OrgSemesterName : string.Empty;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.OrgSemesterName = value;
            }
        }
        public bool StatusFlag
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.StatusFlag : false;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.StatusFlag = value;
            }
        }
        public bool OrgSessionCryrAllotStatus
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.OrgSessionCryrAllotStatus : false;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.OrgSessionCryrAllotStatus = value;
            }
        } 
        public int OrgSessionCourseYearAllocationID
          {
              get
              {
                  return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.OrgSessionCourseYearAllocationID : new int();
              }
              set
              {
                  OrganisationSessionCryrAllocationDTO.OrgSessionCourseYearAllocationID = value;
              }
          }

      
        public string Current_CentreCode
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null && OrganisationSessionCryrAllocationDTO.Current_CentreCode != "") ? OrganisationSessionCryrAllocationDTO.Current_CentreCode : string.Empty;
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.Current_CentreCode = value;
            }
        }
        public int OrgSemesterMstID
        {
            get
            {
                return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.OrgSemesterMstID : new int();
            }
            set
            {
                OrganisationSessionCryrAllocationDTO.OrgSemesterMstID = value;
            }
        }
        //public int totalExpectedWeeks
        //{
        //    get
        //    {
        //        return (OrganisationSessionCryrAllocationDTO != null) ? OrganisationSessionCryrAllocationDTO.totalExpectedWeeks : new int();
        //    }
        //    set
        //    {
        //        OrganisationSessionCryrAllocationDTO.totalExpectedWeeks = value;
        //    }
        //}

        public string errorMessage { get; set; }
        [Display(Name = "DisplayName_SessionName", ResourceType = typeof(AMS.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StreamIDRequired")]
        public string SessionName { get; set; }

    }
}
