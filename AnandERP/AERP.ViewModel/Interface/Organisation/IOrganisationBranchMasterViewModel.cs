using AMS.DTO;
using System;
using System.Collections.Generic;
namespace AMS.ViewModel
{
    public interface IOrganisationBranchMasterViewModel
    {
        OrganisationBranchMaster OrganisationBranchMasterDTO
        {
            get;
            set;
        }
        List<OrganisationDepartmentBranch> OrganisationDepartmentBranchDTO { get; set; }
         int ID
        {
            get;
            set;
        }
         string BranchDescription
        {
            get;
            set;
        }
         int IntroductionYear
        {
            get;
            set;
        }
         string BranchShortCode
        {
            get;
            set;
        }
         string PrintShortCode
        {
            get;
            set;
        }
         bool CommonBranch
        {
            get;
            set;
        }
         Int16 DurationInDays
        {
            get;
            set;
        }
         int UniversityID
        {
            get;
            set;
        }
         int DepartmentID
         {
             get;
             set;
         }
         int DepartmentBranchID
         {
             get;
             set;
         }  
        
         bool IsCommonBranchApplicable
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
    }
    public interface IOrganisationBranchMasterBaseViewModel
    {
        List<OrganisationBranchMaster> ListOrganisationBranchMaster
        {
            get;
            set;
        }
    }
}
