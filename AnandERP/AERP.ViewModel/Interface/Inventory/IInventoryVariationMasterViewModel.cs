using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryVariationMasterViewModel
    {
        InventoryVariationMaster InventoryVariationMasterDTO
        {
            get;
            set;
        }

        byte ID
        {
            get;
            set;
        }
        Int16 InventoryRecipeMasterId
        {
            get;
            set;
        }

        string RecipeVariationTitle
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
        string RecipeTitle
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
