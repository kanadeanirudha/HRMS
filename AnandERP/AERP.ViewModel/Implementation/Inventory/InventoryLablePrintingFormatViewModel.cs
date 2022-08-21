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
    public class InventoryLablePrintingFormatViewModel 
    {
        public InventoryLablePrintingFormatViewModel()
        {
            InventoryLablePrintingFormatDTO = new InventoryLablePrintingFormat();
            InventoryLablePrintingFormatListFromPO = new List<InventoryLablePrintingFormat>();
            ListInventoryLocationMaster = new List<InventoryLocationMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
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
        public InventoryLablePrintingFormat InventoryLablePrintingFormatDTO { get; set; }
        public List<InventoryLablePrintingFormat> InventoryLablePrintingFormatListFromPO { get; set; }
        public List<InventoryLocationMaster> ListInventoryLocationMaster { get; set; }
        public List<InventoryLablePrintingFormat> InventoryLablePrintingFormatDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Properties for InventoryLablePrintingFormat table
        /// </summary>
        public string SelectedCentreCode
        {
            get
            {
                return (InventoryLablePrintingFormatDTO != null) ? InventoryLablePrintingFormatDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                InventoryLablePrintingFormatDTO.SelectedCentreCode = value;
            }
        }
        [Display(Name = "Centre Name")]
        public string CentreCode
        {
            get
            {
                return (InventoryLablePrintingFormatDTO != null) ? InventoryLablePrintingFormatDTO.CentreCode : string.Empty;
            }
            set
            {
                InventoryLablePrintingFormatDTO.CentreCode = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (InventoryLablePrintingFormatDTO != null && InventoryLablePrintingFormatDTO.ItemNumber > 0) ? InventoryLablePrintingFormatDTO.ItemNumber : new int();
            }
            set
            {
                InventoryLablePrintingFormatDTO.ItemNumber = value;
            }
        }
        [Display(Name = "To Item Number")]
        public int ToItemNumber
        {
            get
            {
                return (InventoryLablePrintingFormatDTO != null && InventoryLablePrintingFormatDTO.ToItemNumber > 0) ? InventoryLablePrintingFormatDTO.ToItemNumber : new int();
            }
            set
            {
                InventoryLablePrintingFormatDTO.ToItemNumber = value;
            }
        }
        [Display(Name = "From Item Number")]
        public int FromItemNumber
        {
            get
            {
                return (InventoryLablePrintingFormatDTO != null && InventoryLablePrintingFormatDTO.FromItemNumber > 0) ? InventoryLablePrintingFormatDTO.FromItemNumber : new int();
            }
            set
            {
                InventoryLablePrintingFormatDTO.FromItemNumber = value;
            }
        }
        
        public string errorMessage { get; set; }


        /// <summary>
        /// Properties for PurchaseRequirementDetails table
        /// </summary>

       

        public string BarCode
        {
            get
            {
                return (InventoryLablePrintingFormatDTO != null) ? InventoryLablePrintingFormatDTO.BarCode : string.Empty;
            }
            set
            {
                InventoryLablePrintingFormatDTO.BarCode = value;
            }
        }
        public string CurrencyCode
        {
            get
            {
                return (InventoryLablePrintingFormatDTO != null) ? InventoryLablePrintingFormatDTO.CurrencyCode : string.Empty;
            }
            set
            {
                InventoryLablePrintingFormatDTO.CurrencyCode = value;
            }
        }


       [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (InventoryLablePrintingFormatDTO != null) ? InventoryLablePrintingFormatDTO.ItemDescription : string.Empty;
            }
            set
            {
                InventoryLablePrintingFormatDTO.ItemDescription = value;
            }
        }
        [Display(Name = "Store")]
        public int GeneralUnitsID
        {
            get
            {
                return (InventoryLablePrintingFormatDTO != null && InventoryLablePrintingFormatDTO.GeneralUnitsID > 0) ? InventoryLablePrintingFormatDTO.GeneralUnitsID : new int();
            }
            set
            {
                InventoryLablePrintingFormatDTO.GeneralUnitsID = value;
            }
        }
        [Display(Name = "Sale UoM")]
        public string SalesUoM
        {
            get
            {
                return (InventoryLablePrintingFormatDTO != null) ? InventoryLablePrintingFormatDTO.SalesUoM : string.Empty;
            }
            set
            {
                InventoryLablePrintingFormatDTO.SalesUoM = value;
            }
        }
        
        
       
    }
}
