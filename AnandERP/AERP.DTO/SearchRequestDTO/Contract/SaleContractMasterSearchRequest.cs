using AERP.Base.DTO;

namespace AERP.DTO
{
    public class SaleContractMasterSearchRequest : Request
    {
        public long ID
        {
            get;
            set;
        }
        public int CustomerMasterID
        {
            get;set;
        }
        public int CustomerBranchMasterID
        {
            get; set;
        }
        public string SearchWord
        {
            get;set;
        }
        public long SaleContractTermDetailsID
        {
            get;set;
        }
        public long SaleContractOvertimeID
        {
            get;set;
        }
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
        public int AdminRoleID { get; set; }
    }
}
