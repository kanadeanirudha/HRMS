using System;
using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class VendorMasterReportSearchRequest : BaseDTO
    {
        
        public String  VendorName
        { get; 
          set; 
        }
        public string ContactPerson
        { 
            get; 
            set; 
        }


        public string ReportFor { get; set; }
    }
}


       
       
    
