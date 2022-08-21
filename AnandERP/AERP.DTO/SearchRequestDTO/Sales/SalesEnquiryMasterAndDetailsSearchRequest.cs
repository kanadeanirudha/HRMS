using AERP.Base.DTO;

namespace AERP.DTO
{
    public class SalesEnquiryMasterAndDetailsSearchRequest : Request
    {
        public int SalesEnquiryMasterAndDetailsID
        {
            get;
            set;
        }
        public int CustomerBranchMasterID
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public byte CustomerType
        {
            get;
            set;
        }
        public string SearchWord
        {
            get; set;
        }
        public string SalesEnquiryMasterAndDetailsName
        {
            get; set;
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
        public string TransactionDate
        {
            get;
            set;
        }
    }
}
