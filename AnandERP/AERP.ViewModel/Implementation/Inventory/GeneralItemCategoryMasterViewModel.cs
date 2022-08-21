using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AERP.ViewModel
{
    public class GeneralItemCategoryMasterViewModel : IGeneralItemCategoryMasterViewModel
    {

        public GeneralItemCategoryMasterViewModel()
        {
            GeneralItemCategoryMasterDTO = new GeneralItemCategoryMaster();
        }
        public GeneralItemCategoryMaster GeneralItemCategoryMasterDTO
        {
            get;
            set;
        }
        public HttpPostedFileBase ExcelFile { get; set; }
        public Int16 ID
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null && GeneralItemCategoryMasterDTO.ID > 0) ? GeneralItemCategoryMasterDTO.ID : new Int16();
            }
            set
            {
                GeneralItemCategoryMasterDTO.ID = value;
            }
        }
       // [Required(ErrorMessage = "Category Code should not be blank.")]
        [Display(Name = "Base Merchandise Category Code")]
        public string ItemCategoryCode
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.ItemCategoryCode : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.ItemCategoryCode = value;
            }
        }
      //  [Required(ErrorMessage = "Category Description Name should not be blank.")]
        [Display(Name = "Base Merchandise Category Description")]
        public string ItemCategoryDescription
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.ItemCategoryDescription : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.ItemCategoryDescription = value;
            }
        }
        [Required(ErrorMessage = "Marchandise Group should not be blank.")]
        [Display(Name = "Marchandise Group")]
        public Int16 MarchandiseGroupID
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null && GeneralItemCategoryMasterDTO.MarchandiseGroupID > 0) ? GeneralItemCategoryMasterDTO.MarchandiseGroupID : new Int16();
            }
            set
            {
                GeneralItemCategoryMasterDTO.MarchandiseGroupID = value;
            }
        }
        public string SelectedMarchandiseGroupID
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Merchandise Department should not be blank.")]
        [Display(Name = "Merchandise Department")]
        public Int16 MerchandiseDepartmentID
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null && GeneralItemCategoryMasterDTO.MerchandiseDepartmentID > 0) ? GeneralItemCategoryMasterDTO.MerchandiseDepartmentID : new Int16();
            }
            set
            {
                GeneralItemCategoryMasterDTO.MerchandiseDepartmentID = value;
            }
        }
        public string SelectedMerchandiseDepartmentID
        {
            get;
            set;
        }
        [Required(ErrorMessage = " Merchandise Category should not be blank.")]
        [Display(Name = " Merchandise Category")]
        public Int16 MerchandiseCategoryID
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null && GeneralItemCategoryMasterDTO.MerchandiseCategoryID > 0) ? GeneralItemCategoryMasterDTO.MerchandiseCategoryID : new Int16();
            }
            set
            {
                GeneralItemCategoryMasterDTO.MerchandiseCategoryID = value;
            }
        }
        public string SelectedMerchandiseCategoryID
        {
            get;
            set;
        }
        [Required(ErrorMessage = " Merchandise SubCategory should not be blank.")]
        [Display(Name = " Merchandise SubCategory")]
        public Int16 MarchandiseSubCategoryID
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null && GeneralItemCategoryMasterDTO.MarchandiseSubCategoryID > 0) ? GeneralItemCategoryMasterDTO.MarchandiseSubCategoryID : new Int16();
            }
            set
            {
                GeneralItemCategoryMasterDTO.MarchandiseSubCategoryID = value;
            }

        }
        public string SelectedMarchandiseSubCategoryID
        {
            get;
            set;
        }
        [Required(ErrorMessage = " Merchandise Base Catgory should not be blank.")]
        [Display(Name = " Merchandise Base Catgory")]
        public Int16 MarchandiseBaseCatgoryID
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null && GeneralItemCategoryMasterDTO.MarchandiseBaseCatgoryID > 0) ? GeneralItemCategoryMasterDTO.MarchandiseBaseCatgoryID : new Int16();
            }
            set
            {
                GeneralItemCategoryMasterDTO.MarchandiseBaseCatgoryID = value;
            }
        }
        public string SelectedMarchandiseBaseCatgoryID
        {
            get;
            set;
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralItemCategoryMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null && GeneralItemCategoryMasterDTO.CreatedBy > 0) ? GeneralItemCategoryMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralItemCategoryMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralItemCategoryMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralItemCategoryMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralItemCategoryMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralItemCategoryMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralItemCategoryMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

        //for Group
        [Display(Name = "Group Description")]
        public string GroupDescription
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.GroupDescription : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.GroupDescription = value;
            }
        }

        [Display(Name = "Marchandise Group Code")]
        public string MarchandiseGroupCode
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.MarchandiseGroupCode : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.MarchandiseGroupCode = value;
            }
        }
        //department
        [Display(Name = "Department Code")]
        public string MerchantiseDepartmentCode
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.MerchantiseDepartmentCode : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.MerchantiseDepartmentCode = value;
            }
        }

        [Display(Name = "Department Name")]
        public string MerchantiseDepartmentName
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.MerchantiseDepartmentName : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.MerchantiseDepartmentName = value;
            }
        }
       
        //Category
        [Display(Name = "Category Code")]
        public string MerchantiseCategoryCode
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.MerchantiseCategoryCode : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.MerchantiseCategoryCode = value;
            }
        }

        [Display(Name = "Category Name")]
        public string MerchantiseCategoryName
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.MerchantiseCategoryName : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.MerchantiseCategoryName = value;
            }
        }
        //SubCategory
        [Display(Name = "Sub Category Code")]
        public string MerchantiseSubCategoryCode
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.MerchantiseSubCategoryCode : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.MerchantiseSubCategoryCode = value;
            }
        }

        [Display(Name = " Sub Category Name")]
        public string MarchantiseSubCategoryName
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.MarchantiseSubCategoryName : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.MarchantiseSubCategoryName = value;
            }
        }
        //Base Category
        [Display(Name = "Base Category Code")]
        public string MarchandiseBaseCatgoryCode
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.MarchandiseBaseCatgoryCode : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.MarchandiseBaseCatgoryCode = value;
            }
        }

        [Display(Name = " Base Category Name")]
        public string MarchandiseBaseCategoryName
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.MarchandiseBaseCategoryName : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.MarchandiseBaseCategoryName = value;
            }
        }
         [Display(Name = " Merchandise Group")]
        public string selectedGroupDescription
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.selectedGroupDescription : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.selectedGroupDescription = value;
            }
        }
        public string GroupCode
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.GroupCode : string.Empty;
            }
            set
            {
                GeneralItemCategoryMasterDTO.GroupCode = value;
            }
        }

        //List for dropdown
        public List<GeneralItemMerchantiseDepartment> ListGetDepartmentCodeByGroupCode
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> GetDEpartmentCodeByGroupCodeList
        {
            get
            {
                return new SelectList(ListGetDepartmentCodeByGroupCode, "ID", "MerchantiseDepartmentCode");
            }
        }
        public bool IsConsumable
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.IsConsumable : new bool();
            }
            set
            {
                GeneralItemCategoryMasterDTO.IsConsumable = value;
            }
        }
        public bool IsMachine
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.IsMachine : new bool();
            }
            set
            {
                GeneralItemCategoryMasterDTO.IsMachine = value;
            }
        }
        public bool IsToner
        {
            get
            {
                return (GeneralItemCategoryMasterDTO != null) ? GeneralItemCategoryMasterDTO.IsToner : new bool();
            }
            set
            {
                GeneralItemCategoryMasterDTO.IsToner = value;
            }
        }



    }
}

