using System;
using AERP.Base.DTO;
using AERP.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAddCentreOpeningBalanceForInventoryBA
    {
        IBaseEntityResponse<AddCentreOpeningBalanceForInventory> InsertAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory item);
        IBaseEntityResponse<AddCentreOpeningBalanceForInventory> UpdateAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory item);
        IBaseEntityResponse<AddCentreOpeningBalanceForInventory> DeleteAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory item);
        IBaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory> GetBySearch(AddCentreOpeningBalanceForInventorySearchRequest searchRequest);
        IBaseEntityResponse<AddCentreOpeningBalanceForInventory> SelectByID(AddCentreOpeningBalanceForInventory item);
        IBaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory> GetAddCentreOpeningBalanceForInventorySearchList(AddCentreOpeningBalanceForInventorySearchRequest searchRequest);

    }
}
