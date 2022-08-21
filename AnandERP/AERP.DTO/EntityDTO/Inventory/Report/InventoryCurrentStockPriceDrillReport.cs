using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryCurrentStockPriceDrillReport : BaseDTO
    {

        public string DateFrom { get; set; }
        public string DateTo { get; set; }

        public int SrNo { get; set; }
        public string CentreName { get; set; }
        public string CentreCode { get; set; }
        public string Store { get; set; }
        public string OrgName { get; set; }
        public decimal CurrentStock { get; set; }
        public decimal Amount { get; set; }
        public decimal Cost { get; set; }
        public int GeneralUnitsId { get; set; }
        public string GeneralUnitsName { get; set; }
        public int OrganisationMasterKey { get; set; }
        public string ItemDescription { get; set; }
        public string BaseUomCode { get; set; }
        public int ItemNumber { get; set; }

        public bool IsPosted { get; set; }
    }
}
