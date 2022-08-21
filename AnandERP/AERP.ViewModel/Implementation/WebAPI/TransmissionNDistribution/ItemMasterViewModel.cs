using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class ItemMasterViewModel
    {
        public ItemMasterViewModel()
        {
            ItemMasterDTO = new ItemMaster();
        }

        public ItemMaster ItemMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (ItemMasterDTO != null && ItemMasterDTO.ID > 0) ? ItemMasterDTO.ID : new int();
            }
            set
            {
                ItemMasterDTO.ID = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return (ItemMasterDTO != null && ItemMasterDTO.CategoryID > 0) ? ItemMasterDTO.CategoryID : new int();
            }
            set
            {
                ItemMasterDTO.CategoryID = value;
            }
        }

        public string Item
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.Item : string.Empty;
            }
            set
            {
                ItemMasterDTO.Item = value;
            }
        }

        public string Category
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.Category : string.Empty;
            }
            set
            {
                ItemMasterDTO.Category = value;
            }
        }

        public string Size
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.Size : string.Empty;
            }
            set
            {
                ItemMasterDTO.Size = value;
            }
        }

        public decimal Weight_In_KG
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.Weight_In_KG : new Decimal();
            }
            set
            {
                ItemMasterDTO.Weight_In_KG = value;
            }
        }

        public string Unit
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.Unit : string.Empty;
            }
            set
            {
                ItemMasterDTO.Unit = value;
            }
        }

        public decimal Rate
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.Rate : new Decimal();
            }
            set
            {
                ItemMasterDTO.Rate = value;
            }
        }

        public decimal Quantity
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.Quantity : new Decimal();
            }
            set
            {
                ItemMasterDTO.Quantity = value;
            }
        }

        public string ItemDescription
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                ItemMasterDTO.ItemDescription = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.IsDeleted : false;
            }
            set
            {
                ItemMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ItemMasterDTO != null && ItemMasterDTO.CreatedBy > 0) ? ItemMasterDTO.CreatedBy : new int();
            }
            set
            {
                ItemMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ItemMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ItemMasterDTO != null && ItemMasterDTO.ModifiedBy > 0) ? ItemMasterDTO.ModifiedBy : new int();
            }
            set
            {
                ItemMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ItemMasterDTO != null && ItemMasterDTO.ModifiedDate.HasValue) ? ItemMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ItemMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ItemMasterDTO != null && ItemMasterDTO.DeletedBy > 0) ? ItemMasterDTO.DeletedBy : new int();
            }
            set
            {
                ItemMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ItemMasterDTO != null && ItemMasterDTO.DeletedDate.HasValue) ? ItemMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ItemMasterDTO.DeletedDate = value;
            }
        }

        public string VersionNumber
        {

            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                ItemMasterDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (ItemMasterDTO != null && ItemMasterDTO.LastSyncDate.HasValue) ? ItemMasterDTO.LastSyncDate : null;
            }
            set
            {
                ItemMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.SyncType : string.Empty;
            }
            set
            {
                ItemMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (ItemMasterDTO != null) ? ItemMasterDTO.Entity : string.Empty;
            }
            set
            {
                ItemMasterDTO.Entity = value;
            }
        }
    }
}
