using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
   
    public class OrganisationSubjectGroupDetailsViewModel : IOrganisationSubjectGroupDetailsViewModel
    {

        public OrganisationSubjectGroupDetailsViewModel()
        {
            OrganisationSubjectGroupDetailsDTO = new OrganisationSubjectGroupDetails();
            OrganisationSubjectTypeMasterList = new List<OrganisationSubjectGroupDetails>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();


        }

        public OrganisationSubjectGroupDetails OrganisationSubjectGroupDetailsDTO 
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
        //public string BranchDescription
        //{
        //    get;
        //    set;
        //}

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
        public int ID
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null && OrganisationSubjectGroupDetailsDTO.ID > 0) ? OrganisationSubjectGroupDetailsDTO.ID : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_SubjectID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SubjectIDRequired")]
        public int SubjectID
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.SubjectID : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.SubjectID = value;
            }
        }
        [Display(Name = "DisplayName_ShortDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ShortDescriptionRequired")]
        public string ShortDescription
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.ShortDescription : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.ShortDescription = value;
            }
        }
        public int UniversityID
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null && OrganisationSubjectGroupDetailsDTO.UniversityID > 0) ? OrganisationSubjectGroupDetailsDTO.UniversityID : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.UniversityID = value;
            }
        }
        [Display(Name = "DisplayName_SubjectGroupDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SubjectGroupDescriptionRequired")]
       public string Description
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.Description : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.Description = value;
            }
        }
       public int OrgSemesterMstID
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.OrgSemesterMstID : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.OrgSemesterMstID = value;
            }
        }

      public int CourseYearDetailID
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.CourseYearDetailID : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.CourseYearDetailID = value;
            }
        }

      public int SubjectRuleGrpNumber
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.SubjectRuleGrpNumber : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.SubjectRuleGrpNumber = value;
            }
        }
      public string CompulsoryOptionalFlag
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.CompulsoryOptionalFlag : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.CompulsoryOptionalFlag = value;
            }
        }
      [Display(Name = "DisplayName_UniversityCode", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityCodeRequired")]
      public string UniversityCode
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.UniversityCode : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.UniversityCode = value;
            }
        }
      public string Pattern
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.Pattern : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.Pattern = value;
            }
        }
      public string ElectiveGroupFlag
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.ElectiveGroupFlag : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.ElectiveGroupFlag = value;
            }
        }

      [Display(Name = "DisplayName_OrgElectiveGrpID", ResourceType = typeof(AMS.Common.Resources))]
      public int OrgElectiveGrpID
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.OrgElectiveGrpID : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.OrgElectiveGrpID = value;
            }
        }
     
      public string ElectiveSubGroupFlag
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.ElectiveSubGroupFlag : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.ElectiveSubGroupFlag = value;
            }
        }
      [Display(Name = "DisplayName_OrgSubElectiveGrpID", ResourceType = typeof(AMS.Common.Resources))]
      public int OrgSubElectiveGrpID
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.OrgSubElectiveGrpID : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.OrgSubElectiveGrpID = value;
            }
        }
        public string ElectiveSubjectCompFlag
      {
          get
          {
              return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.ElectiveSubjectCompFlag : string.Empty;
          }
          set
          {
              OrganisationSubjectGroupDetailsDTO.ElectiveSubjectCompFlag = value;
          }
        }
         [Display(Name = "DisplayName_IsElectiveSubjectCompFlag", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsElectiveSubjectCompFlag
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.IsElectiveSubjectCompFlag : false;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.IsElectiveSubjectCompFlag = value;
            }
        }
         public string CentreCode
         {
             get
             {
                 return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.CentreCode : string.Empty;
             }
             set
             {
                 OrganisationSubjectGroupDetailsDTO.CentreCode = value;
             }
         }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.IsDeleted : false;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null && OrganisationSubjectGroupDetailsDTO.CreatedBy > 0) ? OrganisationSubjectGroupDetailsDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null && OrganisationSubjectGroupDetailsDTO.ModifiedBy.HasValue) ? OrganisationSubjectGroupDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null && OrganisationSubjectGroupDetailsDTO.ModifiedDate.HasValue) ? OrganisationSubjectGroupDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null && OrganisationSubjectGroupDetailsDTO.DeletedBy.HasValue) ? OrganisationSubjectGroupDetailsDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null && OrganisationSubjectGroupDetailsDTO.DeletedDate.HasValue) ? OrganisationSubjectGroupDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.DeletedDate = value;
            }
        }
        [Display(Name = "DisplayName_IsCompulsory", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsCompulsory
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.IsCompulsory : false;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.IsCompulsory = value;
            }
        }
        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.IsActive : false;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.IsActive = value;
            }
        }
        public string BranchDescription
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.BranchDescription : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.BranchDescription = value;
            }
        }

        public string CourseYearCode
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.CourseYearCode : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.CourseYearCode = value;
            }
        }
        public string OrgSemesterName
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.OrgSemesterName : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.OrgSemesterName = value;
            }
        }
        public string SemesterType
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.SemesterType : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.SemesterType = value;
            }
        }
        public string RuleName
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.RuleName : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.RuleName = value;
            }
        }

        public string ConcateField
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.ConcateField : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.ConcateField = value;
            }
        }
        public int SessionID
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.SessionID : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.SessionID = value;
            }
        }


        public bool StatusFlag
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.StatusFlag : false;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.StatusFlag = value;
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


        // For Datatable
        public bool Select_Row
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.Select_Row : false;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.Select_Row = value;
            }
        }
        public int SubjectTypeID
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.SubjectTypeID : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.SubjectTypeID = value;
            }

        }
        public string SubjectType_Row
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.SubjectType_Row : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.SubjectType_Row = value;
            }
        }

        public bool Internal_Row
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.Internal_Row : false;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.Internal_Row = value;
            }

        }
        public int Internal_Max_Marks
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.Internal_Max_Marks : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.Internal_Max_Marks = value;
            }

        }
        public int Internal_Passing_Marks
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.Internal_Passing_Marks : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.Internal_Passing_Marks = value;
            }

        }
        public bool External_Row
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.External_Row : false;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.External_Row = value;
            }
        }
        public int External_Max_Marks
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.External_Max_Marks : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.External_Max_Marks = value;
            }

        }
        public int External_Passing_Marks
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.External_Passing_Marks : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.External_Passing_Marks = value;
            }

        }
        public int External_Group_Max_Marks
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.External_Group_Max_Marks : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.External_Group_Max_Marks = value;
            }
        }
        public int External_Group_Min_Marks
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.External_Group_Min_Marks : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.External_Group_Min_Marks = value;
            }

        }
        public int WeeklyPeriodAllocation
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.WeeklyPeriodAllocation : new int();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.WeeklyPeriodAllocation = value;
            }
        }
        public double ExamHours
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.ExamHours : new double();
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.ExamHours = value;
            }

        }

        public string SubjectGrpCombinationIDs
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.SubjectGrpCombinationIDs : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.SubjectGrpCombinationIDs = value;
            }
        }
        public string SubHoursGrpAllocationIDs
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.SubHoursGrpAllocationIDs : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.SubHoursGrpAllocationIDs = value;
            }
        }
        public string SubjectGrpMarksIDs
        {
            get
            {
                return (OrganisationSubjectGroupDetailsDTO != null) ? OrganisationSubjectGroupDetailsDTO.SubjectGrpMarksIDs : string.Empty;
            }
            set
            {
                OrganisationSubjectGroupDetailsDTO.SubjectGrpMarksIDs = value;
            }
        }
        public IEnumerable<SelectListItem> OrganisationSubjectTypeMasterListItems
        {
            get
            {
                return new SelectList(OrganisationSubjectTypeMasterList, "ID", "TypeName");
            }
        }

        public List<OrganisationSubjectGroupDetails> OrganisationSubjectTypeMasterList 
        {
            get;
            set;
        }

        public string errorMessage { get; set; }

    }
}
