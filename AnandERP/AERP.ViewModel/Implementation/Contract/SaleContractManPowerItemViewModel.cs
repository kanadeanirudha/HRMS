using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractManPowerItemViewModel : ISaleContractManPowerItemViewModel
    {

        public SaleContractManPowerItemViewModel()
        {
            SaleContractManPowerItemDTO = new SaleContractManPowerItem();
            SaleContractManPowerItemList = new List<SaleContractManPowerItem>();
            SaleContractManPowerItemCalculateOnList = new List<SalaryAllowanceMaster>();
        }

        public List<SaleContractManPowerItem> SaleContractManPowerItemList { get; set; }
        public List<SalaryAllowanceMaster> SaleContractManPowerItemCalculateOnList { get; set; }

        public SaleContractManPowerItem SaleContractManPowerItemDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.ID > 0) ? SaleContractManPowerItemDTO.ID : new int();
            }
            set
            {
                SaleContractManPowerItemDTO.ID = value;
            }
        }

        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "Item Description Required")]
        public Int32 ItemNumber
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.ItemNumber>0) ? SaleContractManPowerItemDTO.ItemNumber : new Int32();
            }
            set
            {
                SaleContractManPowerItemDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "Item Description Required")]
        public string ItemDescription
        {
            get
            {
                return (SaleContractManPowerItemDTO != null ) ? SaleContractManPowerItemDTO.ItemDescription : string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.ItemDescription = value;
            }
        }

        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Designation Required")]
        public Int16 DesignationMasterID
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.DesignationMasterID > 0) ? SaleContractManPowerItemDTO.DesignationMasterID : new Int16();
            }
            set
            {
                SaleContractManPowerItemDTO.DesignationMasterID = value;
            }
        }
        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Designation Required")]
        public string DesignationMasterName
        {
            get
            {
                return (SaleContractManPowerItemDTO != null ) ? SaleContractManPowerItemDTO.DesignationMasterName : string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.DesignationMasterName = value;
            }
        }
        
        [Display(Name = "Basic Salay Amount")]
        [Required(ErrorMessage = "Basic Salay Required")]
        public decimal BasicSalayAmount
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.BasicSalayAmount>0) ? SaleContractManPowerItemDTO.BasicSalayAmount : new decimal();
            }
            set
            {
                SaleContractManPowerItemDTO.BasicSalayAmount = value;
            }
        }

        [Display(Name = "Total Amount")]
        //[Required(ErrorMessage = "Total Amount Required")]
        public decimal TotalAmount
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.TotalAmount > 0) ? SaleContractManPowerItemDTO.TotalAmount : new decimal();
            }
            set
            {
                SaleContractManPowerItemDTO.TotalAmount = value;
            }
        }
        [Display(Name = "Fixed Salary Amount")]
        //[Required(ErrorMessage = "Total Amount Required")]
        public decimal FixedSalaryAmount
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.FixedSalaryAmount > 0) ? SaleContractManPowerItemDTO.FixedSalaryAmount : new decimal();
            }
            set
            {
                SaleContractManPowerItemDTO.FixedSalaryAmount = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.CustomerBranchMasterID > 0) ? SaleContractManPowerItemDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                SaleContractManPowerItemDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SaleContractManPowerItemDTO != null ) ? SaleContractManPowerItemDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.CustomerBranchMasterName = value;
            }
        }
        
        [Display(Name = "Customer")]
        [Required(ErrorMessage = "Customer Required")]
        public Int32 CustomerMasterID
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.CustomerMasterID>0) ? SaleContractManPowerItemDTO.CustomerMasterID : new Int32();
            }
            set
            {
                SaleContractManPowerItemDTO.CustomerMasterID = value;
            }
        }
        [Required(ErrorMessage = "Customer Required")]
        [Display(Name = "Customer")]
        public string CustomerMasterName
        {
            get
            {
                return (SaleContractManPowerItemDTO != null ) ? SaleContractManPowerItemDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Billing Display Name")]
        public string BillingDisplayName
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.BillingDisplayName : string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.BillingDisplayName = value;
            }
        }
        
        public Int32 RuleID
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.RuleID : new Int32();
            }
            set
            {
                SaleContractManPowerItemDTO.RuleID = value;
            }
        }

        public string RuleType
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.RuleType : string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.RuleType = value;
            }
        }

        public decimal FixedAmount
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.FixedAmount : new decimal();
            }
            set
            {
                SaleContractManPowerItemDTO.FixedAmount = value;
            }
        }

        public decimal Percentage
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.Percentage : new decimal();
            }
            set
            {
                SaleContractManPowerItemDTO.Percentage = value;
            }
        }
        [Display(Name = "Head")]
        public string HeadName
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.HeadName : string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.HeadName = value;
            }
        }
        [Display(Name = "Head")]
        public byte HeadID
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.HeadID : new byte();
            }
            set
            {
                SaleContractManPowerItemDTO.HeadID = value;
            }
        }
        [Display(Name = "Head Type")]
        public string HeadType
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.HeadType :string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.HeadType = value;
            }
        }
        
        [Display(Name = "Calculate On")]
        public byte CalculateOn
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.CalculateOn : new byte();
            }
            set
            {
                SaleContractManPowerItemDTO.CalculateOn = value;
            }
        }
        [Display(Name = "Is Gender Specific")]
        public bool IsGenderSpecific
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.IsGenderSpecific : false;
            }
            set
            {
                SaleContractManPowerItemDTO.IsGenderSpecific = value;
            }
        }
        [Display(Name = "Gender")]
        public byte Gender
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.Gender : new byte();
            }
            set
            {
                SaleContractManPowerItemDTO.Gender = value;
            }
        }
        [Display(Name = "Range From")]
        public decimal RangeFrom
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.RangeFrom : new decimal();
            }
            set
            {
                SaleContractManPowerItemDTO.RangeFrom = value;
            }
        }
        [Display(Name = "Range Upto")]
        public decimal RangeUpto
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.RangeUpto : new decimal();
            }
            set
            {
                SaleContractManPowerItemDTO.RangeUpto = value;
            }
        }
        [Display(Name = "Contribution Type")]
        public byte ContributionType
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.ContributionType : new byte();
            }
            set
            {
                SaleContractManPowerItemDTO.ContributionType = value;
            }
        }
        public decimal GrossSalaryAmount
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.GrossSalaryAmount : new decimal();
            }
            set
            {
                SaleContractManPowerItemDTO.GrossSalaryAmount = value;
            }
        }
        public decimal NetSalaryAmount
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.NetSalaryAmount : new decimal();
            }
            set
            {
                SaleContractManPowerItemDTO.NetSalaryAmount = value;
            }
        }
        public bool IsApplied
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.IsApplied : false;
            }
            set
            {
                SaleContractManPowerItemDTO.IsApplied = value;
            }
        }
        [Display(Name = "Generate Seperate Invoice")]
        public bool GenerateSeperateInvoice
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.GenerateSeperateInvoice : false;
            }
            set
            {
                SaleContractManPowerItemDTO.GenerateSeperateInvoice = value;
            }
        }
        [Display(Name = "Calculate Arrears")]
        public bool CalculateArrears
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.CalculateArrears : false;
            }
            set
            {
                SaleContractManPowerItemDTO.CalculateArrears = value;
            }
        }
        [Display(Name = "With Effective From Date")]
        public string WithEffectiveFromDate
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.WithEffectiveFromDate : string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.WithEffectiveFromDate = value;
            }
        }
        [Display(Name = "Upto Date")]
        public string WithEffectiveUptoDate
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.WithEffectiveUptoDate : string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.WithEffectiveUptoDate = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.IsDeleted : false;
            }
            set
            {
                SaleContractManPowerItemDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.CreatedBy > 0) ? SaleContractManPowerItemDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractManPowerItemDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractManPowerItemDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.ModifiedBy > 0) ? SaleContractManPowerItemDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractManPowerItemDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.ModifiedDate.HasValue) ? SaleContractManPowerItemDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractManPowerItemDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.DeletedBy > 0) ? SaleContractManPowerItemDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractManPowerItemDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.DeletedDate.HasValue) ? SaleContractManPowerItemDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractManPowerItemDTO.DeletedDate = value;
            }
        }

        public string CalculateOnString
        {
            get
            {
                return (SaleContractManPowerItemDTO != null) ? SaleContractManPowerItemDTO.CalculateOnString : string.Empty;
            }
            set
            {
                SaleContractManPowerItemDTO.CalculateOnString = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLStringManPowerItemRules { get; set; }
        public string XMLStringForCalculateOn { get; set; }
        public decimal CalculateOnFixedAmount
        {
            get
            {
                return (SaleContractManPowerItemDTO != null && SaleContractManPowerItemDTO.CalculateOnFixedAmount > 0) ? SaleContractManPowerItemDTO.CalculateOnFixedAmount : new decimal();
            }
            set
            {
                SaleContractManPowerItemDTO.CalculateOnFixedAmount = value;
            }
        }
    }
}

