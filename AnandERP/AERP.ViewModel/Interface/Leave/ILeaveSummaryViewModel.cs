using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
   public interface ILeaveSummaryViewModel
    {
        LeaveSummary LeaveSummaryDTO
        {
            get;
            set;
        }
          int ID
        {
            get;
            set;
        }
         int EmployeeID
        {
            get;
            set;
        }
         int LeaveMasterID
        {
            get;
            set;
        }
         decimal BalanceLeave
        {
            get;
            set;
        }
         int LeaveRuleMasterId
        {
            get;
            set;
        }
         string ReasonForInsertion
        {
            get;
            set;
        }
         bool IsCurrentStatus
        {
            get;
            set;
        }
         int LeaveSessionID
        {
            get;
            set;
        }
         decimal TotalFullDayUtilized
        {
            get;
            set;
        }
         decimal TotalHalfDayUtilized
        {
            get;
            set;
        }
         bool IsBalanceLeaveCarry
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }
         int SummaryIDBFFrom
        {
            get;
            set;
        }
         int SummeryIDCFTo
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
    }   
}
