using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralTaxMaster : BaseDTO
    {
        public int ID { get; set; }
        public string TaxName { get; set; }
        public decimal TaxRate { get; set; }
        //public bool DefaultFlag { get; set; }
        //public Nullable<int> SeqNo { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public bool IsCompoundTax { get; set; }
        public Nullable<int> CreatedBy { get; set; } 
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public bool TaxFlag
        {
            get;
            set;

        }
        public bool IsOtherState { get; set; }
        // public int ErrorCode { get; set; }
    }
}
