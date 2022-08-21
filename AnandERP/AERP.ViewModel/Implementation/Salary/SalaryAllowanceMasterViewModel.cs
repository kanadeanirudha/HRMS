using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SalaryAllowanceMasterViewModel : ISalaryAllowanceMasterViewModel
    {

        public SalaryAllowanceMasterViewModel()
        {
            SalaryAllowanceMasterDTO = new SalaryAllowanceMaster();
            CalculateOnListForRules = new List<SalaryAllowanceMaster>();
        }

        public List<SalaryAllowanceMaster> CalculateOnListForRules { get; set; }

        public SalaryAllowanceMaster SalaryAllowanceMasterDTO
        {
            get;
            set;
        }

        public byte ID
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.ID > 0) ? SalaryAllowanceMasterDTO.ID : new byte();
            }
            set
            {
                SalaryAllowanceMasterDTO.ID = value;
            }
        }

        [Display(Name = "Allowance Head Name")]
        [Required(ErrorMessage = "Allowance Head Name Required")]
        public string AllowanceHeadName
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.AllowanceHeadName : string.Empty;
            }
            set
            {
                SalaryAllowanceMasterDTO.AllowanceHeadName = value;
            }
        }

        [Display(Name = "Allowance Type")]
        [Required(ErrorMessage = "Allowance Type Required")]
        public string AllowanceType
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null ) ? SalaryAllowanceMasterDTO.AllowanceType: string.Empty;
            }
            set
            {
                SalaryAllowanceMasterDTO.AllowanceType = value;
            }
        }
        [Display(Name = "Allowance Sub Type")]
        public string AllowanceSubType
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.AllowanceSubType : string.Empty;
            }
            set
            {
                SalaryAllowanceMasterDTO.AllowanceSubType = value;
            }
        }
        [Display(Name = "Compliance Type")]
        public byte ComplianceType
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.ComplianceType > 0) ? SalaryAllowanceMasterDTO.ComplianceType : new byte();
            }
            set
            {
                SalaryAllowanceMasterDTO.ComplianceType = value;
            }
        }
        [Display(Name = "Salary Allowance Rules ID")]
        public byte SalaryAllowanceRulesID
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.SalaryAllowanceRulesID > 0) ? SalaryAllowanceMasterDTO.SalaryAllowanceRulesID : new byte();
            }
            set
            {
                SalaryAllowanceMasterDTO.SalaryAllowanceRulesID = value;
            }
        }

        [Display(Name = "Salary Pay Rule")]
        public byte SalaryPayRulesID
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.SalaryPayRulesID > 0) ? SalaryAllowanceMasterDTO.SalaryPayRulesID : new byte();
            }
            set
            {
                SalaryAllowanceMasterDTO.SalaryPayRulesID = value;
            }
        }
        [Display(Name = "Is Gender Specific")]
        public bool IsGenderSpecific
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.IsGenderSpecific : false;
            }
            set
            {
                SalaryAllowanceMasterDTO.IsGenderSpecific = value;
            }
        }
        [Display(Name = "Gender")]
        public byte Gender
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.Gender : new byte();
            }
            set
            {
                SalaryAllowanceMasterDTO.Gender = value;
            }
        }
        [Display(Name = "Fixed Amount")]
        public decimal FixedAmount
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.FixedAmount > 0) ? SalaryAllowanceMasterDTO.FixedAmount : new decimal();
            }
            set
            {
                SalaryAllowanceMasterDTO.FixedAmount = value;
            }
        }

        [Display(Name = "Calculate On Fixed Amount")]
        public decimal CalculateOnFixedAmount
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.CalculateOnFixedAmount > 0) ? SalaryAllowanceMasterDTO.CalculateOnFixedAmount : new decimal();
            }
            set
            {
                SalaryAllowanceMasterDTO.CalculateOnFixedAmount = value;
            }
        }
        [Display(Name = "Percentage")]
        public double Percentage
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.Percentage > 0) ? SalaryAllowanceMasterDTO.Percentage : new double();
            }
            set
            {
                SalaryAllowanceMasterDTO.Percentage = value;
            }
        }
        [Display(Name = "Calculate On")]
        public byte CalculateOn
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.CalculateOn>0) ? SalaryAllowanceMasterDTO.CalculateOn : new byte();
            }
            set
            {
                SalaryAllowanceMasterDTO.CalculateOn = value;
            }
        }
        [Display(Name = "Is Current")]
        public bool IsCurrent
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.IsCurrent : false;
            }
            set
            {
                SalaryAllowanceMasterDTO.IsCurrent = value;
            }
        }
        [Display(Name = "Map Account")]
        public Int16 MapAccountID
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.MapAccountID > 0) ? SalaryAllowanceMasterDTO.MapAccountID : new Int16();
            }
            set
            {
                SalaryAllowanceMasterDTO.MapAccountID = value;
            }
        }
        [Display(Name = "Map Account")]
        public string MapAccountName
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.MapAccountName : string.Empty;
            }
            set
            {
                SalaryAllowanceMasterDTO.MapAccountName = value;
            }
        }
        
        [Display(Name = "Effected Date")]
        public string EffectedDate
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.EffectedDate : string.Empty;
            }
            set
            {
                SalaryAllowanceMasterDTO.EffectedDate = value;
            }
        }
        [Display(Name = "Close Date")]
        public string CloseDate
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.CloseDate : string.Empty;
            }
            set
            {
                SalaryAllowanceMasterDTO.CloseDate = value;
            }
        }
        [Display(Name = "Range From")]
        public decimal RangeFrom
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.RangeFrom > 0) ? SalaryAllowanceMasterDTO.RangeFrom : new decimal();
            }
            set
            {
                SalaryAllowanceMasterDTO.RangeFrom = value;
            }
        }
        [Display(Name = "Range Upto")]
        public decimal RangeUpto
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.RangeUpto > 0) ? SalaryAllowanceMasterDTO.RangeUpto : new decimal();
            }
            set
            {
                SalaryAllowanceMasterDTO.RangeUpto = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.IsDeleted : false;
            }
            set
            {
                SalaryAllowanceMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.CreatedBy > 0) ? SalaryAllowanceMasterDTO.CreatedBy : new int();
            }
            set
            {
                SalaryAllowanceMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null) ? SalaryAllowanceMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalaryAllowanceMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.ModifiedBy > 0) ? SalaryAllowanceMasterDTO.ModifiedBy : new int();
            }
            set
            {
                SalaryAllowanceMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.ModifiedDate.HasValue) ? SalaryAllowanceMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalaryAllowanceMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.DeletedBy > 0) ? SalaryAllowanceMasterDTO.DeletedBy : new int();
            }
            set
            {
                SalaryAllowanceMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SalaryAllowanceMasterDTO != null && SalaryAllowanceMasterDTO.DeletedDate.HasValue) ? SalaryAllowanceMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SalaryAllowanceMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLStringForCalculateOn { get; set; }
    }
}

