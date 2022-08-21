using System;
using AERP.Base.DTO;

namespace AERP.DTO
{
   public class CCRMCallLogReportSearchRequest :BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string ReportFor { get; set; }
        public string MIFType { get; set; }
        public string SCNSubmitted { get; set; }
        public string Status { get; set; }
        public string CallStatus { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string SerialNo { get; set; }
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
        public int CallTypeID
        {
            get;
            set;
        }
        public int CCRMLocationTypeID
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }
        public int LoggID
        {
            get;
            set;
        }
        public int AllotUserID
        {
            get;
            set;
        }
    }
}
