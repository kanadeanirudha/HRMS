using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AccountChequeBookMasterBaseViewModel: IAccountChequeBookMasterBaseViewModel
    {
        public AccountChequeBookMasterBaseViewModel()
        {
            ListAccountChequeBookMaster = new List<AccountChequeBookMaster>();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();
        }
        public List<AccountChequeBookMaster> ListAccountChequeBookMaster
        {
            get;
            set;
        }

        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }

        public List<AccountBalancesheetMaster> ListAccountBalancesheetMaster
        {
            get;
            set;
        }

        public string SelectedCentreCode
        {
            get;
            set;
        }

        public string SelectedBalanceSheet
        {
            get;
            set;
        }
        
        public IEnumerable<SelectListItem> ListOrgStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListAccountBalancesheetMasterItems
        {
            get
            {
                return new SelectList(ListAccountBalancesheetMaster, "ID", "AccBalsheetHeadDesc");
            }
        }
    }

    public class AccountChequeBookMasterViewModel : IAccountChequeBookMasterViewModel
    {
        public AccountChequeBookMasterViewModel()
        {
            AccountChequeBookMasterDTO = new AccountChequeBookMaster();
        }

        public AccountChequeBookMaster AccountChequeBookMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (AccountChequeBookMasterDTO != null && AccountChequeBookMasterDTO.ID > 0) ? AccountChequeBookMasterDTO.ID : new int();
            }
            set
            {
                AccountChequeBookMasterDTO.ID = value;
            }
        }
        public Nullable<Int16> AccountID
        {
            get
            {
                return (AccountChequeBookMasterDTO != null && AccountChequeBookMasterDTO.AccountID > 0) ? AccountChequeBookMasterDTO.AccountID : new Int16();
            }
            set
            {
                AccountChequeBookMasterDTO.AccountID = value;
            }
        }

        [Display(Name = "Account Name")]
        public string AccountName
        {
            get
            {
                return (AccountChequeBookMasterDTO != null) ? AccountChequeBookMasterDTO.AccountName : string.Empty;
            }
            set
            {
                AccountChequeBookMasterDTO.AccountName = value;
            }
        }

        public string AccountCode
        {
            get
            {
                return (AccountChequeBookMasterDTO != null) ? AccountChequeBookMasterDTO.AccountCode : string.Empty;
            }
            set
            {
                AccountChequeBookMasterDTO.AccountCode = value;
            }
        }

        [Display(Name = "Start Number :")]
        [Required(ErrorMessage = "Start Number Required")]
        public Nullable<int> ChequeFromNo
        {
            get
            {
                return (AccountChequeBookMasterDTO != null && AccountChequeBookMasterDTO.ChequeFromNo > 0) ? AccountChequeBookMasterDTO.ChequeFromNo : new int();
            }
            set
            {
                AccountChequeBookMasterDTO.ChequeFromNo = value;
            }
        }

        [Display(Name = "End Number")]
        public Nullable<int> ChequeToNo
        {
            get
            {
                return (AccountChequeBookMasterDTO != null && AccountChequeBookMasterDTO.ChequeToNo > 0) ? AccountChequeBookMasterDTO.ChequeToNo : new int();
            }
            set
            {
                AccountChequeBookMasterDTO.ChequeToNo = value;
            }
        }

        [Display(Name = "Total Number Of Cheque")]
        [Required(ErrorMessage = "Total Number Of Cheque Required")]
        public Nullable<Int16> TotalNoCheque
        {
            get
            {
                return (AccountChequeBookMasterDTO != null && AccountChequeBookMasterDTO.TotalNoCheque > 0) ? AccountChequeBookMasterDTO.TotalNoCheque : new Int16();
            }
            set
            {
                AccountChequeBookMasterDTO.TotalNoCheque = value;
            }
        }
        public bool ActiveFlag
        {
            get
            {
                return (AccountChequeBookMasterDTO != null) ? Convert.ToBoolean(AccountChequeBookMasterDTO.ActiveFlag) : false;
            }
            set
            {
                AccountChequeBookMasterDTO.ActiveFlag = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (AccountChequeBookMasterDTO != null) ? AccountChequeBookMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                AccountChequeBookMasterDTO.CentreCode = value;
            }
        }
        public Nullable<Int16> AccBalsheetMstID
        {
            get
            {
                return (AccountChequeBookMasterDTO != null && AccountChequeBookMasterDTO.AccBalsheetMstID > 0) ? AccountChequeBookMasterDTO.AccBalsheetMstID : new Int16();
            }
            set
            {
                AccountChequeBookMasterDTO.AccBalsheetMstID = value;
            }
        }

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (AccountChequeBookMasterDTO != null) ? AccountChequeBookMasterDTO.IsActive : false;
            }
            set
            {
                AccountChequeBookMasterDTO.IsActive = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountChequeBookMasterDTO != null && AccountChequeBookMasterDTO.CreatedBy > 0) ? AccountChequeBookMasterDTO.CreatedBy : new int();
            }
            set
            {
                AccountChequeBookMasterDTO.CreatedBy = value;
            }
        }
        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountChequeBookMasterDTO != null) ? AccountChequeBookMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AccountChequeBookMasterDTO.CreatedDate = value;
            }
        }
        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountChequeBookMasterDTO != null && AccountChequeBookMasterDTO.ModifiedBy > 0) ? AccountChequeBookMasterDTO.ModifiedBy : new int();
            }
            set
            {
                AccountChequeBookMasterDTO.ModifiedBy = value;
            }
        }
        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountChequeBookMasterDTO != null) ? AccountChequeBookMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AccountChequeBookMasterDTO.ModifiedDate = value;
            }
        }
        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountChequeBookMasterDTO != null && AccountChequeBookMasterDTO.DeletedBy > 0) ? AccountChequeBookMasterDTO.DeletedBy : new int();
            }
            set
            {
                AccountChequeBookMasterDTO.DeletedBy = value;
            }
        }
        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountChequeBookMasterDTO != null) ? AccountChequeBookMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AccountChequeBookMasterDTO.DeletedDate = value;
            }
        }
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccountChequeBookMasterDTO != null) ? AccountChequeBookMasterDTO.IsDeleted : false;
            }
            set
            {
                AccountChequeBookMasterDTO.IsDeleted = value;
            }
        }

        public string SelectedCentreCode
        {
            get;
            set;
        }

        [Display(Name = "Selected BalanceSheet")]
        public string SelectedBalanceSheet
        {
            get;
            set;
        }
    }
}
