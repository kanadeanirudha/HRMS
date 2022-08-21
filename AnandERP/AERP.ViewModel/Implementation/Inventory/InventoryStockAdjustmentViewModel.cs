using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class InventoryStockAdjustmentViewModel : IInventoryStockAdjustmentViewModel
    {

        public InventoryStockAdjustmentViewModel()
        {
            InventoryStockAdjustmentDTO = new InventoryStockAdjustment();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGeneralUnits = new List<GeneralUnits>();

        }
        public List<GeneralUnits> ListGeneralUnits
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetGeneralUnitsItems
        {
            get
            {
                return new SelectList(ListGeneralUnits, "ID", "UnitName");
            }
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public InventoryStockAdjustment InventoryStockAdjustmentDTO
        {
            get;
            set;
        }
        public string XMLstring
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.XMLstring : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.XMLstring = value;
            }
        }
        public string OrderUom
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.OrderUom : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.OrderUom = value;
            }
        }
        public bool IsCurrentStock
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.IsCurrentStock : false;
            }
            set
            {
                InventoryStockAdjustmentDTO.IsCurrentStock = value;
            }
        }
        public string CurrentStockStatus
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.CurrentStockStatus : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.CurrentStockStatus = value;
            }
        }
        public Int32 ID
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.ID > 0) ? InventoryStockAdjustmentDTO.ID : new Int32();
            }
            set
            {
                InventoryStockAdjustmentDTO.ID = value;
            }
        }
        [Display(Name = "Store")]
        public int GeneralUnitsID
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.GeneralUnitsID > 0) ? InventoryStockAdjustmentDTO.GeneralUnitsID : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.GeneralUnitsID = value;
            }
        }
        public int InventoryPhysicalStockAdjustmentID
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.InventoryPhysicalStockAdjustmentID > 0) ? InventoryStockAdjustmentDTO.InventoryPhysicalStockAdjustmentID : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.InventoryPhysicalStockAdjustmentID = value;
            }
        }
        public int InventoryPhysicalStockAdjustmentMasterID
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.InventoryPhysicalStockAdjustmentMasterID > 0) ? InventoryStockAdjustmentDTO.InventoryPhysicalStockAdjustmentMasterID : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.InventoryPhysicalStockAdjustmentMasterID = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.ItemNumber > 0) ? InventoryStockAdjustmentDTO.ItemNumber : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.ItemNumber = value;
            }
        }
       
        [Display(Name = "Convertion")]
        public string Convertion
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.Convertion : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.Convertion = value;
            }
        }
        [Display(Name = "UOM")]
        public string LowerUom
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.LowerUom : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.LowerUom = value;
            }
        }
        [Display(Name = "UOM")]
        public string UOM
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.UOM : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.UOM = value;
            }
        }
        [Display(Name = "Item Description")]
        public string ItemName
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.ItemName = value;
            }
        }

        [Display(Name = "Bar Code")]
        public string BarCode
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.BarCode : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.BarCode = value;
            }
        }
        [Display(Name = "Action")]
        public byte Action
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.Action : new byte();
            }
            set
            {
                InventoryStockAdjustmentDTO.Action = value;
            }
        }
        [Display(Name = "Action")]
        public byte ActionStatus
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ActionStatus : new byte();
            }
            set
            {
                InventoryStockAdjustmentDTO.ActionStatus = value;
            }
        }

        [Display(Name = "Date")]
        public string TransDate
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.TransDate : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.TransDate = value;
            }
        }
        public double Quantity
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.Quantity : new double();
            }
            set
            {
                InventoryStockAdjustmentDTO.Quantity = value;
            }
        }
        public double RecipeQuantity
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.RecipeQuantity : new double();
            }
            set
            {
                InventoryStockAdjustmentDTO.RecipeQuantity = value;
            }
        }

        public double Rate
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.Rate : new double();
            }
            set
            {
                InventoryStockAdjustmentDTO.Rate = value;
            }
        }
          [Display(Name = "Corrected Stock")]
        public decimal CorrectedStock
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.CorrectedStock : new decimal();
            }
            set
            {
                InventoryStockAdjustmentDTO.CorrectedStock = value;
            }
        }
          public decimal ConvFact
          {
              get
              {
                  return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ConvFact : new decimal();
              }
              set
              {
                  InventoryStockAdjustmentDTO.ConvFact = value;
              }
          }
         [Display(Name = "Total Stock")]
        public decimal TotalStock
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.TotalStock : new decimal();
            }
            set
            {
                InventoryStockAdjustmentDTO.TotalStock = value;
            }
        }
         [Display(Name = "From Location")]
         public int IssueFromLocationID
         {
             get
             {
                 return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.IssueFromLocationID > 0) ? InventoryStockAdjustmentDTO.IssueFromLocationID : new int();
             }
             set
             {
                 InventoryStockAdjustmentDTO.IssueFromLocationID = value;
             }
         }
         [Display(Name = "Unrestricted Stock")]
        public decimal UnrestrictedStock
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.UnrestrictedStock : new decimal();
            }
            set
            {
                InventoryStockAdjustmentDTO.UnrestrictedStock = value;
            }
        }
        //Common fields//
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.CreatedBy > 0) ? InventoryStockAdjustmentDTO.CreatedBy : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryStockAdjustmentDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryStockAdjustmentDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.DeletedBy : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryStockAdjustmentDTO.DeletedDate = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.IsDeleted : false;
            }
            set
            {
                InventoryStockAdjustmentDTO.IsDeleted = value;
            }
        }

        public string errorMessage { get; set; }
        public string ParameterVoucherXmlForActionSample
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionSample : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionSample = value;
            }
        }

        public string ParameterVoucherXmlForActionDamaged
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionDamaged : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionDamaged = value;
            }
        }
        public string ParameterVoucherXmlForActionBlockedForInsp
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionBlockedForInsp : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionBlockedForInsp = value;
            }
        }
        public string ParameterVoucherXmlForActionPIPostive
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionPIPostive : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionPIPostive = value;
            }
        }
        public string ParameterVoucherXmlForActionPINegative
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionPINegative : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionPINegative = value;
            }
        }
        public string ParameterVoucherXmlForActionWastage
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionWastage : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionWastage = value;
            }
        }
        public string ParameterVoucherXmlForActionManualConsumption
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionManualConsumption : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionManualConsumption = value;
            }
        }

        public string ParameterVoucherXmlForActionShrinkage
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionShrinkage : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionShrinkage = value;
            }
        }
        public string ParameterVoucherXmlForActionBlockedForFreeBie
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionBlockedForFreeBie : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionBlockedForFreeBie = value;
            }
        }

        public int InventoryRecipeMasterID
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.InventoryRecipeMasterID > 0) ? InventoryStockAdjustmentDTO.InventoryRecipeMasterID : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.InventoryRecipeMasterID = value;
            }
        }
        public string RecipeTitle
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.RecipeTitle : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.RecipeTitle = value;
            }
        }

        public string RecipeDescription
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.RecipeDescription : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.RecipeDescription = value;
            }
        }
        public int PrimaryItemOutputID
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.PrimaryItemOutputID > 0) ? InventoryStockAdjustmentDTO.PrimaryItemOutputID : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.PrimaryItemOutputID = value;
            }
        }
        public int InventoryVariationMasterID
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.InventoryVariationMasterID > 0) ? InventoryStockAdjustmentDTO.InventoryVariationMasterID : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.InventoryVariationMasterID = value;
            }
        }
        public string RecipeVariationTitle
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.RecipeVariationTitle : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.RecipeVariationTitle = value;
            }
        }
        public string BatchNumber
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.BatchNumber : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.BatchNumber = value;
            }
        }
        public int BatchMasterID
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null && InventoryStockAdjustmentDTO.BatchMasterID > 0) ? InventoryStockAdjustmentDTO.BatchMasterID : new int();
            }
            set
            {
                InventoryStockAdjustmentDTO.BatchMasterID = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.CentreCode : string.Empty;
            }
            set
            {
                InventoryStockAdjustmentDTO.CentreCode = value;
            }
        }
        public byte SerialAndBatchManagedBy
        {
            get
            {
                return (InventoryStockAdjustmentDTO != null) ? InventoryStockAdjustmentDTO.SerialAndBatchManagedBy : new byte();
            }
            set
            {
                InventoryStockAdjustmentDTO.SerialAndBatchManagedBy = value;
            }
        }

    }
}


