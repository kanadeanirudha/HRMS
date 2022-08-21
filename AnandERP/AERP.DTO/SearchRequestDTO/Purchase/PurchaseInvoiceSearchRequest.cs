using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class PurchaseInvoiceSearchRequest : Request
    {

        public int ID
        {
            get;
            set;
        }
        public int PurchaseOrderMasterID
        {
            get;
            set;
        }
        public int AdminRoleID
        {
            get;
            set;
        }
        public int PurchaseGRNMasterID
        {
            get;
            set;
        }
        public string PurchaseOrderNumber
        {
            get;
            set;
        }
        public string PurchaseOrderDate
        {
            get;
            set;
        }
        public int VendorID
        {
            get;
            set;
        }
        public Int16 PurchaseOrderType
        {
            get;
            set;
        }

        //------------------------------Purchase order details--------------------------------//
        public int PurchaseOrderDetailsID
        {
            get;
            set;
        }
        public int PurchaseRequisitionDetailsID
        {
            get;
            set;
        }
        public int ItemID
        {
            get;
            set;
        }
        public decimal Quantity
        {
            get;
            set;
        }
        public decimal Rate
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public int StorageLocationID
        {
            get;
            set;
        }
        public int IssueFromLocationID
        {
            get;
            set;
        }
        public string ExpectedDeliveryDate
        {
            get;
            set;
        }
        public Int16 PriorityFlag
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
    }
}
