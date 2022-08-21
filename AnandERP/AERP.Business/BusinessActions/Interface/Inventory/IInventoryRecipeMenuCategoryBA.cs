using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IInventoryRecipeMenuCategoryBA
    {
        IBaseEntityResponse<InventoryRecipeMenuCategory> InsertInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item);
        IBaseEntityResponse<InventoryRecipeMenuCategory> UpdateInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item);
        IBaseEntityResponse<InventoryRecipeMenuCategory> DeleteInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item);
        IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> GetBySearch(InventoryRecipeMenuCategorySearchRequest searchRequest);
        IBaseEntityResponse<InventoryRecipeMenuCategory> SelectByID(InventoryRecipeMenuCategory item);
        IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> GetRestaurantCategory(InventoryRecipeMenuCategorySearchRequest searchRequest);
    }
}
