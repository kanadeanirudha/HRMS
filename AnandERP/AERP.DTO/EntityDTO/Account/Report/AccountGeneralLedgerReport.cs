using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class AccountGeneralLedgerReport : BaseDTO
    {
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
        public string ConsolidiateType { get; set; }
        public string VoucherNoWithTranType { get; set; }
        public int PersonID
        {
            get;
            set;
        }
        public int AccountBalsheetMstID
        {
            get;
            set;
        }
        public int IndividualAccountID
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
        public string PersonCode
        {
            get;
            set;
        }
        public string PersonName
        {
            get;
            set;
        }
        public string StudentName
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
        public int IndividualOpeningBalanceID
        {
            get;
            set;
        }
        public string BalanceSheetName
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
        public bool IsPosted { get; set; }
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
        public string TransactionAmount
        {
            get;
            set;
        }
        public decimal DebitAmount
        {
            get;
            set;
        }
        public decimal OpendingBalanceCredit
        {
            get;
            set;
        }
        public decimal OpendingBalanceDebit
        {
            get;
            set;
        }
        public decimal TotalDebitTransactionAmount
        {
            get;
            set;
        }
        public decimal TotalCreditTransactionAmount
        {
            get;
            set;
        }
        public decimal CloseingBalance
        {
            get;
            set;
        }
        public decimal CreditAmount
        {
            get;
            set;
        }
        public decimal OpeningBalance
        {
            get;
            set;
        }
        public decimal Balance
        {
            get;
            set;
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
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public decimal DebitTransactionAmount { get; set; }
        public decimal CreditTransactionAmount { get; set; }
        public decimal RunningTotal { get; set; }
        public string ControlHead { get; set; }
    }
}

