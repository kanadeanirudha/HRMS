using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveRuleExemptedEmployee : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
   
        public int EmployeeID
        {
            get;
            set;
        }

        public string EmployeeFullName
        {
            get;
            set;
        }
        public int LeaveMasterID
        {
            get;
            set;
        }
        public int LeaveRuleMasterID
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public string LeaveRuleDescription
        {
            get;
            set;
        }

        public string LeaveCode
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string UptoDate
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }
        public string LeaveRuleIDs
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
