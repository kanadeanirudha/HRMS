
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
namespace AERP.DTO
{
    public class SalesCustomerReciept : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int SalesInvoiceMasterID
        {
            get;
            set;
        }
        public string ContractNumber { get; set; }
        public int CustomerMasterID { get; set; }
        public int CustomerBranchMasterID { get; set; }


        public byte payementmode
        {
            get; set;
        }
        public decimal CreditAmount
        {
            get; set;
        }

        public decimal PaidAmount
        {
            get; set;
        }
        public string BankName
        {
            get;
            set;
        }
        public string CustomerName
        {
            get;
            set;
        }
        public string CustomerBranchMasterName
        {
            get;
            set;
        }
        public byte CustomerType
        {
            get;set;
        }
        public string BankAddress
        {
            get;
            set;
        }
        public string BranchName
        {
            get;
            set;
        }
        public string Incoterms
        {
            get;
            set;
        }
        public string CreditLimit
        {
            get;
            set;
        }
        public string IFSCCode
        {
            get;
            set;
        }
        public string AccountNo
        {
            get;
            set;
        }
        public string InvoiceDate
        {
            get;
            set;
        }

        public string InvoiceNumber
        {
            get;
            set;
        }
        public decimal InvoiceAmount
        {
            get;
            set;
        }
        public decimal PaidInvoiceAmount
        {
            get;
            set;
        }
        public byte StatusFlag
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
        public bool IsDeleted
        {
            get;
            set;
        }
        public string ChequeNumber { get; set; }
        public string CentreCode { get; set; }
        public string XMLstringForVouchar { get; set; }
        public string XMLstring { get; set; }
        public string errorMessage { get; set; }
        public string TransactionFromDate { get; set; }
        public string TransactionUptoDate { get; set; }

        public string VoucherNumber { get; set; }
        public int InvoiceTrackingMasterID { get; set; }
        public string PayementModeType { get; set; }
    }
}
