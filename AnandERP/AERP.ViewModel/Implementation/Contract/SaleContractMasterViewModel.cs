using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractMasterViewModel : ISaleContractMasterViewModel
    {

        public SaleContractMasterViewModel()
        {
            SaleContractMasterDTO = new SaleContractMaster();
            SaleContractMasterListForManPowerItem = new List<SaleContractMaster>();
            SaleContractMasterListForAssignedEmployee = new List<SaleContractMaster>();
            SaleContractMasterListForContractMaterial = new List<SaleContractMaster>();
            SaleContractMasterListForMachineMaster = new List<SaleContractMaster>();
            SaleContractMasterListForJobWorkItem = new List<SaleContractMaster>();
            SaleContractMasterListForFixItem = new List<SaleContractMaster>();
            SaleContractMasterListForServiceCharge = new List<SaleContractMaster>();
            SaleContractMasterListForServiceChargeForHead = new List<SaleContractMaster>();
            SaleContractMasterListForOverTime = new List<SaleContractMaster>();
            SaleContractMasterListForOverTimeFix = new List<SaleContractMaster>();
            SaleContractMasterListForServiceItem = new List<SaleContractMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public List<SaleContractMaster> SaleContractMasterListForManPowerItem { get; set; }
        public List<SaleContractMaster> SaleContractMasterListForAssignedEmployee { get; set; }
        public List<SaleContractMaster> SaleContractMasterListForContractMaterial { get; set; }
        public List<SaleContractMaster> SaleContractMasterListForMachineMaster { get; set; }
        public List<SaleContractMaster> SaleContractMasterListForJobWorkItem { get; set; }
        public List<SaleContractMaster> SaleContractMasterListForFixItem { get; set; }
        public List<SaleContractMaster> SaleContractMasterListForServiceCharge { get; set; }
        public List<SaleContractMaster> SaleContractMasterListForServiceChargeForHead { get; set; }
        public List<SaleContractMaster> SaleContractMasterListForOverTime { get; set; }
        public List<SaleContractMaster> SaleContractMasterListForOverTimeFix { get; set; }
        public List<SaleContractMaster> SaleContractMasterListForServiceItem { get; set; }

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
        public SaleContractMaster SaleContractMasterDTO
        {
            get;
            set;
        }

        public Int64 ID
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.ID > 0) ? SaleContractMasterDTO.ID : new Int64();
            }
            set
            {
                SaleContractMasterDTO.ID = value;
            }
        }
        [Display(Name = "Centre")]
        public string CentreCode
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "Narration")]
        public string Narration
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.Narration : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.Narration = value;
            }
        }
        [Display(Name = "Operational Manager")]
        public string EmployeeMasterName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.EmployeeMasterName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.EmployeeMasterName = value;
            }
        }
        [Display(Name = "Operational Manager")]
        public Int32 EmployeeMasterID
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.EmployeeMasterID > 0) ? SaleContractMasterDTO.EmployeeMasterID : new Int32();
            }
            set
            {
                SaleContractMasterDTO.EmployeeMasterID = value;
            }
        }
        
        [Display(Name = "Is Confidential")]
        public bool IsConfidential
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsConfidential : false;
            }
            set
            {
                SaleContractMasterDTO.IsConfidential = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.CustomerBranchMasterID > 0) ? SaleContractMasterDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                SaleContractMasterDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.CustomerBranchMasterName = value;
            }
        }

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "Customer Required")]
        public Int32 CustomerMasterID
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.CustomerMasterID > 0) ? SaleContractMasterDTO.CustomerMasterID : new Int32();
            }
            set
            {
                SaleContractMasterDTO.CustomerMasterID = value;
            }
        }
        [Required(ErrorMessage = "Customer Required")]
        [Display(Name = "Customer")]
        public string CustomerMasterName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Customer Type")]
        public byte CustomerType
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.CustomerType : new byte();
            }
            set
            {
                SaleContractMasterDTO.CustomerType = value;
            }
        }
        [Required(ErrorMessage = "Contact Person Required")]
        [Display(Name = "Contact Person")]
        public Int32 CustomerContactPersonID
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.CustomerContactPersonID > 0) ? SaleContractMasterDTO.CustomerContactPersonID : new Int32();
            }
            set
            {
                SaleContractMasterDTO.CustomerContactPersonID = value;
            }
        }
        [Required(ErrorMessage = "Contact Person Required")]
        [Display(Name = "Contact Person")]
        public string CustomerContactPersonName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.CustomerContactPersonName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.CustomerContactPersonName = value;
            }
        }

        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Sale Contract Type")]
        public byte SaleContractType
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.SaleContractType > 0) ? SaleContractMasterDTO.SaleContractType : new byte();
            }
            set
            {
                SaleContractMasterDTO.SaleContractType = value;
            }
        }
        [Display(Name = "Billing Type")]
        public byte BillingType
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.BillingType > 0) ? SaleContractMasterDTO.BillingType : new byte();
            }
            set
            {
                SaleContractMasterDTO.BillingType = value;
            }
        }
        [Display(Name = "Billing Fixed Amount")]
        public decimal BillingFixedAmount
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.BillingFixedAmount > 0) ? SaleContractMasterDTO.BillingFixedAmount : new decimal();
            }
            set
            {
                SaleContractMasterDTO.BillingFixedAmount = value;
            }
        }
        [Display(Name = "Fixed Billing Format")]
        public byte FixedBillingType
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.FixedBillingType : new byte();
            }
            set
            {
                SaleContractMasterDTO.FixedBillingType = value;
            }
        }
        [Display(Name = "Man Power Item")]
        public Int32 FixedBillingForManPowerItemID
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.FixedBillingForManPowerItemID > 0) ? SaleContractMasterDTO.FixedBillingForManPowerItemID : new Int32();
            }
            set
            {
                SaleContractMasterDTO.FixedBillingForManPowerItemID = value;
            }
        }
        [Display(Name = "Man Power Item")]
        public string FixedBillingForManPowerItemName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.FixedBillingForManPowerItemName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.FixedBillingForManPowerItemName = value;
            }
        }

        [Display(Name = "Short/Extra Posting Rate Acc. To")]
        public byte ShortExtraPostingRateAccTo
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ShortExtraPostingRateAccTo : new byte();
            }
            set
            {
                SaleContractMasterDTO.ShortExtraPostingRateAccTo = value;
            }
        }
        [Display(Name = "Fixed Rate")]
        public decimal FixedRate
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.FixedRate > 0) ? SaleContractMasterDTO.FixedRate : new decimal();
            }
            set
            {
                SaleContractMasterDTO.FixedRate = value;
            }
        }
        [Display(Name = "Include All Posting For Short/Extra Rate")]
        public bool IsIncludeAllPostingForShortExtraRate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsIncludeAllPostingForShortExtraRate : false;
            }
            set
            {
                SaleContractMasterDTO.IsIncludeAllPostingForShortExtraRate = value;
            }
        }
        
        public string TaskCode
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.TaskCode : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.TaskCode = value;
            }
        }
        [Display(Name = "Contract Start Date")]
        public string ContractStartDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ContractStartDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.ContractStartDate = value;
            }
        }
        [Display(Name = "Contract End Date")]
        public string ContractEndDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ContractEndDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.ContractEndDate = value;
            }
        }
        public Int32 SaleContractManPowerItemID
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.SaleContractManPowerItemID > 0) ? SaleContractMasterDTO.SaleContractManPowerItemID : new Int32();
            }
            set
            {
                SaleContractMasterDTO.SaleContractManPowerItemID = value;

            }
        }
        [Display(Name = "Post Name")]
        public Int32 SelectedSaleContractManPowerItemID
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.SelectedSaleContractManPowerItemID > 0) ? SaleContractMasterDTO.SelectedSaleContractManPowerItemID : new Int32();
            }
            set
            {
                SaleContractMasterDTO.SelectedSaleContractManPowerItemID = value;

            }
        }
        [Display(Name = "Post Name")]
        public string SaleContractManPowerItemName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractManPowerItemName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.SaleContractManPowerItemName = value;
            }
        }
        [Display(Name = "Required Number")]
        public Int16 SaleContractManPowerItemRequired
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractManPowerItemRequired : new Int16();
            }
            set
            {
                SaleContractMasterDTO.SaleContractManPowerItemRequired = value;
            }
        }
        [Display(Name = "Contract Employee")]
        public Int64 SaleContractEmployeeMasterID
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractEmployeeMasterID : new Int64();
            }
            set
            {
                SaleContractMasterDTO.SaleContractEmployeeMasterID = value;
            }
        }
        [Display(Name = "Contract Employee")]
        public string SaleContractEmployeeMasterName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractEmployeeMasterName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.SaleContractEmployeeMasterName = value;
            }
        }
        [Display(Name = "Gender")]
        public byte Gender
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.Gender > 0) ? SaleContractMasterDTO.Gender : new byte();
            }
            set
            {
                SaleContractMasterDTO.Gender = value;
            }
        }
        [Display(Name = "Is Salary Days Fixed")]
        public bool IsSalaryDaysCountFix
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsSalaryDaysCountFix : false;
            }
            set
            {
                SaleContractMasterDTO.IsSalaryDaysCountFix = value;
            }
        }
        [Display(Name = "Fixed Days")]
        public byte FixedDays
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.FixedDays : new byte();
            }
            set
            {
                SaleContractMasterDTO.FixedDays = value;
            }
        }
        [Display(Name = "Is Salary Days On Off Days")]
        public bool IsSalaryDaysOnWeeklyOff
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsSalaryDaysOnWeeklyOff : false;
            }
            set
            {
                SaleContractMasterDTO.IsSalaryDaysOnWeeklyOff = value;
            }
        }
        [Display(Name = "Is Billing Days Fixed")]
        public bool IsBillingDaysFixed
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsBillingDaysFixed : false;
            }
            set
            {
                SaleContractMasterDTO.IsBillingDaysFixed = value;
            }
        }
        [Display(Name = "Fixed Billing Days")]
        public byte FixedBillingDays
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.FixedBillingDays : new byte();
            }
            set
            {
                SaleContractMasterDTO.FixedBillingDays = value;
            }
        }
        [Display(Name = "Is Billing Days On Off Days")]
        public bool IsBillingDaysOnWeeklyOff
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsBillingDaysOnWeeklyOff : false;
            }
            set
            {
                SaleContractMasterDTO.IsBillingDaysOnWeeklyOff = value;
            }
        }

        [Display(Name = "Weekly Off")]
        public byte ManPowerItemWeeklyOff
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ManPowerItemWeeklyOff : new byte();
            }
            set
            {
                SaleContractMasterDTO.ManPowerItemWeeklyOff = value;
            }
        }
        [Display(Name = "Over Time Per Hours Rate")]
        public decimal OvertimePerHoursRate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.OvertimePerHoursRate : new decimal();
            }
            set
            {
                SaleContractMasterDTO.OvertimePerHoursRate = value;
            }
        }
        [Display(Name = "Assign From Date")]
        public string ManPowerAssignFromDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ManPowerAssignFromDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.ManPowerAssignFromDate = value;
            }
        }

        [Display(Name = "Item Description")]
        public Int32 ItemNumber
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.ItemNumber > 0) ? SaleContractMasterDTO.ItemNumber : new Int32();
            }
            set
            {
                SaleContractMasterDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.ItemDescription = value;
            }
        }
        [Display(Name = "Quantity")]
        public decimal Quantity
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.Quantity > 0) ? SaleContractMasterDTO.Quantity : new decimal();
            }
            set
            {
                SaleContractMasterDTO.Quantity = value;
            }
        }
        [Display(Name = "Unit")]
        public string UOMCode
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.UOMCode : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.UOMCode = value;
            }
        }
        [Display(Name = "Rate")]
        public decimal Rate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.Rate : new decimal();
            }
            set
            {
                SaleContractMasterDTO.Rate = value;
            }
        }

        [Display(Name = "Machine Name")]
        public Int16 SaleContractMachineMasterID
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractMachineMasterID : new Int16();
            }
            set
            {
                SaleContractMasterDTO.SaleContractMachineMasterID = value;
            }
        }
        [Display(Name = "Machine Name")]
        public string SaleContractMachineMasterName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractMachineMasterName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.SaleContractMachineMasterName = value;
            }
        }
        [Display(Name = "Required Number")]
        public Int16 SaleContractMachineMasterRequired
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractMachineMasterRequired : new Int16();
            }
            set
            {
                SaleContractMasterDTO.SaleContractMachineMasterRequired = value;
            }
        }
        [Display(Name = "Serial Number")]
        public string SaleContractMachineMasterSerialNumber
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractMachineMasterSerialNumber : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.SaleContractMachineMasterSerialNumber = value;
            }
        }
        [Display(Name = "Machine Rate")]
        public decimal SaleContractMachineMasterRate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractMachineMasterRate : new decimal();
            }
            set
            {
                SaleContractMasterDTO.SaleContractMachineMasterRate = value;
            }
        }
        [Display(Name = "Assign From Date")]
        public string MachineAssignFromDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.MachineAssignFromDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.MachineAssignFromDate = value;
            }
        }
        [Display(Name = "Employee Shift")]
        public byte EmployeeShiftMasterID
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.EmployeeShiftMasterID : new byte();
            }
            set
            {
                SaleContractMasterDTO.EmployeeShiftMasterID = value;
            }
        }
        [Display(Name = "Additional Amount")]
        public decimal SaleContractEmployeeAdditionalAmount
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractEmployeeAdditionalAmount : new decimal();
            }
            set
            {
                SaleContractMasterDTO.SaleContractEmployeeAdditionalAmount = value;
            }
        }

        [Display(Name = "Billing Cycle In Days")]
        public byte BillingCycleInDays
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.BillingCycleInDays : new byte();
            }
            set
            {
                SaleContractMasterDTO.BillingCycleInDays = value;
            }
        }
        [Display(Name = "Material Supply Day")]
        public byte MaterialSupplyDay
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.MaterialSupplyDay : new byte();
            }
            set
            {
                SaleContractMasterDTO.MaterialSupplyDay = value;
            }
        }
        [Display(Name = "Renew Call Before Days")]
        public byte RenewCallBeforeDays
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.RenewCallBeforeDays : new byte();
            }
            set
            {
                SaleContractMasterDTO.RenewCallBeforeDays = value;
            }
        }
        [Display(Name = "Material Supply Fix Amount")]
        public decimal MaterialSupplyFixAmount
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.MaterialSupplyFixAmount : new decimal();
            }
            set
            {
                SaleContractMasterDTO.MaterialSupplyFixAmount = value;
            }
        }
        [Display(Name = "Salary Span Start Day")]
        public byte SalarySpanStartDay
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SalarySpanStartDay : new byte();
            }
            set
            {
                SaleContractMasterDTO.SalarySpanStartDay = value;
            }
        }
        [Display(Name = "Salary Span Upto Day")]
        public byte SalarySpanUptoDay
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SalarySpanUptoDay : new byte();
            }
            set
            {
                SaleContractMasterDTO.SalarySpanUptoDay = value;
            }
        }
        [Display(Name = "Is Inclusive Service Charges")]
        public bool IsInclusiveServiceCharges
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsInclusiveServiceCharges : false;
            }
            set
            {
                SaleContractMasterDTO.IsInclusiveServiceCharges = value;
            }
        }
        [Display(Name = "Apply Service Charges To Additional Amount")]
        public bool IsServiceChargesAppliedToAddAmount
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsServiceChargesAppliedToAddAmount : false;
            }
            set
            {
                SaleContractMasterDTO.IsServiceChargesAppliedToAddAmount = value;
            }
        }
        [Display(Name = "Apply Service Charges To Service Item")]
        public bool IsServiceChargesAppliedToServiceItem
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsServiceChargesAppliedToServiceItem : false;
            }
            set
            {
                SaleContractMasterDTO.IsServiceChargesAppliedToServiceItem = value;
            }
        }
        [Display(Name = "Apply Service Charges To Over Time")]
        public bool IsServiceChargesAppliedToOverTime
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsServiceChargesAppliedToOverTime : false;
            }
            set
            {
                SaleContractMasterDTO.IsServiceChargesAppliedToOverTime = value;
            }
        }
        [Display(Name = "Is Rate Fixed For Rate Contract")]
        public bool IsRateFixedForRateContract
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsRateFixedForRateContract : false;
            }
            set
            {
                SaleContractMasterDTO.IsRateFixedForRateContract = value;
            }
        }
        
        [Display(Name = "Service Charges Percentage")]
        public decimal ServiceChargesPercentage
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ServiceChargesPercentage : new decimal();
            }
            set
            {
                SaleContractMasterDTO.ServiceChargesPercentage = value;
            }
        }
        [Display(Name = "Span Effective From Date")]
        public string SalaryEffectiveFromDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SalaryEffectiveFromDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.SalaryEffectiveFromDate = value;
            }
        }
        [Display(Name = "Span Effective Upto Date")]
        public string SalaryEffectiveUptoDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SalaryEffectiveUptoDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.SalaryEffectiveUptoDate = value;
            }
        }
        
        [Display(Name = "Service Charges Depend On")]
        public byte ServiceChargesDependOn
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ServiceChargesDependOn : new byte();
            }
            set
            {
                SaleContractMasterDTO.ServiceChargesDependOn = value;
            }
        }
        [Display(Name = "Service Charges Calculate On")]
        public byte ServiceChargesCalculateOn
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ServiceChargesCalculateOn : new byte();
            }
            set
            {
                SaleContractMasterDTO.ServiceChargesCalculateOn = value;
            }
        }
        [Display(Name = "Additional Allowance Paid By")]
        public byte AdditionalAllowancePaidBy
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.AdditionalAllowancePaidBy : new byte();
            }
            set
            {
                SaleContractMasterDTO.AdditionalAllowancePaidBy = value;
            }
        }
        [Display(Name = "Service Charges Fix Amount")]
        public decimal ServiceChargesFixAmount
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ServiceChargesFixAmount : new decimal();
            }
            set
            {
                SaleContractMasterDTO.ServiceChargesFixAmount = value;
            }
        }
        [Display(Name = "Service Charges From Date")]
        public string ServiceChargesFromDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ServiceChargesFromDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.ServiceChargesFromDate = value;
            }
        }
        [Display(Name = "Service Charges Upto Date")]
        public string ServiceChargesUptoDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ServiceChargesUptoDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.ServiceChargesUptoDate = value;
            }
        }
        [Display(Name = "Over Time Depend On")]
        public byte OverTimeDependOn
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.OverTimeDependOn : new byte();
            }
            set
            {
                SaleContractMasterDTO.OverTimeDependOn = value;
            }
        }
        [Display(Name = "Over Time Display Format")]
        public byte OverTimeDisplayFormat
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.OverTimeDisplayFormat : new byte();
            }
            set
            {
                SaleContractMasterDTO.OverTimeDisplayFormat = value;
            }
        }
        [Display(Name = "Is Over Time Salary Days Fix")]
        public bool IsOverTimeDaysFix
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsOverTimeDaysFix : false;
            }
            set
            {
                SaleContractMasterDTO.IsOverTimeDaysFix = value;
            }
        }
        [Display(Name = "Over Time Fix Salary Days")]
        public byte OTFixedDays
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.OTFixedDays : new byte();
            }
            set
            {
                SaleContractMasterDTO.OTFixedDays = value;
            }
        }
        [Display(Name = "Is Over Time Salary Days On Off Days")]
        public bool IsOTDaysOnTotalOff
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsOTDaysOnTotalOff : false;
            }
            set
            {
                SaleContractMasterDTO.IsOTDaysOnTotalOff = value;
            }
        }
        [Display(Name = "Is Over Time Billing Days Fix")]
        public bool IsOverTimeBillingDaysFix
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsOverTimeBillingDaysFix : false;
            }
            set
            {
                SaleContractMasterDTO.IsOverTimeBillingDaysFix = value;
            }
        }
        [Display(Name = "Over Time Fix Billing Days")]
        public byte OTBillingFixedDays
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.OTBillingFixedDays : new byte();
            }
            set
            {
                SaleContractMasterDTO.OTBillingFixedDays = value;
            }
        }
        [Display(Name = "Is Over Time Billing Days On Off Days")]
        public bool IsOTBillingDaysOnTotalOff
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsOTBillingDaysOnTotalOff : false;
            }
            set
            {
                SaleContractMasterDTO.IsOTBillingDaysOnTotalOff = value;
            }
        }
        [Display(Name = "Fixed Amount For Invoice")]
        public decimal FixedAmountForInvoice
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.FixedAmountForInvoice : new decimal();
            }
            set
            {
                SaleContractMasterDTO.FixedAmountForInvoice = value;
            }
        }
        [Display(Name = "Fixed Amount For Salary Compliance")]
        public decimal FixedAmountForSalaryCompliance
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.FixedAmountForSalaryCompliance : new decimal();
            }
            set
            {
                SaleContractMasterDTO.FixedAmountForSalaryCompliance = value;
            }
        }
        [Display(Name = "Salary Allowance Master Name")]
        public Int16 SalaryAllowanceMasterID
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SalaryAllowanceMasterID : new Int16();
            }
            set
            {
                SaleContractMasterDTO.SalaryAllowanceMasterID = value;
            }
        }
        [Display(Name = "Salary Allowance Master Name")]
        public string SalaryAllowanceMasterName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SalaryAllowanceMasterName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.SalaryAllowanceMasterName = value;
            }
        }
        [Display(Name = "For Invoice Or Salary Compliance")]
        public byte ForInvoiceOrSalaryCompliance
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.ForInvoiceOrSalaryCompliance : new byte();
            }
            set
            {
                SaleContractMasterDTO.ForInvoiceOrSalaryCompliance = value;
            }
        }
        [Display(Name = "Over Time From Date")]
        public string OverTimeFromDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.OverTimeFromDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.OverTimeFromDate = value;
            }
        }
        [Display(Name = "Over Time Upto Date")]
        public string OverTimeUptoDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.OverTimeUptoDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.OverTimeUptoDate = value;
            }
        }
        [Display(Name = "Basic Or Allowance")]
        public byte BasicOrAllowance
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.BasicOrAllowance : new byte();
            }
            set
            {
                SaleContractMasterDTO.BasicOrAllowance = value;
            }
        }

        [Display(Name = "Job Work Item Name")]
        public string SaleContractJobWorkItemName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractJobWorkItemName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.SaleContractJobWorkItemName = value;
            }
        }
        [Display(Name = "Job Work Item Name")]
        public Int32 SaleContractJobWorkItemID
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractJobWorkItemID : new Int32();
            }
            set
            {
                SaleContractMasterDTO.SaleContractJobWorkItemID = value;
            }
        }
        [Display(Name = "Job Work Item Rate")]
        public decimal SaleContractJobWorkItemRate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractJobWorkItemRate : new decimal();
            }
            set
            {
                SaleContractMasterDTO.SaleContractJobWorkItemRate = value;
            }
        }
        [Display(Name = "Fix Item Name")]
        public string SaleContractFixItemName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractFixItemName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.SaleContractFixItemName = value;
            }
        }
        [Display(Name = "Fix Item Name")]
        public Int32 SaleContractFixItemID
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractFixItemID : new Int32();
            }
            set
            {
                SaleContractMasterDTO.SaleContractFixItemID = value;
            }
        }
        [Display(Name = "Fix Item Quantity")]
        public decimal SaleContractFixItemQuantity
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractFixItemQuantity : new decimal();
            }
            set
            {
                SaleContractMasterDTO.SaleContractFixItemQuantity = value;
            }
        }
        [Display(Name = "Fix Item Rate")]
        public decimal SaleContractFixItemRate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractFixItemRate : new decimal();
            }
            set
            {
                SaleContractMasterDTO.SaleContractFixItemRate = value;
            }
        }
        [Display(Name = "Service Item Name")]
        public string SaleContractServiceItemName
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractServiceItemName : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.SaleContractServiceItemName = value;
            }
        }
        [Display(Name = "Service Item Name")]
        public Int32 SaleContractServiceItemNumber
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractServiceItemNumber : new Int32();
            }
            set
            {
                SaleContractMasterDTO.SaleContractServiceItemNumber = value;
            }
        }

        [Display(Name = "Service Item Rate")]
        public decimal SaleContractServiceItemRate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.SaleContractServiceItemRate : new decimal();
            }
            set
            {
                SaleContractMasterDTO.SaleContractServiceItemRate = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsDeleted : false;
            }
            set
            {
                SaleContractMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.CreatedBy > 0) ? SaleContractMasterDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.ModifiedBy > 0) ? SaleContractMasterDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.ModifiedDate.HasValue) ? SaleContractMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.DeletedBy > 0) ? SaleContractMasterDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractMasterDTO != null && SaleContractMasterDTO.DeletedDate.HasValue) ? SaleContractMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLstringForManPowerItem { get; set; }
        public string XMLstringForAssignedEmployee { get; set; }
        public string XMLstringForContractMaterial { get; set; }
        public string XMLstringForMachine { get; set; }
        public string XMLstringForJobWorkItem { get; set; }
        public string XMLstringForShiftingEmployee { get; set; }
        public string XMLstringForFixItem { get; set; }
        public string XMLstringForManPowerServiceCharge { get; set; }
        public string XMLstringForManPowerServiceChargeForHead { get; set; }
        public string XMLstringForOverTime { get; set; }
        public string XMLstringForOverTimeFix { get; set; }
        public string XMLstringForServiceItem { get; set; }

        [Display(Name = "Purchase Order Number")]
        public string PurchaseOrderNumber
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.PurchaseOrderNumber : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.PurchaseOrderNumber = value;
            }
        }
        [Display(Name = "Purchase Order Date")]
        public string PurchaseOrderDate
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.PurchaseOrderDate : string.Empty;
            }
            set
            {
                SaleContractMasterDTO.PurchaseOrderDate = value;
            }
        }
        [Display(Name = "Display Purchase Order Details")]
        public bool IsDisplayPurchaseDetails
        {
            get
            {
                return (SaleContractMasterDTO != null) ? SaleContractMasterDTO.IsDisplayPurchaseDetails : false;
            }
            set
            {
                SaleContractMasterDTO.IsDisplayPurchaseDetails = value;
            }
        }
    }
}

