using AMS.Base.DTO;

namespace AMS.DTO
{
    public class GeneralPackingTypeInfoSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int ItemCodeID
        {
            get;
            set;
        }
        public int PackageTypeID
        {
            get;
            set;
        }
        public int UomCodeId
        {
            get;
            set;
        }
        public string PackageType
        {
            get;
            set;
        }
        public string UomCode { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }

        public decimal QuantityPerPackage { get; set; }

        public int ItemNumber
        {
            get;
            set;
        }
        public string ItemDescription
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
    }
}
