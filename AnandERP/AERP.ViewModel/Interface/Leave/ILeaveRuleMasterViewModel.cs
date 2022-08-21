using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
    public interface ILeaveRuleMasterViewModel
    {
         LeaveRuleMaster LeaveRuleMasterDTO
        {
            get;
            set;
        }
         int ID
         {
             get;
             set;
         }
         int LeaveMasterID
         {
             get;
             set;
         }
         string LeaveDescription
         {
             get;
             set;
         }
          string LeaveRuleDescription
         {
             get;
             set;
         }
          Int16 NumberOfLeaves
         {
             get;
             set;
         }
          Int16 MaxLeaveAtTime
         {
             get;
             set;
         }
          int MinimumLeaveEncash
         {
             get;
             set;
         }
          int MaxLeaveEncash
         {
             get;
             set;
         }
          int MaxLeaveAccumulated
         {
             get;
             set;
         }
          int MinServiceRequiredInMonth
         {
             get;
             set;
         }
          int AttendDaysRequired
         {
             get;
             set;
         }
          string CreditDependOn
         {
             get;
             set;
         }
          int DayOfTheMonth
         {
             get;
             set;
         }
          bool IsLocked
         {
             get;
             set;
         }
          double MinLeavesAtTime
         {
             get;
             set;
         }
          string CentreCode
         {
             get;
             set;
         }
          string EntityLevel
         {
             get;
             set;
         }
          string CentreName
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
          List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
          {
              get;
              set;
          }
        
    }
}
