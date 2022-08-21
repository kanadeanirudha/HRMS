using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class ItemCategoryMasterViewModel
    {
        public ItemCategoryMasterViewModel()
        {
            ItemCategoryMasterDTO = new ItemCategoryMaster();
        }

        public ItemCategoryMaster ItemCategoryMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (ItemCategoryMasterDTO != null && ItemCategoryMasterDTO.ID > 0) ? ItemCategoryMasterDTO.ID : new int();
            }
            set
            {
                ItemCategoryMasterDTO.ID = value;
            }
        }

        public string Category
        {
            get
            {
                return (ItemCategoryMasterDTO != null) ? ItemCategoryMasterDTO.Category : string.Empty;
            }
            set
            {
                ItemCategoryMasterDTO.Category = value;
            }
        }

        public string ItemCategoryCode
        {
            get
            {
                return (ItemCategoryMasterDTO != null) ? ItemCategoryMasterDTO.ItemCategoryCode : string.Empty;
            }
            set
            {
                ItemCategoryMasterDTO.ItemCategoryCode = value;
            }
        }

        public string CategoryDescription
        {
            get
            {
                return (ItemCategoryMasterDTO != null) ? ItemCategoryMasterDTO.CategoryDescription : string.Empty;
            }
            set
            {
                ItemCategoryMasterDTO.CategoryDescription = value;
            }
        }

        public bool IsConsumable
        {
            get
            {
                return (ItemCategoryMasterDTO != null) ? ItemCategoryMasterDTO.IsConsumable : false;
            }
            set
            {
                ItemCategoryMasterDTO.IsConsumable = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (ItemCategoryMasterDTO != null) ? ItemCategoryMasterDTO.IsDeleted : false;
            }
            set
            {
                ItemCategoryMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ItemCategoryMasterDTO != null && ItemCategoryMasterDTO.CreatedBy > 0) ? ItemCategoryMasterDTO.CreatedBy : new int();
            }
            set
            {
                ItemCategoryMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ItemCategoryMasterDTO != null) ? ItemCategoryMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ItemCategoryMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ItemCategoryMasterDTO != null && ItemCategoryMasterDTO.ModifiedBy > 0) ? ItemCategoryMasterDTO.ModifiedBy : new int();
            }
            set
            {
                ItemCategoryMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ItemCategoryMasterDTO != null && ItemCategoryMasterDTO.ModifiedDate.HasValue) ? ItemCategoryMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ItemCategoryMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ItemCategoryMasterDTO != null && ItemCategoryMasterDTO.DeletedBy > 0) ? ItemCategoryMasterDTO.DeletedBy : new int();
            }
            set
            {
                ItemCategoryMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ItemCategoryMasterDTO != null && ItemCategoryMasterDTO.DeletedDate.HasValue) ? ItemCategoryMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ItemCategoryMasterDTO.DeletedDate = value;
            }
        }
    }
}
