using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeaveManualAttendanceViewModel
    {
        LeaveManualAttendance LeaveManualAttendanceDTO
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
        string AttendanceDate
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
        string Reason
        {
            get;
            set;
        }
        string Status
        {
            get;
            set;
        }
        int ApprovedByUSerID
        {
            get;
            set;
        }
        bool IsWorkFlow
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
        string EntityLevel
        {
            get;
            set;
        }
        string errorMessage { get; set; }

    }
}
