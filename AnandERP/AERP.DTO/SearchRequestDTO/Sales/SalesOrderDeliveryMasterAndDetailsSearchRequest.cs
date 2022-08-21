using AERP.Base.DTO;

namespace AERP.DTO
{
    public class SalesOrderDeliveryMasterAndDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string SearchWord
        {
            get; set;
        }
        public long SaleContractMasterID
        {
            get; set;
        }
        public long SaleContractBillingSpanID
        {
            get; set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int SalesOrderMasterID
        { get; set; }
        public byte SOStatus
        { get; set; }
        public int AdminRoleID
        { get; set; }

        public int CustomerMasterID
        { get; set; }

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
        public string MonthName
        {
            get;
            set;
        }
        public string MonthYear{
            get;
            set;
        }
}
}
