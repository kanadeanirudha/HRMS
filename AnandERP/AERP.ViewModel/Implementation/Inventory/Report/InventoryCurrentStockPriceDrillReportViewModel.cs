using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryCurrentStockPriceDrillReportViewModel
    {
        public InventoryCurrentStockPriceDrillReportViewModel()
        {
            InventoryCurrentStockPriceDrillReportDTO = new InventoryCurrentStockPriceDrillReport();
            ListInventoryCurrentStockPriceDrillReport = new List<InventoryCurrentStockPriceDrillReport>();
        }


        public List<InventoryCurrentStockPriceDrillReport> ListInventoryCurrentStockPriceDrillReport { get; set; }
        public List<InventoryCurrentStockPriceDrillReport> GetGeneralUnitsForItemmaster { get; set; }
        public InventoryCurrentStockPriceDrillReport InventoryCurrentStockPriceDrillReportDTO { get; set; }


        public bool IsPosted
        {
            get
            {
                return (InventoryCurrentStockPriceDrillReportDTO != null) ? InventoryCurrentStockPriceDrillReportDTO.IsPosted : false;
            }
            set
            {
                InventoryCurrentStockPriceDrillReportDTO.IsPosted = value;
            }
        }

        
      
    }
}

