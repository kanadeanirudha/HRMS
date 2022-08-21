using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class SalePromotionPlanAndDetails : BaseDTO
    {
        //************SalePromotionPlan************//
        public int SalePromotionPlanID
        {
            get;
            set;
        }
        public string PlanTypeName
        {
            get;
            set;
        }
        public string PlanTypeCode
        {
            get;
            set;
        }

        //************SalePromotionPlanDetails************//
        public int SalePromotionPlanDetailsID
        {
            get;
            set;
        }
        public Int16 HowManyQtyToBuy
        {
            get;
            set;
        }
        public int GiftItemQty
        {
            get;
            set;
        }
        public bool IsSampling
        {
            get;
            set;
        }
        public decimal DiscountInPercent
        {
            get;
            set;
        }
        public string type
        {
            get;
            set;
        }
        public decimal BillAmountRangeFrom
        {
            get;
            set;
        }
        public decimal BillAmountRangeUpto
        {
            get;
            set;
        }
        public decimal BillDiscountAmount
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
        public bool IsDeleted
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

        public bool IsPercentage
        {
            get;
            set;
        }
        public bool IsItemWiseDiscountExclude
        {
            get;
            set;
        }
        public string PlanDescription
        {
            get;
            set;
        }
        public string BillRangeList
        {
            get;
            set;
        }
        
    }
}
