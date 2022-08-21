using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class InventoryDashboardReport : BaseDTO
    {
        /// <summary>
        /// Properties for InventoryDashboardReport table
        /// </summary>
        public int ID
        {
            get;
            set;
        }

        public string TotalInvoiceAmountList
        {
            get;
            set;
        }
        public string InvoiceMonth
        {
            get;
            set;
        }
        public string CentreList
        {
            get; set;
        }
    }
}

