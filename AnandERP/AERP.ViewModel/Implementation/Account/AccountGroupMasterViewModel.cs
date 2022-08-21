using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AERP.ViewModel
{
    public class AccountGroupMasterViewModel : IAccountGroupMasterViewModel
    {

        public AccountGroupMasterViewModel()
        {
            AccountGroupMasterDTO = new AccountGroupMaster();
        }

        public AccountGroupMaster AccountGroupMasterDTO { get; set; }



        public Int16 ID
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.ID > 0) ? AccountGroupMasterDTO.ID : new Int16();
            }
            set
            {
                AccountGroupMasterDTO.ID = value;
            }
        }

        [Display(Name = "Group Code")]
        [Required(ErrorMessage ="Group Code Required")]
        public string GroupCode
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.GroupCode : string.Empty;
            }
            set
            {
                AccountGroupMasterDTO.GroupCode = value;
            }
        }

        [Display(Name = "Group Description")]
        [Required(ErrorMessage ="Group Description Required")]
        public string GroupDescription
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.GroupDescription : string.Empty;
            }
            set
            {
                AccountGroupMasterDTO.GroupDescription = value;
            }
        }

        public string GroupDescriptionCategory
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.GroupDescriptionCategory : string.Empty;
            }
            set
            {
                AccountGroupMasterDTO.GroupDescriptionCategory = value;
            }
        }

        [Display(Name = "Category")]
        [Required(ErrorMessage ="Category Required")]
        public Nullable<Int16> CategoryID
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.CategoryID > 0) ? AccountGroupMasterDTO.CategoryID : new Int16();
            }
            set
            {
                AccountGroupMasterDTO.CategoryID = value;
            }
        }

        public string BackDatedEntriesFlag
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.BackDatedEntriesFlag : string.Empty;
            }
            set
            {
                AccountGroupMasterDTO.BackDatedEntriesFlag = value;
            }
        }

        [Display(Name = "Printing Sequence")]
        public Nullable<Int16> PrintingSequence
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.PrintingSequence > 0) ? AccountGroupMasterDTO.PrintingSequence : new Int16();
            }
            set
            {
                AccountGroupMasterDTO.PrintingSequence = value;
            }
        }

        public Nullable<bool> IsActive
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.IsActive : false;
            }
            set
            {
                AccountGroupMasterDTO.IsActive = value;
            }
        }

        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.CreatedBy > 0) ? AccountGroupMasterDTO.CreatedBy : new int();
            }
            set
            {
                AccountGroupMasterDTO.CreatedBy = value;
            }
        }


        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.CreatedDate : null;
            }
            set
            {
                AccountGroupMasterDTO.CreatedDate = value;
            }
        }


        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.ModifiedBy > 0) ? AccountGroupMasterDTO.ModifiedBy : new int();
            }
            set
            {
                AccountGroupMasterDTO.ModifiedBy = value;
            }
        }


        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.ModifiedDate : null;
            }
            set
            {
                AccountGroupMasterDTO.ModifiedDate = value;
            }
        }

        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountGroupMasterDTO != null && AccountGroupMasterDTO.DeletedBy > 0) ? AccountGroupMasterDTO.DeletedBy : new int();
            }
            set
            {
                AccountGroupMasterDTO.DeletedBy = value;
            }
        }


        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.DeletedDate : null;
            }
            set
            {
                AccountGroupMasterDTO.DeletedDate = value;
            }
        }

        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccountGroupMasterDTO != null) ? AccountGroupMasterDTO.IsDeleted : false;
            }
            set
            {
                AccountGroupMasterDTO.IsDeleted = value;
            }
        }
       



    }
}
