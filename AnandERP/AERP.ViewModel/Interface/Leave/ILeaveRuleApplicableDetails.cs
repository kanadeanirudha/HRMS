using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeaveRuleApplicableDetailsViewModel
    {
        LeaveRuleApplicableDetails LeaveRuleApplicableDetailsDTO
        {
            get;
            set;
        }
         int ID
        {
            get;
            set;
        }
         int LeaveRuleMasterID
        {
            get;
            set;
        }
         string LeaveRuleMasterDescription
        {
            get;
            set;
        }
         string CombinationRuleCode
         {
             get;
             set;
         }
         int LeaveSessionID
        {
            get;
            set;
        }
         int LeaveMasterID
        {
            get;
            set;
        }
         int JobStatusID
         {
             get;
             set;
         }
         int JobProfileID
         {
             get;
             set;
         }
         string JobStatusCode
         {
             get;
             set;
         }
         string JobProfileDescription
         {
             get;
             set;
         }
         string JobStatusDescription
         {
             get;
             set;
         }
         bool IsCurrentFlag
        {
            get;
            set;
        }
         int StatusFlag
         {
             get;
             set;
         }
         int TotalRecords
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
         string IDs
         {
             get;
             set;
         }
         string LeaveSessionFromDate
         {
             get;
             set;
         }
         string LeaveSessionUptoDate
         {
             get;
             set;
         }
         bool IsCurrentLeaveSession
         {
             get;
             set;
         }
         string SelectedCentreCode
         {
             get;
             set;
         }
         string SelectedCentreName
         {
             get;
             set;
         }
         string SelectedSessionID
         {
             get;
             set;
         }
         List<LeaveSession> ListLeaveSession
         {
             get;
             set;
         }
         string LeaveDescription
         {
             get;
             set;
         }
         string LeaveCode
         {
             get;
             set;
         }

        ///////////////////////////////Leave Rule Master  details-----------------------//////////////////////////

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
    }
}
