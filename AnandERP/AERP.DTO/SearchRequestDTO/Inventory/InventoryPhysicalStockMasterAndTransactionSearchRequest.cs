using AMS.Base.DTO;

namespace AMS.DTO
{
    public class InventoryPhysicalStockMasterAndTransactionSearchRequest : Request
    {
        public int Id
        {
            get;
            set;
        }
        public int InventoryPhysicalStockMasterId
        {
            get;
            set;
        }
        public int InventoryPhysicalStockTransactionId
        {
            get;
            set;
        }
        public int InventoryLocationMasterID
        {
            get;
            set;
        }
        public int Balancesheet
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
    }
}
