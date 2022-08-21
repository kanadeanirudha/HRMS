using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{


    public interface IAccountGeneralLedgerReportViewModel
    {
        AccountGeneralLedgerReport AccountGeneralLedgerReportDTO { get; set; }
        string TransactionDate
        {
            get;
            set;
        }
        string DebitCreditFlag
        {
            get;
            set;
        }
        string ReverseAccount
        {
            get;
            set;
        }
        int PersonID
        {
            get;
            set;
        }
        string ChequeNo
        {
            get;
            set;
        }
        string ChequeDatetime
        {
            get;
            set;
        }
        string ChequeDetails
        {
            get;
            set;
        }
        string VoucherNumber
        {
            get;
            set;
        }
        string TransactionType
        {
            get;
            set;
        }
        string NarrationDescription
        {
            get;
            set;
        }
        string PersonName
        {
            get;
            set;
        }
        int AccountSessionID
        {
            get;
            set;
        }
        string BalanceSheetName
        {
            get;
            set;
        }
        string AccountType
        {
            get;
            set;
        }
        int AccountID
        {
            get;
            set;
        }
        string AccountName
        {
            get;
            set;
        }
        string ReportParameter
        {
            get;
            set;
        }
        string FromDate
        {
            get;
            set;
        }
        string ToDate
        {
            get;
            set;
        }
        string TransactionAmount
        {
            get;
            set;
        }
        decimal DebitAmount
        {
            get;
            set;
        }
        decimal CreditAmount
        {
            get;
            set;
        }
        decimal Balance
        {
            get;
            set;
        }
        Nullable<int> CreatedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> CreatedDate
        {
            get;
            set;
        }
        Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> ModifiedDate
        {
            get;
            set;
        }
        Nullable<int> DeletedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> DeletedDate
        {
            get;
            set;
        }
        Nullable<bool> IsDeleted
        {
            get;
            set;
        }
    }
}
