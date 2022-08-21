using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class PurchaseReplenishment : BaseDTO
    {
        /// <summary>
        /// Properties for PurchaseReplenishment table
        /// </summary>
        public int ID
        {
            get;
            set;
        }
        public int VendorID
        {
            get;
            set;
        }
        public int VendorNumber
        {
            get;
            set;
        }
        public int ItemCount
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public string Vendor
        {
            get;
            set;
        }
        public string TransDate
        {
            get;
            set;
        }
        public string ReplishmentCode
        {
            get;
            set;
        }
        public Int16 GeneralUnitsID
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
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }

        /// <summary>
        /// Properties for PurchaseRequisitionDetails table
        /// </summary>
      
        public string errorMessage
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string CenterCode
        {
            get;
            set;
        }
        // policy fields for backdated date or not
      
      
    }
}

