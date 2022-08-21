using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountTransactionMaster : BaseDTO
    {
        
        /// <summary>
        /// Properties for table AccTransactionMaster
        /// </summary>
        
        public Int64 ID { get; set; }
        public char TransactionType { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionMasterNarration { get; set; }
        public string NarrationDescription { get; set; }
        public string ModeCode { get; set; }
        public Int16 AccSessionID { get; set; }
        public Int64 VoucherNumber { get; set; }
        public Int16 AccBalsheetMstID { get; set; }
        public string AccBalsheetName { get; set; }
        public Int16 IsPosted { get; set; }
        public int PostedBy { get; set; }
        public string PostedDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int Status { get; set; }

        public string SelectedXmlData { get; set; }
        public decimal VoucherAmount { get; set; } 

        /// <summary>
        /// Properties for table AccTransactionDetails
        /// </summary>
       
        public Int64 AccTransDetailsID { get; set; }
        public Int64 TransactionMainID { get; set; }
        public Int16 AccountID { get; set; }
        public string AccountName { get; set; }
        public decimal TransactionAmount { get; set; }
        public string DebitCreditFlag { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDatetime { get; set; }
        //public string NarrationDescription { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BankClearingDatetime { get; set; }
        public int PersonID { get; set; }
        //public string ModeCode { get; set; }
        public string PersonType { get; set; }
        //public int AccSessionID { get; set; }
        //public int VoucherNumber { get; set; }
        public string SubmitSlipNo { get; set; }
        public string SubmitDatetime { get; set; }
        public string ReconcilationDatetime { get; set; }
        //public int AccBalsheetMstID { get; set; }
        public string BankTransferFlag { get; set; }
        public string ChqDepositSlipNo { get; set; }
        public string ChqDepositDatetime { get; set; }
        

        /// <summary>
        /// Properties for AccTransactionTypeMaster
        /// </summary>

        public int AccTransTypeID { get; set; }
        public string TransactionTypeCode { get; set; }
        public string TransactionTypeName { get; set; }

        public string SubLedgerName { get; set; }
        public string CashBankFlag { get; set; }

        public string ErrorMessage { get; set; }
        public string errorMessage { get; set; }

        public int ReferencePersonID { get; set; }
        //public string ModeCode { get; set; }
        public string ReferencePersonType { get; set; }
        //--------------------------------------Extra properties-------------------------------------------------------
        public string SelectedBalanceSheet { get; set; }
        public int SelectedBalanceSheetID { get; set; }
        public int TaskNotificationDetailsID { get; set; }
        public int TaskNotificationMasterID { get; set; }
        public int GeneralTaskReportingDetailsID { get; set; }
        public string TaskCode { get; set; }
        public int StageSequenceNumber { get; set; }
        public bool IsLastRecord { get; set; }
        public bool RequestApprovedStatus { get; set; }
        public string CentreName { get; set; }
        public string CentreCode { get; set; }
        public string XMLstring { get; set; }
        public string EntityLevel { get; set; }
        public string AccountSpecificNarration { get; set; }

    }
}
