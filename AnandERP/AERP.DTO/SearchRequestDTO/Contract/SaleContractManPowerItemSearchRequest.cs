using AERP.Base.DTO;

namespace AERP.DTO
{
    public class SaleContractManPowerItemSearchRequest : Request
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
        public int CustomerMasterID
        {
            get; set;
        }
        public int CustomerBranchMasterID
        {
            get; set;
        }
        public int AdminRoleID
        { get; set; }
        public bool IsActive
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
    }
}
