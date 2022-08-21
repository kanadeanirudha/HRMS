using System;
using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
   public interface IEmployeeDocumentRequiredViewModel
    {
       EmployeeDocumentRequired EmployeeDocumentRequiredDTO
       {
           get;
           set;
       }
         int ID
        {
            get;
            set;
        }
         int DocumentID
        {
            get;
            set;
        }
         int LeaveRuleMasterID
        {
            get;
            set;
        }
         bool DocumentCompulsaryFlag
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
         string errorMessage { get; set; }
         string CentreCode
         {
             get;
             set;
         }
         string CentreName
         {
             get;
             set;
         }
         string EntityLevel
         {
             get;
             set;
         }
         List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
         {
             get;
             set;
         }
         string LeaveRuleDescription
         {
             get;
             set;
         }
         string LeaveDescription
         {
             get;
             set;
         }
         int LeaveMasterID
         {
             get;
             set;
         }
         string DocumentName
         {
             get;
             set;
         }
         string SelectedIDs
         {
             get;
             set;
         }
       
    }
}
