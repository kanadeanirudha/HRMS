using AERP.Common;
using AERP.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AERP.ViewModel
{
    public class AccountTransactionTypeMasterViewModel : IAccountTransactionTypeMasterViewModel
    {
        public AccountTransactionTypeMasterViewModel()
        {
            AccountTransactionTypeMasterDTO = new AccountTransactionTypeMaster();
        }
        public AccountTransactionTypeMaster AccountTransactionTypeMasterDTO { get; set; }
        public int ID
        {
            get
            {
                return (AccountTransactionTypeMasterDTO != null) ? AccountTransactionTypeMasterDTO.ID : new int();
            }
            set
            {
                AccountTransactionTypeMasterDTO.ID = value;
            }
        }
        public int AccountTransactionTypeMasterID
        {
            get
            {
                return (AccountTransactionTypeMasterDTO != null) ? AccountTransactionTypeMasterDTO.AccountTransactionTypeMasterID : new int();
            }
            set
            {
                AccountTransactionTypeMasterDTO.AccountTransactionTypeMasterID = value;
            }
        }
        [Required(ErrorMessage = "TransactionTypeCode should not be blank.")]
        [Display(Name = "Transaction Type Code")]
        public string TransactionTypeCode
        {
            get {
                return (AccountTransactionTypeMasterDTO != null && AccountTransactionTypeMasterDTO.TransactionTypeCode != null) ? AccountTransactionTypeMasterDTO.TransactionTypeCode :String.Empty ;
                }
            set { 
                AccountTransactionTypeMasterDTO.TransactionTypeCode = value; 
                }
        }
        [Required(ErrorMessage = "TransactionTypeName should not be blank.")]
        [Display(Name = "Transaction Type Name")]
        public String TransactionTypeName
        {
            get {
                return (AccountTransactionTypeMasterDTO != null && AccountTransactionTypeMasterDTO.TransactionTypeName != null) ? AccountTransactionTypeMasterDTO.TransactionTypeName : String.Empty;
                }
            set { AccountTransactionTypeMasterDTO.TransactionTypeName = value;
                }
        }
        public bool IsActive
        {
            get {
                return (AccountTransactionTypeMasterDTO != null) ? AccountTransactionTypeMasterDTO.IsActive : false;
                }
            set {
                AccountTransactionTypeMasterDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get { return (AccountTransactionTypeMasterDTO != null) ? AccountTransactionTypeMasterDTO.IsDeleted : false; }
            set { AccountTransactionTypeMasterDTO.IsDeleted = value; }
        }
        public Int32 CreatedBy
        {
            get { return (AccountTransactionTypeMasterDTO != null && AccountTransactionTypeMasterDTO.CreatedBy > 0) ? AccountTransactionTypeMasterDTO.CreatedBy : new Int32(); }
            set { AccountTransactionTypeMasterDTO.CreatedBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return (AccountTransactionTypeMasterDTO != null && AccountTransactionTypeMasterDTO.CreatedDate != null) ? AccountTransactionTypeMasterDTO.CreatedDate : DateTime.Now; }
            set { AccountTransactionTypeMasterDTO.CreatedDate = value; }
        }
        public Int32 ModifiedBy
        {
            get { return (AccountTransactionTypeMasterDTO != null && AccountTransactionTypeMasterDTO.ModifiedBy > 0) ? AccountTransactionTypeMasterDTO.ModifiedBy : new Int32(); }
            set { AccountTransactionTypeMasterDTO.ModifiedBy = value; }
        }
        public DateTime ModifiedDate
        {
            get { return (AccountTransactionTypeMasterDTO != null && AccountTransactionTypeMasterDTO.ModifiedDate != null) ? AccountTransactionTypeMasterDTO.ModifiedDate : DateTime.Now; }
            set { AccountTransactionTypeMasterDTO.ModifiedDate = value; }
        }
        public Int32 DeletedBy
        {
            get { return (AccountTransactionTypeMasterDTO != null && AccountTransactionTypeMasterDTO.DeletedBy > 0) ? AccountTransactionTypeMasterDTO.DeletedBy : new Int32(); }
            set { AccountTransactionTypeMasterDTO.DeletedBy = value; }
        }
        public DateTime DeletedDate
        {
            get { return (AccountTransactionTypeMasterDTO != null && AccountTransactionTypeMasterDTO.DeletedDate != null) ? AccountTransactionTypeMasterDTO.DeletedDate : DateTime.Now; }
            set { AccountTransactionTypeMasterDTO.DeletedDate = value; }
        }
    }
}
