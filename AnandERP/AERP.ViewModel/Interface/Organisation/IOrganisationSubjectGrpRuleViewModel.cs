using AMS.DTO;
using System;
using System.Collections.Generic;
namespace AMS.ViewModel
{
    public interface IOrganisationSubjectGrpRuleViewModel
    {
        OrganisationSubjectGrpRule OrganisationSubjectGrpRuleDTO { get; set; }
         int ID
        {
            get;
            set;
        }
         string RuleName
        {
            get;
            set;
        }
         string RuleCode
        {
            get;
            set;
        }
         int TotalSubjects
        {
            get;
            set;
        }
         int MaxCompulsorySubjects
        {
            get;
            set;
        }
         int MaxOptSubjects
        {
            get;
            set;
        }
         int NoOfOptSubjects
        {
            get;
            set;
        }
         int MaxGroups
        {
            get;
            set;
        }
         int MaxNoOfCompulsoryGroups
        {
            get;
            set;
        }
         int CourseYearSemesterID
        {
            get;
            set;
        }
         int OrgSessionCryrAllotID
        {
            get;
            set;
        }
         bool IsActive
        {
            get;
            set;
        }
         bool IsDeleted
        {
            get;
            set;
        }
         int CreatedBy
        {
            get;
            set;
        }
         DateTime CreatedDate
        {
            get;
            set;
        }
         int? ModifiedBy
        {
            get;
            set;
        }
         DateTime? ModifiedDate
        {
            get;
            set;
        }
         int? DeletedBy
        {
            get;
            set;
        }
         DateTime? DeletedDate
        {
            get;
            set;
        }
         string OrgSemesterName
         {
             get;
             set;
         }
         string CourseYearCode
         {
             get;
             set;
         }


        ///<summary>
        ///properties required for OrganisationSubjectGroupRuleSessionwise table
        ///<returns><returns>

         int SessionID
         {
             get;
             set;
         }

         int OrgSubGrpRuleSessionwiseID
         {
             get;
             set;
         }
         string BranchDescription
         {
             get;
             set;
         }

         string SemesterName
         {
             get;
             set;
         }
         string BranchShortCode
         {
             get;
             set;
         }
         bool StatusFlag
         {
             get;
             set;
         }

        ///<summary>
        ///properties required for OrgElectiveGrpMaster table
        ///<returns><returns>
          int OrgElectiveGrpMasterID { get; set; }
          string GroupShortCode { get; set; }
          string GroupName { get; set; }
          int SubjectRuleGrpNumber { get; set; }
          bool GroupCompulsoryFlag { get; set; }
          int NoOfSubGroups { get; set; }
          int NoOfCompulsorySubGrp { get; set; }
          int NoOfSubGrpSubjectSelect { get; set; }
          string ElectiveCommonGroup { get; set; }

          ///<summary>
          ///Properties required for OrgSubElectiveGrpMaster table
          ///<returns><returns>

          int OrgSubElectiveGrpMasterID { get; set; }
           int OrgElectiveGrpID { get; set; }
           string OrgSubElectiveGrpDescription { get; set; }
           string ShortDescription { get; set; }
           int TotalNoOfSubjects { get; set; }
           bool SubGrpCompulsorySubjFlag { get; set; }
           int AllowToSelect { get; set; }
           bool SubGroupCompulsoryFlag { get; set; }
           int TotalNoOfSubjectCompulsory { get; set; }
           string ElectiveCommonSubGroup { get; set; }
           bool FeeBased { get; set; }
           int NextSubElectiveGrpID { get; set; }


    }
    interface IOrganisationSubjectGrpRuleBaseViewModel
    {
       
    }
}
