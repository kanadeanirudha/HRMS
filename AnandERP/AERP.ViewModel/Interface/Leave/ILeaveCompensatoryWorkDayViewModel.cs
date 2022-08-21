using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeaveCompensatoryWorkDayViewModel
    {
        LeaveCompensatoryWorkDay LeaveCompensatoryWorkDayDTO
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
        int LeaveSessionID
        {
            get;
            set;
        }
        string WorkingDate
        {
            get;
            set;
        }
        TimeSpan CheckInTime
        {
            get;
            set;
        }
        TimeSpan CheckOutTime
        {
            get;
            set;
        }
        string ApplicationStatus
        {
            get;
            set;
        }
        string WorkingReason
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        bool IsAvailed
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

        #region -------------- TaskNotification Properties---------------
        int TaskNotificationMasterID
        {
            get;
            set;
        }
        string TaskCode
        {
            get;
            set;
        }
        int TaskNotificationDetailsID
        {
            get;
            set;
        }
        int GeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        int PersonID
        {
            get;
            set;
        }
        int StageSequenceNumber
        {
            get;
            set;
        }
        bool IsLastRecord
        {
            get;
            set;
        }
        bool ApprovalStatus { get; set; }
        #endregion

        List<LeaveCompensatoryWorkDay> CompensatoryOffDayApplicationDetailsList { get; set; }
       
    }
}
