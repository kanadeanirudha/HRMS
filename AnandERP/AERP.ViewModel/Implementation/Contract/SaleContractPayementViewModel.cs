using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractPayementViewModel : ISaleContractPayementViewModel
    {

        public SaleContractPayementViewModel()
        {
            SaleContractPayementDTO = new SaleContractPayement();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();

        }

        public SaleContractPayement SaleContractPayementDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<SaleContractPayement> SaleContractPayementList { get; set; }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        [Display(Name = "Customer Branch Name")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerName
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.CustomerName : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.CustomerName = value;
            }
        }
        public Int32 ID
        {
            get
            {
                return (SaleContractPayementDTO != null && SaleContractPayementDTO.ID > 0) ? SaleContractPayementDTO.ID : new Int32();
            }
            set
            {
                SaleContractPayementDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Please select Contract Number.")]
        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Contract Billing Span")]
        public int SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.SaleContractBillingSpanID : new Int16();
            }
            set
            {
                SaleContractPayementDTO.SaleContractBillingSpanID = value;
            }
        }
        
        [Display(Name = "Customer Master ID")]
        public int CustomerMasterID
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.CustomerMasterID : new Int16();
            }
            set
            {
                SaleContractPayementDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Contract Master ID")]
        public Int32 ContractMasterID
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.ContractMasterID : new Int32();
            }
            set
            {
                SaleContractPayementDTO.ContractMasterID = value;
            }
        }
        [Display(Name = "Customer Branch ID")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                SaleContractPayementDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Credit Amount")]
        public decimal CreditAmount
        {
            get
            {
                return (SaleContractPayementDTO != null && SaleContractPayementDTO.CreditAmount > 0) ? SaleContractPayementDTO.CreditAmount : new decimal();
            }
            set
            {
                SaleContractPayementDTO.CreditAmount = value;
            }
        }
        [Display(Name = "Paid Amount")]
        public decimal PaidAmount
        {
            get
            {
                return (SaleContractPayementDTO != null && SaleContractPayementDTO.PaidAmount > 0) ? SaleContractPayementDTO.PaidAmount : new decimal();
            }
            set
            {
                SaleContractPayementDTO.PaidAmount = value;
            }
        }
        [Display(Name = "Bank Name")]
        public string BankName
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.BankName : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.BankName = value;
            }
        }
        [Display(Name = "Bank Address")]
        public string BankAddress
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.BankAddress : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.BankAddress = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string BranchName
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.BranchName : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.BranchName = value;
            }
        }
        [Display(Name = "Bank IFSC Code")]
        public string IFSCCode
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.IFSCCode : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.IFSCCode = value;
            }
        }
        [Display(Name = "Bank Account Number")]
        public string AccountNo
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.AccountNo : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.AccountNo = value;
            }
        }
        [Display(Name = "Invoice Date ")]
        public string InvoiceDate
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.InvoiceDate : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.InvoiceDate = value;
            }
        }
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.InvoiceNumber : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.InvoiceNumber = value;
            }
        }
        [Display(Name = "Contract Amount")]
        public decimal ContractAmount
        {
            get
            {
                return (SaleContractPayementDTO != null && SaleContractPayementDTO.ContractAmount > 0) ? SaleContractPayementDTO.ContractAmount : new decimal();
            }
            set
            {
                SaleContractPayementDTO.ContractAmount = value;
            }
        }
        [Display(Name = "Paid Invoice Amount")]
        public decimal PaidInvoiceAmount
        {
            get
            {
                return (SaleContractPayementDTO != null && SaleContractPayementDTO.PaidInvoiceAmount > 0) ? SaleContractPayementDTO.PaidInvoiceAmount : new decimal();
            }
            set
            {
                SaleContractPayementDTO.PaidInvoiceAmount = value;
            }
        }
        [Display(Name = "Status Flag")]
        public byte StatusFlag
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.StatusFlag : new byte();
            }
            set
            {
                SaleContractPayementDTO.StatusFlag = value;
            }
        }
        [Display(Name = "CustomerType")]
        public byte CustomerType
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.CustomerType : new byte();
            }
            set
            {
                SaleContractPayementDTO.CustomerType = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.IsDeleted : false;
            }
            set
            {
                SaleContractPayementDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractPayementDTO != null && SaleContractPayementDTO.CreatedBy > 0) ? SaleContractPayementDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractPayementDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractPayementDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractPayementDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractPayementDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractPayementDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractPayementDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        [Display(Name = "Payement Mode")]
        public byte payementmode
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.payementmode : new byte();
            }
            set
            {
                SaleContractPayementDTO.payementmode = value;
            }
        }


        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.CentreCode : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.CentreCode = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.XMLstring : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.XMLstring = value;
            }
        }

        public string XMLstringForVouchar
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.XMLstringForVouchar : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.XMLstringForVouchar = value;
            }
        }
        [Display(Name = "Cheque Number")]
        public string ChequeNumber
        {
            get
            {
                return (SaleContractPayementDTO != null) ? SaleContractPayementDTO.ChequeNumber : string.Empty;
            }
            set
            {
                SaleContractPayementDTO.ChequeNumber = value;
            }
        }






    }
}

