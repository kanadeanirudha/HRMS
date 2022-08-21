using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AccountBalancesheetReportViewModel : IAccountBalancesheetReportViewModel
    {
        public AccountBalancesheetReportViewModel()
        {
            AccountBalancesheetReportDTO = new AccountBalancesheetReport();
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

        public AccountBalancesheetReport AccountBalancesheetReportDTO { get; set; }

        public int ID
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.ID > 0) ? AccountBalancesheetReportDTO.ID : new int();
            }
            set
            {
                AccountBalancesheetReportDTO.ID = value;
            }
        }
        [Display(Name = "Session Upto Date")]
        //[Display(Name = "Session UpTo Date :")]
        public string SessionUptoDate
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.SessionUptoDate : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.SessionUptoDate = value;
            }
        }
        [Display(Name = "Session From Date")]
        //[Display(Name = "Session From Date :")]
        public string SessionFromDate
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.SessionFromDate : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.SessionFromDate = value;
            }
        }
        public int AccountId
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.AccountId > 0) ? AccountBalancesheetReportDTO.AccountId : new int();
            }
            set
            {
                AccountBalancesheetReportDTO.AccountId = value;
            }
        }
       // [Display(Name = "Account Session :")]
        [Display(Name = "Account Session")]
        public int AccountSessionID
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.AccountSessionID > 0) ? AccountBalancesheetReportDTO.AccountSessionID : new int();
            }
            set
            {
                AccountBalancesheetReportDTO.AccountSessionID = value;
            }
        }
        public int AccBalsheetMstId
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.AccBalsheetMstId > 0) ? AccountBalancesheetReportDTO.AccBalsheetMstId : new int();
            }
            set
            {
                AccountBalancesheetReportDTO.AccBalsheetMstId = value;
            }
        }
        public string AccBalsheetName
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.AccBalsheetName : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.AccBalsheetName = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.CentreCode : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.CentreCode = value;
            }
        }
        public bool IsZeroBalance
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.IsZeroBalance : false;
            }
            set
            {
                AccountBalancesheetReportDTO.IsZeroBalance = value;
            }
        }
        //[Display(Name = "Group Report By :")]
        [Display(Name = "Is Consolidated Report")]
        public bool IsConsolidated
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.IsConsolidated : false;
            }
            set
            {
                AccountBalancesheetReportDTO.IsConsolidated = value;
            }
        }
        //[Display(Name = "Group Report By :")]
        [Display(Name = "Group Report By")]
        public string GroupBy
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.GroupBy : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.GroupBy = value;
            }
        }
        public bool IsSubLedger
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.IsSubLedger : false;
            }
            set
            {
                AccountBalancesheetReportDTO.IsSubLedger = value;
            }
        }
        public string HeadName
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.HeadName : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.HeadName = value;
            }
        }
        public string HeadCode
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.HeadCode : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.HeadCode = value;
            }
        }
        public string CategoryDescription
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.CategoryDescription : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.CategoryDescription = value;
            }
        }
        public string CategoryCode
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.CategoryCode : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.CategoryCode = value;
            }
        }
        public int CategoryID
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.CategoryID > 0) ? AccountBalancesheetReportDTO.CategoryID : new int();
            }
            set
            {
                AccountBalancesheetReportDTO.CategoryID = value;
            }
        }
        public string GroupDescription
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.GroupDescription : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.GroupDescription = value;
            }
        }
        public int GroupID
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.GroupID > 0) ? AccountBalancesheetReportDTO.GroupID : new int();
            }
            set
            {
                AccountBalancesheetReportDTO.GroupID = value;
            }
        }
        public string AltGroupDescription
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.AltGroupDescription : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.AltGroupDescription = value;
            }
        }
        public int AltGroupID
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.AltGroupID > 0) ? AccountBalancesheetReportDTO.AltGroupID : new int();
            }
            set
            {
                AccountBalancesheetReportDTO.AltGroupID = value;
            }
        }

        public string AccountName
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.AccountName : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.AccountName = value;
            }
        }
        public string AccBalsheetCode
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.AccBalsheetCode : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.AccBalsheetCode = value;
            }
        }
        public string AccBalsheetTypeDesc
        {
            get
            {
                return (AccountBalancesheetReportDTO != null) ? AccountBalancesheetReportDTO.AccBalsheetTypeDesc : string.Empty;
            }
            set
            {
                AccountBalancesheetReportDTO.AccBalsheetTypeDesc = value;
            }
        }
        public int AccBalsheetTypeID
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.AccBalsheetTypeID > 0) ? AccountBalancesheetReportDTO.AccBalsheetTypeID : new int();
            }
            set
            {
                AccountBalancesheetReportDTO.AccBalsheetTypeID = value;
            }
        }
        public int BalanceSheetMstID
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.BalanceSheetMstID > 0) ? AccountBalancesheetReportDTO.BalanceSheetMstID : new int();
            }
            set
            {
                AccountBalancesheetReportDTO.BalanceSheetMstID = value;
            }
        }
        public decimal TransactionAmount
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.TransactionAmount > 0) ? AccountBalancesheetReportDTO.TransactionAmount : new decimal();
            }
            set
            {
                AccountBalancesheetReportDTO.TransactionAmount = value;
            }
        }
        public int Format
        {
            get
            {
                return (AccountBalancesheetReportDTO != null && AccountBalancesheetReportDTO.Format > 0) ? AccountBalancesheetReportDTO.Format : new int();
            }
            set
            {
                AccountBalancesheetReportDTO.Format = value;
            }
        }
        public bool IsPosted { get; set; }
    }
}
