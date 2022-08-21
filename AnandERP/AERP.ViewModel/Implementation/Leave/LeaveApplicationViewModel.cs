using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;
namespace AERP.ViewModel
{
    public class LeaveApplicationViewModel : ILeaveApplicationViewModel
    {

        public LeaveApplicationViewModel()
        {
            LeaveApplicationDTO = new LeaveApplication();
            CompensatoryWorkDayList = new List<LeaveCompensatoryWorkDay>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
        }
        public List<LeaveCompensatoryWorkDay> CompensatoryWorkDayList { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre { get; set; }
        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster { get; set; }

        
        
        public LeaveApplication LeaveApplicationDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.ID > 0) ? LeaveApplicationDTO.ID : new int();
            }
            set
            {
                LeaveApplicationDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.EmployeeID > 0) ? LeaveApplicationDTO.EmployeeID : new int();
            }
            set
            {
                LeaveApplicationDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeName", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeNameRequired")]        
        public string EmployeeName
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.EmployeeName : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.EmployeeName = value;
            }
        }

        [Display(Name = "Application Code")]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ApplicationCodeRequired")]      
        public string ApplicationCode
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.ApplicationCode : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.ApplicationCode = value;
            }
        }

        public int LeaveMasterID
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.LeaveMasterID > 0) ? LeaveApplicationDTO.LeaveMasterID : new int();
            }
            set
            {
                LeaveApplicationDTO.LeaveMasterID = value;
            }
        }

        //[Required(ErrorMessage = "Submitted on date should not be blank.")]
        [Display(Name = "Submitted On Date")]
        public string SubmittedOnDate
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.SubmittedOnDate : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.SubmittedOnDate = value;
            }
        }

        //[Required(ErrorMessage = "From Date should not be blank.")]
        //[Display(Name = "From Date")]
        [Display(Name = "DisplayName_FromDate", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_FromDateRequired")]        
        public string FromDate
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.FromDate : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.FromDate = value;
            }
        }

        //[Required(ErrorMessage = "Upto date should not be blank.")]
        //[Display(Name = "Upto date")]
        [Display(Name = "DisplayName_UptoDate", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UptoDateRequired")]        
        public string UptoDate
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.UptoDate : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.UptoDate = value;
            }
        }

        public Int16 TotalfullDaysLeave
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.TotalfullDaysLeave > 0) ? LeaveApplicationDTO.TotalfullDaysLeave : new Int16();
            }
            set
            {
                LeaveApplicationDTO.TotalfullDaysLeave = value;
            }
        }
        public string CancelDays
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.CancelDays : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.CancelDays = value;
            }
        }
        public string LeaveTotalDay
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.LeaveTotalDay : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.LeaveTotalDay = value;
            }
        }
        public Int16 TotalHalfDayLeave
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.TotalHalfDayLeave > 0) ? LeaveApplicationDTO.TotalHalfDayLeave : new Int16();
            }
            set
            {
                LeaveApplicationDTO.TotalHalfDayLeave = value;
            }
        }

        [Display(Name = "DisplayName_HalfLeaveStatus", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_HalfLeaveStatusRequired")]        
        public string HalfLeaveStatus
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.HalfLeaveStatus : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.HalfLeaveStatus = value;
            }
        }


        [Display(Name = "DisplayName_EmployeeRemark", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeRemarkRequired")]      
        public string EmployeeRemark
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.EmployeeRemark : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.EmployeeRemark = value;
            }
        }

        [Display(Name = "DocumentRequire")]
        public bool DocumentRequire
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.DocumentRequire : false;
            }
            set
            {
                LeaveApplicationDTO.DocumentRequire = value;
            }
        }

        [Display(Name = "DisplayName_LeaveReason", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveReasonRequired")]       
        public string LeaveReason
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.LeaveReason : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.LeaveReason = value;
            }
        }

        [Display(Name = "DisplayName_LeavePriority", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeavePriorityRequired")]        
        public byte LeavePriority
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.LeavePriority : byte.MinValue;
            }
            set
            {
                LeaveApplicationDTO.LeavePriority = value;
            }
        }

        [Display(Name = "DisplayName_ApplicationStatus", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ApplicationStatusRequired")]
        public string ApplicationStatus
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.ApplicationStatus : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.ApplicationStatus = value;
            }
        }
        public string ApprovalStatus
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.ApprovalStatus : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.ApprovalStatus = value;
            }
        }
        public string FullDayHalfDayFlag
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.FullDayHalfDayFlag : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.FullDayHalfDayFlag = value;
            }
        }
        public string HalfLeaveStatusTr
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.HalfLeaveStatusTr : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.HalfLeaveStatusTr = value;
            }
        }

        [Display(Name = "DisplayName_PendingAtApprovalLevel", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PendingAtApprovalLevelRequired")]
        public byte PendingAtApprovalLevel
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.PendingAtApprovalLevel : byte.MinValue;
            }
            set
            {
                LeaveApplicationDTO.PendingAtApprovalLevel = value;
            }
        }



      // [Display(Name = "DisplayName_LeaveSessionID", ResourceType = typeof(AMS.Common.Resources))]
       public int LeaveSessionID
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.LeaveSessionID > 0) ? LeaveApplicationDTO.LeaveSessionID : new int();
           }
           set
           {
               LeaveApplicationDTO.LeaveSessionID = value;
           }
       }

       [Display(Name = "DisplayName_LeaveSessionName", ResourceType = typeof(AERP.Common.Resources))]
       //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveSessionRequired")]
       public string LeaveSession
       {
           get
           {
               return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.LeaveSession : string.Empty;
           }
           set
           {
               LeaveApplicationDTO.LeaveSession = value;
           }
       }

       [Display(Name = "DisplayName_CancelRemark", ResourceType = typeof(AERP.Common.Resources))]
       //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CancelRemarkRequired")]
       public string CancelRemark
       {
           get
           {
               return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.CancelRemark : string.Empty;
           }
           set
           {
               LeaveApplicationDTO.CancelRemark = value;
           }
       }

       //[Required(ErrorMessage = "Application Date should not be blank.")]
       [Display(Name = "Application Date should not be blank")]
       public string ApplicationDate
       {
           get
           {
               return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.ApplicationDate : string.Empty;
           }
           set
           {
               LeaveApplicationDTO.ApplicationDate = value;
           }
       }

       public Int16 SactionedFullDay
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.SactionedFullDay > 0) ? LeaveApplicationDTO.SactionedFullDay : new Int16();
           }
           set
           {
               LeaveApplicationDTO.SactionedFullDay = value;
           }
       }

       public Int16 SactionedHalfDay
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.SactionedHalfDay > 0) ? LeaveApplicationDTO.SactionedHalfDay : new Int16();
           }
           set
           {
               LeaveApplicationDTO.SactionedHalfDay = value;
           }
       }

      // [Display(Name = "DisplayName_SactionedHalfLeaveStatus", ResourceType = typeof(AMS.Common.Resources))]
       //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SactionedHalfLeaveStatusRequired")]
       public string SactionedHalfLeaveStatus
       {
           get
           {
               return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.SactionedHalfLeaveStatus : string.Empty;
           }
           set
           {
               LeaveApplicationDTO.SactionedHalfLeaveStatus = value;
           }
       }

     //  [Display(Name = "DisplayName_TransferToLWP", ResourceType = typeof(AMS.Common.Resources))]
       public decimal TransferToLWP
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.TransferToLWP > 0) ? LeaveApplicationDTO.TransferToLWP : new decimal();
           }
           set
           {
               LeaveApplicationDTO.TransferToLWP = value;
           }
       }

       [Display(Name = "DisplayName_ApprovedByUser", ResourceType = typeof(AERP.Common.Resources))]
       public int ApprovedByUser
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.ApprovedByUser > 0) ? LeaveApplicationDTO.ApprovedByUser : new int();
           }
           set
           {
               LeaveApplicationDTO.ApprovedByUser = value;
           }
       }

       [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AERP.Common.Resources))]
       //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
       public string CentreCode
       {
           get
           {
               return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.CentreCode : string.Empty;
           }
           set
           {
               LeaveApplicationDTO.CentreCode = value;
           }
       }

       [Display(Name = "DisplayName_LeaveRuleMasterID", ResourceType = typeof(AERP.Common.Resources))]
       public int LeaveRuleMasterID
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.LeaveRuleMasterID > 0) ? LeaveApplicationDTO.LeaveRuleMasterID : new int();
           }
           set
           {
               LeaveApplicationDTO.LeaveRuleMasterID = value;
           }
       }

       //[Display(Name = "DisplayName_PendingJobSrNo", ResourceType = typeof(AMS.Common.Resources))]
       public int PendingJobSrNo
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.PendingJobSrNo > 0) ? LeaveApplicationDTO.PendingJobSrNo : new int();
           }
           set
           {
               LeaveApplicationDTO.PendingJobSrNo = value;
           }
       }

      // [Display(Name = "DisplayName_PendingLevelSeqNumber", ResourceType = typeof(AMS.Common.Resources))]
       public int PendingLevelSeqNumber
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.PendingLevelSeqNumber > 0) ? LeaveApplicationDTO.PendingLevelSeqNumber : new int();
           }
           set
           {
               LeaveApplicationDTO.PendingLevelSeqNumber = value;
           }
       }

     //  [Display(Name = "DisplayName_SancWorkReportingMstID", ResourceType = typeof(AMS.Common.Resources))]
       public int SancWorkReportingMstID
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.SancWorkReportingMstID > 0) ? LeaveApplicationDTO.SancWorkReportingMstID : new int();
           }
           set
           {
               LeaveApplicationDTO.SancWorkReportingMstID = value;
           }
       }

     //  [Display(Name = "DisplayName_PendAtWorkReportingDetailID", ResourceType = typeof(AMS.Common.Resources))]
       public int PendAtWorkReportingDetailID
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.PendAtWorkReportingDetailID > 0) ? LeaveApplicationDTO.PendAtWorkReportingDetailID : new int();
           }
           set
           {
               LeaveApplicationDTO.PendAtWorkReportingDetailID = value;
           }
       }

     //  [Display(Name = "DisplayName_SactionFromDate", ResourceType = typeof(AMS.Common.Resources))]
       public string SactionFromDate
       {
           get
           {
               return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.SactionFromDate : string.Empty;
           }
           set
           {
               LeaveApplicationDTO.SactionFromDate = value;
           }
       }

     //  [Display(Name = "DisplayName_SactionUptoDate", ResourceType = typeof(AMS.Common.Resources))]
       public string SactionUptoDate
       {
           get
           {
               return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.SactionUptoDate : string.Empty;
           }
           set
           {
               LeaveApplicationDTO.SactionUptoDate = value;
           }
       }

     //  [Display(Name = "DisplayName_AdminRoleMasterID", ResourceType = typeof(AMS.Common.Resources))]
       public int AdminRoleMasterID
       {
           get
           {
               return (LeaveApplicationDTO != null && LeaveApplicationDTO.AdminRoleMasterID > 0) ? LeaveApplicationDTO.AdminRoleMasterID : new int();
           }
           set
           {
               LeaveApplicationDTO.AdminRoleMasterID = value;
           }
       }

        [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.IsActive : false;
            }
            set
            {
                LeaveApplicationDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.IsDeleted : false;
            }
            set
            {
                LeaveApplicationDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.CreatedBy > 0) ? LeaveApplicationDTO.CreatedBy : new int();
            }
            set
            {
                LeaveApplicationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveApplicationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.ModifiedBy.HasValue) ? LeaveApplicationDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveApplicationDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.ModifiedDate.HasValue) ? LeaveApplicationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveApplicationDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.DeletedBy.HasValue) ? LeaveApplicationDTO.DeletedBy : new int();
            }
            set
            {
                LeaveApplicationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.DeletedDate.HasValue) ? LeaveApplicationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveApplicationDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
        //[Display(Name = "IsSecondHalf")]
        [Display(Name = "DisplayName_IsSecondHalf", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsSecondHalf
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.IsSecondHalf : false;
            }
            set
            {
                LeaveApplicationDTO.IsSecondHalf = value;
            }
        }
      //  [Display(Name = "IsFirstHalf")]
        [Display(Name = "DisplayName_IsFirstHalf", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsFirstHalf
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.IsFirstHalf : false;
            }
            set
            {
                LeaveApplicationDTO.IsFirstHalf = value;
            }
        }
       
        public string LeaveCode
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.LeaveCode : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.LeaveCode = value;
            }
        }

        public string LeaveDescription
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.LeaveDescription : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.LeaveDescription = value;
            }
        }
        public string ApprovalStatusList
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.ApprovalStatusList : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.ApprovalStatusList = value;
            }
        }


        public string NumberOfLeaves
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.NumberOfLeaves : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.NumberOfLeaves = value;
            }
        }

        [Display(Name = "BalanceLeave")]
        public double BalanceLeave
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.BalanceLeave > 0) ? LeaveApplicationDTO.BalanceLeave : new double();
            }
            set
            {
                LeaveApplicationDTO.BalanceLeave = value;
            }
        }

        public string TotalFullDayUtilized
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.TotalFullDayUtilized : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.TotalFullDayUtilized = value;
            }
        }

        public string TotalHalfDayUtilized
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.TotalHalfDayUtilized : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.TotalHalfDayUtilized = value;
            }
        }
       // [Display(Name="Leave Details")]
        [Display(Name = "DisplayName_LeaveDetails", ResourceType = typeof(AERP.Common.Resources))]
        public string LeaveApplicationApprocedPendingStatusDetails
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.LeaveApplicationApprocedPendingStatusDetails : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.LeaveApplicationApprocedPendingStatusDetails = value;
            }
        }

        public int NumberOfApprovalStages
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.NumberOfApprovalStages > 0) ? LeaveApplicationDTO.NumberOfApprovalStages : new int();
            }
            set
            {
                LeaveApplicationDTO.NumberOfApprovalStages = value;
            }
        }
        public int TotalRecords
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.TotalRecords > 0) ? LeaveApplicationDTO.TotalRecords : new int();
            }
            set
            {
                LeaveApplicationDTO.TotalRecords = value;
            }
        }
        public int RowNumber
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.RowNumber > 0) ? LeaveApplicationDTO.RowNumber : new int();
            }
            set
            {
                LeaveApplicationDTO.RowNumber = value;
            }
        }
     
        public Int16 DaysBeforeApplicationSubmitted
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.DaysBeforeApplicationSubmitted > 0) ? LeaveApplicationDTO.DaysBeforeApplicationSubmitted : new Int16();
            }
            set
            {
                LeaveApplicationDTO.DaysBeforeApplicationSubmitted = value;
            }
        }
        [Display(Name = "IsCompensatory")]
        public double IsCompensatory
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.IsCompensatory > 0) ? LeaveApplicationDTO.IsCompensatory : new double();
            }
            set
            {
                LeaveApplicationDTO.IsCompensatory = value;
            }
        }
       
        public string SelectedIDs
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.SelectedIDs : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.SelectedIDs = value;
            }
        }


        /// <summary>
        /// fields for leave attached document//////////////////
        /// </summary>        

         [Display(Name = "DisplayName_AttachDocument", ResourceType = typeof(AERP.Common.Resources))]
        public int LeaveAttachedDocumentID                          ////////////LeaveAttchedDocumentID is ID for LeaveAttachedDocument 
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.LeaveAttachedDocumentID > 0) ? LeaveApplicationDTO.LeaveAttachedDocumentID : new int();
            }
            set
            {
                LeaveApplicationDTO.LeaveAttachedDocumentID = value;
            }
        }
        public int DocumentRequiredID
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.DocumentRequiredID > 0) ? LeaveApplicationDTO.DocumentRequiredID : new int();
            }
            set
            {
                LeaveApplicationDTO.DocumentRequiredID = value;
            }
        }
        public string DateOfSubmission
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.DateOfSubmission : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.DateOfSubmission = value;
            }
        }
        public string FileName
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.FileName : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.FileName = value;
            }
        }
        
        public bool DocumentCompulsaryFlag
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.DocumentCompulsaryFlag : false;
            }
            set
            {
                LeaveApplicationDTO.DocumentCompulsaryFlag = value;
            }
        }

        public bool DocumentRequiredFlag
        {
            get
            {
                return (LeaveApplicationDTO != null) ? LeaveApplicationDTO.DocumentRequiredFlag : false;
            }
            set
            {
                LeaveApplicationDTO.DocumentRequiredFlag = value;
            }
        }
        public HttpPostedFileBase MyFile { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~


        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
               
        public IEnumerable<SelectListItem> ListOrganisationDepartmentMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationDepartmentMaster, "ID", "DepartmentName");
            }
        }

        

        [Display(Name = "Department Name")]
        public string DepartmentID
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.DepartmentID != "") ? LeaveApplicationDTO.DepartmentID : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.DepartmentID = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.DepartmentName != "") ? LeaveApplicationDTO.DepartmentName : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.DepartmentName = value;
            }
        }

        public string EntityLevel
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.EntityLevel != "") ? LeaveApplicationDTO.EntityLevel : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.EntityLevel = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.CentreName != "") ? LeaveApplicationDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.CentreName = value;
            }
        }

        public string LeaveList
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.LeaveList != "") ? LeaveApplicationDTO.LeaveList : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.LeaveList = value;
            }
        }
        public string EmployeeFirstName
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.EmployeeFirstName != "") ? LeaveApplicationDTO.EmployeeFirstName : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.EmployeeFirstName = value;
            }
        }
        public string EmployeeMiddleName
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.EmployeeMiddleName != "") ? LeaveApplicationDTO.EmployeeMiddleName : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.EmployeeMiddleName = value;
            }
        }

        public string EmployeeLastName
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.EmployeeLastName != "") ? LeaveApplicationDTO.EmployeeLastName : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.EmployeeLastName = value;
            }
        }

        public string LeaveSessionName
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.LeaveSessionName != "") ? LeaveApplicationDTO.LeaveSessionName : string.Empty;
            }
            set
            {
                LeaveApplicationDTO.LeaveSessionName = value;
            }
        }

        public int DOJAndCurrentSessionDifferenceInMonth
        {
            get
            {
                return (LeaveApplicationDTO != null && LeaveApplicationDTO.DOJAndCurrentSessionDifferenceInMonth > 0) ? LeaveApplicationDTO.DOJAndCurrentSessionDifferenceInMonth : new int();
            }
            set
            {
                LeaveApplicationDTO.DOJAndCurrentSessionDifferenceInMonth = value;
            }
        }

    }
}
