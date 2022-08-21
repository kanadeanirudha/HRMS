using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveLateMarkRulesDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string LateMarkRuleName
        {
            get;
            set;
        }
        public Int16 LateMarkCount
        {
            get;
            set;
        }
        public decimal NumberLeaveDeducted
        {
            get;
            set;
        }
        public int LeaveID1
        {
            get;
            set;
        }
        public string LeaveID2
        {
            get;
            set;
        }
        public string LeaveID3
        {
            get;
            set;
        }
        public string LeaveID4
        {
            get;
            set;
        }
        public string LeaveID5
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
        public string EntityLevel
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string LeaveDetails
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
    }
}
