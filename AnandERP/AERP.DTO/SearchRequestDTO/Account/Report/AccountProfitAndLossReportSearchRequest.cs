using AERP.Base.DTO;

namespace AERP.DTO
{
    public class AccountProfitAndLossReportSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }


        public string SessionUptoDate
        {
            get;
            set;
        }
        public string SessionFromDate
        {
            get;
            set;
        }
        public int AccountId
        {
            get;
            set;
        }
        public int AccountSessionID
        {
            get;
            set;
        }
        public int AccBalsheetMstId
        {
            get;
            set;
        }
        public string AccBalsheetName { get; set; }
        public string CentreCode
        {
            get;
            set;
        }
        public string ProfitLossFlag
        {
            get;
            set;
        }
        public bool IsZeroBalance
        {
            get;
            set;
        }
        public string GroupBy
        {
            get;
            set;
        }
        public bool IsSubLedger
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
    }
}
