using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class AccountGeneralLedgerReportSearchRequest : Request
    {
        public decimal DebitAmount
        {
            get;
            set;
        }
        public decimal CreditAmount
        {
            get;
            set;
        }
        public decimal Balance
        {
            get;
            set;
        }
        public string AccountType
        {
            get;
            set;
        }
        public int AccountID
        {
            get;
            set;
        }
        public string AccountName
        {
            get;
            set;
        }
        public string PersonTypeName
        {
            get;
            set;
        }
        public string ReportParameter
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string ToDate
        {
            get;
            set;
        }
        public decimal TransactionAmount
        {
            get;
            set;
        }
        public string TransactionDate
        {
            get;
            set;
        }
        public string DebitCreditFlag
        {
            get;
            set;
        }
        public string ReverseAccount
        {
            get;
            set;
        }
        public int PersonID
        {
            get;
            set;
        }
        public string ChequeNo
        {
            get;
            set;
        }
        public string ChequeDatetime
        {
            get;
            set;
        }
        public string ChequeDetails
        {
            get;
            set;
        }
        public string VoucherNumber
        {
            get;
            set;
        }
        public string TransactionType
        {
            get;
            set;
        }
        public string NarrationDescription
        {
            get;
            set;
        }
        public string PersonName
        {
            get;
            set;
        }
        public string PersonType
        {
            get;
            set;
        }
        public int AccountSessionID
        {
            get;
            set;
        }
        public string BalanceSheetName
        {
            get;
            set;
        }
        public int AccBalsheetMstID { get; set; }
        public string SessionFromDate { get; set; }
        public string SessionUptoDate { get; set; }
        public string CentreCode { get; set; }
        public string ConsolidiateType { get; set; }
      
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
