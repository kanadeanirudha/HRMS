using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeaveEmployeeApplicationStatusReportViewModel
    {
        LeaveEmployeeApplicationStatusReport LeaveEmployeeApplicationStatusReportDTO
        {
            get;
            set;
        }
        string DepartmentName
        {
            get;
            set;
        }

        int DepartmentID
        {
            get;
            set;
        }
        string EmployeeFullName
        {
            get;
            set;
        }

        string LeaveType
        {
            get;
            set;
        }
        string ApplicationDate
        {
            get;
            set;
        }
        string Dates
        {
            get;
            set;
        }
        string ApprovalStatus
        {
            get;
            set;
        }
        string FullDayHalfDayStatus
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
        List<OrganisationDepartmentMaster> ListGetOrganisationDepartmentCentreAndRoleWise
        {
            get;
            set;
        }

    }
}
