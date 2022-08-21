using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DTO
{
    public class AccountTransactionDetails : BaseDTO
    {
        public int id { get; set; }
        public Nullable<int> TransactionMainID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<decimal> TransactionAmount { get; set; }
        public string DebitCreditFlag { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<System.DateTime> ChequeDatetime { get; set; }
        public string NarrationDescription { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public Nullable<System.DateTime> BankClearingDatetime { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> PersonID { get; set; }
        public string ModeCode { get; set; }
        public string PersonType { get; set; }
        public Nullable<int> AccSessionID { get; set; }
        public Nullable<int> VoucherNumber { get; set; }
        public string SubmitSlipNo { get; set; }
        public Nullable<System.DateTime> SubmitDatetime { get; set; }
        public Nullable<System.DateTime> ReconcilationDatetime { get; set; }
        public Nullable<int> AccBalsheetMstID { get; set; }
        public string BankTransferFlag { get; set; }
        public string ChqDepositSlipNo { get; set; }
        public Nullable<System.DateTime> ChqDepositDatetime { get; set; }
    }
}
