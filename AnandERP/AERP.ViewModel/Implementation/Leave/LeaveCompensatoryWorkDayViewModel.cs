using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveCompensatoryWorkDayViewModel : ILeaveCompensatoryWorkDayViewModel
    {
        public LeaveCompensatoryWorkDayViewModel()
        {
            LeaveCompensatoryWorkDayDTO = new LeaveCompensatoryWorkDay();
            CompensatoryOffDayApplicationDetailsList = new List<LeaveCompensatoryWorkDay>();
        }
        public LeaveCompensatoryWorkDay LeaveCompensatoryWorkDayDTO
        {
            get;
            set;
        }
       
        public int ID
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null && LeaveCompensatoryWorkDayDTO.ID > 0) ? LeaveCompensatoryWorkDayDTO.ID : new int();
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null && LeaveCompensatoryWorkDayDTO.EmployeeID > 0) ? LeaveCompensatoryWorkDayDTO.EmployeeID : new int();
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.EmployeeID = value;
            }
        }

        public int LeaveSessionID
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null && LeaveCompensatoryWorkDayDTO.LeaveSessionID > 0) ? LeaveCompensatoryWorkDayDTO.LeaveSessionID : new int();
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.LeaveSessionID = value;
            }
        }

        [Display(Name = "DisplayName_WorkingDate", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_WorkingDateRequired")]
        public string WorkingDate
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.WorkingDate : string.Empty;
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.WorkingDate = value;
            }
        }      

        [Display(Name = "DisplayName_CheckInTime", ResourceType = typeof(AERP.Common.Resources))]
         [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CheckInTimeRequired")]      
        public TimeSpan CheckInTime
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.CheckInTime : TimeSpan.Zero;
                //return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.CheckInTime : new TimeSpan();
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.CheckInTime = value;
            }
        }

        [Display(Name = "DisplayName_CheckOutTime", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CheckOutTimeRequired")]
        public TimeSpan CheckOutTime
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.CheckOutTime : TimeSpan.Zero;
                //return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.CheckOutTime : new TimeSpan();
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.CheckOutTime = value;
            }
        }
        

        //[Display(Name = "DisplayName_ApplicationStatus", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ApplicationStatusRequired")]
        public string ApplicationStatus
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.ApplicationStatus : string.Empty;
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.ApplicationStatus = value;
            }
        }
        public bool IsHalfDayUtilized
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.IsHalfDayUtilized : false;
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.IsHalfDayUtilized = value;
            }
        }

        [Display(Name = "DisplayName_Reason", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_WorkingReasonRequired")]
        public string WorkingReason
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.WorkingReason : string.Empty;
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.WorkingReason = value;
            }
        }

        // [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.CentreCode = value;
            }
        }

       // [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public bool IsAvailed
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.IsAvailed : false;
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.IsAvailed = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.IsDeleted : false;
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null && LeaveCompensatoryWorkDayDTO.CreatedBy > 0) ? LeaveCompensatoryWorkDayDTO.CreatedBy : new int();
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null) ? LeaveCompensatoryWorkDayDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null && LeaveCompensatoryWorkDayDTO.ModifiedBy.HasValue) ? LeaveCompensatoryWorkDayDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null && LeaveCompensatoryWorkDayDTO.ModifiedDate.HasValue) ? LeaveCompensatoryWorkDayDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null && LeaveCompensatoryWorkDayDTO.DeletedBy.HasValue) ? LeaveCompensatoryWorkDayDTO.DeletedBy : new int();
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeaveCompensatoryWorkDayDTO != null && LeaveCompensatoryWorkDayDTO.DeletedDate.HasValue) ? LeaveCompensatoryWorkDayDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveCompensatoryWorkDayDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }



        #region -------------- TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get;
            set;
        }
        public string TaskCode
        {
            get;
            set;
        }
        public int TaskNotificationDetailsID
        {
            get;
            set;
        }
        public int GeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        public int PersonID
        {
            get;
            set;
        }
        public int StageSequenceNumber
        {
            get;
            set;
        }
        public bool IsLastRecord
        {
            get;
            set;
        }
        #endregion

        public List<LeaveCompensatoryWorkDay> CompensatoryOffDayApplicationDetailsList { get; set; }

        public bool ApprovalStatus
        {
            get;
            set;
        }
    }
}
