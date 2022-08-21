using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractFixItem : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Int32 ItemNumber
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get; set;
        }
        public Int32 SaleContractManPowerItemID
        {
            get;set;
        }
        public string SaleContractManPowerItemName
        {
            get;set;
        }
        public string CustomerMasterName
        {
            get;set;
        }
        public Int32 CustomerMasterID
        {
            get;set;
        }
        public Int32 CustomerBranchMasterID
        {
            get;set;
        }
        public string CustomerBranchMasterName
        {
            get;set;
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
