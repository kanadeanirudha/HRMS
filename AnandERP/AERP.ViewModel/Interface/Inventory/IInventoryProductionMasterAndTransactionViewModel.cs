using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryProductionMasterAndTransactionViewModel
    {
        InventoryProductionMasterAndTransaction InventoryProductionMasterAndTransactionDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }

        //Feilds From InventoryRecipeMaster
        Int16 InventoryRecipeMasterID
        {
            get;
            set;
        }
        string InventoryRecipeMasterTitle
        {
            get;
            set;
        }
        string Description
        {
            get;
            set;
        }
        int PrimaryItemOutputId
        {
            get;
            set;
        }
        string VersionCode
        {
            get;
            set;
        }
        int OldRecipeId
        {
            get;
            set;
        }
        //Feilds From InventoryVariationMaster
        Int16 InventoryVariationMasterID
        {
            get;
            set;

        }
        string RecipeVariationTitle
        {
            get;
            set;
        }
        //feilds from InventoryRecipeFormulaDetails

        int InventoryRecipeFormulaDetailsID
        {
            get;
            set;
        }
        decimal Cost
        {
            get;
            set;
        }
        byte OrderNumber
        {
            get;
            set;
        }
        //feilds from InventoryRecipeMenuMaster
        Int16 InventoryRecipeMenuMaster
        {
            get;
            set;
        }
        string MenuDescription
        {
            get;
            set;
        }
        string DefineVariants
        {
            get;
            set;
        }
        string BOMRelevant
        {
            get;
            set;
        }
        string BillingItemName
        {
            get;
            set;
        }

        string UnitName
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
