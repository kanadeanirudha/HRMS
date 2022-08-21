
using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralTypeOfAccount : BaseDTO
    {
        public Int16 ID { get; set; }
        public Int16 GeneralTypeOfAccountID { get; set; }
        public string Name { get; set; }
        public string DisplayFor { get; set; }
        public bool IsActive { get; set; }
        public Int32 CreatedBy { get; set; }
        public string CreatedDate { get; set;}
        public Int32 ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public string DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string errorMessage { get; set; }

        //General Type Of Account Map With Account
        public Int32 GeneralTypeOfAccountMapWithAccountID { get; set; }
        public Int16 GeneralTypeOfAccountId { get; set; }
        public string AccountCode { get; set; }
        public Int16 AccountMasterId { get; set; }
        public string AccountName { get; set; }
    }
}
