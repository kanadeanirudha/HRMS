using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IBOMAndRecipeDetailsBA
    {
        IBaseEntityResponse<BOMAndRecipeDetails> InsertBOMAndRecipeDetails(BOMAndRecipeDetails item);
        IBaseEntityResponse<BOMAndRecipeDetails> UpdateBOMAndRecipeDetails(BOMAndRecipeDetails item);
        IBaseEntityResponse<BOMAndRecipeDetails> DeleteBOMAndRecipeDetails(BOMAndRecipeDetails item);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetBySearch(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetBOMAndRecipeDetailsSearchList(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityResponse<BOMAndRecipeDetails> SelectByID(BOMAndRecipeDetails item);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> SelectIngridentsByVarients(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetConsumptionUnitList(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetItemsList(BOMAndRecipeDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetUoMCodeWisePurchasePriceList(BOMAndRecipeDetailsSearchRequest searchRequest);
    }
}

