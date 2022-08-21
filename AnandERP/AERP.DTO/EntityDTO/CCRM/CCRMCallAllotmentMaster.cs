using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;

namespace AERP.DTO
{
  public  class CCRMCallAllotmentMaster:BaseDTO
    {
        public Int32 ID { get; set; }

        public Int32 AllotNo { get; set; }
        public string AllotDate { get; set; }
        public Int32 CallId { get; set; }
        public string CallNo { get; set; }
        public string CallTktNo { get; set; }
        public string CallDate { get; set; }
        public string ItemDescription { get; set; }
        public Int32 AllotEnggId { get; set; }
        public string AllotEnggName { get; set; }
        public byte CallStatus { get; set; }
        public string SerialNo { get; set; }
        public string MIFName { get; set; }
        public string ModelNo { get; set; }
        public string EmailID { get; set; }
        public string CallerName { get; set; }
        public string CallerPh { get; set; }
        public string ComPlaint { get; set; }
        public string SerEnggName { get; set; }
        public string EnggMobNo { get; set; }
        public string Sms { get; set; }
        public string Email { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public string CallTypeName { get; set; }
        public Int32 CallTypeID { get; set; }
        public string SymptomTitle { get; set; }
        public byte Priority { get; set; }
        public Int32 EngineerID { get; set; }
        public string AreaPatchName { get; set; }
        public string CentreCode { get; set; }
        public Int32 AdminRoleMasterID { get; set; }
        public string RightName { get; set; }
        public Int32 EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string ContractStatus { get; set; }
        public bool Cancel { get; set; }
        public string CancelReason { get; set; }
        public bool Allotment { get; set; }
        public decimal AllotPeriod { get; set; }
        public Int32 UserID { get; set; }
        public string UserName { get; set; }
    }
}
