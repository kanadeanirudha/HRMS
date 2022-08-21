using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveManualAttendanceViewModel : ILeaveManualAttendanceViewModel
    {
        public LeaveManualAttendanceViewModel()
        {
            LeaveManualAttendanceDTO = new LeaveManualAttendance();

        }


        public LeaveManualAttendance LeaveManualAttendanceDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (LeaveManualAttendanceDTO != null && LeaveManualAttendanceDTO.ID > 0) ? LeaveManualAttendanceDTO.ID : new int();
            }
            set
            {
                LeaveManualAttendanceDTO.ID = value;
            }
        }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Please select Employee Name.")]
        public int EmployeeID
        {
            get
            {
                return (LeaveManualAttendanceDTO != null && LeaveManualAttendanceDTO.EmployeeID > 0) ? LeaveManualAttendanceDTO.EmployeeID : new int();
            }
            set
            {
                LeaveManualAttendanceDTO.EmployeeID = value;
            }
        }
          [Display(Name = "DisplayName_AttendanceDate", ResourceType = typeof(AERP.Common.Resources))]
          [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AttendanceDateRequired")]
        //[Display(Name = "Attendance Date")]
        //[Required(ErrorMessage = "Please select Attendance Date.")]
        public string AttendanceDate
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.AttendanceDate : string.Empty;
            }
            set
            {
                LeaveManualAttendanceDTO.AttendanceDate = value;
            }
        }

        public string VersionNumber
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.VersionNumber : string.Empty;
            }
            set
            {
                LeaveManualAttendanceDTO.VersionNumber = value;
            }
        }

        // [Display(Name = "Attendance For")]
        [Display(Name = "DisplayName_AttendanceFor", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessage = "Please select Attendance Date.")]
        public string AttendenceFor
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.AttendenceFor : string.Empty;
            }
            set
            {
                LeaveManualAttendanceDTO.AttendenceFor = value;
            }
        }
        
        //[Display(Name = "CheckIn Time")]
        [Display(Name = "DisplayName_CheckInTime", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessage = "CheckIn Time should not be blank.")]
        public TimeSpan CheckInTime
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.CheckInTime : TimeSpan.Zero;
            }
            set
            {
                LeaveManualAttendanceDTO.CheckInTime = value;
            }
        }
        //[Display(Name = "CheckOut Time")]
        [Display(Name = "DisplayName_CheckOutTime", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessage = "CheckOut Time should not be blank.")]
        public TimeSpan CheckOutTime
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.CheckOutTime : TimeSpan.Zero;
            }
            set
            {
                LeaveManualAttendanceDTO.CheckOutTime = value;
            }
        }
       // [Display(Name = "Reason")]
        [Display(Name = "DisplayName_Reason", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessage = "Please enter reason.")]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ReasonRequired")]
        public string Reason
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.Reason : string.Empty;
            }
            set
            {
                LeaveManualAttendanceDTO.Reason = value;
            }
        }

        public string Status
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.Status : string.Empty;
            }
            set
            {
                LeaveManualAttendanceDTO.Status = value;
            }
        }


        public bool IsWorkFlow
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.IsWorkFlow : false;
            }
            set
            {
                LeaveManualAttendanceDTO.IsWorkFlow = value;
            }
        }



        public int ApprovedByUSerID
        {
            get
            {
                return (LeaveManualAttendanceDTO != null && LeaveManualAttendanceDTO.ApprovedByUSerID > 0) ? LeaveManualAttendanceDTO.ApprovedByUSerID : new int();
            }
            set
            {
                LeaveManualAttendanceDTO.ApprovedByUSerID = value;
            }
        }


        // [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.IsActive : false;
            }
            set
            {
                LeaveManualAttendanceDTO.IsActive = value;
            }
        }
        // [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsDeleted
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.IsDeleted : false;
            }
            set
            {
                LeaveManualAttendanceDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveManualAttendanceDTO != null && LeaveManualAttendanceDTO.CreatedBy > 0) ? LeaveManualAttendanceDTO.CreatedBy : new int();
            }
            set
            {
                LeaveManualAttendanceDTO.CreatedBy = value;
            }
        }
      //  [Display(Name = "CreatedDate")]
        [Display(Name = "DisplayName_CreatedDate", ResourceType = typeof(AERP.Common.Resources))]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveManualAttendanceDTO != null) ? LeaveManualAttendanceDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveManualAttendanceDTO.CreatedDate = value;
            }
        }

        //[Display(Name = "ModifiedBy")]
        [Display(Name = "DisplayName_ModifiedBy", ResourceType = typeof(AERP.Common.Resources))]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveManualAttendanceDTO != null && LeaveManualAttendanceDTO.ModifiedBy.HasValue) ? LeaveManualAttendanceDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveManualAttendanceDTO.ModifiedBy = value;
            }
        }

       // [Display(Name = "ModifiedDate")]
        [Display(Name = "DisplayName_ModifiedDate", ResourceType = typeof(AERP.Common.Resources))]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeaveManualAttendanceDTO != null && LeaveManualAttendanceDTO.ModifiedDate.HasValue) ? LeaveManualAttendanceDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveManualAttendanceDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DisplayName_DeletedBy", ResourceType = typeof(AERP.Common.Resources))]
        //[Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveManualAttendanceDTO != null && LeaveManualAttendanceDTO.DeletedBy.HasValue) ? LeaveManualAttendanceDTO.DeletedBy : new int();
            }
            set
            {
                LeaveManualAttendanceDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DisplayName_DeletedDate", ResourceType = typeof(AERP.Common.Resources))]
        //[Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeaveManualAttendanceDTO != null && LeaveManualAttendanceDTO.DeletedDate.HasValue) ? LeaveManualAttendanceDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveManualAttendanceDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }


        public string EntityLevel { get; set; }


    }
}
