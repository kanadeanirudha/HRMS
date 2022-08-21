using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
  public  class OrganisationSubjectGrpRuleBaseViewModel : IOrganisationSubjectGrpRuleBaseViewModel
    {
        public OrganisationSubjectGrpRuleBaseViewModel()
        {
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();       
            ListOrgStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>(); 
            ListOrganisationCourseYearSemester = new List<OrganisationCourseYearSemester>();
        }

        public OrganisationSubjectGrpRule OrganisationSubjectGrpRuleDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<OrganisationStudyCentreMaster> ListOrgStudyCentreMaster
        {
            get;
            set;
        }
        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }
        public List<OrganisationCourseYearSemester> ListOrganisationCourseYearSemester
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
        public string SelectedCourseYearSemesterID
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
        public IEnumerable<SelectListItem> ListOrganisationCourseYearSemesterItems
        {
            get
            {
                return new SelectList(ListOrganisationCourseYearSemester, "SessionID", "SessionName");
            }
        }

  }
  public class OrganisationSubjectGrpRuleViewModel : IOrganisationSubjectGrpRuleViewModel
    {

      public OrganisationSubjectGrpRuleViewModel()
        {
           OrganisationSubjectGrpRuleDTO = new OrganisationSubjectGrpRule();
           ListOrganisationElectiveGroup = new List<OrganisationSubjectGrpRule>();
        }

      public List<OrganisationSubjectGrpRule> ListOrganisationElectiveGroup
      {
          get;
          set;
      }
      public IEnumerable<SelectListItem> ListOrganisationElectiveGroupMasterItems
      {
          get
          {

              return new SelectList(ListOrganisationElectiveGroup, "OrgElectiveGrpMasterID", "GroupName");
          }

      }
        public OrganisationSubjectGrpRule OrganisationSubjectGrpRuleDTO { get; set; }

        public int ID
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null && OrganisationSubjectGrpRuleDTO.ID > 0) ? OrganisationSubjectGrpRuleDTO.ID : new int();
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_MaxOptSubjects", ResourceType = typeof(AMS.Common.Resources))]
        public int MaxOptSubjects
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null && OrganisationSubjectGrpRuleDTO.MaxOptSubjects > 0) ? OrganisationSubjectGrpRuleDTO.MaxOptSubjects : new int();
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.MaxOptSubjects = value;
            }
        }

        [Display(Name = "DisplayName_NoOfOptSubjects", ResourceType = typeof(AMS.Common.Resources))]
        public int NoOfOptSubjects
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null && OrganisationSubjectGrpRuleDTO.NoOfOptSubjects > 0) ? OrganisationSubjectGrpRuleDTO.NoOfOptSubjects : new int();
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.NoOfOptSubjects = value;
            }
        }

        [Display(Name = "DisplayName_MaxGroups", ResourceType = typeof(AMS.Common.Resources))]
        public int MaxGroups
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null && OrganisationSubjectGrpRuleDTO.MaxGroups > 0) ? OrganisationSubjectGrpRuleDTO.MaxGroups : new int();
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.MaxGroups = value;
            }
        }

        [Display(Name = "DisplayName_MaxCompulsorySubjects", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MaxCompulsorySubjectsRequired")]
        public int MaxCompulsorySubjects
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.MaxCompulsorySubjects : new int();
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.MaxCompulsorySubjects = value;
            }
        }

        [Display(Name = "DisplayName_MaxNoOfCompulsoryGroups", ResourceType = typeof(AMS.Common.Resources))]
        public int MaxNoOfCompulsoryGroups
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.MaxNoOfCompulsoryGroups : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.MaxNoOfCompulsoryGroups = value;
          }
      }

        [Display(Name = "DisplayName_TotalSubjects", ResourceType = typeof(AMS.Common.Resources))]
        public int TotalSubjects
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.TotalSubjects : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.TotalSubjects = value;
          }
      }

        public int OrgSessionCryrAllotID
            {
                get
                {
                    return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.OrgSessionCryrAllotID : new int();
                }
                set
                {
                    OrganisationSubjectGrpRuleDTO.OrgSessionCryrAllotID = value;
                }
            }
        public int CourseYearSemesterID
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.CourseYearSemesterID : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.CourseYearSemesterID = value;
          }
      }

        [Display(Name = "DisplayName_RuleName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RuleNameRequired")]
        public string RuleName
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.RuleName : string.Empty;
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.RuleName = value;
            }
        }

        [Display(Name = "DisplayName_RuleCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RuleCodeRequired")]
        public string RuleCode
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.RuleCode : string.Empty;
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.RuleCode = value;
            }

        }

        public string OrgSemesterName
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.OrgSemesterName : string.Empty;
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.OrgSemesterName = value;
            }

        }
        public string CourseYearCode
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.CourseYearCode : string.Empty;
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.CourseYearCode = value;
            }

        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
          {
              get
              {
                  return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.IsActive : false;
              }
              set
              {
                  OrganisationSubjectGrpRuleDTO.IsActive = value;
              }
          }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.IsDeleted: false;
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.IsDeleted= value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null && OrganisationSubjectGrpRuleDTO.CreatedBy > 0) ? OrganisationSubjectGrpRuleDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null && OrganisationSubjectGrpRuleDTO.ModifiedBy.HasValue) ? OrganisationSubjectGrpRuleDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null && OrganisationSubjectGrpRuleDTO.ModifiedDate.HasValue) ? OrganisationSubjectGrpRuleDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null && OrganisationSubjectGrpRuleDTO.DeletedBy.HasValue) ? OrganisationSubjectGrpRuleDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationSubjectGrpRuleDTO != null && OrganisationSubjectGrpRuleDTO.DeletedDate.HasValue) ? OrganisationSubjectGrpRuleDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectGrpRuleDTO.DeletedDate = value;
            }
        }

       public string SelectedCourseYearSemesterID
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


        /// <summary>
        /// Properties for OrganisationSubjectGroupRuleSessionwise table
        /// </summary>      
        /// <returns></returns>



      public int SessionID
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.SessionID : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.SessionID = value;
          }
      }

      public int OrgSubGrpRuleSessionwiseID
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.OrgSubGrpRuleSessionwiseID : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.OrgSubGrpRuleSessionwiseID = value;
          }
      }
      public int OrgSessionCryAllocationID
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.OrgSessionCryAllocationID : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.OrgSessionCryAllocationID = value;
          }
      }
      
      public string BranchDescription
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.BranchDescription : string.Empty;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.BranchDescription = value;
          }

      }

      public string SemesterName
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.SemesterName : string.Empty;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.SemesterName = value;
          }

      }
      public string BranchShortCode
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.BranchShortCode : string.Empty;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.BranchShortCode = value;
          }

      }

      public bool StatusFlag
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.StatusFlag : false;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.StatusFlag = value;
          }
      }
      public bool SessionCryAllocationStatus
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.SessionCryAllocationStatus : false;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.SessionCryAllocationStatus = value;
          }
      }







      /// <summary>
      /// Properties for OrgElectiveGrpMaster table
      /// </summary>      
      /// <returns></returns>     
      public int OrgElectiveGrpMasterID
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.OrgElectiveGrpMasterID : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.OrgElectiveGrpMasterID = value;
          }
      }

      [Display(Name = "DisplayName_GroupName", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GroupNameRequired")]
      public string GroupName
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.GroupName : string.Empty;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.GroupName = value;
          }

      }

      [Display(Name = "DisplayName_GroupShortCode", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GroupShortCodeRequired")]
      public string GroupShortCode
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.GroupShortCode : string.Empty;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.GroupShortCode = value;
          }

      }

      public int SubjectRuleGrpNumber
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.SubjectRuleGrpNumber : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.SubjectRuleGrpNumber = value;
          }
      }

      [Display(Name = "DisplayName_GroupCompulsoryFlag", ResourceType = typeof(AMS.Common.Resources))]
      public bool GroupCompulsoryFlag
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.GroupCompulsoryFlag : false;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.GroupCompulsoryFlag = value;
          }
      }

      [Display(Name = "DisplayName_NoOfSubGroups", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NoOfSubGroupsRequired")]
      public int NoOfSubGroups
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.NoOfSubGroups : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.NoOfSubGroups = value;
          }
      }

     [Display(Name = "DisplayName_NoOfCompulsorySubGrp", ResourceType = typeof(AMS.Common.Resources))]
     [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NoOfCompulsorySubGrpRequired")]

      public int NoOfCompulsorySubGrp
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.NoOfCompulsorySubGrp : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.NoOfCompulsorySubGrp = value;
          }
      }

      [Display(Name = "DisplayName_NoOfSubGrpSubjectSelect", ResourceType = typeof(AMS.Common.Resources))]
      public int NoOfSubGrpSubjectSelect
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.NoOfSubGrpSubjectSelect : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.NoOfSubGrpSubjectSelect = value;
          }
      }

      public string ElectiveCommonGroup
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.ElectiveCommonGroup : string.Empty;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.ElectiveCommonGroup = value;
          }
      }




      ///<summary>
      ///Properties required for OrgSubElectiveGrpMaster table
      ///<returns><returns>

     
      public int OrgSubElectiveGrpMasterID
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.OrgSubElectiveGrpMasterID : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.OrgSubElectiveGrpMasterID = value;
          }
      }

      [Display(Name = "DisplayName_OrgElectiveGrpID", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OrgElectiveGrpIDRequired")]
      public int OrgElectiveGrpID
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.OrgElectiveGrpID : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.OrgElectiveGrpID = value;
          }
      }

      [Display(Name = "DisplayName_OrgSubElectiveGrpDescription", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OrgSubElectiveGrpDescriptionRequired")]
      public string OrgSubElectiveGrpDescription
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.OrgSubElectiveGrpDescription : string.Empty;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.OrgSubElectiveGrpDescription = value;
          }
      }

      [Display(Name = "DisplayName_SubElectiveShortDescription", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SubElectiveShortDescriptionRequired")]
      public string ShortDescription
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.ShortDescription : string.Empty;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.ShortDescription = value;
          }
      }

      [Display(Name = "DisplayName_TotalNoOfSubjects", ResourceType = typeof(AMS.Common.Resources))]
      public int TotalNoOfSubjects
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.TotalNoOfSubjects : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.TotalNoOfSubjects = value;
          }
      }

      public bool SubGrpCompulsorySubjFlag
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.SubGrpCompulsorySubjFlag : false;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.SubGrpCompulsorySubjFlag = value;
          }
      }

      [Display(Name = "DisplayName_AllowToSelect", ResourceType = typeof(AMS.Common.Resources))]
      public int AllowToSelect
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.AllowToSelect : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.AllowToSelect = value;
          }
      }

      [Display(Name = "DisplayName_SubGroupCompulsoryFlag", ResourceType = typeof(AMS.Common.Resources))]
      public bool SubGroupCompulsoryFlag
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.SubGroupCompulsoryFlag : false;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.SubGroupCompulsoryFlag = value;
          }
      }
      public int TotalNoOfSubjectCompulsory
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.TotalNoOfSubjectCompulsory : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.TotalNoOfSubjectCompulsory = value;
          }
      }

      public string ElectiveCommonSubGroup
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.ElectiveCommonSubGroup : string.Empty;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.ElectiveCommonSubGroup = value;
          }
      }
      public bool FeeBased
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.FeeBased : false;
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.FeeBased = value;
          }
      }
      public int NextSubElectiveGrpID
      {
          get
          {
              return (OrganisationSubjectGrpRuleDTO != null) ? OrganisationSubjectGrpRuleDTO.NextSubElectiveGrpID : new int();
          }
          set
          {
              OrganisationSubjectGrpRuleDTO.NextSubElectiveGrpID = value;
          }
      }




      public List<OrganisationSubjectGrpRule> ListOrganisationSubjectGrpRule
      {
          get;
          set;
      }

      public List<OrganisationSubjectGrpRule> ListOrganisationSubElectiveGrpRule
      {
          get;
          set;
      }
      public string errorMessage { get; set; }






    }
}
