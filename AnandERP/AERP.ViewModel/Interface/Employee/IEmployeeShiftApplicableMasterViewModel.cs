using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
   public interface IEmployeeShiftApplicableMasterViewModel
    {
        EmployeeShiftApplicableMaster EmployeeShiftApplicableMasterDTO
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
         string EmployeeName
         {
             get;
             set;
         }
         string EmployeeShiftMasterID
         {
             get;
             set;
         }
         string EmployeeShiftDescription
        {
            get;
            set;
        }
         string RotationDays
        {
            get;
            set;
        }
         string ShiftStartDate
        {
            get;
            set;
        }
         bool CurrentActiveFlag
        {
            get;
            set;
        }
         string ShiftEndDate
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
        string SelectedCentreCode
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
        int SelectedDepartmentID
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
        string EntityLevel
        {
            get;
            set;
        }
         string XmlWeekDaysString { get; set; }
         int WeeklyOffConsideration { get; set; }
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
        List<GeneralWeekDays> ListGeneralWeekDays
        {
            get;
            set;
        }
         int ShiftAllocationCentreID { get; set; }
    }
}