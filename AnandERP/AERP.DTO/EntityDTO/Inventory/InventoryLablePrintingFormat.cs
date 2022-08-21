using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class InventoryLablePrintingFormat : BaseDTO
    {

        public int ItemNumber
        { get; 
          set; 
        }
        public int ToItemNumber
        {
            get;
            set;
        }
        public int FromItemNumber
        {
            get;
            set;
        }
        public string Store
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SalesUoM
        {
            get;
            set;
        } 
        public string ItemDescription
        { 
            get; 
            set; 
        }
        public string ArebicTransalation
        {
            get;
            set;
        }
        public string ShelfNumber
        {
            get;
            set;
        }
        public string CurrencyCode
        {
            get;
            set;
        }
        public Byte ReorderPoint { get; set; }
        public Byte SafetyStockDriven { get; set; }
        public string IsSaleUnit
        { 
            get; 
            set; 
        }
        
        public decimal SalesPrice
        {
            get;
            set;
        }
       
        public string PurchaseUomCode
        {
            get;
            set;
        }

       
        public int GeneralUnitsID
        {
            get;
            set;
        }
        
        public string BarCode
        {
            get;
            set;
        }

        public string TransactionDate
        {
            get;
            set;
        }
        

       
    }
}
