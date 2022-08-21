using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralPeriodTypeMaster : BaseDTO
    {
        public int GeneralPeriodTypeMasterID { get; set; }
        public string PeriodType { get; set; }
        public Int16 NumberOfDays { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
