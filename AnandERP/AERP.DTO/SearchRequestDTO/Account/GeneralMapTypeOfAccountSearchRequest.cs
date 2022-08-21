using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralMapTypeOfAccountSearchRequest : Request
    {
        public Int32 ID { get; set; }
        public Int16 GeneralTypeOfAccountId { get; set; }
        public string MenuCode { get; set; }
        public Int16 DebitCreditStatus { get; set; }
        public string ControlName { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
        public string ModuleCode
        {
            get;
            set;
        }
    }
}
