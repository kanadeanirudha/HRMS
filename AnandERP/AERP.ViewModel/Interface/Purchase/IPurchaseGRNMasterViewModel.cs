using AERP.DTO;
using System;
namespace AERP.ViewModel
{
    public interface IPurchaseGRNMasterViewModel
    {
        PurchaseGRNMaster PurchaseGRNMasterDTO { get; set; }
        /// <summary>
        /// Properties for PurchaseGRNMaster table
        /// </summary>
        int ID
        {
            get;
            set;
        }
        int PurchaseOrderMasterID
        {
            get;
            set;
        }
        string GRNNumber
        {
            get;
            set;
        }
        string GRNTransDate
        {
            get;
            set;
        }

        bool IsLocked
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

        /// <summary>
        /// Properties for PurchaseGRNDetails table
        /// </summary>
        int PurchaseGRNDetailsID
        {
            get;
            set;
        }
        int ItemID
        {
            get;
            set;
        }
        decimal ReceivedQuantity
        {
            get;
            set;
        }
        int ReceivingLocationID
        {
            get;
            set;
        }
        
    }
}
