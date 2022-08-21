using AERP.Base.DTO;

namespace AERP.DTO
{
    public class InventoryLocationMasterSearchRequest : Request
    {
        public int ID { get; set; }
        public string CentreCode { get; set; }
        public int AdminRoleID { get; set; }
        public int AccBalanceSheetID { get; set; }
        public int IssueFromLocationID { get; set; }
        public string LocationName { get; set; }
        public string SearchWord
        {
            get;
            set;
        }
        
        
        public bool IsDeleted
        {
            get;
            set;
        }

        public string SortOrder
        {
            get;
            set;
        }

        public string SortBy
        {
            get;
            set;
        }

        public int StartRow
        {
            get;
            set;
        }

        public int EndRow
        {
            get;
            set;
        }

        public int RowLength
        {
            get;
            set;
        }
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
        public int GeneralUnitsID { get; set; }
        public int UserID { get; set; }
    }
}
