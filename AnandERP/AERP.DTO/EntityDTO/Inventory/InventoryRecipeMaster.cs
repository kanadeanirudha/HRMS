using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryRecipeMaster : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
       
        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
        public string VersionCode
        {
            get;
            set;
        }

        public int OldRecipeId
        {
            get;
            set;
        }


         public string RecipeVariationTitle
        {
            get;
            set;
        }


        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
