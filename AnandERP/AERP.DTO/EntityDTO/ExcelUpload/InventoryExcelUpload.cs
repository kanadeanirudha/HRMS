using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class InventoryExcelUpload : BaseDTO
    {
        #region -------------- InventoryExcelUpload ---------------
        public int ID
        {
            get;
            set;
        }
        public string ExcelFile
        {
            get;
            set;
        }
        public string MarchendiseCategoryList
        {
            get;
            set;
        }
        public string VendorNumberList
        {
            get;
            set;
        }
        public string ExcelSheetName
        {
            get;
            set;
        }
        public string OrderingdayList
        {
            get;
            set;
        }
        
        public string UnitsList
        {
            get;
            set;
        }

        public string XMLstring 
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
        public string errorMessage 
        { 
            get; 
            set;
        }

        #endregion

    }
}
