using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveAvailedSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int LeaveApprovedID
        {
            get;
            set;
        }
        public string LeaveAvailedFromDate
        {
            get;
            set;
        }
        public string LeaveAvailedUptoDate
        {
            get;
            set;
        }
        public Int16 TotalFullDay
        {
            get;
            set;
        }
        public Int16 TotalHalfDay
        {
            get;
            set;
        }
        public string HalfLeaveStartStatus
        {
            get;
            set;
        }
        public int LeaveSummaryID
        {
            get;
            set;
        }
        public string Remark
        {
            get;
            set;
        }
        public string LeaveStatus
        {
            get;
            set;
        }
        public string LeaveAvailedFromDateOrganisation
        {
            get;
            set;
        }
        public string LeaveAvailedUptoDateOrganisation
        {
            get;
            set;
        }
        public Int16 TotalFullDayOrganisation
        {
            get;
            set;
        }
        public Int16 TotalHalfDayOrganisation
        {
            get;
            set;
        }
        public int LeaveApplicationID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public int LeaveCreditDetailsID
        {
            get;
            set;
        }
        public bool LeaveAvailedFlag
        {
            get;
            set;
        }
        public int LeaveCancelCreditID
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }

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
        public int NextGeneralTaskReportingDetailsID
        {
            get;
            set;
        }
        public int PersonID
        {
            get;
            set;
        }
        #endregion
    }
}
