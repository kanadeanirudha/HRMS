using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountCentreOpeningBalance : BaseDTO
    {
        public int ID { get; set; }
        public Int16 AccBalsheetMstID { get; set; }
        public Nullable<Int16> AccSessionID { get; set; }
        public Int16 AccountID { get; set; }
        public Nullable<System.DateTime> OpeningDatetime { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public Nullable<decimal> TotalDebitAmount { get; set; }
        public Nullable<decimal> TotalCreditAmount { get; set; }
        public Nullable<decimal> ClosingBalance { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string SelectedXmlData { get; set; }
        public string SelectedXmlDataForIndividualBalance { get; set; }
        public string BalancesheetName { get; set; }
        public string AccountType { get; set; }
        /// <summary>
        /// properties of table AccountIndividualOpeningBalance
        /// </summary>

        public int AccIndiOpeningBalID { get; set; }
        public string PersonType { get; set; }
        public Nullable<int> PersonID { get; set; }
        public string CarryForward { get; set; }
        //public Nullable<int> AccSessionID { get; set; }
        //public Nullable<int> AccountID { get; set; }
        ////public Nullable<System.DateTime> OpeningDatetime { get; set; }
        ////public Nullable<decimal> OpeningBalance { get; set; }
        ////public Nullable<decimal> TotalDebitAmount { get; set; }
        ////public Nullable<decimal> TotalCreditAmount { get; set; }
        ////public Nullable<decimal> ClosingBalance { get; set; }



        /// <summary>
        /// properties required for USP_AccCentreOpeningBalance_SelectAll procedure
        /// </summary>
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string HeadCode { get; set; }


        /// <summary>
        /// properties required for USP_AccIndividualOpeningBalance_SelectAll procedure
        /// </summary>
        public int StudentID { get; set; }
        public string PersonName { get; set; }

        public string errorMessage { get; set; }       
    }
}
