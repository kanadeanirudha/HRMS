using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class SalePromotionPlanAndDetailsViewModel : ISalePromotionPlanAndDetailsViewModel
    {

        public SalePromotionPlanAndDetailsViewModel()
        {
            SalePromotionPlanAndDetailsDTO = new SalePromotionPlanAndDetails();

        }



        public SalePromotionPlanAndDetails SalePromotionPlanAndDetailsDTO
        {
            get;
            set;
        }

        public Int32 SalePromotionPlanID
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null && SalePromotionPlanAndDetailsDTO.SalePromotionPlanID > 0) ? SalePromotionPlanAndDetailsDTO.SalePromotionPlanID : new Int32();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.SalePromotionPlanID = value;
            }
        }

        [Required(ErrorMessage = "Plan Type Name should not be blank.")]
        [Display(Name = "Plan Type Name")]
        public string PlanTypeName
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.PlanTypeName : string.Empty;
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.PlanTypeName = value;
            }
        }

        [Required(ErrorMessage = "Plan Type Code should not be blank.")]
        [Display(Name = "Plan Type Code")]
        public string PlanTypeCode
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.PlanTypeCode : string.Empty;
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.PlanTypeCode = value;
            }
        }
        //************SalePromotionPlanDetails************//
        public Int32 SalePromotionPlanDetailsID
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null && SalePromotionPlanAndDetailsDTO.SalePromotionPlanDetailsID > 0) ? SalePromotionPlanAndDetailsDTO.SalePromotionPlanDetailsID : new Int32();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.SalePromotionPlanDetailsID = value;
            }
        }
         [Display(Name = "How Many Qty To Buy")]
        public Int16 HowManyQtyToBuy
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null && SalePromotionPlanAndDetailsDTO.HowManyQtyToBuy > 0) ? SalePromotionPlanAndDetailsDTO.HowManyQtyToBuy : new Int16();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.HowManyQtyToBuy = value;
            }
        }
        [Display(Name = "Gift Item Qty")]
        public Int32 GiftItemQty
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null && SalePromotionPlanAndDetailsDTO.GiftItemQty > 0) ? SalePromotionPlanAndDetailsDTO.GiftItemQty : new Int32();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.GiftItemQty = value;
            }
        }
           [Display(Name = "Is Sampling")]
        public bool IsSampling
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.IsSampling : false;
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.IsSampling = value;
            }
        }
           [Display(Name = "Discount (%)")]
        public decimal DiscountInPercent
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.DiscountInPercent : new decimal();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.DiscountInPercent = value;
            }
        }
           [Display(Name = "From Range")]
        public decimal BillAmountRangeFrom
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.BillAmountRangeFrom : new decimal();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.BillAmountRangeFrom = value;
            }
        }
        [Display(Name = "Upto Range")]
        public decimal BillAmountRangeUpto
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.BillAmountRangeUpto : new decimal();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.BillAmountRangeUpto = value;
            }
        }
        [Display(Name = "Bill Discount")]
        public decimal BillDiscountAmount
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.BillDiscountAmount : new decimal();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.BillDiscountAmount = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null && SalePromotionPlanAndDetailsDTO.CreatedBy > 0) ? SalePromotionPlanAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.DeletedBy : new int();
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.DeletedDate = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.IsDeleted = value;
            }
        }

        public string errorMessage { get; set; }

         [Display(Name = "Is Percentage")]
        public bool IsPercentage
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.IsPercentage : false;
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.IsPercentage = value;
            }
        }

           [Display(Name = "Item Wise Discount Exclude")]
        public bool IsItemWiseDiscountExclude
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.IsItemWiseDiscountExclude : false;
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.IsItemWiseDiscountExclude = value;
            }
        }
          [Required(ErrorMessage = "Plan Description should not be blank.")]
          [Display(Name = "Plan Description")]
           public string PlanDescription
           {
               get
               {
                   return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.PlanDescription : string.Empty;
               }
               set
               {
                   SalePromotionPlanAndDetailsDTO.PlanDescription = value;
               }
           }
        public string BillRangeList
        {
            get
            {
                return (SalePromotionPlanAndDetailsDTO != null) ? SalePromotionPlanAndDetailsDTO.BillRangeList : string.Empty;
            }
            set
            {
                SalePromotionPlanAndDetailsDTO.BillRangeList = value;
            }
        }

    }
}


