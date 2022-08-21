using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SalaryAllowanceMaster : BaseDTO
    {
        public byte ID
        {
            get;
            set;
        }

        public string AllowanceHeadName
        {
            get;
            set;
        }

        public string AllowanceType
        {
            get;
            set;
        }
        public string AllowanceSubType
        {
            get; set;
        }
        public byte ComplianceType
        {
            get; set;
        }
        public byte SalaryAllowanceRulesID
        {
            get; set;
        }

        public byte SalaryPayRulesID
        {
            get;
            set;
        }

        public bool IsGenderSpecific
        {
            get;
            set;
        }

        public byte Gender
        {
            get;
            set;
        }

        public decimal FixedAmount
        {
            get;
            set;
        }
        public decimal CalculateOnFixedAmount
        {
            get;
            set;
        }
        public double Percentage
        {
            get; set;
        }
        public byte CalculateOn
        {
            get; set;
        }

        public bool IsCurrent
        {
            get; set;
        }
        public Int16 MapAccountID
        {
            get; set;
        }
        public string MapAccountName
        {
            get; set;
        }
        public string EffectedDate
        {
            get; set;
        }
        public string CloseDate
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
        public Int16 SalaryAllowanceSumOfID
        {
            get; set;
        }
        public byte AllowanceOrDeduction
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
        public string SelectedStatusFlag
        {
            get; set;
        }
        public bool IsActive
        {
            get;
            set;
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
        public string XMLStringForCalculateOn { get; set; }
    }
}
