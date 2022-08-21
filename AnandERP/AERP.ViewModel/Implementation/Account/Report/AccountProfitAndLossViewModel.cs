using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AccountProfitAndLossReportViewModel 
    {

        public AccountProfitAndLossReportViewModel()
        {
            AccountProfitAndLossReportDTO = new AccountProfitAndLossReport();
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

        public AccountProfitAndLossReport AccountProfitAndLossReportDTO { get; set; }


        public int ID
        {
            get
            {
                return (AccountProfitAndLossReportDTO != null && AccountProfitAndLossReportDTO.ID > 0) ? AccountProfitAndLossReportDTO.ID : new int();
            }
            set
            {
                AccountProfitAndLossReportDTO.ID = value;
            }
        }
        [Display(Name = "Is Consolidated Report")]
        public bool IsConsolidated
        {
            get
            {
                return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.IsConsolidated : false;
            }
            set
            {
                AccountProfitAndLossReportDTO.IsConsolidated = value;
            }
        }
        [Display(Name = "Session UpTo Date :")]
        public string SessionUptoDate
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.SessionUptoDate : string.Empty; }
            set { AccountProfitAndLossReportDTO.SessionUptoDate = value; }
        }
        [Display(Name = "Session From Date :")]
        public string SessionFromDate
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.SessionFromDate : string.Empty; }
            set { AccountProfitAndLossReportDTO.SessionFromDate = value; }
        }



        [Display(Name = "Account Session :")]
        public int AccountSessionID
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.AccountSessionID : new int(); }
            set { AccountProfitAndLossReportDTO.AccountSessionID = value; }
        }
        public int AccBalsheetMstId
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.AccBalsheetMstId : new int(); }
            set { AccountProfitAndLossReportDTO.AccBalsheetMstId = value; }
        }
        public string AccBalsheetName
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.AccBalsheetName : string.Empty; }
            set { AccountProfitAndLossReportDTO.AccBalsheetName = value; }
        }
        public string CentreCode
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.CentreCode : string.Empty; }
            set { AccountProfitAndLossReportDTO.CentreCode = value; }
        }
        public bool IsZeroBalance
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.IsZeroBalance : false; }
            set { AccountProfitAndLossReportDTO.IsZeroBalance = value; }
        }
        [Display(Name = "Group Report By :")]
        public string GroupBy
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.GroupBy : string.Empty; }
            set { AccountProfitAndLossReportDTO.GroupBy = value; }
        }
        [Display(Name = "Is Sub Ledger :")]
        public bool IsSubLedger
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.IsSubLedger : false; }
            set { AccountProfitAndLossReportDTO.IsSubLedger = value; }
        }
        public string HeadName
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.HeadName : string.Empty; }
            set { AccountProfitAndLossReportDTO.HeadName = value; }
        }
        public string HeadCode
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.HeadCode : string.Empty; }
            set { AccountProfitAndLossReportDTO.HeadCode = value; }
        }

        public string CategoryDescription
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.CategoryDescription : string.Empty; }
            set { AccountProfitAndLossReportDTO.CategoryDescription = value; }
        }
        public string CategoryCode
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.CategoryCode : string.Empty; }
            set { AccountProfitAndLossReportDTO.CategoryCode = value; }
        }
        public string GroupDescription
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.GroupDescription : string.Empty; }
            set { AccountProfitAndLossReportDTO.GroupDescription = value; }
        }
        public string GroupCode
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.GroupCode : string.Empty; }
            set { AccountProfitAndLossReportDTO.GroupCode = value; }
        }

        public int AccountID
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.AccountID : new int(); }
            set { AccountProfitAndLossReportDTO.AccountID = value; }
        }
        public string AccountName
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.AccountName : string.Empty; }
            set { AccountProfitAndLossReportDTO.AccountName = value; }
        }
        public string AccountCode
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.AccountCode : string.Empty; }
            set { AccountProfitAndLossReportDTO.AccountCode = value; }
        }

        public bool IsPosted
        {
            get
            {
                return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.IsPosted : false;
            }
            set
            {
                AccountProfitAndLossReportDTO.IsPosted = value;
            }
        }

        public decimal OpeningBalanceDebit
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.OpeningBalanceDebit : new decimal(); }
            set { AccountProfitAndLossReportDTO.OpeningBalanceDebit = value; }
        }
        public decimal OpeningBalanceCerdit
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.OpeningBalanceCerdit : new decimal(); }
            set { AccountProfitAndLossReportDTO.OpeningBalanceCerdit = value; }
        }
        public decimal TotalDebit
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.TotalDebit : new decimal(); }
            set { AccountProfitAndLossReportDTO.TotalDebit = value; }
        }
        public decimal OpeningBalance
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.OpeningBalance : new decimal(); }
            set { AccountProfitAndLossReportDTO.OpeningBalance = value; }
        }
        public decimal TotalCredit
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.TotalCredit : new decimal(); }
            set { AccountProfitAndLossReportDTO.TotalCredit = value; }
        }
        public decimal ClosingBalance
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.ClosingBalance : new decimal(); }
            set { AccountProfitAndLossReportDTO.ClosingBalance = value; }
        }
        public decimal ClosingDebitAmount
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.ClosingDebitAmount : new decimal(); }
            set { AccountProfitAndLossReportDTO.ClosingDebitAmount = value; }
        }
        public decimal ClosingCreditAmount
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.ClosingCreditAmount : new decimal(); }
            set { AccountProfitAndLossReportDTO.ClosingCreditAmount = value; }
        }
        public decimal TotalBalanceSum
        {
            get { return (AccountProfitAndLossReportDTO != null) ? AccountProfitAndLossReportDTO.TotalBalanceSum : new decimal(); }
            set { AccountProfitAndLossReportDTO.TotalBalanceSum = value; }
        }
        public int Format
        {
            get
            {
                return (AccountProfitAndLossReportDTO != null && AccountProfitAndLossReportDTO.Format > 0) ? AccountProfitAndLossReportDTO.Format : new int();
            }
            set
            {
                AccountProfitAndLossReportDTO.Format = value;
            }
        }
    }
}
