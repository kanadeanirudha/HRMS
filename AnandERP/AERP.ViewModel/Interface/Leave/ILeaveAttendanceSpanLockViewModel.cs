using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeaveAttendanceSpanLockViewModel
    {
        LeaveAttendanceSpanLock LeaveAttendanceSpanLockDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        int MaxID
        {
            get;
            set;
        }
        int IsSpanLockCount
        {
            get;
            set;
        }
        string SpanFromDate
        {
            get;
            set;
        }
        string SpanUptoDate
        {
            get;
            set;
        }
        bool IsSpanLock
        {
            get;
            set;
        }
        bool IsDescripancyRemoved
        {
            get;
            set;
        }
        bool IsLateMarkProccessed
        {
            get;
            set;
        }
        int TaskDoneByEmployee
        {
            get;
            set;
        }
        string TaskDoneDate
        {
            get;
            set;
        }
        int ApprovedByUserID
        {
            get;
            set;
        }
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
        string EntityLevel
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
        List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }
        List<LeaveAttendanceSpanLock> ListLeaveAttendanceSpanLock
        {
            get;
            set;
        }
        int DepartmentID
        {
            get;
            set;
        }
        int EmployeeID
        {
            get;
            set;
        }
        int SalarySpanID
            {
            get;
            set;
        }
    }
}
