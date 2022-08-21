using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralItemMerchantiseCategoryViewModel : IGeneralItemMerchantiseCategoryViewModel
    {

        public GeneralItemMerchantiseCategoryViewModel()
        {
            GeneralItemMerchantiseCategoryDTO = new GeneralItemMerchantiseCategory();

        }



        public GeneralItemMerchantiseCategory GeneralItemMerchantiseCategoryDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null && GeneralItemMerchantiseCategoryDTO.ID > 0) ? GeneralItemMerchantiseCategoryDTO.ID : new Int16();
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Merchandise Category Name  should not be blank.")]
        [Display(Name = "Merchandise Category Name ")]
        public string MerchantiseCategoryName 
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null) ? GeneralItemMerchantiseCategoryDTO.MerchantiseCategoryName : string.Empty;
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.MerchantiseCategoryName = value;
            }
        }

        [Required(ErrorMessage = "Merchandise Category Code should not be blank.")]
        [Display(Name = "Merchandise Category Code")]
        public string MerchantiseCategoryCode 
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null) ? GeneralItemMerchantiseCategoryDTO.MerchantiseCategoryCode : string.Empty;
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.MerchantiseCategoryCode = value;
            }
        }

        public Int16 MerchandiseDepartmentID
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null && GeneralItemMerchantiseCategoryDTO.MerchandiseDepartmentID > 0) ? GeneralItemMerchantiseCategoryDTO.MerchandiseDepartmentID : new Int16();
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.MerchandiseDepartmentID = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null) ? GeneralItemMerchantiseCategoryDTO.IsDeleted : false;
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null && GeneralItemMerchantiseCategoryDTO.CreatedBy > 0) ? GeneralItemMerchantiseCategoryDTO.CreatedBy : new int();
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null) ? GeneralItemMerchantiseCategoryDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null) ? GeneralItemMerchantiseCategoryDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null) ? GeneralItemMerchantiseCategoryDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null) ? GeneralItemMerchantiseCategoryDTO.DeletedBy : new int();
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralItemMerchantiseCategoryDTO != null) ? GeneralItemMerchantiseCategoryDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMerchantiseCategoryDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

