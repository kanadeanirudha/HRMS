using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class InventoryBrandMasterViewModel : IInventoryBrandMasterViewModel
    {

        public InventoryBrandMasterViewModel()
        {
            InventoryBrandMasterDTO = new InventoryBrandMaster();

        }



        public InventoryBrandMaster InventoryBrandMasterDTO
        {
            get;
            set;
        }

        public int InventoryBrandMasterID
        {
            get
            {
                return (InventoryBrandMasterDTO != null) ? InventoryBrandMasterDTO.InventoryBrandMasterID : new int();
            }
            set
            {
                InventoryBrandMasterDTO.InventoryBrandMasterID = value;
            }
        }
        public Int16 ID
        {
            get
            {
                return (InventoryBrandMasterDTO != null && InventoryBrandMasterDTO.ID > 0) ? InventoryBrandMasterDTO.ID : new Int16();
            }
            set
            {
                InventoryBrandMasterDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Brand Name should not be blank.")]
        [Display(Name = "Brand Name")]
        public string BrandName
        {
            get
            {
                return (InventoryBrandMasterDTO != null) ? InventoryBrandMasterDTO.BrandName : string.Empty;
            }
            set
            {
                InventoryBrandMasterDTO.BrandName = value;
            }
        }

        [Required(ErrorMessage = "Brand Description should not be blank.")]
        [Display(Name = "Brand Description")]
        public string BrandDescription
        {
            get
            {
                return (InventoryBrandMasterDTO != null) ? InventoryBrandMasterDTO.BrandDescription : string.Empty;
            }
            set
            {
                InventoryBrandMasterDTO.BrandDescription = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryBrandMasterDTO != null) ? InventoryBrandMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryBrandMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryBrandMasterDTO != null && InventoryBrandMasterDTO.CreatedBy > 0) ? InventoryBrandMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryBrandMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryBrandMasterDTO != null) ? InventoryBrandMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryBrandMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryBrandMasterDTO != null) ? InventoryBrandMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryBrandMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryBrandMasterDTO != null) ? InventoryBrandMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryBrandMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryBrandMasterDTO != null) ? InventoryBrandMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryBrandMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryBrandMasterDTO != null) ? InventoryBrandMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryBrandMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

