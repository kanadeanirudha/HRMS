using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AERP.Common;
using AERP.DTO;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
   public class CCRMCallLogReportViewModel
    {
        public CCRMCallLogReportViewModel()
        {
            CCRMCallLogReportDTO = new CCRMCallLogReport();


        }
        public CCRMCallLogReport CCRMCallLogReportDTO { get; set; }
        public Int32 ID
        {
            get
            {
                return (CCRMCallLogReportDTO != null && CCRMCallLogReportDTO.ID > 0) ? CCRMCallLogReportDTO.ID : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.ID = value;
            }
        }
        public string MIFName
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.MIFName : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.MIFName = value;
            }
        }
        public string CallTktNo
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CallTktNo : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.CallTktNo = value;
            }
        }
        public string SerialNo
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.SerialNo = value;
            }
        }
        //public Int16 MachineFamilyID
        //{
        //    get
        //    {
        //        return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.MachineFamilyID : new Int16();
        //    }
        //    set
        //    {
        //        CCRMCallLogReportDTO.MachineFamilyID = value;
        //    }
        //}
        //public Int32 CCRMLocationTypeID
        //{
        //    get
        //    {
        //        return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CCRMLocationTypeID : new Int32();
        //    }
        //    set
        //    {
        //        CCRMCallLogReportDTO.CCRMLocationTypeID = value;
        //    }
        //}
        
        public string AreaPatchName
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.AreaPatchName : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.AreaPatchName = value;
            }
        }
        public string CustomerName
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CustomerName : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.CustomerName = value;
            }
        }
        public string MachineFamilyName
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.MachineFamilyName : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.MachineFamilyName = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CentreCode : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.CentreCode = value;
            }
        }
        public Int32 AdminRoleMasterID
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.AdminRoleMasterID : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.AdminRoleMasterID = value;
            }
        }
        public Int32 EngineerID
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.EngineerID : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.EngineerID = value;
            }
        }

        public string RightName
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.RightName : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.RightName = value;
            }
        }
        public Int32 EmployeeID
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.EmployeeID : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.EmployeeID = value;
            }
        }
        public string EmployeeCode
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.EmployeeCode : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.EmployeeCode = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.EmployeeName : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.EmployeeName = value;
            }
        }
        public string ItemDescription
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.ItemDescription = value;
            }
        }
        public bool IsPosted
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.IsPosted : false;
            }
            set
            {
                CCRMCallLogReportDTO.IsPosted = value;
            }
        }
        public string ContractType
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.ContractType : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.ContractType = value;
            }
        }
        public Int32 ContractTypeId
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.ContractTypeId : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.ContractTypeId = value;
            }
        }
        public byte Priority
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.Priority : new byte();
            }
            set
            {
                CCRMCallLogReportDTO.Priority = value;
            }
        }
        public string ContractCode
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.ContractCode : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.ContractCode = value;
            }
        }
        public string EnggName
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.EnggName : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.EnggName = value;
            }
        }
        public string ContractNo
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.ContractNo : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.ContractNo = value;
            }
        }
        public string CallDate
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CallDate : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.CallDate = value;
            }
        }
        [Display(Name = "Call Type")]
        public string CallTypeCode
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CallTypeCode : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.CallTypeCode = value;
            }
        }
        public string MIFType
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.MIFType : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.MIFType = value;
            }
        }
        public string LocationType
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.LocationType : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.LocationType = value;
            }
        }
        public string AllotEnggName
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.AllotEnggName : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.AllotEnggName = value;
            }
        }
        public string AllotDate
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.AllotDate : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.AllotDate = value;
            }
        }
        public string UserName
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.UserName : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.UserName = value;
            }
        }
        public decimal AllotPeriod
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.AllotPeriod :new decimal();
            }
            set
            {
                CCRMCallLogReportDTO.AllotPeriod = value;
            }
        }
        public string CallerPh
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CallerPh : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.CallerPh = value;
            }
        }
        public string CallerName
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CallerName : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.CallerName = value;
            }
        }
        public string CallStatus
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CallStatus : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.CallStatus = value;
            }
        }
        public Int32 A4Mono
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.A4Mono : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.A4Mono = value;
            }
        }
        public Int32 A4Col
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.A4Col : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.A4Col = value;
            }
        }
        public Int32 A3Mono
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.A3Mono : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.A3Mono = value;
            }
        }
        public Int32 A3Col
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.A3Col : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.A3Col = value;
            }
        }
        public string EmailID
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.EmailID : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.EmailID = value;
            }
        }
        public string SplRemarks
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.SplRemarks : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.SplRemarks = value;
            }
        }
        public string ArrivalDate
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.ArrivalDate : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.ArrivalDate = value;
            }
        }
        public string CompletionDate
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CompletionDate : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.CompletionDate = value;
            }
        }
        public decimal ArrivalPeriod
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.ArrivalPeriod : new decimal();
            }
            set
            {
                CCRMCallLogReportDTO.ArrivalPeriod = value;
            }
        }
        public decimal CompletionPeriod
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CompletionPeriod : new decimal();
            }
            set
            {
                CCRMCallLogReportDTO.CompletionPeriod = value;
            }
        }
        public decimal TotalDownTime
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.TotalDownTime : new decimal();
            }
            set
            {
                CCRMCallLogReportDTO.TotalDownTime = value;
            }
        }
        public string ReasonCode
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.ReasonCode : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.ReasonCode = value;
            }
        }
        public string BrokenReason
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.BrokenReason : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.BrokenReason = value;
            }
        }
        public string SymptomCode
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.SymptomCode : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.SymptomCode = value;
            }
        }
        public string CauseCode
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CauseCode : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.CauseCode = value;
            }
        }
        public string ActionCode
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.ActionCode : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.ActionCode = value;
            }
        }
        public string SCNSubmitted
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.SCNSubmitted : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.SCNSubmitted = value;
            }
        }
        public Int32 CallTypeID
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CallTypeID : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.CallTypeID = value;
            }
        }
        public Int32 CCRMLocationTypeID
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.CCRMLocationTypeID : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.CCRMLocationTypeID = value;
            }
        }
        public string SCNStatus
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.SCNStatus : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.SCNStatus = value;
            }
        }
        public string DateFrom
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.DateFrom : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.DateFrom = value;
            }
        }
        public string DateTo
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.DateTo : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.DateTo = value;
            }
        }
        [Display(Name = "Alloted By")]
        public Int32 UserID
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.UserID : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.UserID = value;
            }
        }
        [Display(Name = "Logg By")]
        public Int32 LoggID
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.LoggID : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.LoggID = value;
            }
        }
        public Int32 AllotUserID
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.LoggID : new Int32();
            }
            set
            {
                CCRMCallLogReportDTO.LoggID = value;
            }
        }
        public string Status
        {
            get
            {
                return (CCRMCallLogReportDTO != null) ? CCRMCallLogReportDTO.Status : string.Empty;
            }
            set
            {
                CCRMCallLogReportDTO.Status = value;
            }
        }
    }
}
