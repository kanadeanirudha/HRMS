using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class AddCentreOpeningBalanceForInventory : BaseDTO
    {
        /// Properties for AddCentreOpeningBalanceForInventory table
        public int ID { get; set; }
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public string BaseUomCode { get; set; }
        public decimal OpeningBalanceQuantity { get; set; }
        public int InventoryLocationMasterID{ get; set; }
        public string LocationName { get; set; }
        public string CentreCode { get; set; }
        public int FinanacialYearID { get; set; }

        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public int InventoryStockMasterID { get; set; }
        public bool StatusFlag { get; set; }
        public string XMLstring { get; set; }
    }
}
