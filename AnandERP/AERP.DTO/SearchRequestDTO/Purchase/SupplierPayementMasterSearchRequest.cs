using AERP.Base.DTO;
namespace AERP.DTO
{
    public class SupplierPayementMasterSearchRequest : Request
    {
        public string CentreCode
        {
            get;
            set;
        }
        public int VendorId
        {
            get;
            set;
        }
        public int ID
        {
            get;
            set;
        }
        public int VendorNumber
        {
            get;
            set;
        }
        public string TransactionDate
        {
            get;
            set;
        }
        public string vendor
        {
            get;
            set;
        }
        public string SearchWord
        {
            get;
            set;
        }
        public string SearchFor
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
        public string UnitCode
        {
            get;
            set;
        }
    }
}
