using System;
using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class InventoryReportSearchRequest : BaseDTO
    {
        
        public Int32 ItemNumber
        { get; 
          set; 
        }
        public string ItemName
        { 
            get; 
            set; 
        }
        //Item Master Missing Exception Report
        public string Vendor
        {
            get;
            set;
        }
        public string ReportFor
        {
            get;
            set;
        }
        public Int16 GeneralUnitsID
        {
            get;
            set;
        }
        public string Date
        {
            get;
            set;
        }
        public string GeneralUnitsName
        {
            get;
            set;
        }
        public string CentreName { get; set; }
        public string CentreCode { get; set; }
        public Int32 GeneralItemMasterID { get; set; }
        public string ItemDescription { get; set; }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
    }
}


       
       
    
