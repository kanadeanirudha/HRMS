using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryRecipeMasterViewModel
    {
        InventoryRecipeMaster InventoryRecipeMasterDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        string VersionCode
        {
            get;
            set;
        }
        string Title
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }
        string RecipeVariationTitle
        {
            get;
            set;
        }
        int OldRecipeId
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
