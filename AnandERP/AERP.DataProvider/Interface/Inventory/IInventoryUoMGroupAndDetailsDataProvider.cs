using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IInventoryUoMGroupAndDetailsDataProvider
    {
        IBaseEntityResponse<InventoryUoMGroupAndDetails> InsertInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item);
        IBaseEntityResponse<InventoryUoMGroupAndDetails> UpdateInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item);
        IBaseEntityResponse<InventoryUoMGroupAndDetails> DeleteInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetails item);
        IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetInventoryUoMGroupAndDetailsBySearch(InventoryUoMGroupAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetInventoryUoMGroupAndDetailsSearchList(InventoryUoMGroupAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryUoMGroupAndDetails> GetInventoryUoMGroupAndDetailsByID(InventoryUoMGroupAndDetails item);

        //*******************************************************************
        IBaseEntityResponse<InventoryUoMGroupAndDetails> InsertInventoryUoMGroup(InventoryUoMGroupAndDetails item);
        IBaseEntityResponse<InventoryUoMGroupAndDetails> UpdateInventoryUoMGroup(InventoryUoMGroupAndDetails item);
        IBaseEntityResponse<InventoryUoMGroupAndDetails> DeleteInventoryUoMGroup(InventoryUoMGroupAndDetails item);

        IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetInventoryUoMGroupAndDetailsByInventoryUoMGroupID(InventoryUoMGroupAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> GetInventoryUomCodeByUomGroupCode(InventoryUoMGroupAndDetailsSearchRequest searchRequest);


    }
}
