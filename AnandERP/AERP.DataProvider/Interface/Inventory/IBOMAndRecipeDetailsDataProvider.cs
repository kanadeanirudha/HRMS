using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IBOMAndRecipeDetailsDataProvider
    {
        IBaseEntityResponse<BOMAndRecipeDetails> InsertBOMAndRecipeDetails(BOMAndRecipeDetails item);
        IBaseEntityResponse<BOMAndRecipeDetails> UpdateBOMAndRecipeDetails(BOMAndRecipeDetails item);
        IBaseEntityResponse<BOMAndRecipeDetails> DeleteBOMAndRecipeDetails(BOMAndRecipeDetails item);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetBOMAndRecipeDetailsBySearch(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetBOMAndRecipeDetailsSearchList(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityResponse<BOMAndRecipeDetails> GetBOMAndRecipeDetailsByID(BOMAndRecipeDetails item);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetIngridentsListByVarients(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetConsumptionUnitList(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetItemsList(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetUoMCodeWisePurchasePriceList(BOMAndRecipeDetailsSearchRequest searchRequest);
    }
}
