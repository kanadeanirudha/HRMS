using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractFixAttendance : BaseDTO
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
        public Int32 SaleContractFixItemID
        {
            get; set;
        }
        public string SaleContractFixItemName
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
        public decimal SaleContractFixItemQuantity
        {
            get; set;
        }
        public decimal SaleContractFixItemAttendance
        {
            get; set;
        }
        public decimal SaleContractFixBillingDays
        {
            get; set;
        }
        public decimal SaleContractFixWeeklyOffDays
        {
            get; set;
        }
        public decimal SaleContractFixBillingWeeklyOffDays
        {
            get; set;
        }
        public bool IsSalaryDaysOnWeeklyOff
        {
            get; set;
        }
        public bool IsBillingDaysOnWeeklyOff
        {
            get; set;
        }
        public bool IsIncludeAllPostingForShortExtraRate
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
        public string XMLstringForFixItemData { get; set; }
    }
}
