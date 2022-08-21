using AERP.DTO;
using System;
namespace AERP.ViewModel
{
    public interface IPurchaseInvoiceViewModel
    {
        PurchaseInvoice PurchaseInvoiceDTO { get; set; }
        /// <summary>
        /// Properties for PurchaseInvoice table
        /// </summary>
        int ID
        {
            get;
            set;
        }
        int PurchaseRequisitionMasterID
        {
            get;
            set;
        }
        string PurchaseOrderNumber
        {
            get;
            set;
        }
        string PurchaseOrderDate
        {
            get;
            set;
        }
        int VendorID
        {
            get;
            set;
        }
        Int16 PurchaseOrderType
        {
            get;
            set;
        }
        string PurchaseOrderTypeDescription
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
        decimal Freight
        {
            get;
            set;
        }
        decimal ShippingHandling
        {
            get;
            set;
        }
        decimal Discount
        {
            get;
            set;
        }
        decimal TotalTaxAmount
        {
            get;
            set;
        }

        //-------------------Purchase Order Details fields------------------------//
        int PurchaseOrderDetailsID
        {
            get;
            set;
        }
        int PurchaseRequisitionDetailsID
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
        int IssueFromLocationID
        {
            get;
            set;
        }
        string ExpectedDeliveryDate
        {
            get;
            set;
        }
        Int16 PriorityFlag
        {
            get;
            set;
        }

    }
}
