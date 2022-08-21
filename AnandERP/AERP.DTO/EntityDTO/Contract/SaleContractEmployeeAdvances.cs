using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractEmployeeAdvances : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }

        public int ContractEmployeeMasterID
        {
            get; set;
        }
        public string ContractEmployeeMasterName
        {
            get; set;
        }
        public string TransactionDate
        {
            get; set;
        }
        public decimal AdvanceAmount
        {
            get; set;
        }
        public byte PaymentMode
        {
            get; set;
        }
        public decimal RefundAmount
        {
            get; set;
        }
        public byte IsRefund
        {
            get; set;
        }
        public string RefundDate
        {
            get; set;
        }
        public bool IsActive
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
    }
}
