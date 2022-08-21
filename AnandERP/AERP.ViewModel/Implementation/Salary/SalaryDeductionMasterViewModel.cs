using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SalaryDeductionMasterViewModel : ISalaryDeductionMasterViewModel
    {

        public SalaryDeductionMasterViewModel()
        {
            SalaryDeductionMasterDTO = new SalaryDeductionMaster();
            CalculateOnListForRules = new List<SalaryDeductionMaster>();
        }

        public List<SalaryDeductionMaster> CalculateOnListForRules { get; set; }

        public SalaryDeductionMaster SalaryDeductionMasterDTO
        {
            get;
            set;
        }

        public byte ID
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.ID > 0) ? SalaryDeductionMasterDTO.ID : new byte();
            }
            set
            {
                SalaryDeductionMasterDTO.ID = value;
            }
        }

        [Display(Name = "Deduction Head Name")]
        [Required(ErrorMessage = "Deduction Head Name Required")]
        public string DeductionHeadName
        {
            get
            {
                return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.DeductionHeadName : string.Empty;
            }
            set
            {
                SalaryDeductionMasterDTO.DeductionHeadName = value;
            }
        }

        [Display(Name = "Deduction Type")]
        [Required(ErrorMessage = "Deduction Type Required")]
        public string DeductionType
        {
            get
            {
                return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.DeductionType : string.Empty;
            }
            set
            {
                SalaryDeductionMasterDTO.DeductionType = value;
            }
        }
        [Display(Name = "Deduction Sub Type")]
        public string DeductionSubType
        {
            get
            {
                return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.DeductionSubType : string.Empty;
            }
            set
            {
                SalaryDeductionMasterDTO.DeductionSubType = value;
            }
        }
        [Display(Name = "Compliance Type")]
        public byte ComplianceType
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.ComplianceType > 0) ? SalaryDeductionMasterDTO.ComplianceType : new byte();
            }
            set
            {
                SalaryDeductionMasterDTO.ComplianceType = value;
            }
        }
        
        [Display(Name = "Salary Deduction Rules ID")]
        public byte SalaryDeductionRulesID
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.SalaryDeductionRulesID > 0) ? SalaryDeductionMasterDTO.SalaryDeductionRulesID : new byte();
            }
            set
            {
                SalaryDeductionMasterDTO.SalaryDeductionRulesID = value;
            }
        }

        [Display(Name = "Salary Pay Rule")]
        public byte SalaryPayRulesID
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.SalaryPayRulesID > 0) ? SalaryDeductionMasterDTO.SalaryPayRulesID : new byte();
            }
            set
            {
                SalaryDeductionMasterDTO.SalaryPayRulesID = value;
            }
        }
        [Display(Name = "Is Gender Specific")]
        public bool IsGenderSpecific
        {
            get
            {
                return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.IsGenderSpecific : false;
            }
            set
            {
                SalaryDeductionMasterDTO.IsGenderSpecific = value;
            }
        }
        [Display(Name = "Gender")]
        public byte Gender
        {
            get
            {
                return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.Gender : new byte();
            }
            set
            {
                SalaryDeductionMasterDTO.Gender = value;
            }
        }
        [Display(Name = "Fixed Amount")]
        public decimal FixedAmount
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.FixedAmount > 0) ? SalaryDeductionMasterDTO.FixedAmount : new decimal();
            }
            set
            {
                SalaryDeductionMasterDTO.FixedAmount = value;
            }
        }

        [Display(Name = "Calculate On Fixed Amount")]
        public decimal CalculateOnFixedAmount
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.CalculateOnFixedAmount > 0) ? SalaryDeductionMasterDTO.CalculateOnFixedAmount : new decimal();
            }
            set
            {
                SalaryDeductionMasterDTO.CalculateOnFixedAmount = value;
            }
        }

        [Display(Name = "Percentage")]
        public double Percentage
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.Percentage > 0) ? SalaryDeductionMasterDTO.Percentage : new double();
            }
            set
            {
                SalaryDeductionMasterDTO.Percentage = value;
            }
        }
        [Display(Name = "Calculate On")]
        public byte CalculateOn
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.CalculateOn > 0) ? SalaryDeductionMasterDTO.CalculateOn : new byte();
            }
            set
            {
                SalaryDeductionMasterDTO.CalculateOn = value;
            }
        }
        [Display(Name = "Is Current")]
        public bool IsCurrent
        {
            get
            {
                return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.IsCurrent : false;
            }
            set
            {
                SalaryDeductionMasterDTO.IsCurrent = value;
            }
        }
        [Display(Name = "Location")]
        public Int16 MapAccountID
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.MapAccountID > 0) ? SalaryDeductionMasterDTO.MapAccountID : new Int16();
            }
            set
            {
                SalaryDeductionMasterDTO.MapAccountID = value;
            }
        }
        [Display(Name = "Effected Date")]
        public string EffectedDate
        {
            get
            {
                return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.EffectedDate : string.Empty;
            }
            set
            {
                SalaryDeductionMasterDTO.EffectedDate = value;
            }
        }
        [Display(Name = "Close Date")]
        public string CloseDate
        {
            get
            {
                return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.CloseDate : string.Empty;
            }
            set
            {
                SalaryDeductionMasterDTO.CloseDate = value;
            }
        }
        [Display(Name = "Contribution Type")]
        public byte ContributionType
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.ContributionType > 0) ? SalaryDeductionMasterDTO.ContributionType : new byte();
            }
            set
            {
                SalaryDeductionMasterDTO.ContributionType = value;
            }
        }
        [Display(Name = "Range From")]
        public decimal RangeFrom
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.RangeFrom > 0) ? SalaryDeductionMasterDTO.RangeFrom : new decimal();
            }
            set
            {
                SalaryDeductionMasterDTO.RangeFrom = value;
            }
        }
        [Display(Name = "Range Upto")]
        public decimal RangeUpto
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.RangeUpto > 0) ? SalaryDeductionMasterDTO.RangeUpto : new decimal();
            }
            set
            {
                SalaryDeductionMasterDTO.RangeUpto = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.IsDeleted : false;
            }
            set
            {
                SalaryDeductionMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.CreatedBy > 0) ? SalaryDeductionMasterDTO.CreatedBy : new int();
            }
            set
            {
                SalaryDeductionMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalaryDeductionMasterDTO != null) ? SalaryDeductionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalaryDeductionMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.ModifiedBy > 0) ? SalaryDeductionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                SalaryDeductionMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.ModifiedDate.HasValue) ? SalaryDeductionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalaryDeductionMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.DeletedBy > 0) ? SalaryDeductionMasterDTO.DeletedBy : new int();
            }
            set
            {
                SalaryDeductionMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SalaryDeductionMasterDTO != null && SalaryDeductionMasterDTO.DeletedDate.HasValue) ? SalaryDeductionMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SalaryDeductionMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        public string XMLStringForCalculateOn { get; set; }
    }
}

