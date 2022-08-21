using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class SelfLeaveApplicationViewModel
    {
        public SelfLeaveApplication SelfLeaveApplicationDTO
        {
            get;
            set;
        }
        public SelfLeaveApplicationViewModel()
        {
            SelfLeaveApplicationDTO = new SelfLeaveApplication();
        }
        public int EmployeeID
        {
            get
            {
                return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.EmployeeID > 0) ? SelfLeaveApplicationDTO.EmployeeID : new int();
            }
            set
            {
                SelfLeaveApplicationDTO.EmployeeID = value;
            }
        }
        public int ID
        {
            get
            {
                return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.ID > 0) ? SelfLeaveApplicationDTO.ID : new int();
            }
            set
            {
                SelfLeaveApplicationDTO.ID = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.CentreCode : string.Empty;
            }
            set
            {
                SelfLeaveApplicationDTO.CentreCode = value;
            }
        }
        public int LeaveMasterID
        {
            get
            {
                return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.LeaveMasterID > 0) ? SelfLeaveApplicationDTO.LeaveMasterID : new int();
            }
            set
            {
                SelfLeaveApplicationDTO.LeaveMasterID = value;
            }
        }
      
        public string FromDate
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.FromDate : string.Empty;
            }
            set
            {
                SelfLeaveApplicationDTO.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.UptoDate : string.Empty;
            }
            set
            {
                SelfLeaveApplicationDTO.UptoDate = value;
            }
        }
        public Int16 TotalfullDaysLeave
        {
            get
            {
                return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.TotalfullDaysLeave > 0) ? SelfLeaveApplicationDTO.TotalfullDaysLeave : new Int16();
            }
            set
            {
                SelfLeaveApplicationDTO.TotalfullDaysLeave = value;
            }
        }
        public string CancelDays
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.CancelDays : string.Empty;
            }
            set
            {
                SelfLeaveApplicationDTO.CancelDays = value;
            }
        }
        public string LeaveTotalDay
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.LeaveTotalDay : string.Empty;
            }
            set
            {
                SelfLeaveApplicationDTO.LeaveTotalDay = value;
            }
        }
        public Int16 TotalHalfDayLeave
        {
            get
            {
                return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.TotalHalfDayLeave > 0) ? SelfLeaveApplicationDTO.TotalHalfDayLeave : new Int16();
            }
            set
            {
                SelfLeaveApplicationDTO.TotalHalfDayLeave = value;
            }
        }
        public string FileName
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.FileName : string.Empty;
            }
            set
            {
                SelfLeaveApplicationDTO.FileName = value;
            }
        }     
        public string LeaveReason
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.LeaveReason : string.Empty;
            }
            set
            {
                SelfLeaveApplicationDTO.LeaveReason = value;
            }
        }
        public int LeaveRuleMasterID
        {
            get
            {
                return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.LeaveRuleMasterID > 0) ? SelfLeaveApplicationDTO.LeaveRuleMasterID : new int();
            }
            set
            {
                SelfLeaveApplicationDTO.LeaveRuleMasterID = value;
            }
        }
        public int LeaveSessionID
        {
            get
            {
                return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.LeaveSessionID > 0) ? SelfLeaveApplicationDTO.LeaveSessionID : new int();
            }
            set
            {
                SelfLeaveApplicationDTO.LeaveSessionID = value;
            }
        }
        public string SelectedIDs
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.SelectedIDs : string.Empty;
            }
            set
            {
                SelfLeaveApplicationDTO.SelectedIDs = value;
            }
        }
        public bool IsFirstHalf
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.IsFirstHalf : false;
            }
            set
            {
                SelfLeaveApplicationDTO.IsFirstHalf = value;
            }
        }
        public bool IsSecondHalf
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.IsSecondHalf : false;
            }
            set
            {
                SelfLeaveApplicationDTO.IsSecondHalf = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.IsActive : false;
            }
            set
            {
                SelfLeaveApplicationDTO.IsActive = value;
            }
        }

        public string errorMessage { get; set; }

        public int CreatedBy
        {
            get
            {
                return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.CreatedBy > 0) ? SelfLeaveApplicationDTO.CreatedBy : new int();
            }
            set
            {
                SelfLeaveApplicationDTO.CreatedBy = value;
            }
        }
        public int DocumentRequiredID
        {
            get
            {
                return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.DocumentRequiredID > 0) ? SelfLeaveApplicationDTO.DocumentRequiredID : new int();
            }
            set
            {
                SelfLeaveApplicationDTO.DocumentRequiredID = value;
            }
        }
        public string VersionNumber
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.VersionNumber : string.Empty;
            }
            set
            {
                SelfLeaveApplicationDTO.VersionNumber = value;
            }
        }


        //Get

        //public SelfLeaveApplicationGetViewModel()
        //{
        //    SelfLeaveApplicationDTO = new SelfLeaveApplicationGet();
        //}

        //public SelfLeaveApplicationGet SelfLeaveApplicationDTO
        //{
        //    get;
        //    set;
        //}

        //public int EmployeeID
        //{
        //    get
        //    {
        //        return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.EmployeeID > 0) ? SelfLeaveApplicationDTO.EmployeeID : new int();
        //    }
        //    set
        //    {
        //        SelfLeaveApplicationDTO.EmployeeID = value;
        //    }
        //}

        //public int ID
        //{
        //    get
        //    {
        //        return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.ID > 0) ? SelfLeaveApplicationDTO.ID : new int();
        //    }
        //    set
        //    {
        //        SelfLeaveApplicationDTO.ID = value;
        //    }
        //}

        public string AttendanceDescription
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.AttendanceDescription : string.Empty;
            }
            set
            {
                SelfLeaveApplicationDTO.AttendanceDescription = value;
            }
        }

        public TimeSpan CheckOutTime
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.CheckOutTime : TimeSpan.Zero;
            }
            set
            {
                SelfLeaveApplicationDTO.CheckOutTime = value;
            }
        }

        public TimeSpan CheckInTime
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.CheckInTime : TimeSpan.Zero;
            }
            set
            {
                SelfLeaveApplicationDTO.CheckInTime = value;
            }
        }

        // [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AMS.Common.Resources))]
        //public bool IsDeleted
        //{
        //    get
        //    {
        //        return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.IsDeleted : false;
        //    }
        //    set
        //    {
        //        SelfLeaveApplicationDTO.IsDeleted = value;
        //    }
        //}
        //public int CreatedBy
        //{
        //    get
        //    {
        //        return (SelfLeaveApplicationDTO != null && SelfLeaveApplicationDTO.CreatedBy > 0) ? SelfLeaveApplicationDTO.CreatedBy : new int();
        //    }
        //    set
        //    {
        //        SelfLeaveApplicationDTO.CreatedBy = value;
        //    }
        //}
        [Display(Name = "LeaveSessionFromDate")]
        public DateTime LeaveSessionFromDate
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.LeaveSessionFromDate : DateTime.Now;
            }
            set
            {
                SelfLeaveApplicationDTO.LeaveSessionFromDate = value;
            }
        }
        [Display(Name = "LeaveSessionUptoDate")]
        public DateTime LeaveSessionUptoDate
        {
            get
            {
                return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.LeaveSessionUptoDate : DateTime.Now;
            }
            set
            {
                SelfLeaveApplicationDTO.LeaveSessionUptoDate = value;
            }
        }





        //public string errorMessage { get; set; }


        //public string VersionNumber
        //{

        //    get
        //    {
        //        return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.VersionNumber : string.Empty;
        //    }
        //    set
        //    {
        //        SelfLeaveApplicationDTO.VersionNumber = value;
        //    }
        //}
        //public string Entity
        //{
        //    get
        //    {
        //        return (SelfLeaveApplicationDTO != null) ? SelfLeaveApplicationDTO.Entity : string.Empty;
        //    }
        //    set
        //    {
        //        SelfLeaveApplicationDTO.Entity = value;
        //    }
        //}
    }
}

