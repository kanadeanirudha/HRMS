using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class InventoryUoMGroupAndDetailsViewModel : IInventoryUoMGroupAndDetailsViewModel
    {

        public InventoryUoMGroupAndDetailsViewModel()
        {
            InventoryUoMGroupAndDetailsDTO = new InventoryUoMGroupAndDetails();
            InventoryUoMGroupDetailsList = new List<InventoryUoMGroupAndDetails>();
        }
        public List<InventoryUoMGroupAndDetails> InventoryUoMGroupDetailsList { get; set; }
        public InventoryUoMGroupAndDetails InventoryUoMGroupAndDetailsDTO
        {
            get;
            set;
        }

        //Inventory UoM Group
        public Int16 InventoryUoMGroupID
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null && InventoryUoMGroupAndDetailsDTO.InventoryUoMGroupID > 0) ? InventoryUoMGroupAndDetailsDTO.InventoryUoMGroupID : new Int16();
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.InventoryUoMGroupID = value;
            }
        }

        [Required(ErrorMessage = "Group Code should not be blank.")]
        [Display(Name = "Group Code")]
        public string GroupCode
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.GroupCode : string.Empty;
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.GroupCode = value;
            }
        }
        [Required(ErrorMessage = "Group Description should not be blank.")]
        [Display(Name = "Group Description")]
        public string GroupDescription
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.GroupDescription : string.Empty;
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.GroupDescription = value;
            }
        }
        [Required(ErrorMessage = "Base Uom Code should not be blank.")]
        [Display(Name = "Base Uom Code")]
        public string BaseUomCode
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.BaseUomCode : string.Empty;
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.BaseUomCode = value;
            }
        }
        //Inventory UoM Group Details
        public Int16 InventoryUoMGroupDetailsID
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null && InventoryUoMGroupAndDetailsDTO.InventoryUoMGroupDetailsID > 0) ? InventoryUoMGroupAndDetailsDTO.InventoryUoMGroupDetailsID : new Int16();
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.InventoryUoMGroupDetailsID = value;
            }
        }
        [Required(ErrorMessage = "Alt Uom Name should not be blank.")]
        [Display(Name = "Alt Uom Name")]
        public string AlternativeUomName
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.AlternativeUomName : string.Empty;
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.AlternativeUomName = value;
            }
        }

        [Required(ErrorMessage = "Alt Uom Code should not be blank.")]
        [Display(Name = "Alt Uom Code")]
        public string AlternativeUomCode
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.AlternativeUomCode : string.Empty;
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.AlternativeUomCode = value;
            }
        }
        [Display(Name = "Alt Qty")]
        public decimal AlternativeQuantity
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null && InventoryUoMGroupAndDetailsDTO.AlternativeQuantity > 0) ? InventoryUoMGroupAndDetailsDTO.AlternativeQuantity : new decimal();
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.AlternativeQuantity = value;
            }
        }
         [Display(Name = "Base UoM Qty")]
        public decimal BaseUoMQuantity
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null && InventoryUoMGroupAndDetailsDTO.BaseUoMQuantity > 0) ? InventoryUoMGroupAndDetailsDTO.BaseUoMQuantity : new decimal();
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.BaseUoMQuantity = value;
            }
        }
        [Display(Name = "Price Reduced By")]
        public decimal BasePriceReducedBy
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null && InventoryUoMGroupAndDetailsDTO.BasePriceReducedBy > 0) ? InventoryUoMGroupAndDetailsDTO.BasePriceReducedBy : new decimal();
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.BasePriceReducedBy = value;
            }
        }
         [Display(Name = "Used For")]
         public Int16 UsedFor
         {
             get
             {
                 return (InventoryUoMGroupAndDetailsDTO != null && InventoryUoMGroupAndDetailsDTO.UsedFor > 0) ? InventoryUoMGroupAndDetailsDTO.UsedFor : new Int16();
             }
             set
             {
                 InventoryUoMGroupAndDetailsDTO.UsedFor = value;
             }
         }

        //Common Properties
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null && InventoryUoMGroupAndDetailsDTO.CreatedBy > 0) ? InventoryUoMGroupAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.DeletedBy : new int();
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryUoMGroupAndDetailsDTO != null) ? InventoryUoMGroupAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryUoMGroupAndDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

       
    }
}

