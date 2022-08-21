using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{


    public class OrganisationSyllabusGroupMasterViewModel : IOrganisationSyllabusGroupMasterViewModel
    {

        public OrganisationSyllabusGroupMasterViewModel()
        {
            OrganisationSyllabusGroupMasterDTO = new OrganisationSyllabusGroupMaster();
            ListOrganisationSyllabusGroupMaster = new List<OrganisationSyllabusGroupMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        }

        public OrganisationSyllabusGroupMaster OrganisationSyllabusGroupMasterDTO { get; set; }

        public List<OrganisationSyllabusGroupMaster> ListOrganisationSyllabusGroupMaster
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
        public string SessionName { get; set; }
      
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
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.ID > 0) ? OrganisationSyllabusGroupMasterDTO.ID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.ID = value;
            }
        }
        public Int16 SubjectTypeNumber
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.SubjectTypeNumber > 0) ? OrganisationSyllabusGroupMasterDTO.SubjectTypeNumber : new Int16();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SubjectTypeNumber = value;
            }
        }


        public int SubjectGroupID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.SubjectGroupID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SubjectGroupID = value;
            }
        }

        public bool SyllabusUnitType
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.SyllabusUnitType : false;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SyllabusUnitType = value;
            }
        }
        public string SyllabusDesc
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.SyllabusDesc : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SyllabusDesc = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.CreatedBy > 0) ? OrganisationSyllabusGroupMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.ModifiedBy.HasValue) ? OrganisationSyllabusGroupMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.ModifiedDate.HasValue) ? OrganisationSyllabusGroupMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.DeletedBy.HasValue) ? OrganisationSyllabusGroupMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.DeletedDate.HasValue) ? OrganisationSyllabusGroupMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.DeletedDate = value;
            }
        }

     

        ///<summary>
        ///Properties required for USP_OrgSyllabusGroupMaster_SelectAll 
        ///</summary>



        public string GroupingColumn
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.GroupingColumn : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.GroupingColumn = value;
            }
        }

        public int BranchID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.BranchID > 0) ? OrganisationSyllabusGroupMasterDTO.BranchID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.BranchID = value;
            }
        }

        public string BranchDescription
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.BranchDescription : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.BranchDescription = value;
            }
        }

        public string BranchShortCode
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.BranchShortCode : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.BranchShortCode = value;
            }
        }

        public int UniverstiyID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.UniversityID > 0) ? OrganisationSyllabusGroupMasterDTO.UniversityID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.UniversityID = value;
            }
        }

        public bool IsCommonBranchApplicable
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.IsCommonBranchApplicable : false;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.IsCommonBranchApplicable = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.CentreCode = value;
            }
        }

        public int CourseYearID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.CourseYearID > 0) ? OrganisationSyllabusGroupMasterDTO.CourseYearID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.CourseYearID = value;
            }
        }

        public string CourseYearCode
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.CourseYearCode : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.CourseYearCode = value;
            }
        }

        public int OrgSemesterMstID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.OrgSemesterMstID > 0) ? OrganisationSyllabusGroupMasterDTO.OrgSemesterMstID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.OrgSemesterMstID = value;
            }
        }

        public string SemesterType
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.SemesterType : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SemesterType = value;
            }
        }

        public string OrgSemesterName
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.OrgSemesterName : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.OrgSemesterName = value;
            }
        }

        public string OrgSemesterCode
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.OrgSemesterCode : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.OrgSemesterCode = value;
            }
        }

        public int CourseYearSemesterID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.CourseYearSemesterID > 0) ? OrganisationSyllabusGroupMasterDTO.CourseYearSemesterID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.CourseYearSemesterID = value;
            }
        }

        public int OrgSubjectGrpRuleID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.OrgSubjectGrpRuleID > 0) ? OrganisationSyllabusGroupMasterDTO.OrgSubjectGrpRuleID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.OrgSubjectGrpRuleID = value;
            }
        }

        public string RuleName
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.RuleName : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.RuleName = value;
            }
        }

        public string RuleCode
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.RuleCode : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.RuleCode = value;
            }
        }

        public int SessionID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.SessionID > 0) ? OrganisationSyllabusGroupMasterDTO.SessionID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SessionID = value;
            }
        }

        public int SubjectID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.SubjectID > 0) ? OrganisationSyllabusGroupMasterDTO.SubjectID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SubjectID = value;
            }
        }

        public int SubjectCombgrpID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.SubjectCombgrpID > 0) ? OrganisationSyllabusGroupMasterDTO.SubjectCombgrpID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SubjectCombgrpID = value;
            }
        }

        public string SubjectGroupDesc
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.SubjectGroupDesc : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SubjectGroupDesc = value;
            }
        }

        public string SubjectGroupShortDesc
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.SubjectGroupShortDesc : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SubjectGroupShortDesc = value;
            }
        }

        public string SubjectTypeName
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.SubjectTypeName : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SubjectTypeName = value;
            }
        }

        public bool StatusFlag
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.StatusFlag : false;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.StatusFlag = value;
            }
        }


        public string SubjectName
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.SubjectName : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SubjectName = value;
            }
        }

        ///<summary>
        ///Properties required for OrgSyllabusGroupDetails
        ///</summary>


        public int SyllabusGroupID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.SyllabusGroupID > 0) ? OrganisationSyllabusGroupMasterDTO.SyllabusGroupID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SyllabusGroupID = value;
            }
        }

        public int SyllabusGrpDetailsID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.SyllabusGrpDetailsID > 0) ? OrganisationSyllabusGroupMasterDTO.SyllabusGrpDetailsID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SyllabusGrpDetailsID = value;
            }
        }

        [Display(Name = "DisplayName_UnitDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UnitDescriptionRequired")]
        public string UnitDescription
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.UnitDescription : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.UnitDescription = value;
            }
        }

        [Display(Name = "DisplayName_UnitWeightage", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UnitWeightageRequired")]
        public string UnitWeightage
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.UnitWeightage : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.UnitWeightage = value;
            }
        }

        [Display(Name = "DisplayName_UnitPercentage", ResourceType = typeof(AMS.Common.Resources))]
        public int UnitPercentage
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.UnitPercentage > 0) ? OrganisationSyllabusGroupMasterDTO.UnitPercentage : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.UnitPercentage = value;
            }
        }

        [Display(Name = "DisplayName_NoOfLecturesForUnit", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NoOfLecturesForUnitRequired")]
        public int NoOfLecturesForUnit
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.NoOfLecturesForUnit > 0) ? OrganisationSyllabusGroupMasterDTO.NoOfLecturesForUnit : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.NoOfLecturesForUnit = value;
            }
        }

        [Display(Name = "DisplayName_UnitStatus", ResourceType = typeof(AMS.Common.Resources))]
        public bool UnitStatus
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.UnitStatus : false;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.UnitStatus = value;
            }
        }


        public string UnitName
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.UnitName : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.UnitName = value;
            }
        }

        ///<summary>
        ///Properties required for OrgSyllabusGroupTopics
        ///</summary>


        public int SyllabusGroupDetID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.SyllabusGroupDetID > 0) ? OrganisationSyllabusGroupMasterDTO.SyllabusGroupDetID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SyllabusGroupDetID = value;
            }
        }

        public int SyllabusGrpTopicsID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.SyllabusGrpTopicsID > 0) ? OrganisationSyllabusGroupMasterDTO.SyllabusGrpTopicsID : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SyllabusGrpTopicsID = value;
            }
        }

        [Display(Name = "DisplayName_TopicName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TopicNameRequired")]
        public string TopicName
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.TopicName : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.TopicName = value;
            }
        }

        [Display(Name = "DisplayName_TopicDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TopicDescriptionRequired")]
        public string TopicDescription
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.TopicDescription : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.TopicDescription = value;
            }
        }

        [Display(Name = "DisplayName_TopicWeightage", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TopicWeightageRequired")]
        public string TopicWeightage
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.TopicWeightage : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.TopicWeightage = value;
            }
        }

        [Display(Name = "DisplayName_TopicPercentage", ResourceType = typeof(AMS.Common.Resources))]
        public int TopicPercentage
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.TopicPercentage > 0) ? OrganisationSyllabusGroupMasterDTO.TopicPercentage : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.TopicPercentage = value;
            }
        }

        [Display(Name = "DisplayName_NoOfLecturesForTopic", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NoOfLecturesForTopic")]
        public int NoOfLecturesForTopic
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null && OrganisationSyllabusGroupMasterDTO.NoOfLecturesForTopic > 0) ? OrganisationSyllabusGroupMasterDTO.NoOfLecturesForTopic : new int();
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.NoOfLecturesForTopic = value;
            }
        }

        [Display(Name = "DisplayName_TopicStatus", ResourceType = typeof(AMS.Common.Resources))]
        public bool TopicStatus
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.TopicStatus : false;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.TopicStatus = value;
            }
        }

        public string SyllabusGrpAndDetailID
        {
            get
            {
                return (OrganisationSyllabusGroupMasterDTO != null) ? OrganisationSyllabusGroupMasterDTO.SyllabusGrpAndDetailID : string.Empty;
            }
            set
            {
                OrganisationSyllabusGroupMasterDTO.SyllabusGrpAndDetailID = value;
            }

        }
    }
}
