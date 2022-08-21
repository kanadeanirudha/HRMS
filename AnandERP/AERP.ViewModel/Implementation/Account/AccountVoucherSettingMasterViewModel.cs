using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class AccountVoucherSettingMasterViewModel : IAccountVoucherSettingMasterViewModel
    {

        public AccountVoucherSettingMasterViewModel()
        {
            AccountVoucherSettingMasterDTO = new AccountVoucherSettingMaster();
            ListGetSession =new List<AccountSessionMaster>();
        }
        public List<AccountSessionMaster> ListGetSession
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> AccountSessionMasterItems
        {
            get
            {
                return new SelectList(ListGetSession, "ID", "SessionName");
            }
        }
        public AccountVoucherSettingMaster AccountVoucherSettingMasterDTO
        {
            get;
            set;
        }

        public Int32 ID
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null && AccountVoucherSettingMasterDTO.ID > 0) ? AccountVoucherSettingMasterDTO.ID : new Int32();
            }
            set
            {
                AccountVoucherSettingMasterDTO.ID = value;
            }
        }
        [Display(Name = "Account Session")]
        public Nullable<int> AccSessionID
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null && AccountVoucherSettingMasterDTO.AccSessionID > 0) ? AccountVoucherSettingMasterDTO.AccSessionID : new int();
            }
            set
            {
                AccountVoucherSettingMasterDTO.AccSessionID = value;
            }
        }
        public Nullable<int> AccBalsheetMstID
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null && AccountVoucherSettingMasterDTO.AccBalsheetMstID > 0) ? AccountVoucherSettingMasterDTO.AccBalsheetMstID : new int();
            }
            set
            {
                AccountVoucherSettingMasterDTO.AccBalsheetMstID = value;
            }
        }
         [Display(Name = "Voucher Number")]
        public Nullable<int> VoucherNumber
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null && AccountVoucherSettingMasterDTO.VoucherNumber > 0) ? AccountVoucherSettingMasterDTO.VoucherNumber : new int();
            }
            set
            {
                AccountVoucherSettingMasterDTO.VoucherNumber = value;
            }
        }
        public Nullable<bool> IsActive
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.IsActive : false;
            }
            set
            {
                AccountVoucherSettingMasterDTO.IsActive = value;
            }
        }

        //[Required(ErrorMessage = "Merchandise Base Category Name should not be blank.")]
        //[Display(Name = "Merchandise Base Category Name")]
        [Display(Name = "Transaction Type")]
        public string TransactionType
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.TransactionType : string.Empty;
            }
            set
            {
                AccountVoucherSettingMasterDTO.TransactionType = value;
            }
        }
          [Display(Name = "Balancesheet Name")]
        public string AccBalsheetMstName
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.AccBalsheetMstName : string.Empty;
            }
            set
            {
                AccountVoucherSettingMasterDTO.AccBalsheetMstName = value;
            }
        }
        public string AccSessionName
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.AccSessionName : string.Empty;
            }
            set
            {
                AccountVoucherSettingMasterDTO.AccSessionName = value;
            }
        }
        //[Required(ErrorMessage = "Merchandise Base Category Code should not be blank.")]
        //[Display(Name = "Merchandise Base Category Code")]
        public string TransactionTypeCode
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.TransactionTypeCode : string.Empty;
            }
            set
            {
                AccountVoucherSettingMasterDTO.TransactionTypeCode = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.IsDeleted : false;
            }
            set
            {
                AccountVoucherSettingMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null && AccountVoucherSettingMasterDTO.CreatedBy > 0) ? AccountVoucherSettingMasterDTO.CreatedBy : new int();
            }
            set
            {
                AccountVoucherSettingMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AccountVoucherSettingMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.ModifiedBy : new int();
            }
            set
            {
                AccountVoucherSettingMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AccountVoucherSettingMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.DeletedBy : new int();
            }
            set
            {
                AccountVoucherSettingMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountVoucherSettingMasterDTO != null) ? AccountVoucherSettingMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AccountVoucherSettingMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

