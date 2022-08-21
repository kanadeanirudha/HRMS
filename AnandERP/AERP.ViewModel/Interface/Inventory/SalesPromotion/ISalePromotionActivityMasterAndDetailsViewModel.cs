
using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface ISalePromotionActivityMasterAndDetailsViewModel
    {
        SalePromotionActivityMasterAndDetails SalePromotionActivityMasterAndDetailsDTO
        {
            get;
            set;
        }

         int ID
        {
            get;
            set;
        }
         string Name
        {
            get;
            set;
        }
         string FromDate
        {
            get;
            set;
        }
         string UptoDate
        {
            get;
            set;
        }
         string PlanTypeCode
        {
            get;
            set;
        }
         int SalePromotionPlanDetailsID
        {
            get;
            set;
        }
         int SalePromotionActivityMasterID
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
