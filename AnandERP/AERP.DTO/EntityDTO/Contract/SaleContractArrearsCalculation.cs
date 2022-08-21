using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractArrearsCalculation : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public Int64 SaleContractMasterID
        {
            get; set;
        }
        public string ContractNumber
        {
            get; set;
        }
        public Int64 SaleContractBillingSpanID
        {
            get;
            set;
        }
        public string SaleContractBillingSpanName
        {
            get;
            set;
        }
        public string CustomerMasterName
        {
            get; set;
        }
        public string CustomerBranchMasterName
        {
            get; set;
        }
        public Int64 SaleContractEmployeeMasterID
        {
            get;
            set;
        }
        public string SaleContractEmployeeMasterName
        {
            get;
            set;
        }
        public Int32 SaleContractManPowerItemID
        {
            get;
            set;
        }
        public string SaleContractManPowerItemName
        {
            get; set;
        }
        public string StartDate
        {
            get; set;
        }
        public string EndDate
        {
            get; set;
        }
        public decimal BasicSalayAmount
        {
            get; set;
        }
        public decimal AdjustedBasicAmount
        {
            get; set;
        }
        public decimal ActualBasicAmount
        {
            get; set;
        }
        public decimal TotalAmount
        {
            get; set;
        }
        public decimal PreviousTotalAmount
        {
            get; set;
        }
        public decimal GrossAmount
        {
            get; set;
        }
        public decimal TotalEarnings
        {
            get;set;
        }
        public decimal TotalDeduction
        {
            get; set;
        }
        public decimal NetPayable
        {
            get; set;
        }
        public decimal EmployerContributionTotal
        {
            get; set;
        }
        public decimal TotalSalary
        {
            get; set;
        }
        public decimal FixedSalaryAmount
        {
            get; set;
        }
        public decimal AdjustedTotalSalary
        {
            get; set;
        }
        public bool IsRemoveForAdjustment
        {
            get; set;
        }
        public byte TotalDays
        {
            get; set;
        }
        public decimal AdjustedTotalDays
        {
            get; set;
        }
        public decimal TotalAttendance
        {
            get; set;
        }
        public decimal OvertimeHours
        {
            get; set;
        }
        public Int64 SaleContractArrearsCalculationDetailsID
        {
            get; set;
        }
        public Int32 SaleContractManPowerAllowanceID
        {
            get; set;
        }
        public Int32 SaleContractManPowerDeductionID
        {
            get; set;
        }
        public bool IsAllowance
        {
            get; set;
        }
        public byte Order
        {
            get; set;
        }
        public decimal Amount
        {
            get; set;
        }
        public decimal PreviousAmount
        {
            get; set;
        }
        public decimal ActualAmount
        {
            get; set;
        }
        public decimal AdjustedAmount
        {
            get; set;
        }
        public decimal FinalTotalAmount
        {
            get; set;
        }
        public string RuleType
        {
            get; set;
        }
        public string HeadName
        {
            get; set;
        }
        public byte HeadID
        {
            get; set;
        }
        public decimal FixedAmount
        {
            get; set;
        }
        public byte CalculateOn
        {
            get; set;
        }
        public decimal Percentage
        {
            get; set;
        }
        public string HeadType
        {
            get; set;
        }
        public string HeadSubType
        {
            get; set;
        }
        public byte ComplianceType
        {
            get; set;
        }
        public byte ContributionType
        {
            get; set;
        }
        public string CalculateOnString
        {
            get; set;
        }
        public string SaleContractEmployeeMasterIDList
        {
            get; set;
        }
        public string SaleContractManPowerItemIDList
        {
            get; set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public decimal RangeFrom
        {
            get; set;
        }
        public decimal RangeUpto
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

        public decimal PreviousFixedAmount
        {
            get; set;
        }
     
        public decimal PreviousPercentage
        {
            get; set;
        }
        public decimal CurrentFixedAmount
        {
            get; set;
        }

        public decimal CurrentPercentage
        {
            get; set;
        }
        public string errorMessage { get; set; }
        public string XMLStringSalaryTransaction { get; set; }
        public string XMLStringBulkSalaryTransactionEmployee { get; set; }
        public string XMLStringBulkSalaryTransaction { get; set; }
        public string XMLstringForVouchar { get; set; }
        public string EmployeeCode { get; set; }
        public string CentreName { get; set; }
        public string City { get; set; }
        public string BankACNumber { get; set; }
        public string ESINumber { get; set; }
        public string ProvidentFundNumber { get; set; }
        public string LogoPath { get; set; }
        public string SalaryMonth { get; set; }
        public string SalaryYear { get; set; }
        public string XMLstringForAttendance { get; set; }

        public bool IsSalaryDaysOnWeeklyOff { get; set; }
        public bool IsBillingDaysOnWeeklyOff { get; set; }
        public byte TotalBillingDays { get; set; }
        public byte TotalWeeklyOffDays { get; set; }
        public byte TotalOverTimeSalaryDays { get; set; }
        public byte TotalOverTimeBillingDays { get; set; }
        public bool IsOTDaysOnTotalOff { get; set; }
        public bool IsOTBillingDaysOnTotalOff { get; set; }
        public byte TotalWeeklyOffBillingDays { get; set; }
        public Int64 SaleContractManPowerAssignID { get; set; }
        public bool IsSalaryDaysCountFix { get; set; }
        public bool IsBillingDaysFixed { get; set; }
        public bool IsOverTimeDaysFix { get; set; }
        public bool IsOverTimeBillingDaysFix { get; set; }
        public string SalaryForManPowerItemName { get; set; }
        public decimal CalculateOnFixedAmount { get; set; }
        public decimal PreviousCalculateOnFixedAmount { get; set; }

        public byte SummaryFormat { get; set; }
    }
}
