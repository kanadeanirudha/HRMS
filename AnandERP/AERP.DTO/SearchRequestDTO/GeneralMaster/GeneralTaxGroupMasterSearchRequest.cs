using AERP.Base.DTO;

namespace AERP.DTO
{
    public class GeneralTaxGroupMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int TaxMasterID
        {
            get;
            set;
        }
        public string TaxName
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
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public bool IsOtherState { get; set; }
        public int FromMasterID { get; set; }
        public string FromDetailTable { get; set; }
    }
}
