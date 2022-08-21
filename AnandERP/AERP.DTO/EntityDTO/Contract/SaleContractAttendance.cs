using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractAttendance : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public Int64 SaleContractMasterID
        {
            get;
            set;
        }
        public Int64 SaleContractManPowerAssignID
        {
            get; set;
        }
        public Int32 CustomerBranchMasterID
        {
            get;
            set;
        }
        public string CustomerBranchMasterName
        {
            get;
            set;
        }
        public Int32 CustomerMasterID
        {
            get;
            set;
        }
        public string CustomerMasterName
        {
            get; set;
        }
        public byte CustomerType
        {
            get; set;
        }
        public string ContractNumber
        {
            get; set;
        }
        public Int32 SaleContractManPowerItemID
        {
            get; set;
        }
        public string SaleContractManPowerItemName
        {
            get; set;
        }
        public Int64 SaleContractEmployeeMasterID
        {
            get; set;
        }
        public string SaleContractEmployeeMasterName
        {
            get; set;
        }
        public string AttendanceDate
        {
            get; set;
        }
        public string SplitFromDate
        {
            get; set;
        }
        public byte AttendanceStatus
        {
            get; set;
        }
        public bool IsHalfDayLeave
        {
            get; set;
        }
        public decimal OvertimeHours
        {
            get; set;
        }
        public string InvoiceNumber
        {
            get; set;
        }
        public Int32 SalaryGenerateID
        {
            get; set;
        }
        public string Months
        {
            get; set;
        }
        public string AttendanceStatusList
        {
            get; set;
        }
        public string AttendanceDays
        {
            get; set;
        }
        public string AttendanceForMonth
        {
            get; set;
        }
        public decimal TotalAttendance
        {
            get; set;
        }
        public byte TotalDays
        {
            get; set;
        }
        public Int64 SaleContractBillingSpanID
        {
            get; set;
        }
        public string SaleContractBillingSpanName
        {
            get; set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsSalaryDaysOnWeeklyOff
        {
            get; set;
        }
        public bool IsBillingDaysOnWeeklyOff
        {
            get; set;
        }
        public byte TotalBillingDays
        {
            get; set;
        }
        public byte TotalWeeklyOffDays
        {
            get; set;
        }
        public byte TotalWeeklyOffBillingDays
        {
            get; set;
        }
        public byte TotalOverTimeSalaryDays
        {
            get; set;
        }
        public byte TotalOverTimeBillingDays
        {
            get; set;
        }
        public bool IsOTDaysOnTotalOff
        {
            get; set;
        }
        public bool IsOTBillingDaysOnTotalOff
        {
            get; set;
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

        public int ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string XMLstringForAttendance { get; set; }
        public bool IsSalaryDaysCountFix { get; set; }
        public bool IsBillingDaysFixed { get; set; }
        public bool IsOverTimeDaysFix { get; set; }
        public bool IsOverTimeBillingDaysFix { get; set; }
        public string SalaryForManPowerItemName { get; set; }
        public Int64 SalaryForManPowerItemID { get; set; }
    }
}
