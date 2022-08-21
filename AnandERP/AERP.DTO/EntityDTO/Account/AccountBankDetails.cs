using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DTO
{
    public class AccountBankDetails: BaseDTO
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
        /// Bank account number
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Bank account holder name
        /// </summary>
        public string AccountInNameOf { get; set; }

        /// <summary>
        /// Bank account branch name
        /// </summary>
        public string BankBranchName { get; set; }

        /// <summary>
        /// Bank limit amount
        /// </summary>
        public Nullable<int> BankLimitAmount { get; set; }

        /// <summary>
        /// rate of interest
        /// </summary>
        public Nullable<decimal> RateOfInterest { get; set; }

        /// <summary>
        /// Interest mode
        /// </summary>
        public string InterestMode { get; set; }

        /// <summary>
        /// Interest type
        /// </summary>
        public string InterestType { get; set; }

        /// <summary>
        /// Account opening date
        /// </summary>
        public Nullable<System.DateTime> OpenDatetime { get; set; }

        /// <summary>
        /// Due opening date
        /// </summary>
        public Nullable<System.DateTime> DueDatetime { get; set; }

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
