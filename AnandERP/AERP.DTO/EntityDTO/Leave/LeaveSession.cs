using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveSession : BaseDTO
    {
        public int LeaveSessionID
        {
            get;
            set;
        }

        public string LeaveSessionName
        {
            get;
            set;
        }
        public string LeaveSessionFromDate
        {
            get;
            set;
        }
        public string LeaveSessionUptoDate
        {
            get;
            set;
        }
        public bool IsSessionLocked
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public bool IsCurrentLeaveSession
        {
            get;
            set;
        }
        public int LeaveApplicationSubmittedUptoDays
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }

        ////------------------------Leave Session Details--------------------------////

        public int LeaveSessionDetailsID
        {
            get;
            set;
        }       
        public int JobProfileID
        {
            get;
            set;
        }
        public string JobProfileDescription
        {
            get;
            set;
        }
        public string JobStatusCode
        {
            get;
            set;
        }
        public string JobStatusDescription
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        public string EntityLevel
        {
            get;
            set;
        }
        public int Mode
        {
            get;
            set;
        }
        public string SelectedIDs
        {
            get;
            set;
        }
        
    }
}
