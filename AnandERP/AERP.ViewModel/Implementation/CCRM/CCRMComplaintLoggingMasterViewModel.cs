using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
   public class CCRMComplaintLoggingMasterViewModel :ICCRMComplaintLoggingMasterViewModel
    {
        public CCRMComplaintLoggingMasterViewModel()
        {
            CCRMComplaintLoggingMasterDTO = new CCRMComplaintLoggingMaster();
            PriviousCallByCCRMComplaintLoggingMasterID = new List<CCRMComplaintLoggingMaster>();
        }
        public List<CCRMComplaintLoggingMaster> PriviousCallByCCRMComplaintLoggingMasterID { get; set; }
        public CCRMComplaintLoggingMaster CCRMComplaintLoggingMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.ID > 0) ? CCRMComplaintLoggingMasterDTO.ID : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ID = value;
            }
        }
        [Display(Name = "Call Date")]
       
        public string CallDate
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallDate : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CallDate = value;
            }
        }
        //[Display(Name = "CallTime")]
        ////[Required(ErrorMessage = "Action Title Required")]
        //public string CallTime
        //{
        //    get
        //    {
        //        return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallTime : string.Empty;
        //    }
        //    set
        //    {
        //        CCRMComplaintLoggingMasterDTO.CallTime = value;
        //    }
        //}
        [Display(Name = "Call Tkt No")]
        [Required(ErrorMessage = "Call Tkt No Required")]
        public string CallTktNo
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallTktNo : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CallTktNo = value;
            }
        }
        [Display(Name = "Serial No")]
        [Required(ErrorMessage = "Serial No Required")]
        public string SerialNo
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.SerialNo = value;
            }
        }
        [Display(Name = "Call Type Name")]
        public string CallTypeName
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallTypeName : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CallTypeName = value;
            }
        }
        [Display(Name = "MIF Name")]
        public string MIFName
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.MIFName : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.MIFName = value;
            }
        }
        public string Solution
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.Solution : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.Solution = value;
            }
        }
        [Display(Name = "Company Call Date")]
        public string CompanyCallDate
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CompanyCallDate : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CompanyCallDate = value;
            }
        }
        [Display(Name = "Company Call Time")]
        public string CompanyCallTime
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CompanyCallTime : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CompanyCallTime = value;
            }
        }
        [Display(Name = "Company Call No.")]
        public string CompanyCallNo
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CompanyCallNo : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CompanyCallNo = value;
            }
        }
        [Display(Name = "Customer Name")]
        public string CustomerName
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CustomerName : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CustomerName = value;
            }
        }
        public Int32 CustomertID
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CustomertID : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CustomertID = value;
            }
        }
        [Display(Name = "Area Patch Engg")]
        public Int32 EngineerID
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.EngineerID : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.EngineerID = value;
            }
        }
        public Int32 SymptomID
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.SymptomID : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.SymptomID = value;
            }
        }
        public Int32 CallTypeID
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallTypeID : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CallTypeID = value;
            }
        }
        [Display(Name = "Phone no")]
        public string Phoneno
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.Phoneno : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.Phoneno = value;
            }
        }
        [Display(Name = "Call Status")]
        public byte CallStatus
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallStatus : new byte();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CallStatus = value;
            }
        }
        [Display(Name = "Email ")]
        public string EmailID
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.EmailID : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.EmailID = value;
            }
        }
        [Display(Name = "Symptom Code ")]
        public string SymptomCode
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.SymptomCode : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.SymptomCode = value;
            }
        }
        [Display(Name = "Symptom Title ")]
        public string SymptomTitle
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.SymptomTitle : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.SymptomTitle = value;
            }
        }
        [Display(Name = "Caller Name ")]
        public string CallerName
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallerName : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CallerName = value;
            }
        }
        [Display(Name = "Caller Phone ")]
        public string CallerPh
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallerPh : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CallerPh = value;
            }
        }
        public string ComPlaint
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ComPlaint : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ComPlaint = value;
            }
        }
        public string ItemDescription
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ItemDescription = value;
            }
        }
        [Display(Name = "MC Status")]
        public byte MachineStatus
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.MachineStatus : new byte();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.MachineStatus = value;
            }
        }
        public byte Priority
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.Priority : new byte();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.Priority = value;
            }
        }
        public Int32 KeyOperatorID
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.KeyOperatorID : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.KeyOperatorID = value;
            }
        }
        public Int32 A4Mono
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.A4Mono : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.A4Mono = value;
            }
        }
        public Int32 A4Col
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.A4Col : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.A4Col = value;
            }
        }
        public Int32 A3Mono
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.A3Mono : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.A3Mono = value;
            }
        }
        public Int32 A3Col
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.A3Col : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.A3Col = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.CreatedBy > 0) ? CCRMComplaintLoggingMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CreatedBy = value;
            }
        }
        public decimal CallCharges
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallCharges : new decimal();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CallCharges = value;
            }
        }
        [Display(Name = "Tele Sol")]
        public bool TeleSolution
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.TeleSolution : new bool();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.TeleSolution = value;
            }
        }
        public string Remarks
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.Remarks :string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.Remarks = value;
            }
        }
        [Display(Name = "Spl Instructions")]
        public string SplInstructions
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.SplInstructions : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.SplInstructions = value;
            }
        }
        [Display(Name = "SSS Approval")]
        public bool SSSApproval
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.SSSApproval :new bool();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.SSSApproval = value;
            }
        }
        [Display(Name = "Customer Approval")]
        public bool CustApproval
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CustApproval : new bool();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CustApproval = value;
            }
        }
        [Display(Name = "M/C Address")]
        public string MCAddress
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.MCAddress : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.MCAddress = value;
            }
        }

        public string KeyOperator
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.KeyOperator : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.KeyOperator = value;
            }
        }
        [Display(Name = "Contract No")]
        public string ContractNo
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ContractNo : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ContractNo = value;
            }
        }
        [Display(Name = "Contract Person")]
        public string ContactPerson
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ContactPerson : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ContactPerson = value;
            }
        }
        public Int32 ContactPersonID
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ContactPersonID : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ContactPersonID = value;
            }
        }
        //public Int32 ContractTypeID
        //{

        //    get
        //    {
        //        return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ContractTypeID : new Int32();
        //    }
        //    set
        //    {
        //        CCRMComplaintLoggingMasterDTO.ContractTypeID = value;
        //    }
        //}
        [Display(Name = "Model No")]
        public string ModelNo
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ModelNo : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ModelNo = value;
            }
        }
        [Display(Name = "Contract Type")]
        public string ContractType
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ContractType : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ContractType = value;
            }
        }
        public Int32 ContractTypeId
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ContractTypeId : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ContractTypeId = value;
            }
        }
        [Display(Name = "Contract Op Date")]
        public string ContOpDate
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ContOpDate : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ContOpDate = value;
            }
        }
        [Display(Name = "Contract Cl Date")]
        public string ContClDate
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ContClDate : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ContClDate = value;
            }
        }
        [Display(Name = "Ser Engg Name")]
        public string SerEnggName
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.SerEnggName : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.SerEnggName = value;
            }
        }
        [Display(Name = " Engg Mob No")]
        public string EnggMobNo
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.EnggMobNo : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.EnggMobNo = value;
            }
        }
        [Display(Name = " Spl Remarks")]
        public string SplRemarks
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.SplRemarks : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.SplRemarks = value;
            }
        }
        [Display(Name = " Call Type")]
        public string CallType
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallType : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CallType = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.ModifiedBy.HasValue) ? CCRMComplaintLoggingMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.ModifiedDate.HasValue) ? CCRMComplaintLoggingMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.DeletedBy.HasValue) ? CCRMComplaintLoggingMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.DeletedDate.HasValue) ? CCRMComplaintLoggingMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.DeletedDate = value;
            }
        }
        public string CCRMComplaintLoggingMasterModel
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CCRMComplaintLoggingMasterModel : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CCRMComplaintLoggingMasterModel = value;
            }
        }
        public string VersionNumber
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.VersionNumber = value;
            }
        }
        public Int32 UserID
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.UserID > 0) ? CCRMComplaintLoggingMasterDTO.UserID : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.UserID = value;
            }
        }
        public Int32 MIFID
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.MIFID > 0) ? CCRMComplaintLoggingMasterDTO.MIFID : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.MIFID = value;
            }
        }
        public Int32 ComplaintSrNo
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.ComplaintSrNo > 0) ? CCRMComplaintLoggingMasterDTO.ComplaintSrNo : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ComplaintSrNo = value;
            }
        }
        public bool Allotment
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.Allotment : new bool();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.Allotment = value;
            }
        }
        public bool CallerFlag
        {

            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.CallerFlag : new bool();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.CallerFlag = value;
            }
        }

        public DateTime? LastSyncDate
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.LastSyncDate.HasValue) ? CCRMComplaintLoggingMasterDTO.LastSyncDate : null;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.SyncType : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.Entity : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.Entity = value;
            }
        }

        public byte TrackType
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.TrackType > 0) ? CCRMComplaintLoggingMasterDTO.TrackType : new byte();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.TrackType = value;
            }
        }

        public string DeviceToken
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.DeviceToken : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.DeviceToken = value;
            }
        }

        public decimal Latitude
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.Latitude : new Decimal();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.Latitude = value;
            }
        }

        public decimal Longitude
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.Longitude : new Decimal();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.Longitude = value;
            }
        }

        public Int32 ComplaintCountID
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.ComplaintCountID > 0) ? CCRMComplaintLoggingMasterDTO.ComplaintCountID : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ComplaintCountID = value;
            }
        }

        public Int32 ComplaintCount
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null && CCRMComplaintLoggingMasterDTO.ComplaintCount > 0) ? CCRMComplaintLoggingMasterDTO.ComplaintCount : new Int32();
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ComplaintCount = value;
            }
        }

        public string ComplaintNumberString
        {
            get
            {
                return (CCRMComplaintLoggingMasterDTO != null) ? CCRMComplaintLoggingMasterDTO.ComplaintNumberString : string.Empty;
            }
            set
            {
                CCRMComplaintLoggingMasterDTO.ComplaintNumberString = value;
            }
        }
    }
}
