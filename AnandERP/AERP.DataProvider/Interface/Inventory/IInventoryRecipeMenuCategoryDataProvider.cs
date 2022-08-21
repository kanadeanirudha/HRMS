using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryRecipeMenuCategoryDataProvider
    {
        IBaseEntityResponse<InventoryRecipeMenuCategory> InsertInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item);
        IBaseEntityResponse<InventoryRecipeMenuCategory> UpdateInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item);
        IBaseEntityResponse<InventoryRecipeMenuCategory> DeleteInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item);
        IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> GetInventoryRecipeMenuCategoryBySearch(InventoryRecipeMenuCategorySearchRequest searchRequest);
        IBaseEntityResponse<InventoryRecipeMenuCategory> GetInventoryRecipeMenuCategoryByID(InventoryRecipeMenuCategory item);
        IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> GetRestaurantCategory(InventoryRecipeMenuCategorySearchRequest searchRequest);
    }
}
