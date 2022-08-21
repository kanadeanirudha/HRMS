using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryProductionMasterAndTransactionDataProvider
    {
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> InsertInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item);
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> UpdateInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item);
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> DeleteInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetInventoryProductionMasterAndTransactionBySearch(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetInventoryProductionMasterAndTransactionSearchList(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> GetInventoryProductionMasterAndTransactionByID(InventoryProductionMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetIngridentsListByVarients(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetUnitsByItemNumber(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
    }
}
