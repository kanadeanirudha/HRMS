using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryRecipeMenuCategorySearchRequest : Request
    {
        public Int16 ID { get; set; }
        public string MenuCategory { get; set; }
        public string MenuCategoryCode { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32 ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Int32 DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
    }
}
