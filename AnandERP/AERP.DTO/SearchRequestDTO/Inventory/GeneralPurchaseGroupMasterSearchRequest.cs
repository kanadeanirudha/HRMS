using AERP.Base.DTO;

namespace AERP.DTO
{
    public class GeneralPurchaseGroupMasterSearchRequest : Request
    {
        public int ID { get; set; }
        public string PurchaseGroupName { get; set; }
        public string PurchaseGroupCode { get; set; }
        public bool IsDeleted { get; set; }
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public int RowLength { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
