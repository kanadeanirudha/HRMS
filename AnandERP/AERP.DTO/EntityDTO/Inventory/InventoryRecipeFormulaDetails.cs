using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class InventoryRecipeFormulaDetails : BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }
        public Int32 ItemNumber
        {
            get;
            set;
        }
        public int GeneralItemMasterID
        {
            get;
            set;
        }
        public Boolean InoutType
        {
            get;
            set;
        }
        public Boolean IsOptionalIngrediant
        {
            get;
            set;
        }
        public double Quantity
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string UOMCode
        {
            get;
            set;
        }
        public string RecipeVariationTitle
        {
            get;
            set;
        }
        public byte InventoryVariationMasterID
        {
            get;
            set;
        }
        public byte OrderNumber
        {
            get;
            set;
        }
        public decimal Cost
        {
            get;
            set;
        }
        public double LastPurchasePrice
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
