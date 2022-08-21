using AMS.Base.DTO;
namespace AMS.DTO
{
    public class PurchaseReportSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int PurchaseRequisitionDetailsID
        {
            get;
            set;
        }
        public int VendorID
        {
            get;
            set;
        }
        public int PurchaseRequisitionType
        {
            get;
            set;
        }
        public int PurchaseRequisitionBy
        {
            get;
            set;
        }
        public string TransDate
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
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
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
        public string SearchWord
        {
            get;
            set;
        }
        public string ScopeIdentity
        {
            get;
            set;
        }
        public int PersonID { get; set; }
        public int TaskNotificationMasterID { get; set; }
    }
}
