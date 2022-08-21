using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountMasterReport : BaseDTO
    {
        /// <summary>
        /// properties of AccAccountMaster
        /// </summary>      
        public Int16 ID { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public Int16 GroupID { get; set; }
        public string DebitCreditFlag { get; set; }
        public string CashBankFlag { get; set; }
        public bool BackDatetimedEntries { get; set; }
        public Int16 PrintingSequence { get; set; }
        public string PersonType { get; set; }
        public bool OpBalRequired { get; set; }
        public bool ExclusivelyForCentre { get; set; }
        public string IgnoreChequeNo { get; set; }
        public Int16 AltGroupID { get; set; }
        public bool TrialBalSubledger { get; set; }
        public string SurpDifiFlag { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string SelectedXml { get; set;}
        public string CategoryDescription { get; set; }
        public string CategoryCode { get; set; }
        public string GroupCode { get; set; }
        public string HeadName { get; set; }
        /// <summary>
        /// properties of AccAccountCentrewise
        /// </summary>      
        public Int16 AccAccountCentreID { get; set; }        
        public Int16 AccBalsheetMstID { get; set; }
        public string AccBalsheetHeadDesc { get; set; }
        public string CentreCode { get; set; }
        public int AccCenterwiseID { get; set; }
        public int BankDetailsID { get; set; }
        public string GroupDescription { get; set; }


        /// <summary>
        /// properties of AccBankDetails
        /// </summary>
        public Int16 AccBankDetailsID { get; set; }    
        public string BankAccountNumber { get; set; }
        public string AccountInNameOf { get; set; }
        public string BankBranchName { get; set; }
        public decimal BankLimitAmount { get; set; }
        public decimal RateOfInterest { get; set; }
        public string InterestMode { get; set; }
        public string InterestType { get; set; }
        public string OpenDatetime { get; set; }
        public string DueDatetime { get; set; }

        public string errorMessage { get; set; }
        public string AccountType { get; set; }
        public string ControlHead { get; set; }
        public string Credit { get; set; }
        public string Debit { get; set; }
    }

   

}
