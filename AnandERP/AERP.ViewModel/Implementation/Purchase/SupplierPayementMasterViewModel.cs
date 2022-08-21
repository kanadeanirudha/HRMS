using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SupplierPayementMasterViewModel : ISupplierPayementMasterViewModel
    {

        public SupplierPayementMasterViewModel()
        {
            SupplierPayementMasterDTO = new SupplierPayementMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();

        }

        public SupplierPayementMaster SupplierPayementMasterDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public List<SupplierPayementMaster> SupplierPayementMasterList { get; set; }
        public Int32 ID
        {
            get
            {
                return (SupplierPayementMasterDTO != null && SupplierPayementMasterDTO.ID > 0) ? SupplierPayementMasterDTO.ID : new Int32();
            }
            set
            {
                SupplierPayementMasterDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Please select Vendor.")]
        public string vendor
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.vendor : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.vendor = value;
            }
        }
        [Display(Name = "Vendor")]
        public int VendorId
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.VendorId : new Int16();
            }
            set
            {
                SupplierPayementMasterDTO.VendorId = value;
            }
        }
        [Display(Name = "Vendor Number")]
        public Int32 VendorNumber
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.VendorNumber : new Int32();
            }
            set
            {
                SupplierPayementMasterDTO.VendorNumber = value;
            }
        }
        [Display(Name = "Credit Amount")]
        public decimal CreditAmount
        {
            get
            {
                return (SupplierPayementMasterDTO != null && SupplierPayementMasterDTO.CreditAmount > 0) ? SupplierPayementMasterDTO.CreditAmount : new decimal();
            }
            set
            {
                SupplierPayementMasterDTO.CreditAmount = value;
            }
        }
        [Display(Name = "Paid Amount")]
        public decimal PaidAmount
        {
            get
            {
                return (SupplierPayementMasterDTO != null && SupplierPayementMasterDTO.PaidAmount > 0) ? SupplierPayementMasterDTO.PaidAmount : new decimal();
            }
            set
            {
                SupplierPayementMasterDTO.PaidAmount = value;
            }
        }
        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "Bank Name")]
        public string BankName
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.BankName : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.BankName = value;
            }
        }
        [Display(Name = "Bank Address")]
        public string BankAddress
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.BankAddress : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.BankAddress = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string BranchName
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.BranchName : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.BranchName = value;
            }
        }
        [Display(Name = "Bank IFSC Code")]
        public string IFSCCode
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.IFSCCode : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.IFSCCode = value;
            }
        }
        [Display(Name = "Cheque Number")]
        public string ChequeNumber
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.ChequeNumber : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.ChequeNumber = value;
            }
        }

        
        [Display(Name = "Bank Account Number")]
        public string AccountNo
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.AccountNo : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.AccountNo = value;
            }
        }
        [Display(Name = "Invoice Date ")]
        public string InvoiceDate
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.InvoiceDate : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.InvoiceDate = value;
            }
        }
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.InvoiceNumber : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.InvoiceNumber = value;
            }
        }
        [Display(Name = "Invoice Amount")]
        public decimal InvoiceAmount
        {
            get
            {
                return (SupplierPayementMasterDTO != null && SupplierPayementMasterDTO.InvoiceAmount > 0) ? SupplierPayementMasterDTO.InvoiceAmount : new decimal();
            }
            set
            {
                SupplierPayementMasterDTO.InvoiceAmount = value;
            }
        }
        [Display(Name = "Paid Invoice Amount")]
        public decimal PaidInvoiceAmount
        {
            get
            {
                return (SupplierPayementMasterDTO != null && SupplierPayementMasterDTO.PaidInvoiceAmount > 0) ? SupplierPayementMasterDTO.PaidInvoiceAmount : new decimal();
            }
            set
            {
                SupplierPayementMasterDTO.PaidInvoiceAmount = value;
            }
        }
        [Display(Name = "Status Flag")]
        public byte StatusFlag
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.StatusFlag : new byte();
            }
            set
            {
                SupplierPayementMasterDTO.StatusFlag = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.IsDeleted : false;
            }
            set
            {
                SupplierPayementMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (SupplierPayementMasterDTO != null && SupplierPayementMasterDTO.CreatedBy > 0) ? SupplierPayementMasterDTO.CreatedBy : new int();
            }
            set
            {
                SupplierPayementMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SupplierPayementMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.ModifiedBy : new int();
            }
            set
            {
                SupplierPayementMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SupplierPayementMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.DeletedBy : new int();
            }
            set
            {
                SupplierPayementMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SupplierPayementMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        [Display(Name ="Payement Mode")]
        public byte payementmode
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.payementmode: new byte();
            }
            set
            {
                SupplierPayementMasterDTO.payementmode = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.XMLstring : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.XMLstring = value;
            }
        }
        public string XMLstringForVouchar
        {
            get
            {
                return (SupplierPayementMasterDTO != null) ? SupplierPayementMasterDTO.XMLstringForVouchar : string.Empty;
            }
            set
            {
                SupplierPayementMasterDTO.XMLstringForVouchar = value;
            }
        }




    }
}

