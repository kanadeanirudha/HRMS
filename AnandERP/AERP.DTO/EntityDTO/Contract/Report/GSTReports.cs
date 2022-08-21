using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class GSTReports : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }

        public string CentreName
        {
            get; set;
        }
        public int AccountSessionID { get; set; }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
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

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

        public string CustomerBranchMasterName { get; set; }
        public string GSTINNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceDate { get; set; }
        public string PlaceOfSupply { get; set; }
        public string ReverseCharge { get; set; }
        public string HSNCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }
        public string UOMCode { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal IGST { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
