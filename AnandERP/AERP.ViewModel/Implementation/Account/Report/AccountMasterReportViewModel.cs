using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AccountMasterReportViewModel: IAccountMasterReportViewModel
    {

        public AccountMasterReportViewModel()
        {
            ListAccountMasterReport = new List<AccountMasterReport>();
          
        }
        public List<AccountMasterReport> ListAccountMasterReport
        {
            get;
            set;
        }
      
      
        public string SelectedBalanceSheet
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListAccountMasterReportItems
        {
            get
            {
                return new SelectList(ListAccountMasterReport, "ID", "AccountDescription");
            }
        }
      

        public AccountMasterReport AccountMasterReportDTO { get; set; }

        /// <summary>
        /// properties of AccAccountMaster
        /// </summary>
        public Int16 ID 
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.ID > 0) ? AccountMasterReportDTO.ID : new Int16();
            }
            set
            {
                AccountMasterReportDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_AccountCode", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AccountCodeRequired")]
        public string AccountCode 
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.AccountCode : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.AccountCode = value;
            }
        }

        [Display(Name = "DisplayName_AccountName", ResourceType = typeof(AERP.Common.Resources))]

        public string AccountName 
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.AccountName : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.AccountName = value;
            } 
        }

        [Required(ErrorMessage = "Group ID is required")]
        public Int16 GroupID
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.GroupID > 0) ? AccountMasterReportDTO.GroupID : new Int16();
            }
            set
            {
                AccountMasterReportDTO.GroupID = value;
            }
        }

        [Display(Name = "DisplayName_DebitCreditFlag", ResourceType = typeof(AERP.Common.Resources))]
        public string DebitCreditFlag
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.DebitCreditFlag :string.Empty;
            }
            set
            {
                AccountMasterReportDTO.DebitCreditFlag = value;
            }
        }


        public string CashBankFlag
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.CashBankFlag : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.CashBankFlag = value;
            }
        }

        [Display(Name = "DisplayName_BackDatetimedEntries", ResourceType = typeof(AERP.Common.Resources))]
        public bool BackDatetimedEntries
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.BackDatetimedEntries : false;
            }
            set
            {
                AccountMasterReportDTO.BackDatetimedEntries = value;
            }
        }
        public Int16 PrintingSequence
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.PrintingSequence > 0) ? AccountMasterReportDTO.PrintingSequence : new Int16();
            }
            set
            {
                AccountMasterReportDTO.PrintingSequence = value;
            }
        }
        public string PersonType
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.PersonType : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.PersonType = value;
            }
        }
        public bool OpBalRequired
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.OpBalRequired : false;
            }
            set
            {
                AccountMasterReportDTO.OpBalRequired = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.IsActive : false;
            }
            set
            {
                AccountMasterReportDTO.IsActive = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.CreatedBy > 0) ? AccountMasterReportDTO.CreatedBy : new int();
            }
            set
            {
                AccountMasterReportDTO.CreatedBy = value;
            }
        }
        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.CreatedDate : null;
            }
            set
            {
                AccountMasterReportDTO.CreatedDate = value;
            }
        }
        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.ModifiedBy > 0) ? AccountMasterReportDTO.ModifiedBy : new int();
            }
            set
            {
                AccountMasterReportDTO.ModifiedBy = value;
            }
        }
        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.ModifiedDate : null;
            }
            set
            {
                AccountMasterReportDTO.ModifiedDate = value;
            }
        }
        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.DeletedBy > 0) ? AccountMasterReportDTO.DeletedBy : new int();
            }
            set
            {
                AccountMasterReportDTO.DeletedBy = value;
            }
        }
        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.DeletedDate : null;
            }
            set
            {
                AccountMasterReportDTO.DeletedDate = value;
            }
        }
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.IsDeleted : false;
            }
            set
            {
                AccountMasterReportDTO.IsDeleted = value;
            }
        }

        [Display(Name = "DisplayName_ExclusivelyForBalancesheet", ResourceType = typeof(AERP.Common.Resources))]
        public bool ExclusivelyForCentre
        {
            get
            {
                return (AccountMasterReportDTO != null) ? Convert.ToBoolean(AccountMasterReportDTO.ExclusivelyForCentre) : false;
            }
            set
            {
                AccountMasterReportDTO.ExclusivelyForCentre = value;
            }
        }
        public string IgnoreChequeNo
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.IgnoreChequeNo : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.IgnoreChequeNo = value;
            }
        }
        public Int16 AltGroupID
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.AltGroupID > 0) ? AccountMasterReportDTO.AltGroupID : new Int16();
            }
            set
            {
                AccountMasterReportDTO.AltGroupID = value;
            }
        }
        public bool TrialBalSubledger
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.TrialBalSubledger : false;
            }
            set
            {
                AccountMasterReportDTO.TrialBalSubledger = value;
            }
        }

        [Display(Name = "DisplayName_SurpDifiFlag", ResourceType = typeof(AERP.Common.Resources))]
        public string SurpDifiFlag
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.SurpDifiFlag : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.SurpDifiFlag = value;
            }
        }
        
        public string SelectedXml
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.SelectedXml : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.SelectedXml = value;
            }
        }

        public List<AccountBalancesheetMaster> ListAccountBalancesheetMaster
        {
            get;
            set;
        }
        public List<AccountMaster> ListAccountMaster
        {
            get;
            set;
        }
        /// <summary>
        /// properties of AccAccountCentrewise
        /// </summary>  
        public Int16 AccAccountCentreID 
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.AccAccountCentreID > 0) ? AccountMasterReportDTO.AccAccountCentreID : new Int16();
            }
            set
            {
                AccountMasterReportDTO.AccAccountCentreID = value;
            }
        }
        public Int16 AccBalsheetMstID
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.AccBalsheetMstID > 0) ? AccountMasterReportDTO.AccBalsheetMstID : new Int16();
            }
            set
            {
                AccountMasterReportDTO.AccBalsheetMstID = value;
            }
        }

        public int AccCenterwiseID
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.AccCenterwiseID > 0) ? AccountMasterReportDTO.AccCenterwiseID : new int();
            }
            set
            {
                AccountMasterReportDTO.AccCenterwiseID = value;
            }
        }
        public int BankDetailsID
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.BankDetailsID > 0) ? AccountMasterReportDTO.BankDetailsID : new int();
            }
            set
            {
                AccountMasterReportDTO.BankDetailsID = value;
            }
        }
        public string GroupDescription
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.GroupDescription : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.GroupDescription = value;
            }
        }


        /// <summary>
        /// properties of AccBankDetails
        /// </summary>
        public Int16 AccBankDetailsID
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.AccBankDetailsID > 0) ? AccountMasterReportDTO.AccBankDetailsID : new Int16();
            }
            set
            {
                AccountMasterReportDTO.AccBankDetailsID = value;
            }
        }

        [Display(Name = "DisplayName_BankAccountNumber", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BankAccountNumberRequired")]
        public string BankAccountNumber
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.BankAccountNumber : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.BankAccountNumber = value;
            }
        }

        [Display(Name = "DisplayName_AccountInNameOf", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AccountInNameOfRequired")]
        public string AccountInNameOf
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.AccountInNameOf : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.AccountInNameOf = value;
            }
        }

        [Display(Name = "DisplayName_BankBranchName", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BankBranchNameRequired")]
        public string BankBranchName
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.BankBranchName : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.BankBranchName = value;
            }
        }

        [Display(Name = "DisplayName_BankLimitAmount", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BankLimitAmountRequired")]
        public decimal BankLimitAmount
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.BankLimitAmount > 0) ? AccountMasterReportDTO.BankLimitAmount : new decimal();
            }
            set
            {
                AccountMasterReportDTO.BankLimitAmount = value;
            }
        }

        [Display(Name = "DisplayName_RateOfInterest", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RateOfInterestRequired")]
        public decimal RateOfInterest
        {
            get
            {
                return (AccountMasterReportDTO != null && AccountMasterReportDTO.RateOfInterest > 0) ? AccountMasterReportDTO.RateOfInterest : new decimal();
            }
            set
            {
                AccountMasterReportDTO.RateOfInterest = value;
            }
        }

        [Display(Name = "DisplayName_InterestMode", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_InterestModeRequired")]
        public string InterestMode
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.InterestMode : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.InterestMode = value;
            }
        }

        [Display(Name = "DisplayName_InterestType", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_InterestTypeRequired")]
        public string InterestType
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.InterestType : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.InterestType = value;
            }
        }

        [Display(Name = "DisplayName_OpenDatetime", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OpenDatetimeRequired")]
        public string OpenDatetime
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.OpenDatetime : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.OpenDatetime = value;
            }
        }

        [Display(Name = "DisplayName_DueDatetime", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DueDatetimeRequired")]
        public string DueDatetime
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.DueDatetime :string.Empty;
            }
            set
            {
                AccountMasterReportDTO.DueDatetime = value;
            }
        }

        [Display(Name = "DisplayName_AccountType", ResourceType = typeof(AERP.Common.Resources))]
        public string AccountType
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.AccountType : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.AccountType = value;
            }
        }

        [Display(Name = "DisplayName_ControlHead", ResourceType = typeof(AERP.Common.Resources))]
        public string ControlHead
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.ControlHead : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.ControlHead = value;
            }
        }

        [Display(Name = "DisplayName_Credit", ResourceType = typeof(AERP.Common.Resources))]
        public string Credit
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.Credit : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.Credit = value;
            }
        }

        [Display(Name = "DisplayName_Debit", ResourceType = typeof(AERP.Common.Resources))]
        public string Debit
        {
            get
            {
                return (AccountMasterReportDTO != null) ? AccountMasterReportDTO.Debit : string.Empty;
            }
            set
            {
                AccountMasterReportDTO.Debit = value;
            }
        }
    }
}
