using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AccountChequeBookDetailsBaseViewModel : IAccountChequeBookDetailsBaseViewModel
    {
        public AccountChequeBookDetailsBaseViewModel()
        {
            ListAccountChequeBookDetails = new List<AccountChequeBookDetails>();
            ListAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();
        }
        public List<AccountChequeBookDetails> ListAccountChequeBookDetails
        {
            get;
            set;
        }


        public List<AccountBalancesheetMaster> ListAccountBalancesheetMaster
        {
            get;
            set;
        }
    }

    public class AccountChequeBookDetailsViewModel : IAccountChequeBookDetailsViewModel
    {
        public AccountChequeBookDetailsViewModel()
        {
            AccountChequeBookDetailsDTO = new AccountChequeBookDetails();
        }

        public AccountChequeBookDetails AccountChequeBookDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null && AccountChequeBookDetailsDTO.ID > 0) ? AccountChequeBookDetailsDTO.ID : new int();
            }
            set
            {
                AccountChequeBookDetailsDTO.ID = value;
            }
        }
        public int ChequeBookID
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null && AccountChequeBookDetailsDTO.ChequeBookID > 0) ? AccountChequeBookDetailsDTO.ChequeBookID : new int();
            }
            set
            {
                AccountChequeBookDetailsDTO.ChequeBookID = value;
            }
        }
        public int ChequeNo
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null && AccountChequeBookDetailsDTO.ChequeNo > 0) ? AccountChequeBookDetailsDTO.ChequeNo : new int();
            }
            set
            {
                AccountChequeBookDetailsDTO.ChequeNo = value;
            }
        }
        public DateTime ChequeDatetime
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.ChequeDatetime : DateTime.Now;
            }
            set
            {
                AccountChequeBookDetailsDTO.ChequeDatetime = value;
            }
        }
        public decimal ChequeAmount
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null && AccountChequeBookDetailsDTO.ChequeAmount > 0) ? AccountChequeBookDetailsDTO.ChequeAmount : new decimal();
            }
            set
            {
                AccountChequeBookDetailsDTO.ChequeAmount = value;
            }
        }
        public int TransactionSubID
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null && AccountChequeBookDetailsDTO.TransactionSubID > 0) ? AccountChequeBookDetailsDTO.TransactionSubID : new int();
            }
            set
            {
                AccountChequeBookDetailsDTO.TransactionSubID = value;
            }
        }
        public DateTime TransactionDatetime
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.TransactionDatetime : DateTime.Now;
            }
            set
            {
                AccountChequeBookDetailsDTO.TransactionDatetime = value;
            }
        }
        public string ChequeStatus
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.ChequeStatus : string.Empty;
            }
            set
            {
                AccountChequeBookDetailsDTO.ChequeStatus = value;
            }
        }
        [Display(Name = "Remark :")]
        public string ChequeDescription
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.ChequeDescription : string.Empty;
            }
            set
            {
                AccountChequeBookDetailsDTO.ChequeDescription = value;
            }
        }
     
        public string CanceledBy
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.CanceledBy : string.Empty;
            }
            set
            {
                AccountChequeBookDetailsDTO.CanceledBy = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                AccountChequeBookDetailsDTO.CentreCode = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.IsActive : false;
            }
            set
            {
                AccountChequeBookDetailsDTO.IsActive = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null && AccountChequeBookDetailsDTO.CreatedBy > 0) ? AccountChequeBookDetailsDTO.CreatedBy : new int();
            }
            set
            {
                AccountChequeBookDetailsDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AccountChequeBookDetailsDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null && AccountChequeBookDetailsDTO.ModifiedBy > 0) ? AccountChequeBookDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                AccountChequeBookDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AccountChequeBookDetailsDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null && AccountChequeBookDetailsDTO.DeletedBy > 0) ? AccountChequeBookDetailsDTO.DeletedBy : new int();
            }
            set
            {
                AccountChequeBookDetailsDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AccountChequeBookDetailsDTO.DeletedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.IsDeleted : false;
            }
            set
            {
                AccountChequeBookDetailsDTO.IsDeleted = value;
            }
        }

        public string AccountName
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null) ? AccountChequeBookDetailsDTO.AccountName : string.Empty;
            }
            set
            {
                AccountChequeBookDetailsDTO.AccountName = value;
            }
        }
        public Int16 AccountID
        {
            get
            {
                return (AccountChequeBookDetailsDTO != null && AccountChequeBookDetailsDTO.AccountID > 0) ? AccountChequeBookDetailsDTO.AccountID : new Int16();
            }
            set
            {
                AccountChequeBookDetailsDTO.AccountID = value;
            }
        }
        public string errorMessage { get; set; }
    }
}
