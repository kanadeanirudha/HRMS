using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class AccountDayBookReportSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string SearchWord { get; set; }
        public string TransactionType { get; set; }
        public int AccountId { get; set; }
        public string PersonType { get; set; }
        public string TransactionTypeCode { get; set; }
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
        public Int16 AccBalsheetMstID { get; set; }
        public int RowLength
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string errorMessage { get; set; }
        public Int16 AccSessionID { get; set; }

        public string SessionFromDate { get; set; }
        public string SessionUptoDate { get; set; }
        public string Pattern { get; set; }
        public string PatternType { get; set; }
        public string AccountIDsXmlString { get; set; }
        public string AccBalsheetIDsXmlString { get; set; }
        public string TransactionTypeXmlString { get; set; }
        public string AccountBalsheetMstIDXmlString { get; set; }
        public string CentreCode { get; set; }
        public string ModeCode { get; set; }
        public bool PageLoaded { get; set; }

    }
}
