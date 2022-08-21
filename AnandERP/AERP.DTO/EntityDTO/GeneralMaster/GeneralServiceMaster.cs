using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralServiceMaster : BaseDTO
    {
        public Int16 ID { get; set; }
        public string ServiceName { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public bool IsUserDefined { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public bool StatusFlag { get; set; }
        // public int ErrorCode { get; set; }
    }
}
