using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class BOMAndRecipeDetails : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public int GeneralItemMasterID
        {
            get;
            set;
        }
        public string XMLstring { get; set; }
        //Feilds From InventoryRecipeMaster
        public Int16 InventoryRecipeMasterID
        {
            get;
            set;
        }
        public string InventoryRecipeMasterTitle
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public int PrimaryItemOutputId
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
        //Feilds From InventoryVariationMaster
        public Int16 InventoryVariationMasterID
        {
            get;
            set;

        }
        public string RecipeVariationTitle
        {
            get;
            set;
        }
        //feilds from InventoryRecipeFormulaDetails

        public int InventoryRecipeFormulaDetailsID
        {
            get;
            set;
        }
        public decimal Cost
        {
            get;
            set;
        }
        public decimal WastageInPercentage
        {
            get;
            set;
        }
        public byte OrderNumber
        {
            get;
            set;
        }
        //feilds from InventoryRecipeMenuMaster
        public Int16 InventoryRecipeMenuMaster
        {
            get;
            set;
        }
        public string MenuDescription
        {
            get;
            set;
        }
        public string LowerLevelUomCode
        {
            get;
            set;
        }
        public string DefineVariants
        {
            get;
            set;
        }
        public string BOMRelevant
        {
            get;
            set;
        }
        public string BillingItemName
        {
            get;
            set;
        }
       
        public string UnitName
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
        public double Quantity
        {
            get;
            set;
        }
        public double Quantity1
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string UoMCode
        {
            get;
            set;
        }
        public bool IsOptionalIngrediant
        {
            get;
            set;
        }
        public bool IsBOM
        {
            get;
            set;
        }
        public string OrderUomCode
        {
            get;
            set;
        }
        public decimal ConsumptionPrice
        {
            get;
            set;
        }
        public decimal ConsumptionPrice1
        {
            get;
            set;
        }
        public decimal PurchasePrice
        {
            get;
            set;
        }
        public decimal BaseUomPrice
        {
            get;
            set;
        }
    }
}
