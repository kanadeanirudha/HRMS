using AMS.Base.DTO;

namespace AMS.DTO
{
    public class InventoryDimensionUnitMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string DimensionCode { get; set; }
        public string DimensionDescription { get; set; }
        public string SIUnit { get; set; }
        public string SIDescription { get; set; }

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
