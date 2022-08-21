using System;
using AERP.Base.DTO;

namespace AERP.DTO
{
   public class CCRMCallApprovalMaster:BaseDTO
    {
        public Int32 ID { get; set; }

        public string CallTktNo { get; set; }
        public string CallDate { get; set; }
        public string SerialNo { get; set; }
        public string ModelNo { get; set; }
        public string CallType { get; set; }
        public string MIFName { get; set; }
        public decimal CallCharges { get; set; }
        public bool NotApproved { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public Int32 CallTypeID { get; set; }
        public bool CustApproval { get; set; }
        public string CallTypeName { get; set; }
        public string ItemDescription { get; set; }
    }
}
