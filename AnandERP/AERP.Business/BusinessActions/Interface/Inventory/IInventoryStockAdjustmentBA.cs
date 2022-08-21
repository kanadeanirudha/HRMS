using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IInventoryStockAdjustmentBA
    {
        IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustment(InventoryStockAdjustment item);
        IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustmentXML(InventoryStockAdjustment item);
        IBaseEntityResponse<InventoryStockAdjustment> UpdateInventoryStockAdjustment(InventoryStockAdjustment item);
        IBaseEntityResponse<InventoryStockAdjustment> DeleteInventoryStockAdjustment(InventoryStockAdjustment item);
        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetBySearch(InventoryStockAdjustmentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentSearchList(InventoryStockAdjustmentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetItemNameForCurrentStock(InventoryStockAdjustmentSearchRequest searchRequest);
        IBaseEntityResponse<InventoryStockAdjustment> SelectByID(InventoryStockAdjustment item);
        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentSearchListForRecipeItem(InventoryStockAdjustmentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryStockAdjustmentIngridentListForRecipeItem(InventoryStockAdjustmentSearchRequest searchRequest);

        IBaseEntityResponse<InventoryStockAdjustment> InsertInventoryStockAdjustmentXMLForRecipe(InventoryStockAdjustment item);

        IBaseEntityCollectionResponse<InventoryStockAdjustment> GetInventoryItemBatchMasterList(InventoryStockAdjustmentSearchRequest searchRequest);
    }
}

