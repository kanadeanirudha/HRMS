using AMS.Base.DTO;

namespace AMS.DTO
{
    public class SalePromotionActivityMasterAndDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int SalePromotionActivityDetailsID
        {
            get;
            set;
        }
        public int SalePromotionActivityMasterID
        {
            get;
            set;
        }
        public string PlanTypeCode
        {
            get;
            set;
        }
        public string SearchWord
        {
            get;
            set;
        }
        public int GeneralUnitsID
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
        public string CentreCode
        {
            get;
            set;
        }
    }
}
