using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class GrossOperatingProfitReport : BaseDTO
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
        public string EmployeeName
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
        public Int64 SaleContractMasterID { get; set; }
        public string ContractNumber { get; set; }
        public Int64 SaleContractBillingSpanID { get; set; }
        public string SaleContractBillingSpanName { get; set; }
        public string CustomerMasterName { get; set; }
        public string CustomerBranchMasterName { get; set; }
        public Int32 CustomerMasterID { get; set; }
        public byte CustomerType { get; set; }
        public Int32 CustomerBranchMasterID { get; set; }

        public decimal FixedSale { get; set; }
        public decimal VariableSale { get; set; }
        public decimal ArrearsBonusSale { get; set; }
        public decimal SubTotalSale { get; set; }
        public decimal FoodCost { get; set; }
        public decimal Chemicals { get; set; }
        public decimal ConsumablesReim { get; set; }
        public decimal ConsumableNonReim { get; set; }
        public decimal MaintainanceCost { get; set; }
        public decimal UniformStationaryExps { get; set; }
        public decimal PettyCashExps { get; set; }
        public decimal FuelDieselTravellingExps { get; set; }
        public decimal MiscExps { get; set; }
        public decimal SubTotalExps { get; set; }
        public decimal Payroll { get; set; }
        public decimal PFContribution { get; set; }
        public decimal ESICContribution { get; set; }
        public decimal PTAmount { get; set; }
        public decimal Bonus { get; set; }
        public decimal Depreciation { get; set; }
        public decimal SubTotalAllExps { get; set; }
        public decimal TotalCost { get; set; }
        public decimal BadDebts { get; set; }
        public decimal TDSAmount { get; set; }
        public decimal NetProfit { get; set; }
        public decimal Profit { get; set; }
        public string Granularity { get; set; }
    }
}
