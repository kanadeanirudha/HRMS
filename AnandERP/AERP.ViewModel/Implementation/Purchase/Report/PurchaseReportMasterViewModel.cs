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
    public class PurchaseReportMasterViewModel : IPurchaseReportMasterViewModel
    {
        public PurchaseReportMasterViewModel()
        {
            PurchaseReportMasterDTO = new PurchaseReportMaster();
            PurchaseReportMasterListFromPO = new List<PurchaseReportMaster>();
            ListInventoryLocationMaster = new List<InventoryLocationMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGeneralUnits = new List<GeneralUnits>();
        }
       
        public PurchaseReportMaster PurchaseReportMasterDTO { get; set; }
        public List<PurchaseReportMaster> PurchaseReportMasterListFromPO { get; set; }
        public List<InventoryLocationMaster> ListInventoryLocationMaster { get; set; }
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

        public List<PurchaseReportMaster> PurchaseReportMasterDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Properties for PurchaseReportMaster table
        /// </summary>
        public int ID
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.ID > 0) ? PurchaseReportMasterDTO.ID : new int();
            }
            set
            {
                PurchaseReportMasterDTO.ID = value;
            }
        }
        public int VendorNumber
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.VendorNumber > 0) ? PurchaseReportMasterDTO.VendorNumber : new int();
            }
            set
            {
                PurchaseReportMasterDTO.VendorNumber = value;
            }
        }
          
        public int ItemNumber
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.ItemNumber > 0) ? PurchaseReportMasterDTO.ItemNumber : new int();
            }
            set
            {
                PurchaseReportMasterDTO.ItemNumber = value;
            }
        }
        [Display (Name="Location Name")]
        public int LocationID
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.LocationID > 0) ? PurchaseReportMasterDTO.LocationID : new int();
            }
            set
            {
                PurchaseReportMasterDTO.LocationID = value;
            }
        }
        public int BalancesheetID
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.BalancesheetID > 0) ? PurchaseReportMasterDTO.BalancesheetID : new int();
            }
            set
            {
                PurchaseReportMasterDTO.BalancesheetID = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.CreatedBy > 0) ? PurchaseReportMasterDTO.CreatedBy : new int();
            }
            set
            {
                PurchaseReportMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                PurchaseReportMasterDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.ModifiedBy > 0) ? PurchaseReportMasterDTO.ModifiedBy : new int();
            }
            set
            {
                PurchaseReportMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                PurchaseReportMasterDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.IsDeleted : false;
            }
            set
            {
                PurchaseReportMasterDTO.IsDeleted = value;
            }
        }
        public string errorMessage { get; set; }

     
        /// <summary>
        /// Properties for PurchaseRequirementDetails table
        /// </summary>
       
        public decimal Quantity
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.Quantity > 0) ? PurchaseReportMasterDTO.Quantity : new decimal();
            }
            set
            {
                PurchaseReportMasterDTO.Quantity = value;
            }
        }
       
        public decimal Rate
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.Rate > 0) ? PurchaseReportMasterDTO.Rate : new decimal();
            }
            set
            {
                PurchaseReportMasterDTO.Rate = value;
            }
        }
       
        public string BarCode
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.BarCode : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.BarCode = value;
            }
        }
        public string BatchNumber
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.BatchNumber : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.BatchNumber = value;
            }
        }
        public string PurchaseOrderNumber
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.PurchaseOrderNumber : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.PurchaseOrderNumber = value;
            }
        }
        [Display(Name="Item Name")]
        public string ItemName
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.ItemName : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.ItemName = value;
            }
        }
       
        public decimal OpeningBalanceQty
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.OpeningBalanceQty > 0) ? PurchaseReportMasterDTO.OpeningBalanceQty : new decimal();
            }
            set
            {
                PurchaseReportMasterDTO.OpeningBalanceQty = value;
            }
        }
        public decimal ClosingBalanceQty
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.ClosingBalanceQty > 0) ? PurchaseReportMasterDTO.ClosingBalanceQty : new decimal();
            }
            set
            {
                PurchaseReportMasterDTO.ClosingBalanceQty = value;
            }
        }
        public decimal CurrentStockQty
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.CurrentStockQty > 0) ? PurchaseReportMasterDTO.CurrentStockQty : new decimal();
            }
            set
            {
                PurchaseReportMasterDTO.CurrentStockQty = value;
            }
        }
        public string TransDate
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.TransDate : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.TransDate = value;
            }
        }
        public string BaseUOMCode
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.BaseUOMCode : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.BaseUOMCode = value;
            }
        }
        public string TransactionUOM
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.TransactionUOM : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.TransactionUOM = value;
            }
        }
        public decimal TransactionQuantity
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.TransactionQuantity > 0) ? PurchaseReportMasterDTO.TransactionQuantity : new decimal();
            }
            set
            {
                PurchaseReportMasterDTO.TransactionQuantity = value;
            }
        }
        public string MovementTypeCode
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.MovementTypeCode : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.MovementTypeCode = value;
            }
        }
        public string LocationName
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.LocationName : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.LocationName = value;
            }
        }
        public string ItemDescription
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.ItemDescription = value;
            }
        }
        public string MovementType
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.MovementType : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.MovementType = value;
            }
        }

        public decimal Amount
        {
            get
            {
                return (PurchaseReportMasterDTO != null && PurchaseReportMasterDTO.Amount > 0) ? PurchaseReportMasterDTO.Amount : new decimal();
            }
            set
            {
                PurchaseReportMasterDTO.Amount = value;
            }
        }
        [AllowHtml]
        public string LocationNameListXml
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.LocationNameListXml : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.LocationNameListXml = value;
            }
        }
        public Byte TransactionTypeId
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.TransactionTypeId : new byte();
            }
            set
            {
                PurchaseReportMasterDTO.TransactionTypeId = value;
            }
        }
        //For Order status Report
        public bool IsPosted
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.IsPosted : false;
            }
            set
            {
                PurchaseReportMasterDTO.IsPosted = value;
            }
        }
        public Int16 GeneralUnitsID
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.GeneralUnitsID : new Int16();
            }
            set
            {
                PurchaseReportMasterDTO.GeneralUnitsID = value;
            }
        }
        [Display(Name = "Centre")]
        public string CentreCode
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.CentreCode = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.CentreName : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.CentreName = value;
            }
        }
        public string GeneralUnitsName
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.GeneralUnitsName : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.GeneralUnitsName = value;
            }
        }
        [Display(Name = "From Date")]
        public string FromDate
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.FromDate : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.FromDate = value;
            }
        }
        [Display(Name = "Upto Date")]
        public string UptoDate
        {
            get
            {
                return (PurchaseReportMasterDTO != null) ? PurchaseReportMasterDTO.UptoDate : string.Empty;
            }
            set
            {
                PurchaseReportMasterDTO.UptoDate = value;
            }
        }
    }
}
