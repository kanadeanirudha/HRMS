using AERP.DTO;
using System;
namespace AERP.ViewModel
{
    public interface IPurchaseRequirementMasterViewModel 
    {
        PurchaseRequirementMaster PurchaseRequirementMasterDTO { get; set; }
        /// <summary>
        /// Properties for PurchaseRequirementMaster table
        /// </summary>
        int ID
        {
            get;
            set;
        }
        string PurchaseRequirementNumber
        {
            get;
            set;
        }
        string TransDate
        {
            get;
            set;
        }
        bool IsActive
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
        /// Properties for PurchaseRequirementDetails table
        /// </summary>
        int PurchaseRequirementDetailsID
        {
            get;
            set;
        }
        int ItemID
        {
            get;
            set;
        }
        decimal Quantity
        {
            get;
            set;
        }
        decimal Rate
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        int DepartmentID
        {
            get;
            set;
        }
        int StorageLocationID
        {
            get;
            set;
        }
        Int16 PriorityFlag
        {
            get;
            set;
        }
        Int16 ApprovedStatus
        {
            get;
            set;
        }
        string Remark
        {
            get;
            set;
        }
        int ApprovedBy
        {
            get;
            set;
        }
        string ApprovedDate
        {
            get;
            set;
        }
        decimal ApprovedQuantity
        {
            get;
            set;
        }
        decimal DeliveredQuantity
        {
            get;
            set;
        }

    }
}
