using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryRecipeFormulaDetailsBA
    {
        IBaseEntityResponse<InventoryRecipeFormulaDetails> InsertInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item);
        IBaseEntityResponse<InventoryRecipeFormulaDetails> UpdateInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item);
        IBaseEntityResponse<InventoryRecipeFormulaDetails> DeleteInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item);
        IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> GetBySearch(InventoryRecipeFormulaDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> GetInventoryRecipeFormulaDetailsSearchList(InventoryRecipeFormulaDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryRecipeFormulaDetails> SelectByID(InventoryRecipeFormulaDetails item);
    }
}

