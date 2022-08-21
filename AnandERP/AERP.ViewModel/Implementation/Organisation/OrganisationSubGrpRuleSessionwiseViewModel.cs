using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
  public  class OrganisationSubGrpRuleSessionwiseBaseViewModel : IOrganisationSubGrpRuleSessionwiseBaseViewModel
    {
        public OrganisationSubGrpRuleSessionwiseBaseViewModel()
        {
            ListOrgStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
            ListGeneralSessionMaster = new List<GeneralSessionMaster>();
            ListOrganisationCourseYearSemester = new List<OrganisationCourseYearSemester>();
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public OrganisationSubGrpRuleSessionwise OrganisationSubGrpRuleSessionwiseDTO
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
        public List<GeneralSessionMaster> ListGeneralSessionMaster
        {
            get;
            set;
        }
        public List<OrganisationCourseYearSemester> ListOrganisationCourseYearSemester
        {
            get;
            set;
        }
        public string SessionName { get; set; }
        public int SessionID { get; set; }
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
        public string SelectedSessionID
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
        public IEnumerable<SelectListItem> ListGeneralSessionMasterItems
        {
            get
            {
                return new SelectList(ListGeneralSessionMaster, "ID", "SessionName");
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
  public class OrganisationSubGrpRuleSessionwiseViewModel : IOrganisationSubGrpRuleSessionwiseViewModel
    {

      public OrganisationSubGrpRuleSessionwiseViewModel()
        {
           OrganisationSubGrpRuleSessionwiseDTO = new OrganisationSubGrpRuleSessionwise();
        }

        public OrganisationSubGrpRuleSessionwise OrganisationSubGrpRuleSessionwiseDTO { get; set; }

        public int ID
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null && OrganisationSubGrpRuleSessionwiseDTO.ID > 0) ? OrganisationSubGrpRuleSessionwiseDTO.ID : new int();
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.ID = value;
            }
        }
        public int SubjectRuleGrpNumber
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null && OrganisationSubGrpRuleSessionwiseDTO.SubjectRuleGrpNumber > 0) ? OrganisationSubGrpRuleSessionwiseDTO.SubjectRuleGrpNumber : new int();
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.SubjectRuleGrpNumber = value;
            }
        }


        public int SessionID
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null) ? OrganisationSubGrpRuleSessionwiseDTO.SessionID : new int();
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.SessionID = value;
            }
        }
        public int OrgSessionCryAllocationID
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null) ? OrganisationSubGrpRuleSessionwiseDTO.OrgSessionCryAllocationID : new int();
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.OrgSessionCryAllocationID = value;
            }
        }
        public int CourseYearSemesterID
      {
          get
          {
              return (OrganisationSubGrpRuleSessionwiseDTO != null) ? OrganisationSubGrpRuleSessionwiseDTO.CourseYearSemesterID : new int();
          }
          set
          {
              OrganisationSubGrpRuleSessionwiseDTO.CourseYearSemesterID = value;
          }
      }

        [Display(Name = "DisplayName_IsActiveSessionwiseRule", ResourceType = typeof(Resources))]
        public bool IsActive
          {
              get
              {
                  return (OrganisationSubGrpRuleSessionwiseDTO != null) ? OrganisationSubGrpRuleSessionwiseDTO.IsActive : false;
              }
              set
              {
                  OrganisationSubGrpRuleSessionwiseDTO.IsActive = value;
              }
          }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(Resources))]
        public string CentreName
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null) ? OrganisationSubGrpRuleSessionwiseDTO.CentreName : string.Empty;
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.CentreName = value;
            }
        }

        [Display(Name = "DisplayName_UniversityName", ResourceType = typeof(Resources))]
        public string UniversityName
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null) ? OrganisationSubGrpRuleSessionwiseDTO.UniversityName : string.Empty;
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.UniversityName = value;
            }
        }

        [Display(Name = "DisplayName_SessionName", ResourceType = typeof(Resources))]
        public string SessionName
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null) ? OrganisationSubGrpRuleSessionwiseDTO.SessionName : string.Empty;
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.SessionName = value;
            }
        }

        public string RuleName
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null) ? OrganisationSubGrpRuleSessionwiseDTO.RuleName : string.Empty;
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.RuleName = value;
            }
        }
      
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null) ? OrganisationSubGrpRuleSessionwiseDTO.IsDeleted: false;
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.IsDeleted= value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null && OrganisationSubGrpRuleSessionwiseDTO.CreatedBy > 0) ? OrganisationSubGrpRuleSessionwiseDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null) ? OrganisationSubGrpRuleSessionwiseDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null && OrganisationSubGrpRuleSessionwiseDTO.ModifiedBy.HasValue) ? OrganisationSubGrpRuleSessionwiseDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null && OrganisationSubGrpRuleSessionwiseDTO.ModifiedDate.HasValue) ? OrganisationSubGrpRuleSessionwiseDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null && OrganisationSubGrpRuleSessionwiseDTO.DeletedBy.HasValue) ? OrganisationSubGrpRuleSessionwiseDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationSubGrpRuleSessionwiseDTO != null && OrganisationSubGrpRuleSessionwiseDTO.DeletedDate.HasValue) ? OrganisationSubGrpRuleSessionwiseDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubGrpRuleSessionwiseDTO.DeletedDate = value;
            }
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
        public string SelectedSessionID
        {
            get;
            set;
        }
        public string SelectedCourseYearSemesterID
        {
            get;
            set;
        }
    }
}
