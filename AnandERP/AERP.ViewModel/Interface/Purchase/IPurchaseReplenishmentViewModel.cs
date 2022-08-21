using AERP.DTO;
using System;
namespace AERP.ViewModel
{
    public interface IPurchaseReplenishmentViewModel
    {
        PurchaseReplenishment PurchaseReplenishmentDTO { get; set; }
        /// <summary>
        /// Properties for PurchaseReplenishment table
        /// </summary>
        int ID
        {
            get;
            set;
        }
      
        string TransDate
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
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }

       
       

    }
}
