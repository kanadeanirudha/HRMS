using AMS.Base.DTO;

namespace AMS.DTO
{
    public class InventoryVariationMasterSearchRequest : Request
    {
        public byte ID
        {
            get;
            set;
        }
        public int InventoryRecipeMasterId { get; set; }
        public string RecipeVariationTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RecipeTitle { get; set; }


        public bool IsDeleted
        {
            get;
            set;
        }

        public string SortOrder
        {
            get;
            set;
        }

        public string SortBy
        {
            get;
            set;
        }

        public int StartRow
        {
            get;
            set;
        }

        public int EndRow
        {
            get;
            set;
        }

        public int RowLength
        {
            get;
            set;
        }
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
