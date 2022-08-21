using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryRecipeFormulaDetailsViewModel
    {
        InventoryRecipeFormulaDetails InventoryRecipeFormulaDetailsDTO
        {
            get;
            set;
        }

        Int32 ID
        {
            get;
            set;
        }
        Int32 ItemNumber
        {
            get;
            set;
        }
        Boolean InoutType
        {
            get;
            set;
        }
        Boolean IsOptionalIngrediant
        {
            get;
            set;
        }
        string UOMCode
        {
            get;
            set;
        }
        string RecipeVariationTitle
        {
            get;
            set;
        }
        double Quantity
        {
            get;
            set;
        }
        decimal Cost
        {
            get;
            set;
        }
        byte InventoryVariationMasterID
        {
            get;
            set;
        }
        byte OrderNumber
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
