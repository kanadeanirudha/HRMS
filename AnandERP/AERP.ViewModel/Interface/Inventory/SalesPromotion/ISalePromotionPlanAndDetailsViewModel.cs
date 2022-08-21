using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface ISalePromotionPlanAndDetailsViewModel
    {
        SalePromotionPlanAndDetails SalePromotionPlanAndDetailsDTO
        {
            get;
            set;
        }

        //************SalePromotionPlan************//
         int SalePromotionPlanID
        {
            get;
            set;
        }
         string PlanTypeName
        {
            get;
            set;
        }
         string PlanTypeCode
        {
            get;
            set;
        }

        //************SalePromotionPlanDetails************//
         int SalePromotionPlanDetailsID
        {
            get;
            set;
        }
         Int16 HowManyQtyToBuy
        {
            get;
            set;
        }
         int GiftItemQty
        {
            get;
            set;
        }
         bool IsSampling
        {
            get;
            set;
        }
         decimal DiscountInPercent
        {
            get;
            set;
        }
         decimal BillAmountRangeFrom
        {
            get;
            set;
        }
         decimal BillAmountRangeUpto
        {
            get;
            set;
        }
         decimal BillDiscountAmount
        {
            get;
            set;
        }

       
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
