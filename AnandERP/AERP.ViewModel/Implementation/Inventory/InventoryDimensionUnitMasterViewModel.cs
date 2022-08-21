using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryDimensionUnitMasterViewModel : IInventoryDimensionUnitMasterViewModel
    {

        public InventoryDimensionUnitMasterViewModel()
        {
            InventoryDimensionUnitMasterDTO = new InventoryDimensionUnitMaster();

        }



        public InventoryDimensionUnitMaster InventoryDimensionUnitMasterDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null && InventoryDimensionUnitMasterDTO.ID > 0) ? InventoryDimensionUnitMasterDTO.ID : new Int16();
            }
            set
            {
                InventoryDimensionUnitMasterDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Dimension Code should not be blank.")]
        [Display(Name = "Dimension Code")]
        public string DimensionCode
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null) ? InventoryDimensionUnitMasterDTO.DimensionCode : string.Empty;
            }
            set
            {
                InventoryDimensionUnitMasterDTO.DimensionCode = value;
            }
        }

        [Required(ErrorMessage = "Dimension Description should not be blank.")]
        [Display(Name = "Dimension Description")]
        public string DimensionDescription
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null) ? InventoryDimensionUnitMasterDTO.DimensionDescription : string.Empty;
            }
            set
            {
                InventoryDimensionUnitMasterDTO.DimensionDescription = value;
            }
        }
        [Required(ErrorMessage = "SI Unit should not be blank.")]
        [Display(Name = "SI Unit")]
        public string SIUnit
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null) ? InventoryDimensionUnitMasterDTO.SIUnit : string.Empty;
            }
            set
            {
                InventoryDimensionUnitMasterDTO.SIUnit = value;
            }
        }

        [Required(ErrorMessage = "SI Description should not be blank.")]
        [Display(Name = "SI Description")]
        public string SIDescription
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null) ? InventoryDimensionUnitMasterDTO.SIDescription : string.Empty;
            }
            set
            {
                InventoryDimensionUnitMasterDTO.SIDescription = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null) ? InventoryDimensionUnitMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryDimensionUnitMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null && InventoryDimensionUnitMasterDTO.CreatedBy > 0) ? InventoryDimensionUnitMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryDimensionUnitMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null) ? InventoryDimensionUnitMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryDimensionUnitMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null) ? InventoryDimensionUnitMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryDimensionUnitMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null) ? InventoryDimensionUnitMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryDimensionUnitMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null) ? InventoryDimensionUnitMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryDimensionUnitMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryDimensionUnitMasterDTO != null) ? InventoryDimensionUnitMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryDimensionUnitMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

