using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
namespace AERP.ViewModel
{
    public class SalesEnquiryMasterAndDetailsViewModel : ISalesEnquiryMasterAndDetailsViewModel
    {

        public SalesEnquiryMasterAndDetailsViewModel()
        {


            SalesEnquiryMasterAndDetailsDTO = new SalesEnquiryMasterAndDetails();
            ContactDetailsBySalesEnquiryMasterAndDetailsID = new List<SalesEnquiryMasterAndDetails>();
        }
        public List<SalesEnquiryMasterAndDetails> ContactDetailsBySalesEnquiryMasterAndDetailsID { get; set; }
        public SalesEnquiryMasterAndDetails SalesEnquiryMasterAndDetailsDTO
        {
            get;
            set;
        }
        public int SalesEnquiryMasterID
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.SalesEnquiryMasterID > 0) ? SalesEnquiryMasterAndDetailsDTO.SalesEnquiryMasterID : new int();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.SalesEnquiryMasterID = value;
            }
        }
        public int SaleEnquiryDetailsID
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.SaleEnquiryDetailsID > 0) ? SalesEnquiryMasterAndDetailsDTO.SaleEnquiryDetailsID : new int();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.SaleEnquiryDetailsID = value;
            }
        }
        
         public int SalesQuotationMasterID
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.SalesQuotationMasterID > 0) ? SalesEnquiryMasterAndDetailsDTO.SalesQuotationMasterID : new int();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.SalesQuotationMasterID = value;
            }
        }
        public int CustomerBranchMasterID
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.CustomerBranchMasterID > 0) ? SalesEnquiryMasterAndDetailsDTO.CustomerBranchMasterID : new int();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.CustomerBranchMasterID = value;
            }
        }
        public int CustomerMasterID
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.CustomerMasterID > 0) ? SalesEnquiryMasterAndDetailsDTO.CustomerMasterID : new int();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.CustomerMasterID = value;
            }
        }
        public Int16 ContactPersonID
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.ContactPersonID > 0) ? SalesEnquiryMasterAndDetailsDTO.ContactPersonID : new Int16();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.ContactPersonID = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerMasterName
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Transaction Date")]
        public string TransactionDate
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.TransactionDate : string.Empty;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.TransactionDate = value;
            }
        }
        [Display(Name = "UOM")]
        public string UOM
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.UOM : string.Empty;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.UOM = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.Quantity > 0) ? SalesEnquiryMasterAndDetailsDTO.Quantity : new decimal();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.Quantity = value;
            }
        }
        public float Rate
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.Rate > 0) ? SalesEnquiryMasterAndDetailsDTO.Rate : new float();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.Rate = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.ItemNumber > 0) ? SalesEnquiryMasterAndDetailsDTO.ItemNumber : new int();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Item Description")]
        public string ItemDescription
        { 
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.ItemDescription : string.Empty;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.ItemDescription = value;
            }
        }
        [Display(Name = "Contact person")]
        public string CustomerContactPersonName
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.CustomerContactPersonName : string.Empty;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.CustomerContactPersonName = value;
            }
        }
        [Display(Name = "Enquiry Number")]
        public string EnquiryNumber
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.EnquiryNumber : string.Empty;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.EnquiryNumber = value;
            }
        }
        [Display(Name = "Reference By")]
        public byte ReferenceBy
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.ReferenceBy : new byte();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.ReferenceBy = value;
            }
        }
        [Display(Name = "Status")]
        public byte Status
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.Status : new byte();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.Status = value;
            }
        }
        [Display(Name = "Status Mode")]
        public byte StatusMode
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.StatusMode : new byte();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.StatusMode = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.IsDeleted = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.CreatedBy > 0) ? SalesEnquiryMasterAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.CreatedDate = value;
            }
        }
       
        public int ModifiedBy
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null && SalesEnquiryMasterAndDetailsDTO.ModifiedBy > 0) ? SalesEnquiryMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.ModifiedDate = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }
        
        public string XmlString
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.XmlString : string.Empty;
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.XmlString = value;
            }
        }
        public byte CustomerType
        {
            get
            {
                return (SalesEnquiryMasterAndDetailsDTO != null) ? SalesEnquiryMasterAndDetailsDTO.CustomerType : new byte();
            }
            set
            {
                SalesEnquiryMasterAndDetailsDTO.CustomerType = value;
            }
        }


    }
}

