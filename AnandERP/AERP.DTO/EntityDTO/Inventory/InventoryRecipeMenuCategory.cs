using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryRecipeMenuCategory : BaseDTO
    {
        public Int16 ID { get; set; }
        public string MenuCategory { get; set; }
        public string MenuCategoryCode { get; set; }
        public Byte CategoryType { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string errorMessage { get; set; }
        public bool IsActive { get; set; }
        public string ItemCategoryCode{get;set;}
    }
}
