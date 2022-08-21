using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{

    public class AccountCategoryMasterBaseViewModel : IAccountCategoryMasterBaseViewModel
    {
        public AccountCategoryMasterBaseViewModel()
        {
            ListAccountCategoryMaster = new List<AccountCategoryMaster>();
            ListAccountHeadMaster = new List<AccountHeadMaster>();
        }

        public List<AccountCategoryMaster> ListAccountCategoryMaster
        {
            get;
            set;
        }
        public List<AccountHeadMaster> ListAccountHeadMaster
        {
            get;
            set;
        }

        public int SelectedHeadID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListAccountHeadMasterItems
        {
            get
            {
                return new SelectList(ListAccountHeadMaster, "ID", "HeadName");
            }
        }
    }

    public class AccountCategoryMasterViewModel
    {

        public AccountCategoryMasterViewModel()
        {
            AccountCategoryMasterDTO = new AccountCategoryMaster();
        }
        public AccountCategoryMaster AccountCategoryMasterDTO { get; set; }

        public Int16 ID
        {
            get
            {
                return (AccountCategoryMasterDTO != null && AccountCategoryMasterDTO.ID > 0) ? AccountCategoryMasterDTO.ID : new Int16();
            }
            set
            {
                AccountCategoryMasterDTO.ID = value;
            }
        }

        [Display(Name = "Category Code")]
        [Required(ErrorMessage ="Category Code Required")]
        public string CategoryCode
        {
            get
            {
                return (AccountCategoryMasterDTO != null) ? AccountCategoryMasterDTO.CategoryCode : string.Empty;
            }
            set
            {
                AccountCategoryMasterDTO.CategoryCode = value;
            }
        }

        [Display(Name = "Category Description")]
        [Required(ErrorMessage ="Category Description Required")]
        public string CategoryDescription
        {
            get
            {
                return (AccountCategoryMasterDTO != null) ? AccountCategoryMasterDTO.CategoryDescription : string.Empty;
            }
            set
            {
                AccountCategoryMasterDTO.CategoryDescription = value;
            }
        }

        public string CategoryDescriptionHead
        {
            get
            {
                return (AccountCategoryMasterDTO != null) ? AccountCategoryMasterDTO.CategoryDescriptionHead : string.Empty;
            }
            set
            {
                AccountCategoryMasterDTO.CategoryDescriptionHead = value;
            }
        }

        [Display(Name = "Account Head")]
        [Required(ErrorMessage ="Account Head Required")]
        public Nullable<byte> HeadID
        {
            get
            {
                return (AccountCategoryMasterDTO != null && AccountCategoryMasterDTO.HeadID > 0) ? AccountCategoryMasterDTO.HeadID : new byte();
            }
            set
            {
                AccountCategoryMasterDTO.HeadID = value;
            }
        }

        [Display(Name = "Printing Sequence")]
        public Nullable<Int16> PrintingSequence
        {
            get
            {
                return (AccountCategoryMasterDTO != null && AccountCategoryMasterDTO.PrintingSequence > 0) ? AccountCategoryMasterDTO.PrintingSequence : new Int16();
            }
            set
            {
                AccountCategoryMasterDTO.PrintingSequence = value;
            }
        }

        public Nullable<bool> IsActive
        {
            get
            {
                return (AccountCategoryMasterDTO != null) ? AccountCategoryMasterDTO.IsActive : false;
            }
            set
            {
                AccountCategoryMasterDTO.IsActive = value;
            }
        }

        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountCategoryMasterDTO != null && AccountCategoryMasterDTO.CreatedBy > 0) ? AccountCategoryMasterDTO.CreatedBy : new int();
            }
            set
            {
                AccountCategoryMasterDTO.CreatedBy = value;
            }
        }


        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountCategoryMasterDTO != null) ? AccountCategoryMasterDTO.CreatedDate : null;
            }
            set
            {
                AccountCategoryMasterDTO.CreatedDate = value;
            }
        }


        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountCategoryMasterDTO != null && AccountCategoryMasterDTO.ModifiedBy > 0) ? AccountCategoryMasterDTO.ModifiedBy : new int();
            }
            set
            {
                AccountCategoryMasterDTO.ModifiedBy = value;
            }
        }


        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountCategoryMasterDTO != null) ? AccountCategoryMasterDTO.ModifiedDate : null;
            }
            set
            {
                AccountCategoryMasterDTO.ModifiedDate = value;
            }
        }

        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountCategoryMasterDTO != null && AccountCategoryMasterDTO.DeletedBy > 0) ? AccountCategoryMasterDTO.DeletedBy : new int();
            }
            set
            {
                AccountCategoryMasterDTO.DeletedBy = value;
            }
        }


        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountCategoryMasterDTO != null) ? AccountCategoryMasterDTO.DeletedDate : null;
            }
            set
            {
                AccountCategoryMasterDTO.DeletedDate = value;
            }
        }

        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccountCategoryMasterDTO != null) ? AccountCategoryMasterDTO.IsDeleted : false;
            }
            set
            {
                AccountCategoryMasterDTO.IsDeleted = value;
            }
        }

        
    }
}
