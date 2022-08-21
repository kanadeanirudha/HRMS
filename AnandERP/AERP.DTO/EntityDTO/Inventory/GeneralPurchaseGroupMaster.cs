using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class GeneralPurchaseGroupMaster : BaseDTO
    {
        /// Properties for GeneralPurchaseGroupMaster table
        public Int16 ID { get; set; }
        public string PurchaseGroupName { get; set; }
        public string PurchaseGroupCode { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
