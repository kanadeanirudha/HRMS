using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractArrearsCalculationViewModel : ISaleContractArrearsCalculationViewModel
    {

        public SaleContractArrearsCalculationViewModel()
        {
            SaleContractArrearsCalculationDTO = new SaleContractArrearsCalculation();
            SaleContractArrearsCalculationList = new List<SaleContractArrearsCalculation>();
            SaleContractAttendanceList = new List<SaleContractAttendance>();
        }
        public List<SaleContractArrearsCalculation> SaleContractArrearsCalculationList { get; set; }
        public List<SaleContractAttendance> SaleContractAttendanceList { get; set; }

        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(SaleContractAttendanceList, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }

        public SaleContractArrearsCalculation SaleContractArrearsCalculationDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.ID > 0) ? SaleContractArrearsCalculationDTO.ID : new Int64();
            }
            set
            {
                SaleContractArrearsCalculationDTO.ID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.SaleContractMasterID > 0) ? SaleContractArrearsCalculationDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractArrearsCalculationDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractArrearsCalculationDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.SaleContractBillingSpanID > 0) ? SaleContractArrearsCalculationDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractArrearsCalculationDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                SaleContractArrearsCalculationDTO.SaleContractBillingSpanName = value;
            }
        }
        [Display(Name = "Contract Employee")]
        public Int64 SaleContractEmployeeMasterID
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.SaleContractEmployeeMasterID > 0) ? SaleContractArrearsCalculationDTO.SaleContractEmployeeMasterID : new Int64();
            }
            set
            {
                SaleContractArrearsCalculationDTO.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Contract Employee")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                SaleContractArrearsCalculationDTO.SaleContractEmployeeMasterName = value;
            }
        }

        [Display(Name = "Post")]
        public Int32 SaleContractManPowerItemID
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.SaleContractManPowerItemID > 0) ? SaleContractArrearsCalculationDTO.SaleContractManPowerItemID : new Int32();
            }
            set
            {
                SaleContractArrearsCalculationDTO.SaleContractManPowerItemID = value;
            }
        }
        [Display(Name = "Post")]
        public string SaleContractManPowerItemName
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.SaleContractManPowerItemName : string.Empty;
            }
            set
            {
                SaleContractArrearsCalculationDTO.SaleContractManPowerItemName = value;
            }
        }
        [Display(Name = "Start Date")]
        public string StartDate
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.StartDate : string.Empty;
            }
            set
            {
                SaleContractArrearsCalculationDTO.StartDate = value;
            }
        }

        [Display(Name = "End Date")]
        public string EndDate
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.EndDate : string.Empty;
            }
            set
            {
                SaleContractArrearsCalculationDTO.EndDate = value;
            }
        }
        [Display(Name = "Basic Salay")]
        public decimal BasicSalayAmount
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.BasicSalayAmount > 0) ? SaleContractArrearsCalculationDTO.BasicSalayAmount : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.BasicSalayAmount = value;
            }
        }
        [Display(Name = "Adjusted Basic Salay")]
        public decimal AdjustedBasicAmount
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.AdjustedBasicAmount > 0) ? SaleContractArrearsCalculationDTO.AdjustedBasicAmount : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.AdjustedBasicAmount = value;
            }
        }
        

        [Display(Name = "Total Amount")]
        public decimal TotalAmount
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.TotalAmount > 0) ? SaleContractArrearsCalculationDTO.TotalAmount : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.TotalAmount = value;

            }
        }

        [Display(Name = "Gross Amount")]
        public decimal GrossAmount
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.GrossAmount > 0) ? SaleContractArrearsCalculationDTO.GrossAmount : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.GrossAmount = value;
            }
        }
        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.TotalEarnings > 0) ? SaleContractArrearsCalculationDTO.TotalEarnings : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.TotalEarnings = value;
            }
        }
        
        [Display(Name = "Total Deduction")]
        public decimal TotalDeduction
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.TotalDeduction > 0) ? SaleContractArrearsCalculationDTO.TotalDeduction : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.TotalDeduction = value;
            }
        }
        [Display(Name = "Net Payable")]
        public decimal NetPayable
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.NetPayable > 0) ? SaleContractArrearsCalculationDTO.NetPayable : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.NetPayable = value;
            }
        }
        [Display(Name = "Total Employer Contribution")]
        public decimal EmployerContributionTotal
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.EmployerContributionTotal > 0) ? SaleContractArrearsCalculationDTO.EmployerContributionTotal : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.EmployerContributionTotal = value;
            }
        }
        [Display(Name = "Total Salary")]
        public decimal TotalSalary
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.TotalSalary > 0) ? SaleContractArrearsCalculationDTO.TotalSalary : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.TotalSalary = value;
            }
        }
        public decimal AdjustedTotalSalary
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.AdjustedTotalSalary > 0) ? SaleContractArrearsCalculationDTO.AdjustedTotalSalary : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.AdjustedTotalSalary = value;
            }
        }
        
        [Display(Name = "Remove For Adjustment")]
        public bool IsRemoveForAdjustment
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.IsRemoveForAdjustment : false;
            }
            set
            {
                SaleContractArrearsCalculationDTO.IsRemoveForAdjustment = value;
            }
        }
        [Display(Name = "Total Days")]
        public byte TotalDays
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.TotalDays : new byte();
            }
            set
            {
                SaleContractArrearsCalculationDTO.TotalDays = value;
            }
        }
        [Display(Name = "Adjusted Total Days")]
        public decimal AdjustedTotalDays
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.AdjustedTotalDays : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.AdjustedTotalDays = value;
            }
        }
        
        [Display(Name = "Total Attendance")]
        public decimal TotalAttendance
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.TotalAttendance : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.TotalAttendance = value;
            }
        }

        [Display(Name = "Salary Transaction Details ID")]
        public Int64 SaleContractArrearsCalculationDetailsID
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.SaleContractArrearsCalculationDetailsID > 0) ? SaleContractArrearsCalculationDTO.SaleContractArrearsCalculationDetailsID : new Int64();
            }
            set
            {
                SaleContractArrearsCalculationDTO.SaleContractArrearsCalculationDetailsID = value;
            }
        }
        [Display(Name = "Allowance ID")]
        public Int32 SaleContractManPowerAllowanceID
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.SaleContractManPowerAllowanceID > 0) ? SaleContractArrearsCalculationDTO.SaleContractManPowerAllowanceID : new Int32();
            }
            set
            {
                SaleContractArrearsCalculationDTO.SaleContractManPowerAllowanceID = value;
            }
        }
        [Display(Name = "Deduction ID")]
        public Int32 SaleContractManPowerDeductionID
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.SaleContractManPowerDeductionID > 0) ? SaleContractArrearsCalculationDTO.SaleContractManPowerDeductionID : new Int32();
            }
            set
            {
                SaleContractArrearsCalculationDTO.SaleContractManPowerDeductionID = value;
            }
        }
        [Display(Name = "Is Allowance")]
        public bool IsAllowance
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.IsAllowance : false;
            }
            set
            {
                SaleContractArrearsCalculationDTO.IsAllowance = value;
            }
        }
        [Display(Name = "Order")]
        public byte Order
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.Order : new byte();
            }
            set
            {
                SaleContractArrearsCalculationDTO.Order = value;
            }
        }
        [Display(Name = "Amount")]
        public decimal Amount
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.Amount : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.Amount = value;
            }
        }
        [Display(Name = "Adjusted Amount")]
        public decimal AdjustedAmount
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.AdjustedAmount : new decimal();
            }
            set
            {
                SaleContractArrearsCalculationDTO.AdjustedAmount = value;
            }
        }
        [Display(Name = "Head Name")]
        public string HeadName
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.HeadName : string.Empty;
            }
            set
            {
                SaleContractArrearsCalculationDTO.HeadName = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.IsDeleted : false;
            }
            set
            {
                SaleContractArrearsCalculationDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.CreatedBy > 0) ? SaleContractArrearsCalculationDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractArrearsCalculationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null) ? SaleContractArrearsCalculationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractArrearsCalculationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.ModifiedBy > 0) ? SaleContractArrearsCalculationDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractArrearsCalculationDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.ModifiedDate.HasValue) ? SaleContractArrearsCalculationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractArrearsCalculationDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.DeletedBy > 0) ? SaleContractArrearsCalculationDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractArrearsCalculationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.DeletedDate.HasValue) ? SaleContractArrearsCalculationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractArrearsCalculationDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLStringSalaryTransaction { get; set; }
        public string XMLStringBulkSalaryTransactionEmployee { get; set; }
        public string XMLStringBulkSalaryTransaction { get; set; }
        public string XMLstringForVouchar { get; set; }
        public string XMLstringForAttendance { get; set; }
        [Display(Name = "Summary Format")]
        public byte SummaryFormat
        {
            get
            {
                return (SaleContractArrearsCalculationDTO != null && SaleContractArrearsCalculationDTO.SummaryFormat > 0) ? SaleContractArrearsCalculationDTO.SummaryFormat : new byte();
            }
            set
            {
                SaleContractArrearsCalculationDTO.SummaryFormat = value;
            }
        }
    }
}

