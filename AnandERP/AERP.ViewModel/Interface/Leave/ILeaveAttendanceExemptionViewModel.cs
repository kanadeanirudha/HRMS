using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeaveAttendanceExemptionViewModel
    {
        LeaveAttendanceExemption LeaveAttendanceExemptionDTO
        {
            get;
            set;
        }

         int ID
        {
            get;
            set;
        }
         int EmployeeId
        {
            get;
            set;
        }
         string ExemptionFromDate
        {
            get;
            set;
        }
         string ExemptionUpToDate
        {
            get;
            set;
        }
         bool IsActive
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
          string EmployeeName { get; set; }
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
          string errorMessage { get; set; }
          string EntityLevel { get; set; }
         List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
         {
             get;
             set;
         }
    }
}
