using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractRecieptViewModel : ISaleContractRecieptViewModel
    {

        public SaleContractRecieptViewModel()
        {
            SaleContractRecieptDTO = new SaleContractReciept();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ContactDetailsBySaleContractRecieptID = new List<SaleContractReciept>();

        }

        public SaleContractReciept SaleContractRecieptDTO
        {
            get;
            set;
        }
        public List<SaleContractReciept> ContactDetailsBySaleContractRecieptID { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<SaleContractReciept> SaleContractRecieptList { get; set; }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        [Display(Name ="Customer Branch Name")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name ="Customer Name")]
        public string CustomerName
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.CustomerName : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.CustomerName = value;
            }
        }
        public Int32 ID
        {
            get
            {
                return (SaleContractRecieptDTO != null && SaleContractRecieptDTO.ID > 0) ? SaleContractRecieptDTO.ID : new Int32();
            }
            set
            {
                SaleContractRecieptDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Please select Contract Number.")]
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Customer Master ID")]
        public int CustomerMasterID
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.CustomerMasterID : new Int16();
            }
            set
            {
                SaleContractRecieptDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Customer Main Branch MasterID")]
        public int CustomerMainBranchMasterID
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.CustomerMainBranchMasterID : new Int16();
            }
            set
            {
                SaleContractRecieptDTO.CustomerMainBranchMasterID = value;
            }
        }
        
        [Display(Name = "Contract Master ID")]
        public int ContractMasterID
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.ContractMasterID : new Int16();
            }
            set
            {
                SaleContractRecieptDTO.ContractMasterID = value;
            }
        }
        [Display(Name = "Sale Contract Billing Span")]
        public int SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.SaleContractBillingSpanID : new Int16();
            }
            set
            {
                SaleContractRecieptDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Is Main Branch")]
        public bool IsMainBranch
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.IsMainBranch : new bool();
            }
            set
            {
                SaleContractRecieptDTO.IsMainBranch = value;
            }
        }
        
        [Display(Name = "Customer Branch ID")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                SaleContractRecieptDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Credit Amount")]
        public decimal CreditAmount
        {
            get
            {
                return (SaleContractRecieptDTO != null && SaleContractRecieptDTO.CreditAmount > 0) ? SaleContractRecieptDTO.CreditAmount : new decimal();
            }
            set
            {
                SaleContractRecieptDTO.CreditAmount = value;
            }
        }
        [Display(Name = "Paid Amount")]
        public decimal PaidAmount
        {
            get
            {
                return (SaleContractRecieptDTO != null && SaleContractRecieptDTO.PaidAmount > 0) ? SaleContractRecieptDTO.PaidAmount : new decimal();
            }
            set
            {
                SaleContractRecieptDTO.PaidAmount = value;
            }
        }
        [Display(Name = "Bank Name")]
        public string BankName
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.BankName : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.BankName = value;
            }
        }
        [Display(Name = "Bank Address")]
        public string BankAddress
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.BankAddress : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.BankAddress = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string BranchName
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.BranchName : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.BranchName = value;
            }
        }
        [Display(Name = "Bank IFSC Code")]
        public string IFSCCode
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.IFSCCode : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.IFSCCode = value;
            }
        }
        [Display(Name = "Bank Account Number")]
        public string AccountNo
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.AccountNo : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.AccountNo = value;
            }
        }
        [Display(Name = "Invoice Date ")]
        public string InvoiceDate
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.InvoiceDate : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.InvoiceDate = value;
            }
        }
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.InvoiceNumber : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.InvoiceNumber = value;
            }
        }
        [Display(Name = "Contract Amount")]
        public decimal ContractAmount
        {
            get
            {
                return (SaleContractRecieptDTO != null && SaleContractRecieptDTO.ContractAmount > 0) ? SaleContractRecieptDTO.ContractAmount : new decimal();
            }
            set
            {
                SaleContractRecieptDTO.ContractAmount = value;
            }
        }
        [Display(Name = "Paid Invoice Amount")]
        public decimal PaidInvoiceAmount
        {
            get
            {
                return (SaleContractRecieptDTO != null && SaleContractRecieptDTO.PaidInvoiceAmount > 0) ? SaleContractRecieptDTO.PaidInvoiceAmount : new decimal();
            }
            set
            {
                SaleContractRecieptDTO.PaidInvoiceAmount = value;
            }
        }
        [Display(Name = "Status Flag")]
        public byte StatusFlag
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.StatusFlag : new byte();
            }
            set
            {
                SaleContractRecieptDTO.StatusFlag = value;
            }
        }
        [Display(Name = "CustomerType")]
        public byte CustomerType
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.CustomerType : new byte();
            }
            set
            {
                SaleContractRecieptDTO.CustomerType = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.IsDeleted : false;
            }
            set
            {
                SaleContractRecieptDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractRecieptDTO != null && SaleContractRecieptDTO.CreatedBy > 0) ? SaleContractRecieptDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractRecieptDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractRecieptDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractRecieptDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractRecieptDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractRecieptDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractRecieptDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        [Display(Name = "Payement Mode")]
        public byte payementmode
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.payementmode : new byte();
            }
            set
            {
                SaleContractRecieptDTO.payementmode = value;
            }
        }


        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.CentreCode : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.CentreCode = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.XMLstring : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.XMLstring = value;
            }
        }

        public string XMLstringForVouchar
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.XMLstringForVouchar : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.XMLstringForVouchar = value;
            }
        }
        [Display(Name = "Cheque Number")]
        public string ChequeNumber
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.ChequeNumber : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.ChequeNumber = value;
            }
        }
        [Display(Name = "From Date")]
        public string TransactionFromDate
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.TransactionFromDate : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.TransactionFromDate = value;
            }
        }
        [Display(Name = "Upto Date")]
        public string TransactionUptoDate
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.TransactionUptoDate : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.TransactionUptoDate = value;
            }
        }

        [Display(Name = "Voucher Number")]
        public string VoucherNumber
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.VoucherNumber : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.VoucherNumber = value;
            }
        }

        
        public int InvoiceTrackingMasterID
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.InvoiceTrackingMasterID : new int();
            }
            set
            {
                SaleContractRecieptDTO.InvoiceTrackingMasterID = value;
            }
        }

        [Display(Name = "Payement Mode")]
        public string PayementModeType
        {
            get
            {
                return (SaleContractRecieptDTO != null) ? SaleContractRecieptDTO.PayementModeType : string.Empty;
            }
            set
            {
                SaleContractRecieptDTO.PayementModeType = value;
            }
        }


    }
}

