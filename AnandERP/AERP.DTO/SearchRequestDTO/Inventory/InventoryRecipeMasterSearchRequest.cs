using AMS.Base.DTO;

namespace AMS.DTO
{
    public class InventoryRecipeMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int OldRecipeId
        {
            get;
            set;
        }
        public string VersionCode
        {
            get;
            set;
        }

        public string Title { get; set; }
        public string Description { get; set; }

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
