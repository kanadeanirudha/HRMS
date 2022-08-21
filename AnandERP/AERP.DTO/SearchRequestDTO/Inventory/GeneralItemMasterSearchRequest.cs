using AERP.Base.DTO;

namespace AERP.DTO
{
    public class GeneralItemMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int PurchaseRequisitionType
        {
            get;
            set;
        }
        public string TaskCode
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
        public string SearchWord
        {
            get;
            set;
        }
        public string SearchWord1
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public int GeneralVendorID
        {
            get;
            set;
        }
        public string CentreListXML
        {
            get;
            set;
        }
        public string ModelNo
        {
            get;
            set;
        }
    }
}

