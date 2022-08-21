using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class ContractPaymentPendingReport : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public string CustomerMasterName
        {
            get; set;
        }
        public string BranchName
        {
            get; set;
        }
        public string ContractNumber
        {
            get; set;
        }
        public string ContractStartDate
        {
            get; set;
        }
        public string ContractEndDate
        {
            get; set;
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
        public string ContractBillingSpan { get; set; }
        public string InvoiceNumber{ get; set; }
        public byte StatusFlag { get; set; }
        public decimal TotalBillAmount { get; set; }
        public string ManagerName { get; set; }
    }
}
