using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeSalaryRulesViewModel : IEmployeeSalaryRulesViewModel
    {

        public EmployeeSalaryRulesViewModel()
        {
            EmployeeSalaryRulesDTO = new EmployeeSalaryRules();
            EmployeeSalaryRulesList = new List<EmployeeSalaryRules>();
            EmployeeSalaryRulesCalculateOnList = new List<SalaryAllowanceMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGetOrganisationDepartmentCentreAndRoleWise = new List<OrganisationDepartmentMaster>();
            EmployeeSalarySpanList = new List<EmployeeSalarySpan>();
        }

        public List<EmployeeSalaryRules> EmployeeSalaryRulesList { get; set; }
        public List<SalaryAllowanceMaster> EmployeeSalaryRulesCalculateOnList { get; set; }
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
        public EmployeeSalaryRules EmployeeSalaryRulesDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.ID > 0) ? EmployeeSalaryRulesDTO.ID : new int();
            }
            set
            {
                EmployeeSalaryRulesDTO.ID = value;
            }
        }

        [Display(Name = "Item Description")]
       
        public Int32 ItemNumber
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.ItemNumber>0) ? EmployeeSalaryRulesDTO.ItemNumber : new Int32();
            }
            set
            {
                EmployeeSalaryRulesDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Item Description")]
        
        public string ItemDescription
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null ) ? EmployeeSalaryRulesDTO.ItemDescription : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.ItemDescription = value;
            }
        }

        [Display(Name = "Designation")]
        
        public Int16 DesignationMasterID
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.DesignationMasterID > 0) ? EmployeeSalaryRulesDTO.DesignationMasterID : new Int16();
            }
            set
            {
                EmployeeSalaryRulesDTO.DesignationMasterID = value;
            }
        }
        [Display(Name = "Designation")]
        
        public string DesignationMasterName
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null ) ? EmployeeSalaryRulesDTO.DesignationMasterName : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.DesignationMasterName = value;
            }
        }
        
        [Display(Name = "Basic Salay Amount")]
        [Required(ErrorMessage = "Basic Salay Required")]
        public decimal BasicSalayAmount
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.BasicSalayAmount>0) ? EmployeeSalaryRulesDTO.BasicSalayAmount : new decimal();
            }
            set
            {
                EmployeeSalaryRulesDTO.BasicSalayAmount = value;
            }
        }

        [Display(Name = "Total Amount")]
        //[Required(ErrorMessage = "Total Amount Required")]
        public decimal TotalAmount
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.TotalAmount > 0) ? EmployeeSalaryRulesDTO.TotalAmount : new decimal();
            }
            set
            {
                EmployeeSalaryRulesDTO.TotalAmount = value;
            }
        }
        [Display(Name = "Fixed Salary Amount")]
        //[Required(ErrorMessage = "Total Amount Required")]
        public decimal FixedSalaryAmount
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.FixedSalaryAmount > 0) ? EmployeeSalaryRulesDTO.FixedSalaryAmount : new decimal();
            }
            set
            {
                EmployeeSalaryRulesDTO.FixedSalaryAmount = value;
            }
        }
        [Display(Name = "Calculate On Fixed Amount")]
        //[Required(ErrorMessage = "Total Amount Required")]
        public decimal CalculateOnFixedAmount
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.CalculateOnFixedAmount > 0) ? EmployeeSalaryRulesDTO.CalculateOnFixedAmount : new decimal();
            }
            set
            {
                EmployeeSalaryRulesDTO.CalculateOnFixedAmount = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.CustomerBranchMasterID > 0) ? EmployeeSalaryRulesDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                EmployeeSalaryRulesDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null ) ? EmployeeSalaryRulesDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.CustomerBranchMasterName = value;
            }
        }
        
        [Display(Name = "Customer")]
        
        public Int32 CustomerMasterID
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.CustomerMasterID>0) ? EmployeeSalaryRulesDTO.CustomerMasterID : new Int32();
            }
            set
            {
                EmployeeSalaryRulesDTO.CustomerMasterID = value;
            }
        }
        
        [Display(Name = "Customer")]
        public string CustomerMasterName
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null ) ? EmployeeSalaryRulesDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Billing Display Name")]
        public string BillingDisplayName
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.BillingDisplayName : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.BillingDisplayName = value;
            }
        }
        
        public Int32 RuleID
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.RuleID : new Int32();
            }
            set
            {
                EmployeeSalaryRulesDTO.RuleID = value;
            }
        }

        public string RuleType
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.RuleType : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.RuleType = value;
            }
        }

        public decimal FixedAmount
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.FixedAmount : new decimal();
            }
            set
            {
                EmployeeSalaryRulesDTO.FixedAmount = value;
            }
        }

        public decimal Percentage
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.Percentage : new decimal();
            }
            set
            {
                EmployeeSalaryRulesDTO.Percentage = value;
            }
        }
        [Display(Name = "Head")]
        public string HeadName
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.HeadName : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.HeadName = value;
            }
        }
        [Display(Name = "Head")]
        public byte HeadID
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.HeadID : new byte();
            }
            set
            {
                EmployeeSalaryRulesDTO.HeadID = value;
            }
        }
        [Display(Name = "Head Type")]
        public string HeadType
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.HeadType :string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.HeadType = value;
            }
        }
        
        [Display(Name = "Calculate On")]
        public byte CalculateOn
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.CalculateOn : new byte();
            }
            set
            {
                EmployeeSalaryRulesDTO.CalculateOn = value;
            }
        }
        [Display(Name = "Is Gender Specific")]
        public bool IsGenderSpecific
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.IsGenderSpecific : false;
            }
            set
            {
                EmployeeSalaryRulesDTO.IsGenderSpecific = value;
            }
        }
        [Display(Name = "Gender")]
        public byte Gender
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.Gender : new byte();
            }
            set
            {
                EmployeeSalaryRulesDTO.Gender = value;
            }
        }
        [Display(Name = "Range From")]
        public decimal RangeFrom
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.RangeFrom : new decimal();
            }
            set
            {
                EmployeeSalaryRulesDTO.RangeFrom = value;
            }
        }
        [Display(Name = "Range Upto")]
        public decimal RangeUpto
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.RangeUpto : new decimal();
            }
            set
            {
                EmployeeSalaryRulesDTO.RangeUpto = value;
            }
        }
        [Display(Name = "Contribution Type")]
        public byte ContributionType
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.ContributionType : new byte();
            }
            set
            {
                EmployeeSalaryRulesDTO.ContributionType = value;
            }
        }
        public decimal GrossSalaryAmount
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.GrossSalaryAmount : new decimal();
            }
            set
            {
                EmployeeSalaryRulesDTO.GrossSalaryAmount = value;
            }
        }
        public decimal NetSalaryAmount
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.NetSalaryAmount : new decimal();
            }
            set
            {
                EmployeeSalaryRulesDTO.NetSalaryAmount = value;
            }
        }
        public bool IsApplied
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.IsApplied : false;
            }
            set
            {
                EmployeeSalaryRulesDTO.IsApplied = value;
            }
        }
        [Display(Name = "Generate Seperate Invoice")]
        public bool GenerateSeperateInvoice
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.GenerateSeperateInvoice : false;
            }
            set
            {
                EmployeeSalaryRulesDTO.GenerateSeperateInvoice = value;
            }
        }
        [Display(Name = "Calculate Arrears")]
        public bool CalculateArrears
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.CalculateArrears : false;
            }
            set
            {
                EmployeeSalaryRulesDTO.CalculateArrears = value;
            }
        }
        [Display(Name = "With Effective From Date")]
        public string WithEffectiveFromDate
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.WithEffectiveFromDate : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.WithEffectiveFromDate = value;
            }
        }
        [Display(Name = "Upto Date")]
        public string WithEffectiveUptoDate
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.WithEffectiveUptoDate : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.WithEffectiveUptoDate = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.IsDeleted : false;
            }
            set
            {
                EmployeeSalaryRulesDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.CreatedBy > 0) ? EmployeeSalaryRulesDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeSalaryRulesDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeSalaryRulesDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.ModifiedBy > 0) ? EmployeeSalaryRulesDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeSalaryRulesDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.ModifiedDate.HasValue) ? EmployeeSalaryRulesDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeSalaryRulesDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.DeletedBy > 0) ? EmployeeSalaryRulesDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeSalaryRulesDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.DeletedDate.HasValue) ? EmployeeSalaryRulesDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeSalaryRulesDTO.DeletedDate = value;
            }
        }

        public string CalculateOnString
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.CalculateOnString : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.CalculateOnString = value;
            }
        }
        
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedDepartmentID
        {
            get;
            set;
        }
        [Display(Name = "Employee Name")]
        public string EmployeeName
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.EmployeeName : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.EmployeeName = value;
            }
        }
        public string EmployeeCode
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.EmployeeCode : string.Empty;
            }
            set
            {
                EmployeeSalaryRulesDTO.EmployeeCode = value;
            }
        }
        public Int64 EmployeeSalaryRulesID
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.EmployeeSalaryRulesID : new Int64();
            }
            set
            {
                EmployeeSalaryRulesDTO.EmployeeSalaryRulesID = value;
            }
        }
        public Int32 EmployeeMasterID
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null) ? EmployeeSalaryRulesDTO.EmployeeMasterID : new Int32();
            }
            set
            {
                EmployeeSalaryRulesDTO.EmployeeMasterID = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLStringManPowerItemRules { get; set; }
        public string XMLStringForCalculateOn { get; set; }

        [Display(Name = "From Salary Span")]
        public Int32 FromEmployeeSalarySpanID
        {
            get
            {
                return (EmployeeSalaryRulesDTO != null && EmployeeSalaryRulesDTO.FromEmployeeSalarySpanID > 0) ? EmployeeSalaryRulesDTO.FromEmployeeSalarySpanID : new Int32();
            }
            set
            {
                EmployeeSalaryRulesDTO.FromEmployeeSalarySpanID = value;
            }
        }
    }
}

