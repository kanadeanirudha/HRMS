using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IInventoryRecipeMenuCategoryViewModel
    {
        InventoryRecipeMenuCategory InventoryRecipeMenuCategoryDTO { get; set; }
        Int16 ID { get; set; }
        string MenuCategory { get; set; }
        string MenuCategoryCode { get; set; }
        Int32 CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        Int32 ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        Int32 DeletedBy { get; set; }
        DateTime DeletedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
