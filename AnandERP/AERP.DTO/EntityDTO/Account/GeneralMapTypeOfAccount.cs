using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralMapTypeOfAccount : BaseDTO
    {
        public Int32 ID { get; set; }
        public Int16 GeneralTypeOfAccountId { get; set; }
        public string MenuCode { get; set; }
        public string ModuleName { get; set; }
        public string AccName { get; set; }
        public string MenuName { get; set; }
        public string XMLstring { get; set; }
        public byte DebitCreditStatus { get; set; }
        public string ControlName { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string errorMessage { get; set; }
        public int UserMainMenuMasterID { get; set; }
    }
}
