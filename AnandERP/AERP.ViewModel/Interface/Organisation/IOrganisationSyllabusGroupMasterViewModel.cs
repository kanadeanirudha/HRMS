using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationSyllabusGroupMasterViewModel
    {
        OrganisationSyllabusGroupMaster OrganisationSyllabusGroupMasterDTO { get; set; }

         int ID { get; set; }
         Int16 SubjectTypeNumber { get; set; }
         string SyllabusDesc { get; set; }
         bool SyllabusUnitType { get; set; }
         int SubjectGroupID { get; set; }
         bool IsDeleted { get; set; }
         int CreatedBy { get; set; }
         DateTime CreatedDate { get; set; }
         int? ModifiedBy { get; set; }
         DateTime? ModifiedDate { get; set; }
         int? DeletedBy { get; set; }
         DateTime? DeletedDate { get; set; }
        
        string SyllabusGrpAndDetailID { get; set; }

        ///<summary>
        ///Properties required for USP_OrgSyllabusGroupMaster_SelectAll 
        ///</summary>


         string GroupingColumn { get; set; }
         int BranchID { get; set; }
         string BranchDescription { get; set; }
         string BranchShortCode { get; set; }
         int UniverstiyID { get; set;}
         bool IsCommonBranchApplicable { get; set;}
         string CentreCode { get; set; }
         int CourseYearID { get; set; }
         string CourseYearCode { get; set;}
         int OrgSemesterMstID { get; set; }
         string SemesterType { get; set; }
         string OrgSemesterName { get; set; }
         string OrgSemesterCode { get; set; }
         int CourseYearSemesterID { get; set; }
         int OrgSubjectGrpRuleID { get; set; }
         string RuleName { get; set; }
         string RuleCode { get; set; }
         int SessionID { get; set; }         
         int SubjectID { get; set; }
         int SubjectCombgrpID { get; set; }
         string SubjectGroupDesc { get; set; }
         string SubjectGroupShortDesc { get; set; }        
         string SubjectTypeName { get; set; }
         bool StatusFlag { get; set; }
         string SubjectName { get; set; }

        ///<summary>
        ///Properties required for OrgSyllabusGroupDetails
        ///</summary>

         int SyllabusGroupID { get; set; }
         int SyllabusGrpDetailsID { get; set; }
         string UnitDescription { get; set; }
         string UnitWeightage { get; set; }
         int UnitPercentage { get; set; }
         int NoOfLecturesForUnit { get; set; }
         bool UnitStatus { get; set; }
         string UnitName { get; set; }

        ///<summary>
        ///Properties required for OrgSyllabusGroupTopics
        ///</summary>

         int SyllabusGroupDetID { get; set; }
         int SyllabusGrpTopicsID { get; set; }
         string TopicName { get; set; }
         string TopicDescription { get; set; }
         string TopicWeightage { get; set; }
         int TopicPercentage { get; set; }
         int NoOfLecturesForTopic { get; set; }        
         bool TopicStatus { get; set; }




    }

    public interface IOrganisationSyllabusGroupMasterBaseViewModel
    {
        List<OrganisationSyllabusGroupMaster> ListOrganisationSyllabusGroupMaster
        {
            get;
            set;
        }
    }
}
