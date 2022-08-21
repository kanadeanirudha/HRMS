using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{

    public interface IAccountMasterBaseViewModel
    {

    }

    public interface IAccountMasterViewModel
    {
        AccountMaster AccountMasterDTO { get; set; }
        Int16 ID { get; set; }
        string AccountCode { get; set; }
        string AccountName { get; set; }
        Int16 GroupID { get; set; }
        string DebitCreditFlag { get; set; }
        string CashBankFlag { get; set; }
        bool BackDatetimedEntries { get; set; }
        Int16 PrintingSequence { get; set; }
        string PersonType { get; set; }
        bool OpBalRequired { get; set; }
        bool IsActive { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<System.DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        bool ExclusivelyForCentre { get; set; }
        string IgnoreChequeNo { get; set; }
        Int16 AltGroupID { get; set; }
        bool TrialBalSubledger { get; set; }
        string SurpDifiFlag { get; set; }
        string SelectedXml { get; set; }

        /// <summary>
        /// properties of AccAccountCentrewise
        /// </summary>  
         Int16 AccAccountCentreID { get; set; }        
        Int16  AccBalsheetMstID { get; set; }

        int AccCenterwiseID { get; set; }
        int BankDetailsID { get; set; }
        string GroupDescription { get; set; }

        /// <summary>
        /// properties of AccBankDetails
        /// </summary>
        Int16 AccBankDetailsID { get; set; }      
        string BankAccountNumber { get; set; }
        string AccountInNameOf { get; set; }
        string BankBranchName { get; set; }
        decimal BankLimitAmount { get; set; }
        decimal RateOfInterest { get; set; }
        string InterestMode { get; set; }
        string InterestType { get; set; }
        string OpenDatetime { get; set; }
        string DueDatetime { get; set; }




    }
}
