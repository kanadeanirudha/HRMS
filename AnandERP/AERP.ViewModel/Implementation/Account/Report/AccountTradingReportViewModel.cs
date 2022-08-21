using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AccountTradingReportViewModel : IAccountTradingReportViewModel
    {

        public AccountTradingReportViewModel()
        {
            AccountTradingReportDTO = new AccountTradingReport();
            ListAccountSessionMasterReport = new List<AccountSessionMaster>();
        }


        public List<AccountSessionMaster> ListAccountSessionMasterReport { get; set; }

        public IEnumerable<SelectListItem> AccountSessionMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountSessionMasterReport, "ID", "SessionName");
            }
        }

        public AccountTradingReport AccountTradingReportDTO { get; set; }


        public int ID
        {
            get
            {
                return (AccountTradingReportDTO != null && AccountTradingReportDTO.ID > 0) ? AccountTradingReportDTO.ID : new int();
            }
            set
            {
                AccountTradingReportDTO.ID = value;
            }
        }

        [Display(Name = "Session UpTo Date :")]
        public string SessionUptoDate
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.SessionUptoDate : string.Empty; }
            set { AccountTradingReportDTO.SessionUptoDate = value; }
        }
        [Display(Name = "Session From Date :")]
        public string SessionFromDate
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.SessionFromDate : string.Empty; }
            set { AccountTradingReportDTO.SessionFromDate = value; }
        }



        [Display(Name = "Account Session :")]
        public int AccountSessionID
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.AccountSessionID : new int(); }
            set { AccountTradingReportDTO.AccountSessionID = value; }
        }
        public int AccBalsheetMstId
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.AccBalsheetMstId : new int(); }
            set { AccountTradingReportDTO.AccBalsheetMstId = value; }
        }
        public string AccBalsheetName
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.AccBalsheetName : string.Empty; }
            set { AccountTradingReportDTO.AccBalsheetName = value; }
        }
        public string CentreCode
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.CentreCode : string.Empty; }
            set { AccountTradingReportDTO.CentreCode = value; }
        }
        public bool IsZeroBalance
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.IsZeroBalance : false; }
            set { AccountTradingReportDTO.IsZeroBalance = value; }
        }
        [Display(Name = "Group Report By :")]
        public string GroupBy
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.GroupBy : string.Empty; }
            set { AccountTradingReportDTO.GroupBy = value; }
        }
        [Display(Name = "Is Sub Ledger :")]
        public bool IsSubLedger
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.IsSubLedger : false; }
            set { AccountTradingReportDTO.IsSubLedger = value; }
        }
        public string HeadName
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.HeadName : string.Empty; }
            set { AccountTradingReportDTO.HeadName = value; }
        }
        public string HeadCode
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.HeadCode : string.Empty; }
            set { AccountTradingReportDTO.HeadCode = value; }
        }

        public string CategoryDescription
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.CategoryDescription : string.Empty; }
            set { AccountTradingReportDTO.CategoryDescription = value; }
        }
        public string CategoryCode
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.CategoryCode : string.Empty; }
            set { AccountTradingReportDTO.CategoryCode = value; }
        }
        public string GroupDescription
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.GroupDescription : string.Empty; }
            set { AccountTradingReportDTO.GroupDescription = value; }
        }
        public string GroupCode
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.GroupCode : string.Empty; }
            set { AccountTradingReportDTO.GroupCode = value; }
        }

        public int AccountID
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.AccountID : new int(); }
            set { AccountTradingReportDTO.AccountID = value; }
        }
        public string AccountName
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.AccountName : string.Empty; }
            set { AccountTradingReportDTO.AccountName = value; }
        }
        public string AccountCode
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.AccountCode : string.Empty; }
            set { AccountTradingReportDTO.AccountCode = value; }
        }

        public bool IsPosted
        {
            get
            {
                return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.IsPosted : false;
            }
            set
            {
                AccountTradingReportDTO.IsPosted = value;
            }
        }

        public decimal OpeningBalanceDebit
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.OpeningBalanceDebit : new decimal(); }
            set { AccountTradingReportDTO.OpeningBalanceDebit = value; }
        }
        public decimal OpeningBalanceCerdit
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.OpeningBalanceCerdit : new decimal(); }
            set { AccountTradingReportDTO.OpeningBalanceCerdit = value; }
        }
        public decimal TotalDebit
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.TotalDebit : new decimal(); }
            set { AccountTradingReportDTO.TotalDebit = value; }
        }
        public decimal OpeningBalance
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.OpeningBalance : new decimal(); }
            set { AccountTradingReportDTO.OpeningBalance = value; }
        }
        public decimal TotalCredit
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.TotalCredit : new decimal(); }
            set { AccountTradingReportDTO.TotalCredit = value; }
        }
        public decimal ClosingBalance
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.ClosingBalance : new decimal(); }
            set { AccountTradingReportDTO.ClosingBalance = value; }
        }
        public decimal ClosingDebitAmount
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.ClosingDebitAmount : new decimal(); }
            set { AccountTradingReportDTO.ClosingDebitAmount = value; }
        }
        public decimal ClosingCreditAmount
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.ClosingCreditAmount : new decimal(); }
            set { AccountTradingReportDTO.ClosingCreditAmount = value; }
        }
        public decimal TotalBalanceSum
        {
            get { return (AccountTradingReportDTO != null) ? AccountTradingReportDTO.TotalBalanceSum : new decimal(); }
            set { AccountTradingReportDTO.TotalBalanceSum = value; }
        }

    }
}
