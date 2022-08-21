using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AccountTrialBalanceReportViewModel : IAccountTrialBalanceReportViewModel
    {

        public AccountTrialBalanceReportViewModel()
        {
            AccountTrialBalanceReportDTO = new AccountTrialBalanceReport();
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

        public AccountTrialBalanceReport AccountTrialBalanceReportDTO { get; set; }


        public int ID
        {
            get
            {
                return (AccountTrialBalanceReportDTO != null && AccountTrialBalanceReportDTO.ID > 0) ? AccountTrialBalanceReportDTO.ID : new int();
            }
            set
            {
                AccountTrialBalanceReportDTO.ID = value;
            }
        }

        [Display(Name = "Session UpTo Date :")]
        public string SessionUptoDate
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.SessionUptoDate : string.Empty; }
            set { AccountTrialBalanceReportDTO.SessionUptoDate = value; }
        }
        [Display(Name = "Session From Date :")]
        public string SessionFromDate
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.SessionFromDate : string.Empty; }
            set { AccountTrialBalanceReportDTO.SessionFromDate = value; }
        }



        [Display(Name = "Account Session :")]
        public int AccountSessionID
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.AccountSessionID : new int(); }
            set { AccountTrialBalanceReportDTO.AccountSessionID = value; }
        }
        public int AccBalsheetMstId
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.AccBalsheetMstId : new int(); }
            set { AccountTrialBalanceReportDTO.AccBalsheetMstId = value; }
        }
        public string CentreCode
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.CentreCode : string.Empty; }
            set { AccountTrialBalanceReportDTO.CentreCode = value; }
        }
        public bool IsZeroBalance
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.IsZeroBalance : false; }
            set { AccountTrialBalanceReportDTO.IsZeroBalance = value; }
        }
        [Display(Name = "Group Report By :")]
        public string GroupBy
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.GroupBy : string.Empty; }
            set { AccountTrialBalanceReportDTO.GroupBy = value; }
        }
        [Display(Name = "Is Sub Ledger :")]
        public bool IsSubLedger
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.IsSubLedger : false; }
            set { AccountTrialBalanceReportDTO.IsSubLedger = value; }
        }
        public string HeadName
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.HeadName : string.Empty; }
            set { AccountTrialBalanceReportDTO.HeadName = value; }
        }
        public string HeadCode
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.HeadCode : string.Empty; }
            set { AccountTrialBalanceReportDTO.HeadCode = value; }
        }
        public string CategoryDescription
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.CategoryDescription : string.Empty; }
            set { AccountTrialBalanceReportDTO.CategoryDescription = value; }
        }
        public string CategoryCode
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.CategoryCode : string.Empty; }
            set { AccountTrialBalanceReportDTO.CategoryCode = value; }
        }
        public int CategoryID
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.CategoryID : new int(); }
            set { AccountTrialBalanceReportDTO.CategoryID = value; }
        }
        public string GroupDescription
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.GroupDescription : string.Empty; }
            set { AccountTrialBalanceReportDTO.GroupDescription = value; }
        }
        public int GroupID
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.GroupID : new int(); }
            set { AccountTrialBalanceReportDTO.GroupID = value; }
        }
        public string AltGroupDescription
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.AltGroupDescription : string.Empty; }
            set { AccountTrialBalanceReportDTO.AltGroupDescription = value; }
        }
        public int AltGroupID
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.AltGroupID : new int(); }
            set { AccountTrialBalanceReportDTO.AltGroupID = value; }
        }
        public int AccountID
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.AccountID : new int(); }
            set { AccountTrialBalanceReportDTO.AccountID = value; }
        }
        public string AccountName
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.AccountName : string.Empty; }
            set { AccountTrialBalanceReportDTO.AccountName = value; }
        }
        public string AccBalsheetCode
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.AccBalsheetCode : string.Empty; }
            set { AccountTrialBalanceReportDTO.AccBalsheetCode = value; }
        }
        public string AccBalsheetTypeDesc
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.AccBalsheetTypeDesc : string.Empty; }
            set { AccountTrialBalanceReportDTO.AccBalsheetTypeDesc = value; }
        }
        public int AccBalsheetTypeID
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.AccBalsheetTypeID : new int(); }
            set { AccountTrialBalanceReportDTO.AccBalsheetTypeID = value; }
        }
        public int BalanceSheetMstID
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.BalanceSheetMstID : new int(); }
            set { AccountTrialBalanceReportDTO.BalanceSheetMstID = value; }
        }
        public string AccBalsheetName
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.AccBalsheetName : string.Empty; }
            set { AccountTrialBalanceReportDTO.AccBalsheetName = value; }
        }        
        public bool IsPosted
        {
            get
            {
                return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.IsPosted : false;
            }
            set
            {
                AccountTrialBalanceReportDTO.IsPosted = value;
            }
        }
        public decimal OpeningBalanceDebit
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.OpeningBalanceDebit : new decimal(); }
            set { AccountTrialBalanceReportDTO.OpeningBalanceDebit = value; }
        }
        public decimal OpeningBalanceCerdit
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.OpeningBalanceCerdit : new decimal(); }
            set { AccountTrialBalanceReportDTO.OpeningBalanceCerdit = value; }
        }
        public decimal CurrentDebitTransactionAmount
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.CurrentDebitTransactionAmount : new decimal(); }
            set { AccountTrialBalanceReportDTO.CurrentDebitTransactionAmount = value; }
        }
        public decimal CurrentCreditTransactionAmount
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.CurrentCreditTransactionAmount : new decimal(); }
            set { AccountTrialBalanceReportDTO.CurrentCreditTransactionAmount = value; }
        }
        public decimal ClosingBalanceDebitAsPerCal
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.ClosingBalanceDebitAsPerCal : new decimal(); }
            set { AccountTrialBalanceReportDTO.ClosingBalanceDebitAsPerCal = value; }
        }
        public decimal ClosingBalanceCreditAsPerCal
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.ClosingBalanceCreditAsPerCal : new decimal(); }
            set { AccountTrialBalanceReportDTO.ClosingBalanceCreditAsPerCal = value; }
        }
        public decimal ActualClosingDebitBalance
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.ActualClosingDebitBalance : new decimal(); }
            set { AccountTrialBalanceReportDTO.ActualClosingDebitBalance = value; }
        }
        public decimal ActualClosingCreditBalance
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.ActualClosingCreditBalance : new decimal(); }
            set { AccountTrialBalanceReportDTO.ActualClosingCreditBalance = value; }
        }
        public decimal ClosingBalance
        {
            get { return (AccountTrialBalanceReportDTO != null) ? AccountTrialBalanceReportDTO.ClosingBalance : new decimal(); }
            set { AccountTrialBalanceReportDTO.ClosingBalance = value; }
        }







    }
}
