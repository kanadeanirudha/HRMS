using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractMaster : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get; set;
        }
        public bool IsConfidential
        {
            get; set;
        }
        public string Narration
        {
            get; set;
        }
        public string EmployeeMasterName
        {
            get; set;
        }
        public Int32 EmployeeMasterID
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
        public Int32 CustomerContactPersonID
        {
            get; set;
        }
        public string CustomerContactPersonName
        {
            get; set;
        }
        public string ContractNumber
        {
            get; set;
        }
        public byte SaleContractType
        {
            get; set;
        }
        public byte BillingType
        {
            get; set;
        }
        public decimal BillingFixedAmount
        {
            get; set;
        }
        public byte FixedBillingType
        {
            get; set;
        }
        public Int32 FixedBillingForManPowerItemID
        {
            get; set;
        }
        public string FixedBillingForManPowerItemName
        {
            get; set;
        }
        public decimal FixedRate
        {
            get; set;
        }
        public byte ShortExtraPostingRateAccTo
        {
            get; set;
        }
        public bool IsIncludeAllPostingForShortExtraRate
        {
            get; set;
        }
        public string TaskCode
        {
            get; set;
        }
        public string ContractStartDate
        {
            get; set;
        }
        public string ContractEndDate
        {
            get; set;
        }
        public Int64 SaleContractRequirementDetailsID
        {
            get; set;
        }
        public Int64 SaleContractManPowerAssignID
        {
            get; set;
        }
        public Int64 SaleContractMachineAssignID
        {
            get; set;
        }
        public Int32 SaleContractManPowerItemID
        {
            get; set;
        }
        public Int32 SelectedSaleContractManPowerItemID
        {
            get; set;
        }
        public string SaleContractManPowerItemName
        {
            get; set;
        }
        public Int16 SaleContractManPowerItemRequired
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
        public bool IsSalaryDaysCountFix
        {
            get; set;
        }
        public byte FixedDays
        {
            get; set;
        }
        public bool IsSalaryDaysOnWeeklyOff
        {
            get; set;
        }
        public bool IsBillingDaysFixed
        {
            get; set;
        }
        public byte FixedBillingDays
        {
            get; set;
        }
        public bool IsBillingDaysOnWeeklyOff
        {
            get; set;
        }
        public byte ManPowerItemWeeklyOff
        {
            get; set;
        }
        public decimal OvertimePerHoursRate
        {
            get; set;
        }
        public byte Gender
        {
            get; set;
        }
        public Int32 ItemNumber
        {
            get; set;
        }
        public string ItemDescription
        {
            get; set;
        }
        public decimal Quantity
        {
            get; set;
        }
        public string UOMCode
        {
            get; set;
        }
        public decimal Rate
        {
            get; set;
        }
        public Int16 SaleContractMachineMasterID
        {
            get; set;
        }
        public string SaleContractMachineMasterName
        {
            get; set;
        }
        public Int16 SaleContractMachineMasterRequired
        {
            get; set;
        }
        public string SaleContractMachineMasterSerialNumber
        {
            get; set;
        }
        public decimal SaleContractMachineMasterRate
        {
            get; set;
        }
        public string MachineAssignFromDate
        {
            get; set;
        }
        public byte EmployeeShiftMasterID
        {
            get; set;
        }
        public decimal SaleContractEmployeeAdditionalAmount
        {
            get; set;
        }
        public string EmployeeShiftMasterName
        {
            get; set;
        }
        public string ManPowerAssignFromDate
        {
            get; set;
        }
        public Int64 SaleContractTermDetailsID
        {
            get; set;
        }
        public byte BillingCycleInDays
        {
            get; set;
        }
        public byte MaterialSupplyDay
        {
            get; set;
        }
        public byte RenewCallBeforeDays
        {
            get; set;
        }
        public decimal MaterialSupplyFixAmount
        {
            get; set;
        }
        public byte SalarySpanStartDay
        {
            get; set;
        }
        public byte SalarySpanUptoDay
        {
            get; set;
        }
        public bool IsInclusiveServiceCharges
        {
            get; set;
        }
        public bool IsServiceChargesAppliedToAddAmount
        {
            get; set;
        }
        public bool IsServiceChargesAppliedToServiceItem
        {
            get; set;
        }
        public bool IsServiceChargesAppliedToOverTime
        {
            get; set;
        }
        public bool IsRateFixedForRateContract
        {
            get; set;
        }
        public decimal ServiceChargesPercentage
        {
            get; set;
        }
        public byte ServiceChargesDependOn
        {
            get; set;
        }
        public byte ServiceChargesCalculateOn
        {
            get; set;
        }
        public byte AdditionalAllowancePaidBy
        {
            get; set;
        }
        public Int64 SaleContractServiceChargeOnManPowerItemID { get; set; }
        public decimal ServiceChargesFixAmount
        {
            get; set;
        }
        public string ServiceChargesFromDate
        {
            get; set;
        }
        public string ServiceChargesUptoDate
        {
            get; set;
        }
        public byte ReferenceID
        {
            get; set;
        }
        public string CalculateOnName
        {
            get; set;
        }
        public byte AllowanceOrDeduction
        {
            get; set;
        }
        public string SelectedStatusFlag
        {
            get; set;
        }
        public Int64 ServiceChargeOnSalaryHeadsID
        {
            get; set;
        }
        public string SalaryEffectiveFromDate
        {
            get; set;
        }
        public string SalaryEffectiveUptoDate { get; set; }
        public Int64 SaleContractOvertimeID
        {
            get; set;
        }
        public Int64 SaleContractOvertimeSumOfID
        {
            get; set;
        }
        public byte OverTimeDependOn
        {
            get; set;
        }
        public byte OverTimeDisplayFormat
        {
            get; set;
        }
        public bool IsOverTimeDaysFix
        {
            get; set;
        }
        public byte OTFixedDays
        {
            get; set;
        }
        public bool IsOTDaysOnTotalOff
        {
            get; set;
        }
        public bool IsOverTimeBillingDaysFix
        {
            get; set;
        }
        public byte OTBillingFixedDays
        {
            get; set;
        }
        public bool IsOTBillingDaysOnTotalOff
        {
            get; set;
        }
        public decimal FixedAmountForInvoice
        {
            get; set;
        }
        public decimal FixedAmountForSalaryCompliance
        {
            get; set;
        }
        public Int16 SalaryAllowanceMasterID
        {
            get; set;
        }
        public string SalaryAllowanceMasterName
        {
            get; set;
        }
        public byte ForInvoiceOrSalaryCompliance
        {
            get; set;
        }
        public string OverTimeFromDate
        {
            get; set;
        }
        public string OverTimeUptoDate
        {
            get; set;
        }
        public byte BasicOrAllowance
        {
            get; set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string SaleContractJobWorkItemName
        {
            get; set;
        }
        public Int32 SaleContractJobWorkItemID
        {
            get; set;
        }
        public decimal SaleContractJobWorkItemRate
        {
            get; set;
        }
        public string SaleContractFixItemName
        {
            get; set;
        }
        public Int32 SaleContractFixItemID
        {
            get; set;
        }
        public decimal SaleContractFixItemQuantity
        {
            get; set;
        }
        public decimal SaleContractFixItemRate
        {
            get; set;
        }
        public string SaleContractServiceItemName
        {
            get; set;
        }
        public Int32 SaleContractServiceItemNumber
        {
            get; set;
        }
        public decimal SaleContractServiceItemRate
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
        public string PurchaseOrderNumber { get; set; }
        public string PurchaseOrderDate { get; set; }
        public bool IsDisplayPurchaseDetails { get; set; }
        public int AdminRoleID { get; set; }
    }
}
