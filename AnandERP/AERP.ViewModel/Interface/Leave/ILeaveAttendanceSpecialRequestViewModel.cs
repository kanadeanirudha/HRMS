using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeaveAttendanceSpecialRequestViewModel
    {
         LeaveAttendanceSpecialRequest LeaveAttendanceSpecialRequestDTO
        {
            get;
            set;
        }
         int ID
        {
            get;
            set;
        }
         int EmployeeAttendanceID
        {
            get;
            set;
        }
         int EmployeeID
        {
            get;
            set;
        }
         bool AttendanceStatus
        {
            get;
            set;
        }
         string RequestedDate { get; set; }
         TimeSpan CommingTime
        {
            get;
            set;
        }
         TimeSpan LeavingTime
        {
            get;
            set;
        }
         string StatusFlag
        {
            get;
            set;
        }
         string Reason
        {
            get;
            set;
        }
         int ApprovedByUserID
        {
            get;
            set;
        }
         int EmployeeShiftMasterID
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }
         string UpdatedInEmployeeAttendance
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
         int ModifiedBy
        {
            get;
            set;
        }
         DateTime ModifiedDate
        {
            get;
            set;
        }
         int DeletedBy
        {
            get;
            set;
        }
         DateTime DeletedDate
        {
            get;
            set;
        }
         string EntityLevel{get;set;}
         string CentreName { get; set; }
        List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
    }
}
