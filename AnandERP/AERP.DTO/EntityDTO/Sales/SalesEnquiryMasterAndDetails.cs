using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class SalesEnquiryMasterAndDetails : BaseDTO
    {
        public Int32 SalesEnquiryMasterID
        {
            get;
            set;
        }
        public Int32 SaleEnquiryDetailsID
        {
            get;
            set;
        }
       
        public string CustomerMasterName
        {
            get;set;
        }
        public string CustomerBranchMasterName
        {
            get; set;
        }
        public string CustomerContactPersonName
        {
            get; set;
        }
        public int CustomerMasterID
        {
            get;
            set;
        }
        public int CustomerBranchMasterID
        {
            get;
            set;
        }
        public Int16 ContactPersonID
        {
            get;
            set;
        }
        public string TransactionDate
        {
            get;set;
        }
        public string EnquiryNumber
        {
            get; set;
        }
        public byte StatusMode
        {
            get;set;
        }
        public byte Status
        {
            get;set;
        }
        public byte ReferenceBy
        {
            get; set;
        }
        public decimal Quantity

        {
            get;set;
        }
        public float Total
        {
            get;set;
        }
        public string UOM
        {
            get;set;
        }
         public int ItemNumber
        {
            get;set;
        }
        public string ItemDescription
        {
            get; set;
        }

        public float Rate
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
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string XmlString { get; set; }
        public int SalesQuotationMasterID { get; set; }
        public byte CustomerType { get; set; }
    }
}
