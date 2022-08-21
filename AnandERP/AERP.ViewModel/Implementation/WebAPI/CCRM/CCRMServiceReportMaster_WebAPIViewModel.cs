using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class CCRMServiceReportMaster_WebAPIViewModel
    {
        public CCRMServiceReportMaster_WebAPIViewModel()
        {
            CCRMServiceReportMasterDTO = new CCRMServiceReportMaster();
             

        }
        public List<CCRMServiceReportMaster> ListOfItemsDetails
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ListOfItemsDetails : new List<CCRMServiceReportMaster>();
            }
            set
            {
                ListOfItemsDetails = value;
            }
        }
        public CCRMServiceReportMaster CCRMServiceReportMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ID > 0) ? CCRMServiceReportMasterDTO.ID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.ID = value;
            }
        }

        public Int32 CurrentReadA4Mono
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.CurrentReadA4Mono > 0) ? CCRMServiceReportMasterDTO.CurrentReadA4Mono : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.CurrentReadA4Mono = value;
            }
        }
        public Int32 CurrentReadA4Col
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.CurrentReadA4Col > 0) ? CCRMServiceReportMasterDTO.CurrentReadA4Col : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.CurrentReadA4Col = value;
            }
        }
        public Int32 CurrentReadA3Mono
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.CurrentReadA3Mono > 0) ? CCRMServiceReportMasterDTO.CurrentReadA3Mono : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.CurrentReadA3Mono = value;
            }
        }
        public Int32 CurrentReadA3Col
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.CurrentReadA3Col > 0) ? CCRMServiceReportMasterDTO.CurrentReadA3Col : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.CurrentReadA3Col = value;
            }
        }
        public Int32 SymptomID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.SymptomID > 0) ? CCRMServiceReportMasterDTO.SymptomID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.SymptomID = value;
            }
        }
        public string SymptomCode
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.SymptomCode : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.SymptomCode = value;
            }
        }
        public string CauseCode
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CauseCode : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.CauseCode = value;
            }
        }
        public string ActionCode
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ActionCode : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ActionCode = value;
            }
        }
        public string SymptomTitle
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.SymptomTitle : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.SymptomTitle = value;
            }
        }

        public byte CallStatus
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.CallStatus > 0) ? CCRMServiceReportMasterDTO.CallStatus : new byte();
            }
            set
            {
                CCRMServiceReportMasterDTO.CallStatus = value;
            }
        }

        public string ReasonCode
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ReasonCode : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ReasonCode = value;
            }
        }

        public string CallTktNo
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CallTktNo : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.CallTktNo = value;
            }
        }

        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.CreatedBy > 0) ? CCRMServiceReportMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMServiceReportMasterDTO.CreatedBy = value;
            }
        }

        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMServiceReportMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMServiceReportMasterDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ModifiedBy.HasValue) ? CCRMServiceReportMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMServiceReportMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ModifiedDate.HasValue) ? CCRMServiceReportMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMServiceReportMasterDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.DeletedBy.HasValue) ? CCRMServiceReportMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMServiceReportMasterDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.DeletedDate.HasValue) ? CCRMServiceReportMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMServiceReportMasterDTO.DeletedDate = value;
            }
        }
        public bool SCNSubmitted
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.SCNSubmitted : new bool();
            }
            set
            {
                CCRMServiceReportMasterDTO.SCNSubmitted = value;
            }
        }

        public Int32 ReasonCodeID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ReasonCodeID > 0) ? CCRMServiceReportMasterDTO.ReasonCodeID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.ReasonCodeID = value;
            }
        }

        public string XmlString
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.XmlString : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.XmlString = value;
            }
        }

        public string VersionNumber
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.VersionNumber = value;
            }
        }

        public string BrokenReason
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.BrokenReason : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.BrokenReason = value;
            }
        }

        public Int32 CauseID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.CauseID > 0) ? CCRMServiceReportMasterDTO.CauseID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.CauseID = value;
            }
        }
        public string CauseTitle
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CauseTitle : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.CauseTitle = value;
            }
        }
        public Int32 ActionID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ActionID > 0) ? CCRMServiceReportMasterDTO.ActionID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.ActionID = value;
            }
        }
        public string ActionTitle
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ActionTitle : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ActionTitle = value;
            }
        }
        public string SymptomDescrip
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.SymptomDescrip : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.SymptomDescrip = value;
            }
        }
        public string CauseDescrip
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CauseDescrip : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.CauseDescrip = value;
            }
        }
        public string ActionDescrip
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ActionDescrip : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ActionDescrip = value;
            }
        }

    }
}
