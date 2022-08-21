﻿using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IInventoryCurrentStockPriceDrillReportBA
    {
        IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByOrganisation(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByCentre(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByStore(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryCurrentStockPriceDrillReport> GetInventoryCurrentStockPriceDrillReportByArticle(InventoryCurrentStockPriceDrillReportSearchRequest searchRequest);
    }
}
