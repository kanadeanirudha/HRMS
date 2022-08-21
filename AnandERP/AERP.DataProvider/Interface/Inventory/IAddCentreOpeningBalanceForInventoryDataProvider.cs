using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IAddCentreOpeningBalanceForInventoryDataProvider
    {
        IBaseEntityResponse<AddCentreOpeningBalanceForInventory> InsertAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory item);
        IBaseEntityResponse<AddCentreOpeningBalanceForInventory> UpdateAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory item);
        IBaseEntityResponse<AddCentreOpeningBalanceForInventory> DeleteAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory item);
        IBaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory> GetAddCentreOpeningBalanceForInventoryBySearch(AddCentreOpeningBalanceForInventorySearchRequest searchRequest);
        IBaseEntityResponse<AddCentreOpeningBalanceForInventory> GetAddCentreOpeningBalanceForInventoryByID(AddCentreOpeningBalanceForInventory item);
        IBaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory> GetAddCentreOpeningBalanceForInventorySearchList(AddCentreOpeningBalanceForInventorySearchRequest searchRequest);
    }
}
