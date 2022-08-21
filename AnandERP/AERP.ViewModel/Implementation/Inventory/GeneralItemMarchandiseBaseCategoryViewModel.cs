using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralItemMarchandiseBaseCategoryViewModel : IGeneralItemMarchandiseBaseCategoryViewModel
    {

        public GeneralItemMarchandiseBaseCategoryViewModel()
        {
            GeneralItemMarchandiseBaseCategoryDTO = new GeneralItemMarchandiseBaseCategory();

        }



        public GeneralItemMarchandiseBaseCategory GeneralItemMarchandiseBaseCategoryDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null && GeneralItemMarchandiseBaseCategoryDTO.ID > 0) ? GeneralItemMarchandiseBaseCategoryDTO.ID : new Int16();
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Merchandise Base Category Name should not be blank.")]
        [Display(Name = "Merchandise Base Category Name")]
        public string MarchandiseBaseCategoryName
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null) ? GeneralItemMarchandiseBaseCategoryDTO.MarchandiseBaseCategoryName : string.Empty;
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.MarchandiseBaseCategoryName = value;
            }
        }

        [Required(ErrorMessage = "Merchandise Base Category Code should not be blank.")]
        [Display(Name = "Merchandise Base Category Code")]
        public string MarchandiseBaseCategoryCode
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null) ? GeneralItemMarchandiseBaseCategoryDTO.MarchandiseBaseCategoryCode : string.Empty;
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.MarchandiseBaseCategoryCode = value;
            }
        }
        public Int16 MarchandiseSubCategoryID
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null && GeneralItemMarchandiseBaseCategoryDTO.MarchandiseSubCategoryID > 0) ? GeneralItemMarchandiseBaseCategoryDTO.MarchandiseSubCategoryID : new Int16();
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.MarchandiseSubCategoryID = value;
            }
        }

        

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null) ? GeneralItemMarchandiseBaseCategoryDTO.IsDeleted : false;
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null && GeneralItemMarchandiseBaseCategoryDTO.CreatedBy > 0) ? GeneralItemMarchandiseBaseCategoryDTO.CreatedBy : new int();
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null) ? GeneralItemMarchandiseBaseCategoryDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null) ? GeneralItemMarchandiseBaseCategoryDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null) ? GeneralItemMarchandiseBaseCategoryDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null) ? GeneralItemMarchandiseBaseCategoryDTO.DeletedBy : new int();
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralItemMarchandiseBaseCategoryDTO != null) ? GeneralItemMarchandiseBaseCategoryDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMarchandiseBaseCategoryDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

