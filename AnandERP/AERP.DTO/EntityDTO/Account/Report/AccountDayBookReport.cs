using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountDayBookReport : BaseDTO
    {

        public string SessionFromDate { get; set; }
        public string SessionUptoDate { get; set; }
        public string Pattern { get; set; }
        public string PatternType { get; set; }
        public string AccountIDsXmlString { get; set; }
        public string TransactionTypeXmlString { get; set; }
        public string AccountBalsheetMstIDXmlString { get; set; }
        public bool PageLoaded { get; set; }
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
        public string VoucherNumber { get; set; }
        public Int16 AccBalsheetMstID { get; set; }
        public string AccBalsheetName { get; set; }
        public bool IsPosted { get; set; }
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

        /// <summary>
        /// Properties for table AccTransactionDetails
        /// </summary>

        public Int64 AccTransDetailsID { get; set; }
        public Int64 TransactionMainID { get; set; }
        public Int16 AccountID { get; set; }
        public string AccountName { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal DebitTransactionAmount { get; set; }
        public decimal CreditTransactionAmount { get; set; }
        public string DebitCreditFlag { get; set; }
        public decimal OuterReceiptAmount { get; set; }
        public decimal OuterPaymentAmount { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDatetime { get; set; }
        //public string NarrationDescription { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public DateTime BankClearingDatetime { get; set; }
        public int PersonID { get; set; }
        //public string ModeCode { get; set; }
        public string PersonType { get; set; }
        //public int AccSessionID { get; set; }
        //public int VoucherNumber { get; set; }
        public string SubmitSlipNo { get; set; }
        public DateTime SubmitDatetime { get; set; }
        public DateTime ReconcilationDatetime { get; set; }
        //public int AccBalsheetMstID { get; set; }
        public string BankTransferFlag { get; set; }
        public string ChqDepositSlipNo { get; set; }
        public DateTime ChqDepositDatetime { get; set; }


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
    }
}
