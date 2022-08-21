using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryProductionMasterAndTransactionBA
    {
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> InsertInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item);
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> UpdateInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item);
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> DeleteInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetBySearch(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetInventoryProductionMasterAndTransactionSearchList(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
        IBaseEntityResponse<InventoryProductionMasterAndTransaction> SelectByID(InventoryProductionMasterAndTransaction item);
        IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> SelectIngridentsByVarients(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> GetUnitsByItemNumber(InventoryProductionMasterAndTransactionSearchRequest searchRequest);
    }
}

