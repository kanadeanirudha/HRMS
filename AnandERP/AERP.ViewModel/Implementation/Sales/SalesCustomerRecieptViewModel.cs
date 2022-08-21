using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SalesCustomerRecieptViewModel : ISalesCustomerRecieptViewModel
    {

        public SalesCustomerRecieptViewModel()
        {
            SalesCustomerRecieptDTO = new SalesCustomerReciept();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ContactDetailsBySalesCustomerRecieptID = new List<SalesCustomerReciept>();

        }
        public List<SalesCustomerReciept> ContactDetailsBySalesCustomerRecieptID { get; set; }
        public SalesCustomerReciept SalesCustomerRecieptDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<SalesCustomerReciept> SalesCustomerRecieptList { get; set; }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public Int32 ID
        {
            get
            {
                return (SalesCustomerRecieptDTO != null && SalesCustomerRecieptDTO.ID > 0) ? SalesCustomerRecieptDTO.ID : new Int32();
            }
            set
            {
                SalesCustomerRecieptDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Please select Contract Number.")]
        public string ContractNumber
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.ContractNumber : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Customer Master ID")]
        public int CustomerMasterID
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.CustomerMasterID : new Int16();
            }
            set
            {
                SalesCustomerRecieptDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Customer Branch ID")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                SalesCustomerRecieptDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Credit Amount")]
        public decimal CreditAmount
        {
            get
            {
                return (SalesCustomerRecieptDTO != null && SalesCustomerRecieptDTO.CreditAmount > 0) ? SalesCustomerRecieptDTO.CreditAmount : new decimal();
            }
            set
            {
                SalesCustomerRecieptDTO.CreditAmount = value;
            }
        }

        [Display(Name = "Customer Branch Name")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerName
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.CustomerName : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.CustomerName = value;
            }
        }

        [Display(Name = "Paid Amount")]
        public decimal PaidAmount
        {
            get
            {
                return (SalesCustomerRecieptDTO != null && SalesCustomerRecieptDTO.PaidAmount > 0) ? SalesCustomerRecieptDTO.PaidAmount : new decimal();
            }
            set
            {
                SalesCustomerRecieptDTO.PaidAmount = value;
            }
        }
        [Display(Name = "Bank Name")]
        public string BankName
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.BankName : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.BankName = value;
            }
        }
        [Display(Name = "Bank Address")]
        public string BankAddress
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.BankAddress : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.BankAddress = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string BranchName
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.BranchName : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.BranchName = value;
            }
        }
        [Display(Name = "Bank IFSC Code")]
        public string IFSCCode
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.IFSCCode : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.IFSCCode = value;
            }
        }
        [Display(Name = "Bank Account Number")]
        public string AccountNo
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.AccountNo : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.AccountNo = value;
            }
        }
        [Display(Name = "Invoice Date ")]
        public string InvoiceDate
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.InvoiceDate : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.InvoiceDate = value;
            }
        }
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.InvoiceNumber : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.InvoiceNumber = value;
            }
        }
        [Display(Name = "Invoice Amount")]
        public decimal InvoiceAmount
        {
            get
            {
                return (SalesCustomerRecieptDTO != null && SalesCustomerRecieptDTO.InvoiceAmount > 0) ? SalesCustomerRecieptDTO.InvoiceAmount : new decimal();
            }
            set
            {
                SalesCustomerRecieptDTO.InvoiceAmount = value;
            }
        }
        [Display(Name = "Paid Invoice Amount")]
        public decimal PaidInvoiceAmount
        {
            get
            {
                return (SalesCustomerRecieptDTO != null && SalesCustomerRecieptDTO.PaidInvoiceAmount > 0) ? SalesCustomerRecieptDTO.PaidInvoiceAmount : new decimal();
            }
            set
            {
                SalesCustomerRecieptDTO.PaidInvoiceAmount = value;
            }
        }
        [Display(Name = "Status Flag")]
        public byte StatusFlag
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.StatusFlag : new byte();
            }
            set
            {
                SalesCustomerRecieptDTO.StatusFlag = value;
            }
        }
        [Display(Name = "Customer Type")]
        public byte CustomerType
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.CustomerType : new byte();
            }
            set
            {
                SalesCustomerRecieptDTO.CustomerType = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.IsDeleted : false;
            }
            set
            {
                SalesCustomerRecieptDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SalesCustomerRecieptDTO != null && SalesCustomerRecieptDTO.CreatedBy > 0) ? SalesCustomerRecieptDTO.CreatedBy : new int();
            }
            set
            {
                SalesCustomerRecieptDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SalesCustomerRecieptDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.ModifiedBy : new int();
            }
            set
            {
                SalesCustomerRecieptDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SalesCustomerRecieptDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.DeletedBy : new int();
            }
            set
            {
                SalesCustomerRecieptDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SalesCustomerRecieptDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        [Display(Name = "Payement Mode")]
        public byte payementmode
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.payementmode : new byte();
            }
            set
            {
                SalesCustomerRecieptDTO.payementmode = value;
            }
        }


        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.CentreCode : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.CentreCode = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.XMLstring : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.XMLstring = value;
            }
        }
        
        public string XMLstringForVouchar
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.XMLstringForVouchar : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.XMLstringForVouchar = value;
            }
        }
        [Display(Name = "Cheque Number")]
        public string ChequeNumber
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.ChequeNumber : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.ChequeNumber = value;
            }
        }
        [Display(Name = "From Date")]
        public string TransactionFromDate
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.TransactionFromDate : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.TransactionFromDate = value;
            }
        }
        [Display(Name = "Upto Date")]
        public string TransactionUptoDate
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.TransactionUptoDate : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.TransactionUptoDate = value;
            }
        }
        [Display(Name = "Voucher Number")]
        public string VoucherNumber
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.VoucherNumber : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.VoucherNumber = value;
            }
        }

        [Display(Name = "InvoiceTrackingMasterID")]
        public int InvoiceTrackingMasterID
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.InvoiceTrackingMasterID : new int();
            }
            set
            {
                SalesCustomerRecieptDTO.InvoiceTrackingMasterID = value;
            }
        }

        [Display(Name = "Payement Mode")]
        public string PayementModeType
        {
            get
            {
                return (SalesCustomerRecieptDTO != null) ? SalesCustomerRecieptDTO.PayementModeType : string.Empty;
            }
            set
            {
                SalesCustomerRecieptDTO.PayementModeType = value;
            }
        }


    }
}

