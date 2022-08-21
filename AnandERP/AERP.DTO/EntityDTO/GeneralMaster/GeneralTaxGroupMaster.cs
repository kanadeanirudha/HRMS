using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralTaxGroupMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public string TaxGroupName
        {
            get;
            set;
        }
        public string SelectedTaxMaterIDs
        {
            get;
            set;
        }
        
        public int TaxMasterID
        {
            get;
            set;
        }
        public String TaxName
        { get; set; }

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
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
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

        public bool TaxFlag
        {
            get;
            set;

        }
        public decimal TaxAmount
        {
            get;set;
        }
        public decimal TaxRate
        {
            get;set;
        }
        public string TaxAmountList
        {
            get; set;
        }
        public string TaxRateList
        {
            get; set;
        }
        public string TaxList
        {
            get;set;
        }
        public string TaxableAmountList
        {
            get;set;
        }
    }
}
