using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralItemMarchandiseSubCategoryViewModel : IGeneralItemMarchandiseSubCategoryViewModel
    {

        public GeneralItemMarchandiseSubCategoryViewModel()
        {
            GeneralItemMarchandiseSubCategoryDTO = new GeneralItemMarchandiseSubCategory();

        }



        public GeneralItemMarchandiseSubCategory GeneralItemMarchandiseSubCategoryDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null && GeneralItemMarchandiseSubCategoryDTO.ID > 0) ? GeneralItemMarchandiseSubCategoryDTO.ID : new Int16();
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Merchandise Sub Category Name should not be blank.")]
        [Display(Name = "Merchandise Sub Category Name")]
        public string MarchantiseSubCategoryName
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null) ? GeneralItemMarchandiseSubCategoryDTO.MarchantiseSubCategoryName : string.Empty;
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.MarchantiseSubCategoryName = value;
            }
        }

        [Required(ErrorMessage = "Merchandise Sub Category Code should not be blank.")]
        [Display(Name = "Merchandise Sub Category Code")]
        public string MarchantiseSubCategoryCode
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null) ? GeneralItemMarchandiseSubCategoryDTO.MarchantiseSubCategoryCode : string.Empty;
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.MarchantiseSubCategoryCode = value;
            }
        }
        public Int16 MerchandiseCategoryID
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null && GeneralItemMarchandiseSubCategoryDTO.MerchandiseCategoryID > 0) ? GeneralItemMarchandiseSubCategoryDTO.MerchandiseCategoryID : new Int16();
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.MerchandiseCategoryID = value;
            }
        }
        

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null) ? GeneralItemMarchandiseSubCategoryDTO.IsDeleted : false;
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null && GeneralItemMarchandiseSubCategoryDTO.CreatedBy > 0) ? GeneralItemMarchandiseSubCategoryDTO.CreatedBy : new int();
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null) ? GeneralItemMarchandiseSubCategoryDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null) ? GeneralItemMarchandiseSubCategoryDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null) ? GeneralItemMarchandiseSubCategoryDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null) ? GeneralItemMarchandiseSubCategoryDTO.DeletedBy : new int();
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralItemMarchandiseSubCategoryDTO != null) ? GeneralItemMarchandiseSubCategoryDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMarchandiseSubCategoryDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

