using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IInventoryDashboardReportViewModel
    {
        InventoryDashboardReport InventoryDashboardReportDTO { get; set; }
        /// <summary>
        /// Properties for InventoryDashboardReport table
        /// </summary>
        int ID
        {
            get;
            set;
        }
        string PurchaseRequirementNumber
        {
            get;
            set;
        }
        string TransDate
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }

      

    }
}
