using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AERP.ViewModel
{
    public class AccountHeadMasterViewModel: IAccountHeadMasterViewModel
    {
        public AccountHeadMasterViewModel()
        {
            AccountHeadMasterDTO = new AccountHeadMaster();
        }

        public AccountHeadMaster AccountHeadMasterDTO { get; set; }
        public string errorMessage { get; set; }

        public byte ID
        {
            get
            {
                return (AccountHeadMasterDTO != null && AccountHeadMasterDTO.ID > 0) ? AccountHeadMasterDTO.ID : new byte();
            }
            set
            {
                AccountHeadMasterDTO.ID = value;
            }
        }

        [Display(Name = "Head Code")]
        public string HeadCode
        {
            get
            {
                return (AccountHeadMasterDTO != null) ? AccountHeadMasterDTO.HeadCode : string.Empty;
            }
            set
            {
                AccountHeadMasterDTO.HeadCode = value;
            }
        }
        [Display(Name = "Head Name")]
        public string HeadName
        {
            get
            {
                return (AccountHeadMasterDTO != null) ? AccountHeadMasterDTO.HeadName : string.Empty;
            }
            set
            {
                AccountHeadMasterDTO.HeadName = value;
            }
        }
        [Display(Name = "Credit/Debit")]
        public char CreditDebitFlag
        {
            get
            {
                return (AccountHeadMasterDTO != null) ? AccountHeadMasterDTO.CreditDebitFlag : new char();
            }
            set
            {
                AccountHeadMasterDTO.CreditDebitFlag = value;
            }
        }
        [Display(Name = "Printing Sequence")]
        public Nullable<int> PrintingSequence
        {
            get
            {
                return (AccountHeadMasterDTO != null && AccountHeadMasterDTO.PrintingSequence > 0) ? AccountHeadMasterDTO.PrintingSequence : new int();
            }
            set
            {
                AccountHeadMasterDTO.PrintingSequence = value;
            }
        }

        public Nullable<bool> IsActive
        {
            get
            {
                return (AccountHeadMasterDTO != null) ? AccountHeadMasterDTO.IsActive : false;
            }
            set
            {
                AccountHeadMasterDTO.IsActive = value;
            }
        }

       

        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountHeadMasterDTO != null && AccountHeadMasterDTO.CreatedBy > 0) ? AccountHeadMasterDTO.CreatedBy : new int();
            }
            set
            {
                AccountHeadMasterDTO.CreatedBy = value;
            }
        }


        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountHeadMasterDTO != null) ? AccountHeadMasterDTO.CreatedDate : null;
            }
            set
            {
                AccountHeadMasterDTO.CreatedDate = value;
            }
        }


        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountHeadMasterDTO != null && AccountHeadMasterDTO.ModifiedBy > 0) ? AccountHeadMasterDTO.ModifiedBy : new int();
            }
            set
            {
                AccountHeadMasterDTO.ModifiedBy = value;
            }
        }


        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountHeadMasterDTO != null) ? AccountHeadMasterDTO.ModifiedDate : null;
            }
            set
            {
                AccountHeadMasterDTO.ModifiedDate = value;
            }
        }

        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountHeadMasterDTO != null && AccountHeadMasterDTO.DeletedBy > 0) ? AccountHeadMasterDTO.DeletedBy : new int();
            }
            set
            {
                AccountHeadMasterDTO.DeletedBy = value;
            }
        }


        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountHeadMasterDTO != null) ? AccountHeadMasterDTO.DeletedDate : null;
            }
            set
            {
                AccountHeadMasterDTO.DeletedDate = value;
            }
        }

        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccountHeadMasterDTO != null) ? AccountHeadMasterDTO.IsDeleted : false;
            }
            set
            {
                AccountHeadMasterDTO.IsDeleted = value;
            }
        }

    }
}
