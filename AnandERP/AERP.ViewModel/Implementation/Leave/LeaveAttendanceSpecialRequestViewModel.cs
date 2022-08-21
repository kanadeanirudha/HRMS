using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveAttendanceSpecialRequestViewModel : ILeaveAttendanceSpecialRequestViewModel
    {
        public LeaveAttendanceSpecialRequestViewModel()
        {
            LeaveAttendanceSpecialRequestDTO = new LeaveAttendanceSpecialRequest();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public LeaveAttendanceSpecialRequest LeaveAttendanceSpecialRequestDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null && LeaveAttendanceSpecialRequestDTO.ID > 0) ? LeaveAttendanceSpecialRequestDTO.ID : new int();
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.ID = value;
            }
        }
        public int EmployeeAttendanceID
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null && LeaveAttendanceSpecialRequestDTO.EmployeeAttendanceID > 0) ? LeaveAttendanceSpecialRequestDTO.EmployeeAttendanceID : new int();
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.EmployeeAttendanceID = value;
            }
        }
        public int EmployeeID
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null && LeaveAttendanceSpecialRequestDTO.EmployeeID > 0) ? LeaveAttendanceSpecialRequestDTO.EmployeeID : new int();
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.EmployeeID = value;
            }
        }
        public bool AttendanceStatus
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.AttendanceStatus : false;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.AttendanceStatus = value;
            }
        }
        //[Required(ErrorMessage = "Date must be selected")]
        //[Display(Name = "Date")]
        [Display(Name = "DisplayName_Date", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DateRequired")]
        public string RequestedDate
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.RequestedDate : string.Empty;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.RequestedDate = value;
            }
        }

        public string VersionNumber
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.VersionNumber : string.Empty;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.VersionNumber = value;
            }
        }

        //   [Display(Name = "In Time")]
        [Display(Name = "DisplayName_InTime", ResourceType = typeof(AERP.Common.Resources))]
        public TimeSpan CommingTime
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.CommingTime : new TimeSpan();
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.CommingTime = value;
            }
        }
        [Display(Name = "DisplayName_OutTime", ResourceType = typeof(AERP.Common.Resources))]
       // [Display(Name = "Out Time")]
        public TimeSpan LeavingTime
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.LeavingTime : new TimeSpan();
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.LeavingTime = value;
            }
        }

      //  [Required(ErrorMessage = "Status Flag must be selected")]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StatusFlagRequired")]
        public string StatusFlag
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.StatusFlag : string.Empty;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.StatusFlag = value;
            }
        }
        //[Required (ErrorMessage="Reason should not be blank")]
       // [Display(Name="Reason")]
        [Display(Name = "DisplayName_Reason", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ReasonRequired")]
        public string Reason
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.Reason : string.Empty;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.Reason = value;
            }
        }
        public int ApprovedByUserID
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null && LeaveAttendanceSpecialRequestDTO.ApprovedByUserID > 0) ? LeaveAttendanceSpecialRequestDTO.ApprovedByUserID : new int();
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.ApprovedByUserID = value;
            }
        }
        public int EmployeeShiftMasterID
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null && LeaveAttendanceSpecialRequestDTO.EmployeeShiftMasterID > 0) ? LeaveAttendanceSpecialRequestDTO.EmployeeShiftMasterID : new int();
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.EmployeeShiftMasterID = value;
            }
        }
        public string UpdatedInEmployeeAttendance
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.UpdatedInEmployeeAttendance : string.Empty;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.UpdatedInEmployeeAttendance = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.CentreCode = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.IsDeleted : false;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null && LeaveAttendanceSpecialRequestDTO.CreatedBy > 0) ? LeaveAttendanceSpecialRequestDTO.CreatedBy : new int();
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null && LeaveAttendanceSpecialRequestDTO.ModifiedBy > 0) ? LeaveAttendanceSpecialRequestDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null && LeaveAttendanceSpecialRequestDTO.DeletedBy > 0) ? LeaveAttendanceSpecialRequestDTO.DeletedBy : new int();
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (LeaveAttendanceSpecialRequestDTO != null) ? LeaveAttendanceSpecialRequestDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveAttendanceSpecialRequestDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        public string EntityLevel { get; set; }
        public string CentreName { get; set; }
    }
}
