using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractJobWorkData : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public Int64 SaleContractMasterID
        {
            get;
            set;
        }
        public Int32 CustomerBranchMasterID
        {
            get;
            set;
        }
        public string CustomerBranchMasterName
        {
            get;
            set;
        }
        public Int32 CustomerMasterID
        {
            get;
            set;
        }
        public string CustomerMasterName
        {
            get; set;
        }
        public string ContractNumber
        {
            get; set;
        }
        public Int32 SaleContractJobWorkItemID
        {
            get; set;
        }
        public string SaleContractJobWorkItemName
        {
            get; set;
        }
        public Int64 SaleContractBillingSpanID
        {
            get; set;
        }
        public string SaleContractBillingSpanName
        {
            get; set;
        }
        public decimal Quantity
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
        public string XMLstringForJobWorkData { get; set; }
    }
}
