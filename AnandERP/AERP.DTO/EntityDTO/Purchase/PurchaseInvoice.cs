using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class PurchaseInvoice : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int PurchaseRequisitionMasterID
        {
            get;
            set;
        }
        public int AdminRoleID
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
        public string PurchaseOrderTypeDescription
        {
            get;
            set;
        }
        public decimal Freight
        {
            get;
            set;
        }
        public decimal ShippingHandling
        {
            get;
            set;
        }
        public decimal Discount
        {
            get;
            set;
        }
        public decimal TotalTaxAmount
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

        //-------------------Purchase Order Details fields------------------------//
        public int PurchaseOrderDetailsID
        {
            get;
            set;
        }
        public int PurchaseOrderMasterID
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
          public decimal FocReceivedQuantity
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
        public string DepartmentName
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
        public string ItemName
        {
            get;
            set;
        }
        public string LocationName
        {
            get;
            set;
        }
        public decimal Amount
        {
            get;
            set;
        }
        public string VendorName
        {
            get;
            set;
        }
        public string VendorInvoiceNo
        {
            get;
            set;
        }
        public bool IsOtherState
        {
            get;set;
        }
        public int ItemCount
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        public string PurchaseRequisitionNumber
        {
            get;
            set;
        }
       
        public decimal TaxRate { get; set; }
        public int GenTaxGroupMasterID { get; set; }

        //new Itemaster Feilds
        public int ItemNumber
        {
            get;
            set;
        }
        public string BarCode
        {
            get;
            set;
        }
        public string OrderUomCode
        {
            get;
            set;
        }

        public int GeneralItemCodeID
        {
            get;
            set;
        }

        public decimal BaseUOMQuantity
        {
            get;
            set;
        }
        public string BaseUOMCode
        {
            get;
            set;
        }
        public int PurchaseGRNMasterID
        {
            get;
            set;
        }

        public string GRNNumber
        {
            get;
            set;
        }
        public string GRNTransDate
        {
            get;
            set;
        }
        public string BatchNumber
        {
            get;
            set;
        }
        public string ExpiryDate
        {
            get;
            set;
        }
        public decimal TotalInvoiceAmount
        {
            get;
            set;
        }
        public string XMLstringForVouchar
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public Int16 GeneralUnitsID
        {
            get;
            set;
        }
        public string Convertion
        {
            get;
            set;
        }
        public string UnitCode
        {
            get;
            set;
        }
        public string TaxRateList
        {
            get;
            set;
        }
        public string TaxList
        {
            get;
            set;
        }
        public string XmlStringForDirectinvoiceVoucher { get; set; }
        public string PurchaseDetailsXML { get; set; }

    }
}
