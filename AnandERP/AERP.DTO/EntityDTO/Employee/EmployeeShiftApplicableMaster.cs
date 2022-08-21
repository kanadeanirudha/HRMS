using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeShiftApplicableMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }
        public string EmployeeShiftMasterID
        {
            get;
            set;
        }
        public string EmployeeShiftDescription
        {
            get;
            set;
        }
        public string ShiftTypeDescription
        {
            get;
            set;
        }
        public string RotationDays
        {
            get;
            set;
        }
        public string ShiftStartDate
        {
            get;
            set;
        }
        public bool CurrentActiveFlag
        {
            get;
            set;
        }
        public string ShiftEndDate
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public string EntityLevel
        {
            get;
            set;
        }        
        public string DepartmentName
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public int SelectedDepartmentID
        {
            get;
            set;
        }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeMiddleName
        {
            get;
            set;
        }
        public string EmployeeLastName
        {
            get;
            set;
        }
        public int GeneralWeekDayID
        {
            get;
            set;
        }
        public string EmployeeShistApplicableMasterFromDate
        {
            get;
            set;
        }
     
        public string XmlWeekDaysString { get; set; }
        public int WeeklyOffConsideration { get; set; }
        public int ShiftAllocationCentreID { get; set; }
    }
}
