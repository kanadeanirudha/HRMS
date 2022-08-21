using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AccountGeneralLedgerReportViewModel
    {

        public AccountGeneralLedgerReportViewModel()
        {
            AccountGeneralLedgerReportDTO = new AccountGeneralLedgerReport();
            ListAccountSessionMasterReport = new List<AccountSessionMaster>();
            ListAccountNameReport = new List<AccountMaster>();
            ListIndividualAccountNameReport = new List<AccountGeneralLedgerReport>();
            UserTypeList = new List<UserMaster>();
        }


        public List<AccountSessionMaster> ListAccountSessionMasterReport { get; set; }
        public List<AccountMaster> ListAccountNameReport { get; set; }
        public List<AccountGeneralLedgerReport> ListIndividualAccountNameReport { get; set; }
        public List<UserMaster> UserTypeList { get; set; }
        public IEnumerable<SelectListItem> UserTypeListItems
        {
            get
            {
                return new SelectList(UserTypeList, "UserType", "UserDescription");
            }
        }
        public IEnumerable<SelectListItem> AccountSessionMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountSessionMasterReport, "ID", "SessionName");
            }
        }
        public IEnumerable<SelectListItem> AccountNameReportItems
        {
            get
            {
                return new SelectList(ListAccountNameReport, "ID", "AccountName");
            }
        }
        public IEnumerable<SelectListItem> IndividualAccountNameReportItems
        {
            get
            {
                return new SelectList(ListIndividualAccountNameReport, "PersonID", "PersonName");
            }
        }
        public AccountGeneralLedgerReport AccountGeneralLedgerReportDTO { get; set; }

        public string TransactionDate
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.TransactionDate : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.TransactionDate = value;
            }
        }
        public string DebitCreditFlag
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.DebitCreditFlag : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.DebitCreditFlag = value;
            }
        }
        public string ReverseAccount
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.ReverseAccount : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.ReverseAccount = value;
            }
        }
        public int PersonID
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.PersonID : new int();
            }
            set
            {
                AccountGeneralLedgerReportDTO.PersonID = value;
            }
        }
        public int AccountBalsheetMstID
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.AccountBalsheetMstID : new int();
            }
            set
            {
                AccountGeneralLedgerReportDTO.AccountBalsheetMstID = value;
            }
        }
        [Display(Name = "Individual Account")]
        //[Display(Name = "DisplayName_IndividualAccount", ResourceType = typeof(AERP.Common.Resources))]
        public int IndividualAccountID
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.IndividualAccountID : new int();
            }
            set
            {
                AccountGeneralLedgerReportDTO.IndividualAccountID = value;
            }
        }
        public string ChequeNo
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.ChequeNo : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.ChequeNo = value;
            }
        }
        public string ChequeDatetime
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.ChequeDatetime : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.ChequeDatetime = value;
            }
        }
        public string ChequeDetails
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.ChequeDetails : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.ChequeDetails = value;
            }
        }
        public string VoucherNumber
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.VoucherNumber : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.VoucherNumber = value;
            }
        }
        public string TransactionType
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.TransactionType : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.TransactionType = value;
            }
        }
        public string NarrationDescription
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.NarrationDescription : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.NarrationDescription = value;
            }
        }
        [Display(Name = "Student Name :")]
        //[Display(Name = "DisplayName_StudentName", ResourceType = typeof(AERP.Common.Resources))]
        public string StudentName
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.StudentName : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.StudentName = value;
            }
        }

        public string PersonName
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.PersonName : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.PersonName = value;
            }
        }

        [Display(Name = "Person Type :")]
        //[Display(Name = "DisplayName_PersonType", ResourceType = typeof(AERP.Common.Resources))]
        public string PersonType
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.PersonType : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.PersonType = value;
            }
        }
        [Display(Name = "Account Session :")]
        //[Display(Name = "DisplayName_AccountSession", ResourceType = typeof(AERP.Common.Resources))]
        public int AccountSessionID
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.AccountSessionID : new int();
            }
            set
            {
                AccountGeneralLedgerReportDTO.AccountSessionID = value;
            }
        }
        public string BalanceSheetName
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.BalanceSheetName : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.BalanceSheetName = value;
            }
        }
        [Display(Name = "Account Type :")]
        //[Display(Name = "DisplayName_AccountType", ResourceType = typeof(AERP.Common.Resources))]
        public string AccountType
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.AccountType : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.AccountType = value;
            }
        }
        [Display(Name = "Account Name :")]
        public int AccountID
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.AccountID : new int();
            }
            set
            {
                AccountGeneralLedgerReportDTO.AccountID = value;
            }
        }
        [Display(Name = "Account Name :")]
        //[Display(Name = "DisplayName_AccountName", ResourceType = typeof(AERP.Common.Resources))]
        public string AccountName
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.AccountName : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.AccountName = value;
            }
        }
        public bool IsPosted
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.IsPosted : false;
            }
            set
            {
                AccountGeneralLedgerReportDTO.IsPosted = value;
            }
        }
        public string PersonTypeName
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.PersonTypeName : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.PersonTypeName = value;
            }
        }
        [Display(Name = "Report Parameter :")]
        //[Display(Name = "DisplayName_ReportParameter", ResourceType = typeof(AERP.Common.Resources))]
        public string ReportParameter
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.ReportParameter : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.ReportParameter = value;
            }
        }
        [Display(Name = "Session From Date :")]
        //[Display(Name = "DisplayName_SessionFromDate", ResourceType = typeof(AERP.Common.Resources))]
        public string FromDate
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.FromDate : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.FromDate = value;
            }
        }
        [Display(Name = "Session To Date :")]
        //[Display(Name = "DisplayName_SessionToDate", ResourceType = typeof(AERP.Common.Resources))]
        public string ToDate
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.ToDate : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.ToDate = value;
            }
        }
        public string TransactionAmount
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.TransactionAmount : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.TransactionAmount = value;
            }
        }
        public decimal DebitAmount
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.DebitAmount : new decimal();
            }
            set
            {
                AccountGeneralLedgerReportDTO.DebitAmount = value;
            }
        }
        public decimal CreditAmount
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.CreditAmount : new decimal();
            }
            set
            {
                AccountGeneralLedgerReportDTO.CreditAmount = value;
            }
        }
        public decimal Balance
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.Balance : new decimal();
            }
            set
            {
                AccountGeneralLedgerReportDTO.Balance = value;
            }
        }

        [Display(Name = "DisplayName_ControlHead", ResourceType = typeof(AERP.Common.Resources))]
        public string ControlHead
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.ControlHead : string.Empty;
            }
            set
            {
                AccountGeneralLedgerReportDTO.ControlHead = value;
            }
        }

        //public Nullable<bool> IsActive
        //{
        //    get
        //    {
        //        return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.IsActive : false;
        //    }
        //    set
        //    {
        //        AccountGeneralLedgerReportDTO.IsActive = value;
        //    }
        //}

        //public Nullable<int> CreatedBy
        //{
        //    get
        //    {
        //        return (AccountGeneralLedgerReportDTO != null && AccountGeneralLedgerReportDTO.CreatedBy > 0) ? AccountGeneralLedgerReportDTO.CreatedBy : new int();
        //    }
        //    set
        //    {
        //        AccountGeneralLedgerReportDTO.CreatedBy = value;
        //    }
        //}


        //public Nullable<System.DateTime> CreatedDate
        //{
        //    get
        //    {
        //        return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.CreatedDate : null;
        //    }
        //    set
        //    {
        //        AccountGeneralLedgerReportDTO.CreatedDate = value;
        //    }
        //}


        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null && AccountGeneralLedgerReportDTO.ModifiedBy > 0) ? AccountGeneralLedgerReportDTO.ModifiedBy : new int();
            }
            set
            {
                AccountGeneralLedgerReportDTO.ModifiedBy = value;
            }
        }


        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.ModifiedDate : null;
            }
            set
            {
                AccountGeneralLedgerReportDTO.ModifiedDate = value;
            }
        }

        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null && AccountGeneralLedgerReportDTO.DeletedBy > 0) ? AccountGeneralLedgerReportDTO.DeletedBy : new int();
            }
            set
            {
                AccountGeneralLedgerReportDTO.DeletedBy = value;
            }
        }


        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountGeneralLedgerReportDTO != null) ? AccountGeneralLedgerReportDTO.DeletedDate : null;
            }
            set
            {
                AccountGeneralLedgerReportDTO.DeletedDate = value;
            }
        }




    }
}
