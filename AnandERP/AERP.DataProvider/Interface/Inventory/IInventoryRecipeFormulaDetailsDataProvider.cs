using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryRecipeFormulaDetailsDataProvider
    {
        IBaseEntityResponse<InventoryRecipeFormulaDetails> InsertInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item);
        IBaseEntityResponse<InventoryRecipeFormulaDetails> UpdateInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item);
        IBaseEntityResponse<InventoryRecipeFormulaDetails> DeleteInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item);
        IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> GetInventoryRecipeFormulaDetailsBySearch(InventoryRecipeFormulaDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> GetInventoryRecipeFormulaDetailsSearchList(InventoryRecipeFormulaDetailsSearchRequest searchRequest);
        IBaseEntityResponse<InventoryRecipeFormulaDetails> GetInventoryRecipeFormulaDetailsByID(InventoryRecipeFormulaDetails item);
    }
}
