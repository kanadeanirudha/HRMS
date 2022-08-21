using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessActions
{
    public interface IInventoryReportBA
    {
        IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_PriceList(InventoryReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ItemList(InventoryReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryReport> GetInventoryReportBySearch_ArticleList(InventoryReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryReport> GetItemRequirementReportList(InventoryReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryReport> GetItemHistoryReportList(InventoryReportSearchRequest searchRequest); 
    }
}
