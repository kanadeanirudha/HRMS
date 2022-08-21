using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class ECommerceSystemSettingsViewModel : IECommerceSystemSettingsViewModel
    {

        public ECommerceSystemSettingsViewModel()
        {
            ECommerceSystemSettingsDTO = new ECommerceSystemSettings();
          // EComSystemSettings_Menus = new List<ECommerceSystemSettings>();
        }
        //public List<ECommerceSystemSettings> EComSystemSettings_Menus { get; set; }
        public ECommerceSystemSettings ECommerceSystemSettingsDTO
        {
            get;
            set;
        }
       
        public int ID
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null && ECommerceSystemSettingsDTO.ID > 0) ? ECommerceSystemSettingsDTO.ID : new int();
            }
            set
            {
                ECommerceSystemSettingsDTO.ID = value;
            }
        }


        public string TaskCode
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.TaskCode : string.Empty;
            }
            set
            {
                ECommerceSystemSettingsDTO.TaskCode = value;
            }
        }
        public int EComStoreSettingID
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null && ECommerceSystemSettingsDTO.EComStoreSettingID > 0) ? ECommerceSystemSettingsDTO.EComStoreSettingID : new int();
            }
            set
            {
                ECommerceSystemSettingsDTO.EComStoreSettingID = value;
            }
        }
      
        [Display(Name = "Store")]
        public Int16 GeneralUnitsID
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.GeneralUnitsID : new Int16();
            }
            set
            {
                ECommerceSystemSettingsDTO.GeneralUnitsID = value;
            }
        }
        public string EComSystemSettingsMenus
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.EComSystemSettingsMenus : string.Empty;
            }
            set
            {
                ECommerceSystemSettingsDTO.EComSystemSettingsMenus = value;
            }
        }
         [Display(Name = "Merchandise Group")]
        public string MerchandiseGroup
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.MerchandiseGroup : string.Empty;
            }
            set
            {
                ECommerceSystemSettingsDTO.MerchandiseGroup = value;
            }
        }
         [Display(Name = "Department")]
        public string Department
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.Department : string.Empty;
            }
            set
            {
                ECommerceSystemSettingsDTO.Department = value;
            }
        }
         [Display(Name = "Category")]
        public string Category
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.Category : string.Empty;
            }
            set
            {
                ECommerceSystemSettingsDTO.Category = value;
            }
        }
         [Display(Name = "Sub Category")]
        public string SubCategory
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.SubCategory : string.Empty;
            }
            set
            {
                ECommerceSystemSettingsDTO.SubCategory = value;
            }
        }
         [Display(Name = "Base Merchandise Category")]
        public string BaseMerchandiseCategory
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.BaseMerchandiseCategory : string.Empty;
            }
            set
            {
                ECommerceSystemSettingsDTO.BaseMerchandiseCategory = value;
            }
        }
         public Int16 EComCategorySettingID
         {
             get
             {
                 return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.EComCategorySettingID : new Int16();
             }
             set
             {
                 ECommerceSystemSettingsDTO.EComCategorySettingID = value;
             }
         }
         public Int16 SequenceNumber
         {
             get
             {
                 return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.SequenceNumber : new Int16();
             }
             set
             {
                 ECommerceSystemSettingsDTO.SequenceNumber = value;
             }
         }
         public Int16 LevelNumber
         {
             get
             {
                 return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.LevelNumber : new Int16();
             }
             set
             {
                 ECommerceSystemSettingsDTO.LevelNumber = value;
             }

         }
         public string Name
         {
             get
             {
                 return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.Name : string.Empty;
             }
             set
             {
                 ECommerceSystemSettingsDTO.Name = value;
             }
         }
         public Int16 NextLevel
         {
             get
             {
                 return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.NextLevel : new Int16();
             }
             set
             {
                 ECommerceSystemSettingsDTO.NextLevel = value;
             }
         }
         public string SelectedIDs
         {
             get
             {
                 return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.SelectedIDs : string.Empty;
             }
             set
             {
                 ECommerceSystemSettingsDTO.SelectedIDs = value;
             }
         }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.IsDeleted : false;
            }
            set
            {
                ECommerceSystemSettingsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null && ECommerceSystemSettingsDTO.CreatedBy > 0) ? ECommerceSystemSettingsDTO.CreatedBy : new int();
            }
            set
            {
                ECommerceSystemSettingsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ECommerceSystemSettingsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.ModifiedBy : new int();
            }
            set
            {
                ECommerceSystemSettingsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ECommerceSystemSettingsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.DeletedBy : new int();
            }
            set
            {
                ECommerceSystemSettingsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (ECommerceSystemSettingsDTO != null) ? ECommerceSystemSettingsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ECommerceSystemSettingsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

