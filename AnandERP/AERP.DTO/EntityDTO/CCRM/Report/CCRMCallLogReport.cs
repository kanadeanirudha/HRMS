using AERP.Base.DTO;
using System;


namespace AERP.DTO
{
   public class CCRMCallLogReport :BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }
        
        public string MIFName
        {
            get; set;
        }
      
        public string CallTktNo
        {
            get; set;
        }
        public string SerialNo
        {
            get; set;
        }
        public Int16 MachineFamilyID
        {
            get; set;
        }
        public string AreaPatchName
        {
            get; set;
        }
        public Int32 CCRMLocationTypeID
        {
            get; set;
        }
        public string CustomerName
        {
            get; set;
        }
      
        public Int16 CCRMAreaPatchMasterID
        {
            get;
            set;
        }
       
        public string MachineFamilyName
        {
            get; set;
        }
        public string CentreCode
        {
            get; set;
        }
        public Int32 AdminRoleMasterID
        {
            get;
            set;
        }
        public string RightName
        {
            get; set;
        }
        public Int32 EmployeeID
        {
            get;
            set;
        }
        public string EmployeeCode
        {
            get; set;
        }
        public string EmployeeName
        {
            get; set;
        }
        public string ItemDescription
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }
        public bool IsPosted
        {
            get; set;
        }
        public string ContractType
        {
            get; set;
        }
        public Int32 ContractTypeId
        {
            get;
            set;
        }
        public string ContractCode
        {
            get; set;
        }
        public string EnggName
        {
            get; set;
        }
        public Int32 EngineerID
        {
            get;
            set;
        }
        
       
        public byte Priority
        {
            get; set;
        }
        public string ContractNo
        {
            get; set;
        }
        public string CallDate
        {
            get; set;
        }
        public string CallTypeCode
        {
            get; set;
        }
        public string MIFType
        {
            get; set;
        }
        public string LocationType
        {
            get; set;
        }
        public string AllotEnggName
        {
            get; set;
        }
        public string AllotDate
        {
            get; set;
        }
        public string UserName
        {
            get; set;
        }
        public decimal AllotPeriod
        {
            get; set;
        }
        public string CallerName
        {
            get; set;
        }
        public string CallerPh
        {
            get; set;
        }
        public string CallStatus
        {
            get; set;
        }
        public Int32 A4Mono
        {
            get; set;
        }
        public Int32 A4Col
        {
            get; set;
        }
        public Int32 A3Mono
        {
            get; set;
        }
        public Int32 A3Col
        {
            get; set;
        }
        public string EmailID
        {
            get; set;
        }
        public string SplRemarks
        {
            get; set;
        }
        public string ArrivalDate
        {
            get; set;
        }
        public string CompletionDate
        {
            get; set;
        }
        public decimal ArrivalPeriod
        {
            get; set;
        }
        public decimal CompletionPeriod
        {
            get; set;
        }
        public decimal TotalDownTime
        {
            get; set;
        }
        public string ReasonCode
        {
            get; set;
        }
        public string BrokenReason
        {
            get; set;
        }
        public string SymptomCode
        {
            get; set;
        }
        public string CauseCode
        {
            get; set;
        }
        public string ActionCode
        {
            get; set;
        }
        public string SCNSubmitted
        {
            get; set;
        }
        public string SCNStatus
        {
            get; set;
        }
        public string CallType { get; set; }
        public Int32 CallTypeID { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public Int32 UserID { get; set; }
        public Int32 LoggID { get; set; }
        public Int32 AllotUserID { get; set; }
        public string Allotment { get; set; }
    }
}
