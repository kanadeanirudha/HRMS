using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DTO
{
    /// <summary>
    /// This DTO contains bank account transection details
    /// </summary>
    public class AccountBankTransaction : BaseDTO
    {
        /// <summary>
        /// Row Unique ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Account ID
        /// </summary>
        public Nullable<int> AccountID { get; set; }

        /// <summary>
        /// Transection date
        /// </summary>
        public Nullable<System.DateTime> TransactionDate { get; set; }

        /// <summary>
        /// Transaction amount
        /// </summary>
        public Nullable<decimal> TransactionAmount { get; set; }

        /// <summary>
        /// Debit Credit Flag (Type of transaction)
        /// </summary>
        public string DebitCreditFlag { get; set; }


        /// <summary>
        /// Cheque number
        /// </summary>
        public string ChequeNo { get; set; }

        /// <summary>
        /// Cheque date time 
        /// </summary>
        public Nullable<System.DateTime> ChequeDatetime { get; set; }

        /// <summary>
        /// Reconciliation ID
        /// </summary>
        public Nullable<int> ReconciliationID { get; set; }

        /// <summary>
        /// Reconciliation date
        /// </summary>
        public Nullable<System.DateTime> ReconciliationDate { get; set; }

        /// <summary>
        /// Narration description
        /// </summary>
        public string NarrationDescription { get; set; }

        /// <summary>
        /// Account balance sheet master id
        /// </summary>
        public Nullable<int> AccBalsheetMstID { get; set; }

        /// <summary>
        /// Set status of record is currently active or not
        /// </summary>
        public Nullable<bool> IsActive { get; set; }

        /// <summary>
        /// User id of person who created the record
        /// </summary>
        public Nullable<int> CreatedBy { get; set; }

        /// <summary>
        /// Creation date of record
        /// </summary>
        public Nullable<System.DateTime> CreatedDate { get; set; }

        /// <summary>
        /// User id of person who modified the record
        /// </summary>
        public Nullable<int> ModifiedBy { get; set; }

        /// <summary>
        /// Modification date of record
        /// </summary>
        public Nullable<System.DateTime> ModifiedDate { get; set; }

        /// <summary>
        /// User id of person who deleted the record
        /// </summary>
        public Nullable<int> DeletedBy { get; set; }

        /// <summary>
        /// Deletion date of record
        /// </summary>
        public Nullable<System.DateTime> DeletedDate { get; set; }

        /// <summary>
        /// Status for deletion of record
        /// </summary>
        public Nullable<bool> IsDeleted { get; set; }
    }
}
