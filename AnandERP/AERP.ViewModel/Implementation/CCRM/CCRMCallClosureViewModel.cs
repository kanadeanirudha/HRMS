using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
   public class CCRMCallClosureViewModel:ICCRMCallClosureViewModel
    {
        public CCRMCallClosureViewModel()
        {
            CCRMCallClosureDTO = new CCRMCallClosure();
        }
        public CCRMCallClosure CCRMCallClosureDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMCallClosureDTO != null && CCRMCallClosureDTO.ID > 0) ? CCRMCallClosureDTO.ID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.ID = value;
            }
        }
        [Display(Name = "Serial No")]
        //[Required(ErrorMessage = "Action Desciption Required")]
        public string SerialNo
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.SerialNo = value;
            }
        }
        [Display(Name = "Model No")]
        public string ModelNo
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ModelNo : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ModelNo = value;
            }
        }
        [Display(Name = "MIF Name")]
        public string MIFName
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.MIFName : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.MIFName = value;
            }
        }
        public byte Priority
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.Priority : new byte();
            }
            set
            {
                CCRMCallClosureDTO.Priority = value;
            }
        }
        public Int32 LocationID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.LocationID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.LocationID = value;
            }
        }
        [Display(Name = "Location Type Code")]
        public string LocationTypeCode
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.LocationTypeCode : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.LocationTypeCode = value;
            }
        }
        public Int16 MachineFamilyID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.MachineFamilyID : new Int16();
            }
            set
            {
                CCRMCallClosureDTO.MachineFamilyID = value;
            }
        }
        [Display(Name = "Machine Family Name")]
        public string MachineFamilyName
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.MachineFamilyName : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.MachineFamilyName = value;
            }
        }
        [Display(Name = "Contract Code")]
        public string ContractCode
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ContractCode : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ContractCode = value;
            }
        }
        public Int32 ContractTypeID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ContractTypeID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.ContractTypeID = value;
            }
        }
        public Int32 ComplaintSrNo
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ComplaintSrNo : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.ComplaintSrNo = value;
            }
        }
        [Display(Name = "Call Date")]
        public string CallDate
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CallDate : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.CallDate = value;
            }
        }
        public Int32 CallTypeID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CallTypeID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.CallTypeID = value;
            }
        }
        [Display(Name = "ComPlaint")]
        public string ComPlaint
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ComPlaint : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ComPlaint = value;
            }
        }
        [Display(Name = "Allot Date")]
        public string AllotDate
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.AllotDate : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.AllotDate = value;
            }
        }
        [Display(Name = "Allot Period")]
        public decimal AllotPeriod
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.AllotPeriod : new decimal();
            }
            set
            {
                CCRMCallClosureDTO.AllotPeriod = value;
            }
        }
        //[Display(Name = "call Close Date")]
        //public string callCloseDate
        //{

        //    get
        //    {
        //        return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.callCloseDate : string.Empty;
        //    }
        //    set
        //    {
        //        CCRMCallClosureDTO.callCloseDate = value;
        //    }
        //}
        [Display(Name = "SR Date")]
        public string SRDate
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SRDate : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.SRDate = value;
            }
        }
        [Display(Name = "Arrival Date")]
        public string ArrivalDate
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ArrivalDate : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ArrivalDate = value;
            }
        }
        [Display(Name = "Response Time")]
        public decimal ResponseTime
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ResponseTime : new decimal();
            }
            set
            {
                CCRMCallClosureDTO.ResponseTime = value;
            }
        }
        [Display(Name = "Down Time")]
        public decimal DownTime
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.DownTime : new decimal();
            }
            set
            {
                CCRMCallClosureDTO.DownTime = value;
            }
        }
        [Display(Name = "Total Down Time")]
        public decimal TotalDownTime
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.TotalDownTime : new decimal();
            }
            set
            {
                CCRMCallClosureDTO.TotalDownTime = value;
            }
        }
        //[Display(Name = "Mtr Read A4 Mono")]
        public Int32 CurrentReadA4Mono
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CurrentReadA4Mono : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.CurrentReadA4Mono = value;
            }
        }
       // [Display(Name = "Mtr Read A4Col")]
        public Int32 CurrentReadA4Col
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CurrentReadA4Col : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.CurrentReadA4Col = value;
            }
        }
        //[Display(Name = "Mtr Read A3Col")]
        public Int32 CurrentReadA3Mono
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CurrentReadA3Mono : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.CurrentReadA3Mono = value;
            }
        }
        //[Display(Name = "Mtr Read A3 Mono")]
        public Int32 CurrentReadA3Col
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CurrentReadA3Col : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.CurrentReadA3Col = value;
            }
        }
        public Int32 SymptomID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SymptomID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.SymptomID = value;
            }
        }
        [Display(Name = "Symptom Code")]
        public string SymptomCode
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SymptomCode : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.SymptomCode = value;
            }
        }
        [Display(Name = "Cause Code")]
        public string CauseCode
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CauseCode : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.CauseCode = value;
            }
        }
        [Display(Name = "Action Code")]
        public string ActionCode
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ActionCode : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ActionCode = value;
            }
        }
        [Display(Name = "Symptom Title")]
        public string SymptomTitle
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SymptomTitle : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.SymptomTitle = value;
            }
        }
        public Int32 EngineerID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.EngineerID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.EngineerID = value;
            }
        }
        public string Remarks
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.Remarks : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.Remarks = value;
            }
        }
        public byte CallStatus
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CallStatus : new byte();
            }
            set
            {
                CCRMCallClosureDTO.CallStatus = value;
            }
        }
        public string Status
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.Status : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.Status = value;
            }
        }
        public string ReasonCode
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ReasonCode : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ReasonCode = value;
            }
        }
        [Display(Name = "Call No")]

        public string CallTktNo
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CallTktNo : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.CallTktNo = value;
            }
        }
        [Display(Name = "Engg Name")]

        public string EnggName
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.EnggName : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.EnggName = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMCallClosureDTO != null && CCRMCallClosureDTO.CreatedBy > 0) ? CCRMCallClosureDTO.CreatedBy : new int();
            }
            set
            {
                CCRMCallClosureDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.IsDeleted : false;
            }
            set
            {
                CCRMCallClosureDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMCallClosureDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMCallClosureDTO != null && CCRMCallClosureDTO.ModifiedBy.HasValue) ? CCRMCallClosureDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMCallClosureDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMCallClosureDTO != null && CCRMCallClosureDTO.ModifiedDate.HasValue) ? CCRMCallClosureDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMCallClosureDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMCallClosureDTO != null && CCRMCallClosureDTO.DeletedBy.HasValue) ? CCRMCallClosureDTO.DeletedBy : new int();
            }
            set
            {
                CCRMCallClosureDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMCallClosureDTO != null && CCRMCallClosureDTO.DeletedDate.HasValue) ? CCRMCallClosureDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMCallClosureDTO.DeletedDate = value;
            }
        }
        public string ItemDescription
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ItemDescription = value;
            }
        }
        [Display(Name = "Call Type")]
        public string CallTypeName
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CallTypeName : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.CallTypeName = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.EmployeeName : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.EmployeeName = value;
            }
        }
        public string CallerName
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CallerName : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.CallerName = value;
            }
        }
        public Int32 A4Mono
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.A4Mono : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.A4Mono = value;
            }
        }
        // [Display(Name = "Mtr Read A4Col")]
        public Int32 A4Col
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.A4Col : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.A4Col = value;
            }
        }
        //[Display(Name = "Mtr Read A3Col")]
        public Int32 A3Mono
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.A3Mono : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.A3Mono = value;
            }
        }
        //[Display(Name = "Mtr Read A3 Mono")]
        public Int32 A3Col
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.A3Col : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.A3Col = value;
            }
        }
        public Int32 CauseID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CauseID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.CauseID = value;
            }
        }
        public string CauseTitle
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CauseTitle : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.CauseTitle = value;
            }
        }
        public Int32 ActionID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ActionID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.ActionID = value;
            }
        }
        public string ActionTitle
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ActionTitle : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ActionTitle = value;
            }
        }
        [Display(Name = "Symptom")]
        public string SymptomDescrip
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SymptomDescrip : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.SymptomDescrip = value;
            }
        }
        [Display(Name = "Cause")]
        public string CauseDescrip
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CauseDescrip : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.CauseDescrip = value;
            }
        }
        [Display(Name = "Action")]
        public string ActionDescrip
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ActionDescrip : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ActionDescrip = value;
            }
        }
        public string Feedback
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.Feedback : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.Feedback = value;
            }
        }
        [Display(Name = "Signed By")]
        public string SignedBy
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SignedBy : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.SignedBy = value;
            }
        }
        [Display(Name = "Phone No")]
        public string PhoneNo
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.PhoneNo : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.PhoneNo = value;
            }
        }
        public Int32 ItemID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ItemID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.ItemID = value;
            }
        }
        public string ItemName
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ItemName : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ItemName = value;
            }
        }
        [Display(Name = "Item Code")]
        public string ItemCategoryCode
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ItemCategoryCode : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ItemCategoryCode = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.Rate : new decimal();
            }
            set
            {
                CCRMCallClosureDTO.Rate = value;
            }
        }
        public Int32 Quantity
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.Quantity : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.Quantity = value;
            }
        }
        public byte Requierd
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.Requierd : new byte();
            }
            set
            {
                CCRMCallClosureDTO.Requierd = value;
            }
        }
        public Int32 ItemNumber
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ItemNumber : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.ItemNumber = value;
            }
        }

        [Display(Name = "Completion Period")]
        public decimal CompletionPeriod
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CompletionPeriod : new decimal();
            }
            set
            {
                CCRMCallClosureDTO.CompletionPeriod = value;
            }
        }
        [Display(Name = "Arrival Period")]
        public decimal ArrivalPeriod
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ArrivalPeriod : new decimal();
            }
            set
            {
                CCRMCallClosureDTO.ArrivalPeriod = value;
            }
        }
        public Int32 SignedID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SignedID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.SignedID = value;
            }
        }
        [Display(Name = "Job start Date")]
        public string JobstartDate
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.JobstartDate : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.JobstartDate = value;
            }
        }
        [Display(Name = "Job End Date")]
        public string JobEndDate
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.JobEndDate : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.JobEndDate = value;
            }
        }
        [Display(Name = "Job Period")]
        public decimal JobPeriod
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.JobPeriod : new decimal();
            }
            set
            {
                CCRMCallClosureDTO.JobPeriod = value;
            }
        }
        [Display(Name = "SCN Submitted")]
        public bool SCNSubmitted
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SCNSubmitted : new bool();
            }
            set
            {
                CCRMCallClosureDTO.SCNSubmitted = value;
            }
        }
        public Int32 FeedbackID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.FeedbackID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.FeedbackID = value;
            }
        }
        public string Symptom
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.Symptom : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.Symptom = value;
            }
        }
        public Int32 SrNo
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SrNo : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.SrNo = value;
            }
        }
        public string SCRNo
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.SCRNo : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.SCRNo = value;
            }
        }
        public string ServEnggName
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ServEnggName : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ServEnggName = value;
            }
        }
        public Int32 CallId
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CallId : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.CallId = value;
            }
        }
        //public string CallCloseDate
        //{
        //    get
        //    {
        //        return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CallCloseDate : string.Empty;
        //    }
        //    set
        //    {
        //        CCRMCallClosureDTO.CallCloseDate = value;
        //    }
        //}
        public Int32 MIFID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.MIFID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.MIFID = value;
            }
        }
        public string ContractType
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ContractType : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.ContractType = value;
            }
        }
        public string DispDate
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.DispDate : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.DispDate = value;
            }
        }
        public string CompletionDate
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.CompletionDate : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.CompletionDate = value;
            }
        }
        public string XmlString
        {
            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.XmlString : string.Empty;
            }
            set
            {
                CCRMCallClosureDTO.XmlString = value;
            }
        }
        public Int32 ReasonID
        {

            get
            {
                return (CCRMCallClosureDTO != null) ? CCRMCallClosureDTO.ReasonID : new Int32();
            }
            set
            {
                CCRMCallClosureDTO.ReasonID = value;
            }
        }
    }
}
