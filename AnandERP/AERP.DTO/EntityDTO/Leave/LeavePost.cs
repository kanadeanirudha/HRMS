using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeavePost : BaseDTO
    {
        public int LeaveMasterID
        {
            get;
            set;
        }
        public string LeaveCode
        {
            get;
            set;
        }
        public string LeaveDescription
        {
            get;
            set;
        }
        public int LeaveRuleMasterID
        {
            get;
            set;
        }
        public string LeaveRuleDescription
        {
            get;
            set;
        } 
        public string LeaveType
        {
            get;
            set;
        }
        public int LeaveSessionID
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
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

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
        public int EmployeeID
        {
            get;
            set;
        }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeMiddleName
        {
            get;
            set;
        }
        public string EmployeeLastName
        {
            get;
            set;
        }
        public string LeaveSessionName
        {
            get;
            set;
        }
        public string LeaveList
        {
            get;
            set;
        }
        public int SelectedFromSessionID
        {
            get;
            set;
        }
        public int DOJAndCurrentSessionDifferenceInMonth
        {
            get;
            set;
        }
        public int SelectedToSessionID
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
