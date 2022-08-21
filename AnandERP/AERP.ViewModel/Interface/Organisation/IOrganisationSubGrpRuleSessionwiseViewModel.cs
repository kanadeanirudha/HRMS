using AMS.DTO;
using System;
using System.Collections.Generic;
namespace AMS.ViewModel
{
    public interface IOrganisationSubGrpRuleSessionwiseViewModel
    {
        OrganisationSubGrpRuleSessionwise OrganisationSubGrpRuleSessionwiseDTO { get; set; }
         int ID
        {
            get;
            set;
        }
         int SubjectRuleGrpNumber
        {
            get;
            set;
        }
         int SessionID
        {
            get;
            set;
        }
         bool IsActive
        {
            get;
            set;
        }
         int CourseYearSemesterID
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

         string CentreName
         {
             get;
             set;
         }
         string UniversityName
         {
             get;
             set;
         }
         string SessionName
         {
             get;
             set;
         }
    
    }
    public interface IOrganisationSubGrpRuleSessionwiseBaseViewModel
    {
       
    }
}
