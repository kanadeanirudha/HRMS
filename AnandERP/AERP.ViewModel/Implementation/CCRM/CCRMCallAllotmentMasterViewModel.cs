using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;


namespace AERP.ViewModel
{
   public class CCRMCallAllotmentMasterViewModel :ICCRMCallAllotmentMasterViewModel
    {
        public CCRMCallAllotmentMasterViewModel()
        {
            CCRMCallAllotmentMasterDTO = new CCRMCallAllotmentMaster();
            PendingCallByCCRMCallAllotmentMasterID = new List<CCRMCallAllotmentMaster>();
        }
        public List<CCRMCallAllotmentMaster> PendingCallByCCRMCallAllotmentMasterID { get; set; }
        public CCRMCallAllotmentMaster CCRMCallAllotmentMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null && CCRMCallAllotmentMasterDTO.ID > 0) ? CCRMCallAllotmentMasterDTO.ID : new Int32();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.ID = value;
            }
        }
        public Int32 AllotNo
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null && CCRMCallAllotmentMasterDTO.ID > 0) ? CCRMCallAllotmentMasterDTO.AllotNo : new Int32();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.AllotNo = value;
            }
        }
        [Display(Name = "Allot Date")]
        
        public string AllotDate
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.AllotDate : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.AllotDate = value;
            }
        }
        [Display(Name = "Call Id")]
        public Int32 CallId
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CallId : new Int32();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CallId = value;
            }
        }
        [Display(Name = "Call No")]
        //[Required(ErrorMessage = "Area Patch Name Required")]
        public string CallNo
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CallNo : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CallNo = value;
            }
        }
        [Display(Name = "Call Log Date")]
        //[Required(ErrorMessage = "Area Patch Name Required")]
        public string CallDate
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CallDate : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CallDate = value;
            }
        }
        public Int32 AllotEnggId
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.AllotEnggId : new Int32();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.AllotEnggId = value;
            }
        }
        [Display(Name = "Allot Engg Name")]
        //[Required(ErrorMessage = "Employee Name Required")]
        public string AllotEnggName
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.AllotEnggName : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.AllotEnggName = value;
            }
        }
        public byte CallStatus
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CallStatus : new byte();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CallStatus = value;
            }
        }
        public string SerialNo
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.SerialNo = value;
            }
        }
        public string MIFName
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.MIFName : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.MIFName = value;
            }
        }
        public string ModelNo
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.ModelNo : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.ModelNo = value;
            }
        }
        public string EmailID
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.EmailID : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.EmailID = value;
            }
        }
        public string CallerPh
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CallerPh : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CallerPh = value;
            }
        }
        [Display(Name = "CallerDetails")]
        public string CallerName
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CallerName : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CallerName = value;
            }
        }
        public string ComPlaint
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.ComPlaint : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.ComPlaint = value;
            }
        }
        public string SerEnggName
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.SerEnggName : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.SerEnggName = value;
            }
        }
        public string EnggMobNo
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.EnggMobNo : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.EnggMobNo = value;
            }
        }
        public string Sms
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.Sms : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.Sms = value;
            }
        }
        public string Email
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.Email : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.Email = value;
            }
        }
        public string CallTktNo
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CallTktNo : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CallTktNo = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null && CCRMCallAllotmentMasterDTO.CreatedBy > 0) ? CCRMCallAllotmentMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null && CCRMCallAllotmentMasterDTO.ModifiedBy.HasValue) ? CCRMCallAllotmentMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null && CCRMCallAllotmentMasterDTO.ModifiedDate.HasValue) ? CCRMCallAllotmentMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null && CCRMCallAllotmentMasterDTO.DeletedBy.HasValue) ? CCRMCallAllotmentMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null && CCRMCallAllotmentMasterDTO.DeletedDate.HasValue) ? CCRMCallAllotmentMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.DeletedDate = value;
            }
        }
        public Nullable<bool> IsActive
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.IsDeleted = value;
            }
        }
        public string ItemDescription
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.ItemDescription = value;
            }
        }
        [Display(Name = "Call Type")]
        public string CallTypeName
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CallTypeName : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CallTypeName = value;
            }
        }
        public Int32 CallTypeID
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CallTypeID : new Int32();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CallTypeID = value;
            }
        }
        public string SymptomTitle
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.SymptomTitle : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.SymptomTitle = value;
            }
        }
        public byte Priority
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.Priority : new byte();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.Priority = value;
            }
        }
        public Int32 EngineerID
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.EngineerID : new Int32();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.EngineerID = value;
            }
        }
        public string AreaPatchName
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.AreaPatchName : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.AreaPatchName = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.EmployeeName : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.EmployeeName = value;
            }
        }
        public string ContractStatus
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.ContractStatus : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.ContractStatus = value;
            }
        }
        public bool Cancel
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.Cancel : new bool();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.Cancel = value;
            }
        }
        public string CancelReason
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.CancelReason : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.CancelReason = value;
            }
        }
        public bool Allotment
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.Allotment : new bool();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.Allotment = value;
            }
        }
        public decimal AllotPeriod
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.AllotPeriod : new decimal();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.AllotPeriod = value;
            }
        }
        public Int32 UserID
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.UserID : new Int32();
            }
            set
            {
                CCRMCallAllotmentMasterDTO.UserID = value;
            }
        }
        public string UserName
        {
            get
            {
                return (CCRMCallAllotmentMasterDTO != null) ? CCRMCallAllotmentMasterDTO.UserName : string.Empty;
            }
            set
            {
                CCRMCallAllotmentMasterDTO.UserName = value;
            }
        }
    }
}
