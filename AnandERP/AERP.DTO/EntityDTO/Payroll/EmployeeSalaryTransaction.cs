using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class EmployeeSalaryTransaction : BaseDTO
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
        public Int32 EmployeeMasterID
        {
            get;
            set;
        }
        public string EmployeeName
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
        public decimal BasicAmount
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
        public Int64 EmployeeSalaryTransactionDetailsID
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
        public decimal CalculateOnFixedAmount
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
        public string errorMessage { get; set; }
        public string XMLStringSalaryTransaction { get; set; }
        public string XMLStringBulkSalaryTransactionEmployee { get; set; }
        public string XMLStringBulkSalaryTransaction { get; set; }
        public string XMLstringForVouchar { get; set; }
        public string EmployeeCode { get; set; }
        public string CentreName { get; set; }
        public string City { get; set; }
        public string BankACNumber { get; set; }
        public string DesignationName { get; set; }
        public string UANNumber { get; set; }
        public string ESINumber { get; set; }
        public string ProvidentFundNumber { get; set; }
        public string LogoPath { get; set; }
        public string SalaryMonth { get; set; }
        public string SalaryYear { get; set; }
        public Int16 EmployeeSalarySpanID { get; set; }
        public Int64 EmployeeSalaryTransactionID { get; set; }
        public Int64 EmployeeSalaryRulesID { get; set; }
        public string SpanName { get; set; }
        public Int64 EmployeeSalaryRulesAllowanceID { get; set; }
        public Int64 EmployeeSalaryRulesDeductionID { get; set; }
        public Int32 DepartmentMasterID { get; set; }
        public string DepartmentName { get; set; }

        public string CentreCode { get; set; }

        public string ExcelSheetName
        {
            get;
            set;
        }
        public string XMLString
        {
            get;
            set;
        }
    }
}
