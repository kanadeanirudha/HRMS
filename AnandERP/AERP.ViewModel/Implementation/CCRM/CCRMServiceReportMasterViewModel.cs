using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public class CCRMServiceReportMasterViewModel : ICCRMServiceReportMasterViewModel
    {
        public CCRMServiceReportMasterViewModel()
        {
            CCRMServiceReportMasterDTO = new CCRMServiceReportMaster();
            ItemsDetailsCCRMServiceReportMasterID = new List<CCRMServiceReportMaster>();
            ListOfItemsDetails = new List<CCRMServiceReportMaster>();

        }
        public List<CCRMServiceReportMaster> ItemsDetailsCCRMServiceReportMasterID { get; set; }
        public List<CCRMServiceReportMaster> ListOfItemsDetails { get; set; }

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
        [Display(Name = "Serial No")]
        //[Required(ErrorMessage = "Action Desciption Required")]
        public string SerialNo
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.SerialNo = value;
            }
        }
        [Display(Name = "Model No")]
        public string ModelNo
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ModelNo : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ModelNo = value;
            }
        }
        [Display(Name = "MIF Name")]
        public string MIFName
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.MIFName : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.MIFName = value;
            }
        }
        public byte Priority
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.Priority > 0) ? CCRMServiceReportMasterDTO.Priority : new byte();
            }
            set
            {
                CCRMServiceReportMasterDTO.Priority = value;
            }
        }
        public Int32 LocationID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.LocationID > 0) ? CCRMServiceReportMasterDTO.LocationID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.LocationID = value;
            }
        }
        [Display(Name = "Location Type Code")]
        public string LocationTypeCode
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.LocationTypeCode : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.LocationTypeCode = value;
            }
        }
        public Int16 MachineFamilyID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.MachineFamilyID > 0) ? CCRMServiceReportMasterDTO.MachineFamilyID : new Int16();
            }
            set
            {
                CCRMServiceReportMasterDTO.MachineFamilyID = value;
            }
        }
        [Display(Name = "Machine Family Name")]
        public string MachineFamilyName
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.MachineFamilyName : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.MachineFamilyName = value;
            }
        }
        [Display(Name = "Contract Code")]
        public string ContractCode
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ContractCode : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ContractCode = value;
            }
        }
        public Int32 ContractTypeID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ContractTypeID > 0) ? CCRMServiceReportMasterDTO.ContractTypeID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.ContractTypeID = value;
            }
        }
        public Int32 ComplaintSrNo
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ComplaintSrNo > 0) ? CCRMServiceReportMasterDTO.ComplaintSrNo : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.ComplaintSrNo = value;
            }
        }
        [Display(Name = "Call Date")]
        public string CallDate
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CallDate : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.CallDate = value;
            }
        }
        public Int32 CallTypeID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.CallTypeID > 0) ? CCRMServiceReportMasterDTO.CallTypeID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.CallTypeID = value;
            }
        }
        [Display(Name = "ComPlaint")]
        public string ComPlaint
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ComPlaint : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ComPlaint = value;
            }
        }
        [Display(Name = "Allot Date")]
        public string AllotDate
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.AllotDate : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.AllotDate = value;
            }
        }
        [Display(Name = "Allot Period")]
        public decimal AllotPeriod
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.AllotPeriod > 0) ? CCRMServiceReportMasterDTO.AllotPeriod : new decimal();
            }
            set
            {
                CCRMServiceReportMasterDTO.AllotPeriod = value;
            }
        }
        [Display(Name = "call Close Date")]
        public string CallCloseDate
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CallCloseDate : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.CallCloseDate = value;
            }
        }
        [Display(Name = "SR Date")]
        public string SRDate
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.SRDate : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.SRDate = value;
            }
        }
        [Display(Name = "Arrival Date")]
        public string ArrivalDate
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ArrivalDate : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ArrivalDate = value;
            }
        }
        [Display(Name = "Response Time")]
        public decimal ResponseTime
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ResponseTime > 0) ? CCRMServiceReportMasterDTO.ResponseTime : new decimal();
            }
            set
            {
                CCRMServiceReportMasterDTO.ResponseTime = value;
            }
        }
        [Display(Name = "Submite On")]
        public string SubmittedOn
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.SubmittedOn : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.SubmittedOn = value;
            }
        }
        [Display(Name = "Down Time")]
        public decimal DownTime
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.DownTime > 0) ? CCRMServiceReportMasterDTO.DownTime : new decimal();
            }
            set
            {
                CCRMServiceReportMasterDTO.DownTime = value;
            }
        }
        [Display(Name = "Total Down Time")]
        public decimal TotalDownTime
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.TotalDownTime > 0) ? CCRMServiceReportMasterDTO.TotalDownTime : new decimal();
            }
            set
            {
                CCRMServiceReportMasterDTO.TotalDownTime = value;
            }
        }
        //null&=20&=15&=0&=0&CallTktNo=18082801&=QUOTATION DROP&=QD&=10&SymptomCode=02&SymptomTitle=Paper / Document Feed&SymptomDescrip=OTHER&=8&CauseCode=B01&CauseTitle=CRUM&CauseDescrip=SCANNERMOTOR/SCANNER DRIVES&=29&ActionCode=986&ActionTitle=apple&ActionDescrip=mango&SCNSubmitted=1&CallStatus=1&CreatedBy=21&VersionNumber=1.0.0&ListOfItemsDetails=[]
        //[Display(Name = "Mtr Read A4 Mono")]
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
        // [Display(Name = "Mtr Read A4Col")]
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
        //[Display(Name = "Mtr Read A3Col")]
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
        //[Display(Name = "Mtr Read A3 Mono")]
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
        [Display(Name = "Symptom Code")]
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
        [Display(Name = "Cause Code")]
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
        [Display(Name = "Action Code")]
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
        [Display(Name = "Symptom Title")]
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
        public Int32 EngineerID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.EngineerID > 0) ? CCRMServiceReportMasterDTO.EngineerID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.EngineerID = value;
            }
        }
        public string Remarks
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.Remarks : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.Remarks = value;
            }
        }
        public byte CallStatus
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null &&CCRMServiceReportMasterDTO.CallStatus > 0) ? CCRMServiceReportMasterDTO.CallStatus : new byte();
            }
            set
            {
                CCRMServiceReportMasterDTO.CallStatus = value;
            }
        }
        public string Status
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.Status : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.Status = value;
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
        [Display(Name = "Call No")]

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
        [Display(Name = "Engg Name")]

        public string EnggName
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.EnggName : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.EnggName = value;
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
        [Display(Name = "IsDeleted")]
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
        [Display(Name = "ModifiedBy")]
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
        [Display(Name = "ModifiedDate")]
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
        [Display(Name = "DeletedBy")]
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
        [Display(Name = "DeletedDate")]
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
        public string ItemDescription
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ItemDescription = value;
            }
        }
        [Display(Name = "Call Type")]
        public string CallTypeName
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CallTypeName : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.CallTypeName = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.EmployeeName : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.EmployeeName = value;
            }
        }
        public string CallerName
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CallerName : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.CallerName = value;
            }
        }
        public Int32 A4Mono
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.A4Mono > 0) ? CCRMServiceReportMasterDTO.A4Mono : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.A4Mono = value;
            }
        }
        // [Display(Name = "Mtr Read A4Col")]
        public Int32 A4Col
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.A4Col > 0) ? CCRMServiceReportMasterDTO.A4Col : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.A4Col = value;
            }
        }
        //[Display(Name = "Mtr Read A3Col")]
        public Int32 A3Mono
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.A3Mono > 0) ? CCRMServiceReportMasterDTO.A3Mono : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.A3Mono = value;
            }
        }
        //[Display(Name = "Mtr Read A3 Mono")]
        public Int32 A3Col
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.A4Col > 0) ? CCRMServiceReportMasterDTO.A3Col : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.A3Col = value;
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
        [Display(Name = "Symptom")]
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
        [Display(Name = "Cause")]
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
        [Display(Name = "Action")]
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
        public string Feedback
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.Feedback : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.Feedback = value;
            }
        }
        [Display(Name = "Signed By")]
        public string SignedBy
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.SignedBy : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.SignedBy = value;
            }
        }
        [Display(Name = "Phone No")]
        public string PhoneNo
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.PhoneNo : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.PhoneNo = value;
            }
        }
        public Int32 ItemID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ItemID > 0) ? CCRMServiceReportMasterDTO.ItemID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.ItemID = value;
            }
        }
        public string ItemName
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ItemName : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ItemName = value;
            }
        }
        [Display(Name = "Item Code")]
        public string ItemCategoryCode
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ItemCategoryCode : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ItemCategoryCode = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.Rate > 0) ? CCRMServiceReportMasterDTO.Rate : new decimal();
            }
            set
            {
                CCRMServiceReportMasterDTO.Rate = value;
            }
        }
        public Int32 Quantity
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.Quantity > 0) ? CCRMServiceReportMasterDTO.Quantity : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.Quantity = value;
            }
        }
        public byte Requierd
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.Requierd > 0) ? CCRMServiceReportMasterDTO.Requierd : new byte();
            }
            set
            {
                CCRMServiceReportMasterDTO.Requierd = value;
            }
        }
        public Int32 ItemNumber
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ItemNumber > 0) ? CCRMServiceReportMasterDTO.ItemNumber : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.ItemNumber = value;
            }
        }

        [Display(Name = "Completion Period")]
        public decimal CompletionPeriod
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.CompletionPeriod > 0) ? CCRMServiceReportMasterDTO.CompletionPeriod : new decimal();
            }
            set
            {
                CCRMServiceReportMasterDTO.CompletionPeriod = value;
            }
        }
        [Display(Name = "Arrival Period")]
        public decimal ArrivalPeriod
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.ArrivalPeriod > 0) ? CCRMServiceReportMasterDTO.ArrivalPeriod : new decimal();
            }
            set
            {
                CCRMServiceReportMasterDTO.ArrivalPeriod = value;
            }
        }
        public Int32 SignedID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.SignedID > 0) ? CCRMServiceReportMasterDTO.SignedID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.SignedID = value;
            }
        }
        [Display(Name = "Job start Date")]
        public string JobstartDate
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.JobstartDate : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.JobstartDate = value;
            }
        }
        [Display(Name = "Job End Date")]
        public string JobEndDate
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.JobEndDate : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.JobEndDate = value;
            }
        }
        [Display(Name = "Job Period")]
        public decimal JobPeriod
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.JobPeriod > 0) ? CCRMServiceReportMasterDTO.JobPeriod : new decimal();
            }
            set
            {
                CCRMServiceReportMasterDTO.JobPeriod = value;
            }
        }
        [Display(Name = "SCN Submitted")]
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
        public Int32 FeedbackID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.FeedbackID > 0) ? CCRMServiceReportMasterDTO.FeedbackID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.FeedbackID = value;
            }
        }
        public string Symptom
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.Symptom : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.Symptom = value;
            }
        }
        public Int32 SrNo
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.SrNo > 0) ? CCRMServiceReportMasterDTO.SrNo : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.SrNo = value;
            }
        }
        public string SCRNo
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.SCRNo : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.SCRNo = value;
            }
        }
        public string ServEnggName
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ServEnggName : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ServEnggName = value;
            }
        }
        public Int32 CallId
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.CallId > 0) ? CCRMServiceReportMasterDTO.CallId : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.CallId = value;
            }
        }
        //public string CallCloseDate
        //{
        //    get
        //    {
        //        return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CallCloseDate : string.Empty;
        //    }
        //    set
        //    {
        //        CCRMServiceReportMasterDTO.CallCloseDate = value;
        //    }
        //}
        public Int32 MIFID
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null && CCRMServiceReportMasterDTO.MIFID > 0) ? CCRMServiceReportMasterDTO.MIFID : new Int32();
            }
            set
            {
                CCRMServiceReportMasterDTO.MIFID = value;
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
        public string ContractType
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.ContractType : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.ContractType = value;
            }
        }
        public string DispDate
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.DispDate : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.DispDate = value;
            }
        }
        public string CompletionDate
        {
            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.CompletionDate : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.CompletionDate = value;
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

        public string FileName
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.FileName : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.FileName = value;
            }
        }
        [Display(Name = "Submitte On")]
        public string TimeStamp
        {

            get
            {
                return (CCRMServiceReportMasterDTO != null) ? CCRMServiceReportMasterDTO.TimeStamp : string.Empty;
            }
            set
            {
                CCRMServiceReportMasterDTO.TimeStamp = value;
            }
        }
    }
}
