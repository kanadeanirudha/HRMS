using System;
using AERP.Base.DTO;

namespace AERP.DTO
{
  public  class CCRMMIFReportSearchRequest :BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string ReportFor { get; set; }
        public string Status
        {
            get;
            set;
        }
        public int ContractTypeId
        {
            get;
            set;
        }
        public int EngineerID
        {
            get;
            set;
        }
        public int CCRMAreaPatchMasterID
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }
    }
}
