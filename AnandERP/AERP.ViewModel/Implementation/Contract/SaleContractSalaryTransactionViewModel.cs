using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractSalaryTransactionViewModel : ISaleContractSalaryTransactionViewModel
    {

        public SaleContractSalaryTransactionViewModel()
        {
            SaleContractSalaryTransactionDTO = new SaleContractSalaryTransaction();
            SaleContractSalaryTransactionList = new List<SaleContractSalaryTransaction>();
            SaleContractSalarySlipExcelList = new List<SaleContractSalaryTransaction>();
        }
        public List<SaleContractSalaryTransaction> SaleContractSalaryTransactionList { get; set; }
        public List<SaleContractSalaryTransaction> SaleContractSalarySlipExcelList { get; set; }
        public SaleContractSalaryTransaction SaleContractSalaryTransactionDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.ID > 0) ? SaleContractSalaryTransactionDTO.ID : new Int64();
            }
            set
            {
                SaleContractSalaryTransactionDTO.ID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.SaleContractMasterID > 0) ? SaleContractSalaryTransactionDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractSalaryTransactionDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractSalaryTransactionDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.SaleContractBillingSpanID > 0) ? SaleContractSalaryTransactionDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                SaleContractSalaryTransactionDTO.SaleContractBillingSpanName = value;
            }
        }
        [Display(Name = "Contract Employee")]
        public Int64 SaleContractEmployeeMasterID
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.SaleContractEmployeeMasterID > 0) ? SaleContractSalaryTransactionDTO.SaleContractEmployeeMasterID : new Int64();
            }
            set
            {
                SaleContractSalaryTransactionDTO.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Contract Employee")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                SaleContractSalaryTransactionDTO.SaleContractEmployeeMasterName = value;
            }
        }

        [Display(Name = "Post")]
        public Int32 SaleContractManPowerItemID
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.SaleContractManPowerItemID > 0) ? SaleContractSalaryTransactionDTO.SaleContractManPowerItemID : new Int32();
            }
            set
            {
                SaleContractSalaryTransactionDTO.SaleContractManPowerItemID = value;
            }
        }
        [Display(Name = "Post")]
        public string SaleContractManPowerItemName
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.SaleContractManPowerItemName : string.Empty;
            }
            set
            {
                SaleContractSalaryTransactionDTO.SaleContractManPowerItemName = value;
            }
        }
        [Display(Name = "Start Date")]
        public string StartDate
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.StartDate : string.Empty;
            }
            set
            {
                SaleContractSalaryTransactionDTO.StartDate = value;
            }
        }

        [Display(Name = "End Date")]
        public string EndDate
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.EndDate : string.Empty;
            }
            set
            {
                SaleContractSalaryTransactionDTO.EndDate = value;
            }
        }
        [Display(Name = "Basic Salay")]
        public decimal BasicSalayAmount
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.BasicSalayAmount > 0) ? SaleContractSalaryTransactionDTO.BasicSalayAmount : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.BasicSalayAmount = value;
            }
        }
        [Display(Name = "Adjusted Basic Salay")]
        public decimal AdjustedBasicAmount
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.AdjustedBasicAmount > 0) ? SaleContractSalaryTransactionDTO.AdjustedBasicAmount : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.AdjustedBasicAmount = value;
            }
        }
        

        [Display(Name = "Total Amount")]
        public decimal TotalAmount
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.TotalAmount > 0) ? SaleContractSalaryTransactionDTO.TotalAmount : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.TotalAmount = value;

            }
        }

        [Display(Name = "Gross Amount")]
        public decimal GrossAmount
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.GrossAmount > 0) ? SaleContractSalaryTransactionDTO.GrossAmount : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.GrossAmount = value;
            }
        }
        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.TotalEarnings > 0) ? SaleContractSalaryTransactionDTO.TotalEarnings : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.TotalEarnings = value;
            }
        }
        
        [Display(Name = "Total Deduction")]
        public decimal TotalDeduction
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.TotalDeduction > 0) ? SaleContractSalaryTransactionDTO.TotalDeduction : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.TotalDeduction = value;
            }
        }
        [Display(Name = "Net Payable")]
        public decimal NetPayable
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.NetPayable > 0) ? SaleContractSalaryTransactionDTO.NetPayable : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.NetPayable = value;
            }
        }
        [Display(Name = "Net Payable")]
        public decimal AdjustedNetPayable
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.AdjustedNetPayable > 0) ? SaleContractSalaryTransactionDTO.AdjustedNetPayable : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.AdjustedNetPayable = value;
            }
        }
        [Display(Name = "Total Emplyoer Contribution")]
        public decimal EmployerContributionTotal
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.EmployerContributionTotal > 0) ? SaleContractSalaryTransactionDTO.EmployerContributionTotal : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.EmployerContributionTotal = value;
            }
        }
        [Display(Name = "Total Salary")]
        public decimal TotalSalary
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.TotalSalary > 0) ? SaleContractSalaryTransactionDTO.TotalSalary : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.TotalSalary = value;
            }
        }
        public decimal AdjustedTotalSalary
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.AdjustedTotalSalary > 0) ? SaleContractSalaryTransactionDTO.AdjustedTotalSalary : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.AdjustedTotalSalary = value;
            }
        }
        
        [Display(Name = "Remove For Adjustment")]
        public bool IsRemoveForAdjustment
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.IsRemoveForAdjustment : false;
            }
            set
            {
                SaleContractSalaryTransactionDTO.IsRemoveForAdjustment = value;
            }
        }
        [Display(Name = "Total Days")]
        public byte TotalDays
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.TotalDays : new byte();
            }
            set
            {
                SaleContractSalaryTransactionDTO.TotalDays = value;
            }
        }
        [Display(Name = "Adjusted Total Days")]
        public decimal AdjustedTotalDays
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.AdjustedTotalDays : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.AdjustedTotalDays = value;
            }
        }
        
        [Display(Name = "Total Attendance")]
        public decimal TotalAttendance
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.TotalAttendance : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.TotalAttendance = value;
            }
        }

        [Display(Name = "Salary Transaction Details ID")]
        public Int64 SaleContractSalaryTransactionDetailsID
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.SaleContractSalaryTransactionDetailsID > 0) ? SaleContractSalaryTransactionDTO.SaleContractSalaryTransactionDetailsID : new Int64();
            }
            set
            {
                SaleContractSalaryTransactionDTO.SaleContractSalaryTransactionDetailsID = value;
            }
        }
        [Display(Name = "Allowance ID")]
        public Int32 SaleContractManPowerAllowanceID
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.SaleContractManPowerAllowanceID > 0) ? SaleContractSalaryTransactionDTO.SaleContractManPowerAllowanceID : new Int32();
            }
            set
            {
                SaleContractSalaryTransactionDTO.SaleContractManPowerAllowanceID = value;
            }
        }
        [Display(Name = "Deduction ID")]
        public Int32 SaleContractManPowerDeductionID
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.SaleContractManPowerDeductionID > 0) ? SaleContractSalaryTransactionDTO.SaleContractManPowerDeductionID : new Int32();
            }
            set
            {
                SaleContractSalaryTransactionDTO.SaleContractManPowerDeductionID = value;
            }
        }
        [Display(Name = "Is Allowance")]
        public bool IsAllowance
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.IsAllowance : false;
            }
            set
            {
                SaleContractSalaryTransactionDTO.IsAllowance = value;
            }
        }
        [Display(Name = "Order")]
        public byte Order
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.Order : new byte();
            }
            set
            {
                SaleContractSalaryTransactionDTO.Order = value;
            }
        }
        [Display(Name = "Amount")]
        public decimal Amount
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.Amount : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.Amount = value;
            }
        }
        [Display(Name = "Adjusted Amount")]
        public decimal AdjustedAmount
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.AdjustedAmount : new decimal();
            }
            set
            {
                SaleContractSalaryTransactionDTO.AdjustedAmount = value;
            }
        }
        [Display(Name = "Head Name")]
        public string HeadName
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.HeadName : string.Empty;
            }
            set
            {
                SaleContractSalaryTransactionDTO.HeadName = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.IsDeleted : false;
            }
            set
            {
                SaleContractSalaryTransactionDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.CreatedBy > 0) ? SaleContractSalaryTransactionDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractSalaryTransactionDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null) ? SaleContractSalaryTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractSalaryTransactionDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.ModifiedBy > 0) ? SaleContractSalaryTransactionDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractSalaryTransactionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.ModifiedDate.HasValue) ? SaleContractSalaryTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractSalaryTransactionDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.DeletedBy > 0) ? SaleContractSalaryTransactionDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractSalaryTransactionDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.DeletedDate.HasValue) ? SaleContractSalaryTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractSalaryTransactionDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLStringSalaryTransaction { get; set; }
        public string XMLStringBulkSalaryTransactionEmployee { get; set; }
        public string XMLStringBulkSalaryTransaction { get; set; }
        public string XMLstringForVouchar { get; set; }
        [Display(Name = "Summary Format")]
        public byte SummaryFormat
        {
            get
            {
                return (SaleContractSalaryTransactionDTO != null && SaleContractSalaryTransactionDTO.SummaryFormat > 0) ? SaleContractSalaryTransactionDTO.SummaryFormat : new byte();
            }
            set
            {
                SaleContractSalaryTransactionDTO.SummaryFormat = value;
            }
        }
        
    }
}

