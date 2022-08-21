using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
    public class AccountDayBookReportViewModel : IAccountDayBookReportViewModel
    {
        public AccountDayBookReportViewModel()
        {
            AccountDayBookReportDTO = new AccountDayBookReport();
            ListAccountSessionMasterReport = new List<AccountSessionMaster>();
             ListAccountMasterReport = new List<AccountMaster>();
            ListTransactionTypeMasterReport = new List<AccountTransactionTypeMaster>();
        }

        [Display(Name = "Account Session")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedAccountSessionIDRequired")]
        public string SelectedAccountSessionID { get; set; }
        [Display(Name = "Session From Date")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SessionFromDateReportRequired")]
        public string SessionFromDate { get; set; }
        [Display(Name = "Session Upto Date")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SessionUptoDateReportRequired")]
        public string SessionUptoDate { get; set; }
        [Display(Name = "Pattern")]
        public string Pattern { get; set; }
        [Display(Name = "Pattern Type")]
        public string PatternType { get; set; }
        [AllowHtml]
        public string AccountIDsXmlString { get; set; }
        [AllowHtml]
        public string TransactionTypeXmlString
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.TransactionTypeXmlString : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.TransactionTypeXmlString = value;
            }
        }
         
        public string AccountBalsheetMstIDXmlString
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.AccountBalsheetMstIDXmlString : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.AccountBalsheetMstIDXmlString = value;
            }
        }

        public List<AccountSessionMaster> ListAccountSessionMasterReport { get; set; }
        public List<AccountMaster> ListAccountMasterReport { get; set; }
        public List<AccountTransactionTypeMaster> ListTransactionTypeMasterReport { get; set; }

        public IEnumerable<SelectListItem> AccountSessionMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountSessionMasterReport, "ID", "SessionName");
            }
        }

        public AccountDayBookReport AccountDayBookReportDTO
        {
            get;
            set;
        }
        public bool PageLoaded { get; set; }

        /// <summary>
        /// Properties for table AccTransactionMaster
        /// </summary>


        public Int64 ID
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.ID > 0) ? AccountDayBookReportDTO.ID : new Int64();
            }
            set
            {
                AccountDayBookReportDTO.ID = value;
            }
        }
        [Display(Name = "Transaction Type")]
        public char TransactionType
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.TransactionType : new char();
            }
            set
            {
                AccountDayBookReportDTO.TransactionType = value;
            }
        }

        [Display(Name = "Transaction Date")]
        [Required(ErrorMessage ="Transaction Date Required")]
        public string TransactionDate
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.TransactionDate : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.TransactionDate = value;
            }
        }

        [Display(Name = "Narration Description")]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NarrationDescription")]
        public string NarrationDescription
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.NarrationDescription : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.NarrationDescription = value;
            }
        }

        public string ModeCode
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.ModeCode : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.ModeCode = value;
            }
        }

        public Int16 AccSessionID
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.AccSessionID > 0) ? AccountDayBookReportDTO.AccSessionID : new Int16();
            }
            set
            {
                AccountDayBookReportDTO.AccSessionID = value;
            }
        }

        public string VoucherNumber
        {
            get
            {
                return (AccountDayBookReportDTO != null ) ? AccountDayBookReportDTO.VoucherNumber : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.VoucherNumber = value;
            }
        }

        public Int16 AccBalsheetMstID
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.AccBalsheetMstID > 0) ? AccountDayBookReportDTO.AccBalsheetMstID : new Int16();
            }
            set
            {
                AccountDayBookReportDTO.AccBalsheetMstID = value;
            }
        }

        public string AccBalsheetName
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.AccBalsheetName : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.AccBalsheetName = value;
            }
        }

        public bool IsPosted
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.IsPosted : false;
            }
            set
            {
                AccountDayBookReportDTO.IsPosted = value;
            }
        }

        public int PostedBy
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.PostedBy > 0) ? AccountDayBookReportDTO.PostedBy : new int();
            }
            set
            {
                AccountDayBookReportDTO.PostedBy = value;
            }
        }

        public string PostedDate
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.PostedDate : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.PostedDate = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.IsActive : false;
            }
            set
            {
                AccountDayBookReportDTO.IsActive = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.CreatedBy > 0) ? AccountDayBookReportDTO.CreatedBy : new int();
            }
            set
            {
                AccountDayBookReportDTO.CreatedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AccountDayBookReportDTO.CreatedDate = value;
            }
        }

        public int ModifiedBy
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.ModifiedBy > 0) ? AccountDayBookReportDTO.ModifiedBy : new int();
            }
            set
            {
                AccountDayBookReportDTO.ModifiedBy = value;
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AccountDayBookReportDTO.ModifiedDate = value;
            }
        }

        public int DeletedBy
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.ModifiedBy > 0) ? AccountDayBookReportDTO.DeletedBy : new int();
            }
            set
            {
                AccountDayBookReportDTO.DeletedBy = value;
            }
        }

        public DateTime DeletedDate
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AccountDayBookReportDTO.DeletedDate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.IsDeleted : false;
            }
            set
            {
                AccountDayBookReportDTO.IsDeleted = value;
            }
        }

        public string SelectedTransactionType { get; set; }

        public string SelectedXmlData
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.SelectedXmlData : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.SelectedXmlData = value;
            }
        }

        public List<AccountTransactionTypeMaster> ListAccountTransactionTypeMaster
        {
            get;
            set;
        }

        public List<AccountDayBookReport> ListAccountDayBookReport { get; set; }

        /// <summary>
        /// Properties for table AccTransactionDetails
        /// </summary>


        public Int64 AccTransDetailsID
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.AccTransDetailsID > 0) ? AccountDayBookReportDTO.AccTransDetailsID : new Int64();
            }
            set
            {
                AccountDayBookReportDTO.AccTransDetailsID = value;
            }
        }

        public Int64 TransactionMainID
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.TransactionMainID > 0) ? AccountDayBookReportDTO.TransactionMainID : new Int64();
            }
            set
            {
                AccountDayBookReportDTO.TransactionMainID = value;
            }
        }
        [Display(Name = "Account")]
        public Int16 AccountID
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.AccountID > 0) ? AccountDayBookReportDTO.AccountID : new Int16();
            }
            set
            {
                AccountDayBookReportDTO.AccountID = value;
            }
        }

        public string AccountName
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.AccountName : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.AccountName = value;
            }
        }

        public decimal TransactionAmount
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.TransactionAmount > 0) ? AccountDayBookReportDTO.TransactionAmount : new decimal();
            }
            set
            {
                AccountDayBookReportDTO.TransactionAmount = value;
            }
        }

        public string DebitCreditFlag
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.DebitCreditFlag : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.DebitCreditFlag = value;
            }
        }

        public string ChequeNo
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.ChequeNo : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.ChequeNo = value;
            }
        }

        public string ChequeDatetime
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.ChequeDatetime : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.ChequeDatetime = value;
            }
        }

        // string NarrationDescription { get; set; }

        public string BankName
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.BankName : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.BankName = value;
            }
        }

        public string BranchName
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.BranchName : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.BranchName = value;
            }
        }

        public DateTime BankClearingDatetime
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.BankClearingDatetime : DateTime.Now;
            }
            set
            {
                AccountDayBookReportDTO.BankClearingDatetime = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.PersonID > 0) ? AccountDayBookReportDTO.PersonID : new int();
            }
            set
            {
                AccountDayBookReportDTO.PersonID = value;
            }
        }

        // string ModeCode { get; set; }

        public string PersonType
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.PersonType : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.PersonType = value;
            }
        }
        // int AccSessionID { get; set; }
        // int VoucherNumber { get; set; }

        public string SubmitSlipNo
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.SubmitSlipNo : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.SubmitSlipNo = value;
            }
        }

        public DateTime SubmitDatetime
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.SubmitDatetime : DateTime.Now;
            }
            set
            {
                AccountDayBookReportDTO.SubmitDatetime = value;
            }
        }

        public DateTime ReconcilationDatetime
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.ReconcilationDatetime : DateTime.Now;
            }
            set
            {
                AccountDayBookReportDTO.ReconcilationDatetime = value;
            }
        }

        // int AccBalsheetMstID { get; set; }

        public string BankTransferFlag
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.BankTransferFlag : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.BankTransferFlag = value;
            }
        }

        public string ChqDepositSlipNo
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.ChqDepositSlipNo : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.ChqDepositSlipNo = value;
            }
        }

        public DateTime ChqDepositDatetime
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.ChqDepositDatetime : DateTime.Now;
            }
            set
            {
                AccountDayBookReportDTO.ChqDepositDatetime = value;
            }
        }


        /// <summary>
        /// Properties for AccTransactionTypeMaster
        /// </summary>

        public int AccTransTypeID
        {
            get
            {
                return (AccountDayBookReportDTO != null && AccountDayBookReportDTO.ModifiedBy > 0) ? AccountDayBookReportDTO.AccTransTypeID : new int();
            }
            set
            {
                AccountDayBookReportDTO.AccTransTypeID = value;
            }
        }

        public string TransactionTypeCode
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.TransactionTypeCode : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.TransactionTypeCode = value;
            }
        }

        public string TransactionTypeName
        {
            get
            {
                return (AccountDayBookReportDTO != null) ? AccountDayBookReportDTO.TransactionTypeName : string.Empty;
            }
            set
            {
                AccountDayBookReportDTO.TransactionTypeName = value;
            }
        }
    }
}
