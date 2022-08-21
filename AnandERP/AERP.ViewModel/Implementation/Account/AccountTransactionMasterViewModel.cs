using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{

    public class AccountTransactionMasterViewModel : IAccountTransactionMasterViewModel
    {
        public AccountTransactionMasterViewModel() 
        {
            AccountTransactionMasterDTO = new AccountTransactionMaster();
            ListAccountTransactionMaster = new List<AccountTransactionMaster>();
            ListAccountTransactionTypeMaster = new List<AccountTransactionTypeMaster>();
            AccountVoucherDetailsList = new List<AccountTransactionMaster>();
        }
        public List<AccountTransactionMaster> AccountVoucherDetailsList { get; set; }
        public AccountTransactionMaster AccountTransactionMasterDTO
        {
            get;
            set;
        }


        /// <summary>
        /// Properties for table AccTransactionMaster
        /// </summary>

        public string SelectedTransactionType { get; set; }

        public AccountSessionMaster AccountSessionMasterDTO { get; set; }

        public string SessionName { get; set; }

        public string TransactionTypeWithCode { get; set; }


        public Int64 ID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.ID > 0) ? AccountTransactionMasterDTO.ID : new Int64();
            }
            set
            {
                AccountTransactionMasterDTO.ID = value;
            }
        }

        public char TransactionType 
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.TransactionType : new char();
            }
            set
            {
                AccountTransactionMasterDTO.TransactionType = value;
            }
        }

        [Display(Name = "Transaction Date")]
        [Required(ErrorMessage ="Transaction Date Required")]
        public string TransactionDate
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.TransactionDate : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.TransactionDate = value;
            }
        }

        [Display(Name = "Narration Description")]
        public string NarrationDescription
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.NarrationDescription : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.NarrationDescription = value;
            }
        }

        public string ModeCode
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.ModeCode : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.ModeCode = value;
            }
        }

        public Int16 AccSessionID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.AccSessionID > 0) ? AccountTransactionMasterDTO.AccSessionID : new Int16();
            }
            set
            {
                AccountTransactionMasterDTO.AccSessionID = value;
            }
        }

        public Int64 VoucherNumber
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.VoucherNumber > 0) ? AccountTransactionMasterDTO.VoucherNumber : new Int64();
            }
            set
            {
                AccountTransactionMasterDTO.VoucherNumber = value;
            }
        }

        public Int16 AccBalsheetMstID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.AccBalsheetMstID > 0) ? AccountTransactionMasterDTO.AccBalsheetMstID : new Int16();
            }
            set
            {
                AccountTransactionMasterDTO.AccBalsheetMstID = value;
            }
        }

        public string AccBalsheetName
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.AccBalsheetName : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.AccBalsheetName = value;
            }
        }

        public Int16 IsPosted
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.IsPosted : new short();
            }
            set
            {
                AccountTransactionMasterDTO.IsPosted = value;
            }
        }

        public int PostedBy
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.PostedBy > 0) ? AccountTransactionMasterDTO.PostedBy : new int();
            }
            set
            {
                AccountTransactionMasterDTO.PostedBy = value;
            }
        }

        public string PostedDate
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.PostedDate : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.PostedDate = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.IsActive : false;
            }
            set
            {
                AccountTransactionMasterDTO.IsActive = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.CreatedBy > 0) ? AccountTransactionMasterDTO.CreatedBy : new int();
            }
            set
            {
                AccountTransactionMasterDTO.CreatedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AccountTransactionMasterDTO.CreatedDate = value;
            }
        }

        public int ModifiedBy
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.ModifiedBy > 0) ? AccountTransactionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                AccountTransactionMasterDTO.ModifiedBy = value;
            }
        }

        public DateTime ModifiedDate
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AccountTransactionMasterDTO.ModifiedDate = value;
            }
        }

        public int DeletedBy
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.ModifiedBy > 0) ? AccountTransactionMasterDTO.DeletedBy : new int();
            }
            set
            {
                AccountTransactionMasterDTO.DeletedBy = value;
            }
        }

        public DateTime DeletedDate
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AccountTransactionMasterDTO.DeletedDate = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.IsDeleted : false;
            }
            set
            {
                AccountTransactionMasterDTO.IsDeleted = value;
            }
        }


        public string SelectedXmlData
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.SelectedXmlData : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.SelectedXmlData = value;
            }
        }

        public decimal VoucherAmount
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.VoucherAmount : new decimal();
            }
            set
            {
                AccountTransactionMasterDTO.VoucherAmount = value;
            }
        }

        public List<AccountTransactionMaster> ListAccountTransactionMaster { get; set; }
        public List<AccountTransactionTypeMaster> ListAccountTransactionTypeMaster
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListAccountTransactionTypeMasterItems
        {
            get
            {
                return new SelectList(ListAccountTransactionTypeMaster, "TransactionTypeCode", "TransactionTypeName");
            }
        }
        /// <summary>
        /// Properties for table AccTransactionDetails
        /// </summary>


        public Int64 AccTransDetailsID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.AccTransDetailsID > 0) ? AccountTransactionMasterDTO.AccTransDetailsID : new Int64();
            }
            set
            {
                AccountTransactionMasterDTO.AccTransDetailsID = value;
            }
        }

        public Int64 TransactionMainID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.TransactionMainID > 0) ? AccountTransactionMasterDTO.TransactionMainID : new Int64();
            }
            set
            {
                AccountTransactionMasterDTO.TransactionMainID = value;
            }
        }

        public Int16 AccountID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.AccountID > 0) ? AccountTransactionMasterDTO.AccountID : new Int16();
            }
            set
            {
                AccountTransactionMasterDTO.AccountID = value;
            }
        }

        public string AccountName
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.AccountName : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.AccountName = value;
            }
        }

        public decimal TransactionAmount
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.TransactionAmount > 0) ? AccountTransactionMasterDTO.TransactionAmount : new decimal();
            }
            set
            {
                AccountTransactionMasterDTO.TransactionAmount = value;
            }
        }

        public string DebitCreditFlag
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.DebitCreditFlag : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.DebitCreditFlag = value;
            }
        }

        public string ChequeNo
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.ChequeNo : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.ChequeNo = value;
            }
        }

        public string ChequeDatetime
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.ChequeDatetime : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.ChequeDatetime = value;
            }
        }

        // string NarrationDescription { get; set; }

        public string BankName
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.BankName : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.BankName = value;
            }
        }

        public string BranchName
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.BranchName : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.BranchName = value;
            }
        }

        public string BankClearingDatetime
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.BankClearingDatetime : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.BankClearingDatetime = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.PersonID > 0) ? AccountTransactionMasterDTO.PersonID : new int();
            }
            set
            {
                AccountTransactionMasterDTO.PersonID = value;
            }
        }

        // string ModeCode { get; set; }

        public string PersonType
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.PersonType : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.PersonType = value;
            }
        }
        // int AccSessionID { get; set; }
        // int VoucherNumber { get; set; }

        public string SubmitSlipNo
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.SubmitSlipNo : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.SubmitSlipNo = value;
            }
        }

        public string SubmitDatetime
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.SubmitDatetime : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.SubmitDatetime = value;
            }
        }

        public string ReconcilationDatetime
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.ReconcilationDatetime : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.ReconcilationDatetime = value;
            }
        }

        // int AccBalsheetMstID { get; set; }

        public string BankTransferFlag
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.BankTransferFlag : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.BankTransferFlag = value;
            }
        }

        public string ChqDepositSlipNo
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.ChqDepositSlipNo : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.ChqDepositSlipNo = value;
            }
        }

        public string ChqDepositDatetime
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.ChqDepositDatetime : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.ChqDepositDatetime = value;
            }
        }


        /// <summary>
        /// Properties for AccTransactionTypeMaster
        /// </summary>

        public int AccTransTypeID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.ModifiedBy > 0) ? AccountTransactionMasterDTO.AccTransTypeID : new int();
            }
            set
            {
                AccountTransactionMasterDTO.AccTransTypeID = value;
            }
        }

        public string TransactionTypeCode
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.TransactionTypeCode : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.TransactionTypeCode = value;
            }
        }

        public string TransactionTypeName
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.TransactionTypeName : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.TransactionTypeName = value;
            }
        }


        //--------------------------------------Extra properties-------------------------------------------------------
        public string errorMessage
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.errorMessage : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.errorMessage = value;
            }
        }
        public string SelectedBalanceSheet
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.SelectedBalanceSheet : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.SelectedBalanceSheet = value;
            }
        }
        public int SelectedBalanceSheetID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.SelectedBalanceSheetID > 0) ? AccountTransactionMasterDTO.SelectedBalanceSheetID : new int();
            }
            set
            {
                AccountTransactionMasterDTO.SelectedBalanceSheetID = value;
            }
        }
        public int TaskNotificationDetailsID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.TaskNotificationDetailsID > 0) ? AccountTransactionMasterDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                AccountTransactionMasterDTO.TaskNotificationDetailsID = value;
            }
        }
        public int TaskNotificationMasterID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.TaskNotificationMasterID > 0) ? AccountTransactionMasterDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                AccountTransactionMasterDTO.TaskNotificationMasterID = value;
            }
        }
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.GeneralTaskReportingDetailsID > 0) ? AccountTransactionMasterDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                AccountTransactionMasterDTO.GeneralTaskReportingDetailsID = value;
            }
        }
        public string TaskCode
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.TaskCode : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.TaskCode = value;
            }
        }
        public int StageSequenceNumber
        {
            get
            {
                return (AccountTransactionMasterDTO != null && AccountTransactionMasterDTO.StageSequenceNumber > 0) ? AccountTransactionMasterDTO.StageSequenceNumber : new int();
            }
            set
            {
                AccountTransactionMasterDTO.StageSequenceNumber = value;
            }
        }
        public bool IsLastRecord
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.IsLastRecord : false;
            }
            set
            {
                AccountTransactionMasterDTO.IsLastRecord = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.CentreName : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.CentreName = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.CentreCode = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.XMLstring : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.XMLstring = value;
            }
        }
        public string EntityLevel
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.EntityLevel : string.Empty;
            }
            set
            {
                AccountTransactionMasterDTO.EntityLevel = value;
            }
        }
        public bool RequestApprovedStatus
        {
            get
            {
                return (AccountTransactionMasterDTO != null) ? AccountTransactionMasterDTO.RequestApprovedStatus : false;
            }
            set
            {
                AccountTransactionMasterDTO.RequestApprovedStatus = value;
            }
        }
    }
}
