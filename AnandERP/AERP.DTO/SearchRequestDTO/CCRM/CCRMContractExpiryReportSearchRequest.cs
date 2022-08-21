using System;
using AERP.Base.DTO;


namespace AERP.DTO
{
   public class CCRMContractExpiryReportSearchRequest :BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string ReportFor { get; set; }
    }
}
