using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractManPowerItem : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public Int32 ItemNumber
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get; set;
        }
        public Int16 DesignationMasterID
        {
            get;
            set;
        }
        public string DesignationMasterName
        {
            get; set;
        }
        public decimal BasicSalayAmount
        {
            get; set;
        }

        public decimal TotalAmount
        {
            get;
            set;
        }
        public decimal FixedSalaryAmount
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
            get; set;
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
        public string BillingDisplayName
        {
            get; set;
        }
        public Int32 RuleID
        {
            get; set;
        }
        public string RuleType
        {
            get; set;
        }
        public decimal FixedAmount
        {
            get; set;
        }
        public decimal Percentage
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
        public string HeadType
        {
            get; set;
        }
        public byte CalculateOn
        {
            get; set;
        }
        public string CalculateOnString
        {
            get; set;
        }
        public bool IsGenderSpecific
        {
            get; set;
        }
        public byte Gender
        {
            get; set;
        }
        public decimal RangeFrom
        {
            get; set;
        }
        public decimal RangeUpto
        {
            get; set;
        }
        public byte ContributionType
        {
            get; set;
        }
        public decimal GrossSalaryAmount
        {
            get; set;
        }
        public decimal NetSalaryAmount
        {
            get; set;
        }
        public byte AllowanceOrDeduction
        {
            get; set;
        }
        public bool IsApplied
        {
            get; set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public decimal CalculatedAmount
        {
            get; set;
        }
        public bool GenerateSeperateInvoice
        {
            get;
            set;
        }
        public bool CalculateArrears
        {
            get; set;
        }
        public string WithEffectiveFromDate
        {
            get; set;
        }
        public string WithEffectiveUptoDate
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
        public string XMLStringManPowerItemRules { get; set; }
        public string XMLStringForCalculateOn { get; set; }
        public Int32 AdminRoleID { get; set; }
        public decimal CalculateOnFixedAmount { get; set; }
    }
}
