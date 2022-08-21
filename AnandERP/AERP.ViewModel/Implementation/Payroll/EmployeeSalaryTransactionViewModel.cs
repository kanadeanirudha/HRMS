using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeSalaryTransactionViewModel : IEmployeeSalaryTransactionViewModel
    {

        public EmployeeSalaryTransactionViewModel()
        {
            EmployeeSalaryTransactionDTO = new EmployeeSalaryTransaction();
            EmployeeSalaryTransactionList = new List<EmployeeSalaryTransaction>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGetOrganisationDepartmentCentreAndRoleWise = new List<OrganisationDepartmentMaster>();
            EmployeeSalarySpanList = new List<EmployeeSalarySpan>();
        }
        public List<EmployeeSalaryTransaction> EmployeeSalaryTransactionList { get; set; }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public List<OrganisationDepartmentMaster> ListGetOrganisationDepartmentCentreAndRoleWise
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetOrganisationDepartmentCentreAndRoleWiseItems
        {
            get
            {
                return new SelectList(ListGetOrganisationDepartmentCentreAndRoleWise, "ID", "DepartmentName");
            }
        }
        public List<EmployeeSalarySpan> EmployeeSalarySpanList
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> EmployeeSalarySpanListItems
        {
            get
            {
                return new SelectList(EmployeeSalarySpanList, "SpanID", "Span");
            }
        }
        public EmployeeSalaryTransaction EmployeeSalaryTransactionDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.ID > 0) ? EmployeeSalaryTransactionDTO.ID : new Int64();
            }
            set
            {
                EmployeeSalaryTransactionDTO.ID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public Int64 SaleContractMasterID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.SaleContractMasterID > 0) ? EmployeeSalaryTransactionDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                EmployeeSalaryTransactionDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.ContractNumber : string.Empty;
            }
            set
            {
                EmployeeSalaryTransactionDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Billing Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.SaleContractBillingSpanID > 0) ? EmployeeSalaryTransactionDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                EmployeeSalaryTransactionDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Billing Span")]
        public string SaleContractBillingSpanName
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.SaleContractBillingSpanName : string.Empty;
            }
            set
            {
                EmployeeSalaryTransactionDTO.SaleContractBillingSpanName = value;
            }
        }
        [Display(Name = "Employee")]
        public Int32 EmployeeMasterID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.EmployeeMasterID > 0) ? EmployeeSalaryTransactionDTO.EmployeeMasterID : new Int32();
            }
            set
            {
                EmployeeSalaryTransactionDTO.EmployeeMasterID = value;
            }
        }
        
        public Int64 EmployeeSalaryTransactionID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.EmployeeSalaryTransactionID > 0) ? EmployeeSalaryTransactionDTO.EmployeeSalaryTransactionID : new Int64();
            }
            set
            {
                EmployeeSalaryTransactionDTO.EmployeeSalaryTransactionID = value;
            }
        }
        
        [Display(Name = "Employee")]
        public string EmployeeName
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.EmployeeName: string.Empty;
            }
            set
            {
                EmployeeSalaryTransactionDTO.EmployeeName = value;
            }
        }

        [Display(Name = "Post")]
        public Int32 SaleContractManPowerItemID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.SaleContractManPowerItemID > 0) ? EmployeeSalaryTransactionDTO.SaleContractManPowerItemID : new Int32();
            }
            set
            {
                EmployeeSalaryTransactionDTO.SaleContractManPowerItemID = value;
            }
        }
        [Display(Name = "Post")]
        public string SaleContractManPowerItemName
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.SaleContractManPowerItemName : string.Empty;
            }
            set
            {
                EmployeeSalaryTransactionDTO.SaleContractManPowerItemName = value;
            }
        }
        [Display(Name = "Start Date")]
        public string StartDate
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.StartDate : string.Empty;
            }
            set
            {
                EmployeeSalaryTransactionDTO.StartDate = value;
            }
        }

        [Display(Name = "End Date")]
        public string EndDate
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.EndDate : string.Empty;
            }
            set
            {
                EmployeeSalaryTransactionDTO.EndDate = value;
            }
        }
        [Display(Name = "Basic Salary")]
        public decimal BasicAmount
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.BasicAmount > 0) ? EmployeeSalaryTransactionDTO.BasicAmount : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.BasicAmount = value;
            }
        }
        [Display(Name = "Adjusted Basic Salary")]
        public decimal AdjustedBasicAmount
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.AdjustedBasicAmount > 0) ? EmployeeSalaryTransactionDTO.AdjustedBasicAmount : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.AdjustedBasicAmount = value;
            }
        }
        

        [Display(Name = "Total Amount")]
        public decimal TotalAmount
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.TotalAmount > 0) ? EmployeeSalaryTransactionDTO.TotalAmount : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.TotalAmount = value;

            }
        }

        [Display(Name = "Gross Amount")]
        public decimal GrossAmount
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.GrossAmount > 0) ? EmployeeSalaryTransactionDTO.GrossAmount : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.GrossAmount = value;
            }
        }
        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.TotalEarnings > 0) ? EmployeeSalaryTransactionDTO.TotalEarnings : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.TotalEarnings = value;
            }
        }
        
        [Display(Name = "Total Deduction")]
        public decimal TotalDeduction
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.TotalDeduction > 0) ? EmployeeSalaryTransactionDTO.TotalDeduction : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.TotalDeduction = value;
            }
        }
        [Display(Name = "Net Payable")]
        public decimal NetPayable
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.NetPayable > 0) ? EmployeeSalaryTransactionDTO.NetPayable : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.NetPayable = value;
            }
        }
        [Display(Name = "Total Emplyoer Contribution")]
        public decimal EmployerContributionTotal
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.EmployerContributionTotal > 0) ? EmployeeSalaryTransactionDTO.EmployerContributionTotal : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.EmployerContributionTotal = value;
            }
        }
        [Display(Name = "Total Salary")]
        public decimal TotalSalary
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.TotalSalary > 0) ? EmployeeSalaryTransactionDTO.TotalSalary : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.TotalSalary = value;
            }
        }
        public decimal AdjustedTotalSalary
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.AdjustedTotalSalary > 0) ? EmployeeSalaryTransactionDTO.AdjustedTotalSalary : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.AdjustedTotalSalary = value;
            }
        }
        
        [Display(Name = "Remove For Adjustment")]
        public bool IsRemoveForAdjustment
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.IsRemoveForAdjustment : false;
            }
            set
            {
                EmployeeSalaryTransactionDTO.IsRemoveForAdjustment = value;
            }
        }
        [Display(Name = "Total Days")]
        public byte TotalDays
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.TotalDays : new byte();
            }
            set
            {
                EmployeeSalaryTransactionDTO.TotalDays = value;
            }
        }
        [Display(Name = "Adjusted Total Days")]
        public decimal AdjustedTotalDays
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.AdjustedTotalDays : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.AdjustedTotalDays = value;
            }
        }
        
        [Display(Name = "Total Attendance")]
        public decimal TotalAttendance
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.TotalAttendance : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.TotalAttendance = value;
            }
        }

        [Display(Name = "Salary Transaction Details ID")]
        public Int64 EmployeeSalaryTransactionDetailsID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.EmployeeSalaryTransactionDetailsID > 0) ? EmployeeSalaryTransactionDTO.EmployeeSalaryTransactionDetailsID : new Int64();
            }
            set
            {
                EmployeeSalaryTransactionDTO.EmployeeSalaryTransactionDetailsID = value;
            }
        }
        [Display(Name = "Allowance ID")]
        public Int32 SaleContractManPowerAllowanceID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.SaleContractManPowerAllowanceID > 0) ? EmployeeSalaryTransactionDTO.SaleContractManPowerAllowanceID : new Int32();
            }
            set
            {
                EmployeeSalaryTransactionDTO.SaleContractManPowerAllowanceID = value;
            }
        }
        [Display(Name = "Deduction ID")]
        public Int32 SaleContractManPowerDeductionID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.SaleContractManPowerDeductionID > 0) ? EmployeeSalaryTransactionDTO.SaleContractManPowerDeductionID : new Int32();
            }
            set
            {
                EmployeeSalaryTransactionDTO.SaleContractManPowerDeductionID = value;
            }
        }
        [Display(Name = "Is Allowance")]
        public bool IsAllowance
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.IsAllowance : false;
            }
            set
            {
                EmployeeSalaryTransactionDTO.IsAllowance = value;
            }
        }
        [Display(Name = "Order")]
        public byte Order
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.Order : new byte();
            }
            set
            {
                EmployeeSalaryTransactionDTO.Order = value;
            }
        }
        [Display(Name = "Amount")]
        public decimal Amount
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.Amount : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.Amount = value;
            }
        }
        [Display(Name = "Adjusted Amount")]
        public decimal AdjustedAmount
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.AdjustedAmount : new decimal();
            }
            set
            {
                EmployeeSalaryTransactionDTO.AdjustedAmount = value;
            }
        }
        [Display(Name = "Head Name")]
        public string HeadName
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.HeadName : string.Empty;
            }
            set
            {
                EmployeeSalaryTransactionDTO.HeadName = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.IsDeleted : false;
            }
            set
            {
                EmployeeSalaryTransactionDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.CreatedBy > 0) ? EmployeeSalaryTransactionDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeSalaryTransactionDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null) ? EmployeeSalaryTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeSalaryTransactionDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.ModifiedBy > 0) ? EmployeeSalaryTransactionDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeSalaryTransactionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.ModifiedDate.HasValue) ? EmployeeSalaryTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeSalaryTransactionDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.DeletedBy > 0) ? EmployeeSalaryTransactionDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeSalaryTransactionDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.DeletedDate.HasValue) ? EmployeeSalaryTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeSalaryTransactionDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLStringSalaryTransaction { get; set; }
        public string XMLStringBulkSalaryTransactionEmployee { get; set; }
        public string XMLStringBulkSalaryTransaction { get; set; }
        public string XMLstringForVouchar { get; set; }

        public string SelectedCentreCode
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null ) ? EmployeeSalaryTransactionDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeSalaryTransactionDTO.CentreCode = value;
            }
        }
        public string SelectedDepartmentID
        {
            get;
            set;
        }
        public Int32 DepartmentMasterID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.DepartmentMasterID > 0) ? EmployeeSalaryTransactionDTO.DepartmentMasterID : new Int32();
            }
            set
            {
                EmployeeSalaryTransactionDTO.DepartmentMasterID = value;
            }
        }

        [Display(Name = "Salary Span")]
        public Int16 EmployeeSalarySpanID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.EmployeeSalarySpanID > 0) ? EmployeeSalaryTransactionDTO.EmployeeSalarySpanID : new Int16();
            }
            set
            {
                EmployeeSalaryTransactionDTO.EmployeeSalarySpanID = value;
            }
        }

        [Display(Name = "Salary Rules")]
        public Int64 EmployeeSalaryRulesID
        {
            get
            {
                return (EmployeeSalaryTransactionDTO != null && EmployeeSalaryTransactionDTO.EmployeeSalaryRulesID > 0) ? EmployeeSalaryTransactionDTO.EmployeeSalaryRulesID : new Int64();
            }
            set
            {
                EmployeeSalaryTransactionDTO.EmployeeSalaryRulesID = value;
            }
        }
        
    }
}

