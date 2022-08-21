using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralCountryMaster : BaseDTO
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string ContryCode { get; set; }
        public bool DefaultFlag { get; set; }
        public Nullable<int> SeqNo { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public bool IsUserDefined { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
       // public int ErrorCode { get; set; }
    }
}
