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
    public class PurchaseReplenishmentViewModel : IPurchaseReplenishmentViewModel
    {
        public PurchaseReplenishmentViewModel()
        {
            PurchaseReplenishmentDTO = new PurchaseReplenishment();
            GetReplenishmentList = new List<PurchaseReplenishment>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();

            ListGeneralUnits = new List<GeneralUnits>();
        }
        public List<GeneralUnits> ListGeneralUnits
        {
            get;
            set;
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
        public IEnumerable<SelectListItem> ListGetGeneralUnitsItems
        {
            get
            {
                return new SelectList(ListGeneralUnits, "ID", "UnitName");
            }
        }
        public List<PurchaseReplenishment> GetReplenishmentList { get; set; }
        public PurchaseReplenishment PurchaseReplenishmentDTO { get; set; }
        
        /// <summary>
        /// Properties for PurchaseReplenishment table
        /// </summary>
        public int ID
        {
            get
            {
                return (PurchaseReplenishmentDTO != null && PurchaseReplenishmentDTO.ID > 0) ? PurchaseReplenishmentDTO.ID : new int();
            }
            set
            {
                PurchaseReplenishmentDTO.ID = value;
            }
        }
           [Display(Name = "Centre Name")]
        public string CentreCode
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.CentreCode : string.Empty;
            }
            set
            {
                PurchaseReplenishmentDTO.CentreCode = value;
            }
        }
        public string SelectedCentreCode
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                PurchaseReplenishmentDTO.SelectedCentreCode = value;
            }
        }

        public string CenterCode
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.CenterCode : string.Empty;
            }
            set
            {
                PurchaseReplenishmentDTO.CenterCode = value;
            }
        }
        public int ItemCount
        {
            get
            {
                return (PurchaseReplenishmentDTO != null && PurchaseReplenishmentDTO.ItemCount > 0) ? PurchaseReplenishmentDTO.ItemCount : new int();
            }
            set
            {
                PurchaseReplenishmentDTO.ItemCount = value;
            }
        }
        public int VendorNumber
        {
            get
            {
                return (PurchaseReplenishmentDTO != null && PurchaseReplenishmentDTO.VendorNumber > 0) ? PurchaseReplenishmentDTO.VendorNumber : new int();
            }
            set
            {
                PurchaseReplenishmentDTO.VendorNumber = value;
            }
        }    
        [Display(Name = "Date")]
        public string TransDate
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.TransDate : string.Empty;
            }
            set
            {
                PurchaseReplenishmentDTO.TransDate = value;
            }
        }
        public string ReplishmentCode
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.ReplishmentCode : string.Empty;
            }
            set
            {
                PurchaseReplenishmentDTO.ReplishmentCode = value;
            }
        }
        [Display(Name = "Store")]
        public Int16 GeneralUnitsID
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.GeneralUnitsID : new Int16();
            }
            set
            {
                PurchaseReplenishmentDTO.GeneralUnitsID = value;
            }
        }
        
        public decimal Price
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.Price : new decimal();
            }
            set
            {
                PurchaseReplenishmentDTO.Price = value;
            }
        }
        public string Vendor
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.Vendor : string.Empty;
            }
            set
            {
                PurchaseReplenishmentDTO.Vendor = value;
            }
        }
        public int VendorID
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.VendorID : new int();
            }
            set
            {
                PurchaseReplenishmentDTO.VendorID = value;
            }
        }


        public int CreatedBy
        {
            get
            {
                return (PurchaseReplenishmentDTO != null && PurchaseReplenishmentDTO.CreatedBy > 0) ? PurchaseReplenishmentDTO.CreatedBy : new short();
            }
            set
            {
                PurchaseReplenishmentDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                PurchaseReplenishmentDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (PurchaseReplenishmentDTO != null && PurchaseReplenishmentDTO.ModifiedBy > 0) ? PurchaseReplenishmentDTO.ModifiedBy : new int();
            }
            set
            {
                PurchaseReplenishmentDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                PurchaseReplenishmentDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (PurchaseReplenishmentDTO != null) ? PurchaseReplenishmentDTO.IsDeleted : false;
            }
            set
            {
                PurchaseReplenishmentDTO.IsDeleted = value;
            }
        }
        public string errorMessage { get; set; }

      
      
    }
}
