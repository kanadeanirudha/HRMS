using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralUnitType : BaseDTO
    {
        public int ID { get; set; }
        public string UnitType { get; set; }
        public Int16 RelatedWith { get; set; }
       public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string errorMessage { get; set; }
        // public int ErrorCode { get; set; }
    }
}