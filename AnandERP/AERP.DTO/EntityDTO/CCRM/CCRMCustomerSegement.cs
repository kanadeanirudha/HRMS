using System;
using AERP.Base.DTO;

namespace AERP.DTO
{
   public class CCRMCustomerSegement:BaseDTO
    {
        public byte ID { get; set; }
       
        public string SegementName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
       
    }
}
