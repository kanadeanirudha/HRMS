using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class SalePromotionActivityMasterAndDetailsViewModel : ISalePromotionActivityMasterAndDetailsViewModel
    {

        public SalePromotionActivityMasterAndDetailsViewModel()
        {
            SalePromotionActivityMasterAndDetailsDTO = new SalePromotionActivityMasterAndDetails();
            ListGetGeneralunits = new List<GeneralUnits>();
            GetPlanList = new List<SalePromotionActivityMasterAndDetails>();
            GetConsessionItemList = new List<SalePromotionActivityMasterAndDetails>();
            GetItemList = new List<SalePromotionActivityMasterAndDetails>();
            GetGiftVocherList = new List<SalePromotionActivityMasterAndDetails>();
            GetFixAmountList = new List<SalePromotionActivityMasterAndDetails>();
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
        public List<SalePromotionActivityMasterAndDetails> GetPlanList { get; set; }
        public List<SalePromotionActivityMasterAndDetails> GetConsessionItemList { get; set; }
        public List<SalePromotionActivityMasterAndDetails> GetItemList { get; set; }
        public List<SalePromotionActivityMasterAndDetails> GetGiftVocherList { get; set; }
        
        public List<SalePromotionActivityMasterAndDetails> GetFixAmountList { get; set; }
        public SalePromotionActivityMasterAndDetails SalePromotionActivityMasterAndDetailsDTO
        {
            get;
            set;
        }
        public List<GeneralUnits> ListGetGeneralunits
        {
            get;
            set;
        }
        //public IEnumerable<SelectListItem> ListGetGeneralUnitsItems
        //{
        //    get
        //    {
        //        return new SelectList(ListGetGeneralunits, "ID", "UnitName");
        //    }
        //}
           
        public int ID
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null && SalePromotionActivityMasterAndDetailsDTO.ID > 0) ? SalePromotionActivityMasterAndDetailsDTO.ID : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.ID = value;
            }
        }
            [Required(ErrorMessage = "Please Enter Name.")]
        public string Name
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.Name : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.Name = value;
            }
        }
            [Required(ErrorMessage = "Please Enter Promotion For.")]
            [Display(Name = "Promotion For")]
            public string PromotionFor
            {
                get
                {
                    return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.PromotionFor : string.Empty;
                }
                set
                {
                    SalePromotionActivityMasterAndDetailsDTO.PromotionFor = value;
                }
            }
        public string SubActivityName
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.SubActivityName : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.SubActivityName = value;
            }
        }
        public string SaleUOMCode
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.SaleUOMCode : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.SaleUOMCode = value;
            }
        }
        [Required(ErrorMessage = "Please Select From Date.")]
        [Display(Name = "From Date")]
        public string FromDate
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.FromDate : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.FromDate = value;
            }
        }
      
         [Display(Name = "Upto Date")]
        public string UptoDate
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.UptoDate : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.UptoDate = value;
            }
        }
        [Required(ErrorMessage = "Please Select Plan Type Code.")]
          [Display(Name = "Plan Type Code")]
        public string PlanTypeCode
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.PlanTypeCode : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.PlanTypeCode = value;
            }
        }
        [Display(Name = "Plan Type Name")]
        public string PlanTypeName
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.PlanTypeName : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.PlanTypeName = value;
            }
        }
        public int SalePromotionPlanDetailsID
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null && SalePromotionActivityMasterAndDetailsDTO.SalePromotionPlanDetailsID > 0) ? SalePromotionActivityMasterAndDetailsDTO.SalePromotionPlanDetailsID : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.SalePromotionPlanDetailsID = value;
            }
        }
        public int SalePromotionActivityMasterID
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null && SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityMasterID > 0) ? SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityMasterID : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityMasterID = value;
            }
        }
        public int GeneralUnitsID
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null && SalePromotionActivityMasterAndDetailsDTO.GeneralUnitsID > 0) ? SalePromotionActivityMasterAndDetailsDTO.GeneralUnitsID : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.GeneralUnitsID = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null && SalePromotionActivityMasterAndDetailsDTO.ItemNumber > 0) ? SalePromotionActivityMasterAndDetailsDTO.ItemNumber : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Discount (%)")]
        public decimal DiscountInPercentage
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null && SalePromotionActivityMasterAndDetailsDTO.DiscountInPercentage > 0) ? SalePromotionActivityMasterAndDetailsDTO.DiscountInPercentage : new decimal();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.DiscountInPercentage = value;
            }
        }
         [Display(Name = "UOM Code")]
        public string UOMCode
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.UOMCode : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.UOMCode = value;
            }
        }
          [Display(Name = "UOM Code")]
        public string UOMCodeForConcession
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.UOMCodeForConcession : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.UOMCodeForConcession = value;
            }
        }
         [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.ItemDescription : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.ItemDescription = value;
            }
        }
         [Display(Name = "Item Description")]
         public string ItemDescriptionForConcession
         {
             get
             {
                 return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.ItemDescriptionForConcession : string.Empty;
             }
             set
             {
                 SalePromotionActivityMasterAndDetailsDTO.ItemDescriptionForConcession = value;
             }
         }
        
        public int InventoryVariationMasterID
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null && SalePromotionActivityMasterAndDetailsDTO.InventoryVariationMasterID > 0) ? SalePromotionActivityMasterAndDetailsDTO.InventoryVariationMasterID : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.InventoryVariationMasterID = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.XMLstring : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.XMLstring = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.IsActive : false;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.IsActive = value;
            }
        }
        public bool StatusFlag
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.StatusFlag : false;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.StatusFlag = value;
            }
        }
        [Display(Name = "External Flag")]
        public Int16 ExternalFlag
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.ExternalFlag : new short();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.ExternalFlag = value;
            }
        }
        [Display(Name = "Is Coupon Or Gift Voucher Applicable")]
        public bool IsCoupanOrGiftVoucherApplicable
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.IsCoupanOrGiftVoucherApplicable : false;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.IsCoupanOrGiftVoucherApplicable = value;
            }
        }
        [Display(Name = "Is Common")]
        public bool IsCommon
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.IsCommon : false;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.IsCommon = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null && SalePromotionActivityMasterAndDetailsDTO.CreatedBy > 0) ? SalePromotionActivityMasterAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.DeletedBy : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }


        public int SalePromotionPlanID
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.SalePromotionPlanID : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.SalePromotionPlanID = value;
            }
        }

        public int SalePromotionActivityDetailsID
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityDetailsID : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityDetailsID = value;
            }
        }
        public int PromotionActivityDiscounteItemListID
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.PromotionActivityDiscounteItemListID : new int();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.PromotionActivityDiscounteItemListID = value;
            }
        }
        public string ParameterXmlForFixedData
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.ParameterXmlForFixedData : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.ParameterXmlForFixedData = value;
            }
        }
        public string ParameterXmlForItemDetails
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.ParameterXmlForItemDetails : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.ParameterXmlForItemDetails = value;
            }
        }
        public bool IsActivted
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.IsActivted : false;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.IsActivted = value;
            }
        }
         [Display(Name = "Plan Description")]
        public string PlanDescription
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.PlanDescription : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.PlanDescription = value;
            }
        }
        [Display(Name = "Product Concession Free Type")]
        public byte ProductConcessionFreeType
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.ProductConcessionFreeType : new byte();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.ProductConcessionFreeType = value;
            }
        }
        public byte PromotionApplicableTo
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.PromotionApplicableTo : new byte();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.PromotionApplicableTo = value;
            }
        }
        [Display(Name = "Bill Range")]
        public string BillRange
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.BillRange : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.BillRange = value;
            }
        }
        public bool IsDiscountAmount
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.IsDiscountAmount : new bool();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.IsDiscountAmount = value;
            }
        }

        public bool IsFreeItem
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.IsFreeItem : new bool();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.IsFreeItem = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.Quantity : new decimal();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.Quantity = value;
            }
        }
        [Display(Name = "Discount Amount")]
        public decimal BillDiscountAmount
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.BillDiscountAmount : new decimal();
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.BillDiscountAmount = value;
            }
        }
        public string ParameterXmlForGiftVouchar
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.ParameterXmlForGiftVouchar : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.ParameterXmlForGiftVouchar = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (SalePromotionActivityMasterAndDetailsDTO != null) ? SalePromotionActivityMasterAndDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                SalePromotionActivityMasterAndDetailsDTO.CentreCode = value;
            }
        }
    }
}

