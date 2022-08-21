using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryPhysicalStockMasterAndTransactionDataProvider
    {
        IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> InsertInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item);
        IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> UpdateInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item);
        IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> DeleteInventoryPhysicalStockMasterAndTransaction(InventoryPhysicalStockMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetInventoryPhysicalStockMasterAndTransactionBySearch(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetInventoryPhysicalStockMasterAndTransactionSearchList(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryPhysicalStockMasterAndTransaction> GetInventoryStockDetails(InventoryPhysicalStockMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityResponse<InventoryPhysicalStockMasterAndTransaction> GetInventoryPhysicalStockMasterAndTransactionByID(InventoryPhysicalStockMasterAndTransaction item);
    }
}
