using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class SalePromotionActivityMasterAndDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UOMCodeForConcession
        {
            get;
            set;
        }
        public string PromotionFor
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }
        public string PlanTypeCode
        {
            get;
            set;
        }
        public int SalePromotionPlanDetailsID
        {
            get;
            set;
        }
        public int SalePromotionActivityMasterID
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public int GeneralItemMasterID
        {
            get;
            set;
        }
        public int PromotionActivityDiscounteItemListID
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string ItemDescriptionForConcession { get; set; }
        public string SaleUOMCode { get; set; }
        public string UOMCode
        {
            get;
            set;
        }
        public int InventoryVariationMasterID
        {
            get;
            set;
        }
        public decimal DiscountInPercentage
        {
            get;
            set;
        }
        public decimal DiscountInPercentageForItemdetails
        {
            get;
            set;
        }
        public string XMLstring
        {
            get;
            set;
        }
        public string ParameterXmlForFixedData
        {
            get;
            set;
        }
        public string ParameterXmlForItemDetails
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool StatusFlag
        {
            get;
            set;
        }
        public Int16 ExternalFlag
        {
            get;
            set;
        }
        public bool IsCoupanOrGiftVoucherApplicable
        {
            get;
            set;
        }
        public bool IsCommon
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

        public string PlanTypeName { get; set; }
        public string SubActivityName { get; set; }
        public decimal BillAmountRangeFrom { get; set; }
        public decimal BillAmountRangeUpto { get; set; }
        public decimal BillDiscountAmount { get; set; }
        public bool IsItemWiseDiscountExclude { get; set; }
        public bool IsPercentage { get; set; }

        public int SalePromotionPlanID
        {
            get;
            set;
        }
        public int SalePromotionActivityDetailsID
        {
            get;
            set;
        }
        public int SalePromotionGiftVoucharID
        {
            get;
            set;
        }

        public bool IsActivted
        {
            get;
            set;
        }
        public string PlanDescription { get; set; }

        public string RecipeVariationTitle { get; set; }
        public string MenuDescription { get; set; }
        public byte ProductConcessionFreeType
        {
            get;
            set;    
        }
        public byte PromotionApplicableTo
        {
            get;
            set;
        }
        public string  BillRange
        {
            get;
            set;
        }
        public bool IsDiscountAmount
        {
            get;
            set;
        }

        public bool IsFreeItem
        {
            get;
            set;
        }

        public decimal Quantity
        {
            get;
            set;
        }
        public string ParameterXmlForGiftVouchar
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }

    }
}
