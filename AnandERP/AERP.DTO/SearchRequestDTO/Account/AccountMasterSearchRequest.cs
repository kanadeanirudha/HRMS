using AERP.Base.DTO;

namespace AERP.DTO
{
    public class AccountMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int GroupID
        {
            get;
            set;
        }
        public string SearchWord
        {
            get; set;
        }
        public bool IsActive
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
        public string CashBankFlag
        {
            get;
            set;
        }
        public string PersonType
        {
            get;
            set;
        }
        public int BalancesheetID
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }

    public class AccountTreeViewSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
    }

}
