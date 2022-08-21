using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;

namespace AERP.DTO
{
   public class CCRMComplaintLoggingMaster :BaseDTO
    {
        public Int32 ID { get; set; }
        public Int32 UserID { get; set; }
        public string CallDate { get; set; }
        public string CallTime { get; set; }
        public string CallTktNo { get; set; }
        public string SerialNo { get; set; }
        public string MIFName { get; set; }
        public string CompanyCallDate { get; set; }
        public string CompanyCallTime { get; set; }
        public string CompanyCallNo { get; set; }
        public string CustomerName { get; set; }
        public Int32 CustomertID { get; set; }
        public string Phoneno { get; set; }
        public string EmailID { get; set; }
        public string SymptomCode { get; set; }
        public string SymptomTitle { get; set; }
        public string CallerName { get; set; }
        public string CallerPh { get; set; }
        public string ComPlaint { get; set; }
        public byte MachineStatus { get; set; }
        public byte Priority { get; set; }
        public Int32 A4Mono { get; set; }
        public Int32 A4Col { get; set; }
        public Int32 A3Mono { get; set; }
        public Int32 A3Col { get; set; }
        public decimal CallCharges { get; set; }
        public bool TeleSolution { get; set; }
        public bool CustApproval { get; set; }
        public string Remarks { get; set; }
        public string SplInstructions { get; set; }
        public bool SSSApproval { get; set; }
        public string MCAddress { get; set; }
        public string ContactPerson { get; set; }
        public Int32 ContactPersonID { get; set; }
        public string ModelNo { get; set; }
        public string ContractType { get; set; }
        public Int32 ContractTypeID { get; set; }
        public string ContractNo { get; set; }
        public Int32 ContractTypeId { get; set; }
        public string ContOpDate { get; set; }
        public string ContClDate { get; set; }
        public string SerEnggName { get; set; }
        public string EnggMobNo { get; set; }
        public string SplRemarks { get; set; }
        public string CallType { get; set; }
        public Int32 CallTypeID { get; set; }
        public Int32 EngineerID { get; set; }
        public Int32 SymptomID { get; set; }
        public string KeyOperator { get; set; }
        public byte CallStatus { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public string ItemDescription { get; set; }
        public Int32 KeyOperatorID { get; set; }
        public string Solution { get; set; }
        public string CallTypeName { get; set; }
        public string CCRMComplaintLoggingMasterModel { get; set; }
        public string KeyOperatorName { get; set; }
        public string AreaPatchName { get; set; }
        public Int32 MIFID { get; set; }
        public Int32 ComplaintSrNo { get; set; }
        public bool Allotment { get; set; }
        public bool CallerFlag { get; set; }
        public Int16 AdminRoleMasterID { get; set; }
        public string CentreCode { get; set; }
        public string RightName { get; set; }
        public string EmployeeCode { get; set; }
        public string UserName { get; set; }
        public string EmployeeName { get; set; }
        public Int32 EmployeeID { get; set; }
        public Int32 CallerID { get; set; }
        public string VersionNumber { get; set; }
        public Nullable<System.DateTime> LastSyncDate { get; set; }
        public string SyncType
        {
            get; set;
        }
        public string Entity
        {
            get; set;
        }

        public string BrokenReason
        {
            get; set;
        } 
        public byte TrackType
        {
            get;
            set;
        }
        public string DeviceToken
        {
            get;
            set;
        }
        public string ComplaintNumberString
        {
            get;
            set;
        }
        public string JSON
        {
            get;
            set;
        }
        public decimal Latitude
        {
            get;
            set;
        }

        public decimal Longitude
        {
            get;
            set;
        }
        public Int32 ComplaintCountID { get; set; }
        public Int32 ComplaintCount { get; set; }

        public string ContractClosingDate
        {
            get;
            set;
        }
    }
}
