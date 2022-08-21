using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeavePostViewModel
    {
        LeavePost LeavePostDTO
        {
            get;
            set;
        }
        int LeaveMasterID
        {
            get;
            set;
        }
        string LeaveCode
        {
            get;
            set;
        }
        string LeaveDescription
        {
            get;
            set;
        }
        int LeaveRuleMasterID
        {
            get;
            set;
        }
        string LeaveRuleDescription
        {
            get;
            set;
        }
        int LeaveSessionID
        {
            get;
            set;
        }
        string LeaveType
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
        string CentreName
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
        List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }       
        List<LeaveSession> ListFromLeaveSession
        {
            get;
            set;
        }
        List<LeaveSession> ListToLeaveSession
        {
            get;
            set;
        }
        int EmployeeID
        {
            get;
            set;
        }
        string EmployeeFirstName
        {
            get;
            set;
        }
        string EmployeeMiddleName
        {
            get;
            set;
        }
        string EmployeeLastName
        {
            get;
            set;
        }
        string LeaveSessionName
        {
            get;
            set;
        }
        string LeaveList
        {
            get;
            set;
        }
       int SelectedFromSessionID
       {
           get;
           set;
       }
       int SelectedToSessionID
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
