using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{


    public class AccountCentreOpeningBalanceViewModel : IAccountCentreOpeningBalanceViewModel
    {
        public AccountCentreOpeningBalanceViewModel()
        {
            AccountCentreOpeningBalanceDTO = new AccountCentreOpeningBalance();
            ListAccountGroupMaster = new List<AccountGroupMaster>();
            ListAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();
            ListAccountType = new List<AccountCentreOpeningBalance>();
        }

        public List<AccountGroupMaster> ListAccountGroupMaster
        {
            get;
            set;
        }
        public List<AccountCentreOpeningBalance> ListAccountType
        {
            get;
            set;

        }
        //   List<SelectListItem> AccountTypeList = new List<SelectListItem>();
        //AccountTypeList.Add(new SelectListItem { Text = "Non Control Head Type", Value = "0" });
        //AccountTypeList.Add(new SelectListItem { Text = "Control Head Type", Value = "1" });
        public List<AccountBalancesheetMaster> ListAccountBalancesheetMaster
        {
            get;
            set;
        }
        public string SelectedGroupID
        {
            get;
            set;
        }
        public string SelectedBalanceSheet
        {
            get;
            set;
        }

        //public string SessionName { get; set; }
        //public Int16 SessionID { get; set; }

        public IEnumerable<SelectListItem> ListAccountTypeItems
        {

            get
            {
                List<SelectListItem> AccountTypeList = new List<SelectListItem>();
                AccountTypeList.Add(new SelectListItem { Text = Resources.ddlHeaders_AccountType, Value = "" });
                AccountTypeList.Add(new SelectListItem { Text = Resources.DropdownMessage_NonControlHeadType, Value = "0" });
                AccountTypeList.Add(new SelectListItem { Text = Resources.DropdownMessage_ControlHeadType, Value = "1" });
                return new SelectList(AccountTypeList, "Value", "Text");
            }
        }
        public IEnumerable<SelectListItem> ListAccountGroupMasterItems
        {
            get
            {
                return new SelectList(ListAccountGroupMaster, "GroupID", "GroupName");
            }
        }
        public IEnumerable<SelectListItem> ListAccountBalancesheetMasterItems
        {
            get
            {
                return new SelectList(ListAccountBalancesheetMaster, "ID", "AccBalsheetHeadDesc");
            }
        }
        public AccountCentreOpeningBalance AccountCentreOpeningBalanceDTO { get; set; }
        public AccountSessionMaster AccountSessionMasterDTO { get; set; }
        public string SessionName { get; set; }
        public Int16 SessionID { get; set; }
        /// <summary>
        /// properties of AccCentreOpeningBalance
        /// </summary>
        public int ID
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.ID > 0) ? AccountCentreOpeningBalanceDTO.ID : new int();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.ID = value;
            }
        }
        public Int16 AccBalsheetMstID
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.AccBalsheetMstID > 0) ? AccountCentreOpeningBalanceDTO.AccBalsheetMstID : new Int16();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.AccBalsheetMstID = value;
            }
        }

        public Int16? AccSessionID
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.AccSessionID > 0) ? AccountCentreOpeningBalanceDTO.AccSessionID : new Int16();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.AccSessionID = value;
            }
        }

        public Int16 AccountID
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.AccountID > 0) ? AccountCentreOpeningBalanceDTO.AccountID : new Int16();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.AccountID = value;
            }
        }

        public Nullable<System.DateTime> OpeningDatetime
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.OpeningDatetime : null;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.OpeningDatetime = value;
            }
        }

        public decimal? TotalDebitAmount
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.TotalDebitAmount > 0) ? AccountCentreOpeningBalanceDTO.TotalDebitAmount : new decimal();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.TotalDebitAmount = value;
            }
        }

        public decimal? TotalCreditAmount
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.TotalCreditAmount > 0) ? AccountCentreOpeningBalanceDTO.TotalCreditAmount : new decimal();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.TotalCreditAmount = value;
            }
        }
        public decimal? ClosingBalance
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.ClosingBalance > 0) ? AccountCentreOpeningBalanceDTO.ClosingBalance : new decimal();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.ClosingBalance = value;
            }
        }




        public decimal? OpeningBalance
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.ID > 0) ? AccountCentreOpeningBalanceDTO.OpeningBalance : new decimal();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.OpeningBalance = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.IsActive : false;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.IsActive = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.CreatedBy > 0) ? AccountCentreOpeningBalanceDTO.CreatedBy : new int();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.CreatedBy = value;
            }
        }
        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.CreatedDate : null;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.CreatedDate = value;
            }
        }
        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.ModifiedBy > 0) ? AccountCentreOpeningBalanceDTO.ModifiedBy : new int();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.ModifiedBy = value;
            }
        }
        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.ModifiedDate : null;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.ModifiedDate = value;
            }
        }
        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.DeletedBy > 0) ? AccountCentreOpeningBalanceDTO.DeletedBy : new int();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.DeletedBy = value;
            }
        }
        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.DeletedDate : null;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.DeletedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.IsDeleted : false;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.IsDeleted = value;
            }
        }

        public string SelectedXmlData
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.SelectedXmlData : string.Empty;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.SelectedXmlData = value;
            }
        }
        [Required(ErrorMessage = "hfdghdhfd")]
        public string SelectedAccountType
        {
            get;
            set;
        }
        //public string AccountType
        //{
        //    get
        //    {
        //        return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.AccountType : string.Empty;
        //    }
        //    set
        //    {
        //        AccountCentreOpeningBalanceDTO.AccountType = value;
        //    }
        //}

        public string SelectedXmlDataForIndividualBalance
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.SelectedXmlDataForIndividualBalance : string.Empty;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.SelectedXmlDataForIndividualBalance = value;
            }
        }

        [Display(Name = "Balancesheet Name")]
        public string BalancesheetName
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.BalancesheetName : string.Empty;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.BalancesheetName = value;
            }
        }

        /// <summary>
        /// properties of AccIndividualOpeningBalance
        /// </summary>  



        public int AccIndiOpeningBalID
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.AccIndiOpeningBalID > 0) ? AccountCentreOpeningBalanceDTO.AccIndiOpeningBalID : new int();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.AccIndiOpeningBalID = value;
            }
        }

        public string PersonType
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.PersonType : string.Empty;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.PersonType = value;
            }
        }
        public int? PersonID
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.PersonID > 0) ? AccountCentreOpeningBalanceDTO.PersonID : new int();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.PersonID = value;
            }
        }

        public string CarryForward
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.CarryForward : string.Empty;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.CarryForward = value;
            }
        }

        /// <summary>
        /// properties required for select all procedure
        /// </summary>

        public string AccountCode
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.AccountCode : string.Empty;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.AccountCode = value;
            }
        }

        [Display(Name = "Account Name")]
        public string AccountName
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.AccountName : string.Empty;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.AccountName = value;
            }
        }
        public string HeadCode
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.HeadCode : string.Empty;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.HeadCode = value;
            }
        }



        /// <summary>
        /// properties required for USP_AccIndividualOpeningBalance_SelectAll procedure
        /// </summary>

        public int StudentID
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null && AccountCentreOpeningBalanceDTO.StudentID > 0) ? AccountCentreOpeningBalanceDTO.StudentID : new int();
            }
            set
            {
                AccountCentreOpeningBalanceDTO.StudentID = value;
            }
        }

        public string PersonName
        {
            get
            {
                return (AccountCentreOpeningBalanceDTO != null) ? AccountCentreOpeningBalanceDTO.PersonName : string.Empty;
            }
            set
            {
                AccountCentreOpeningBalanceDTO.PersonName = value;
            }
        }


    }
}
