using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class ManualAttendanceStatusReport : BaseDTO
    {
        public string DepartmentName
        {
            get;
            set;
        }

        public string Reason
        {
            get;
            set;
        }

        public int DepartmentID
        {
            get;
            set;
        }
        public string EmployeeFullName
        {
            get;
            set;
        }

        public string LeaveType
        {
            get;
            set;
        }
        public string ApplicationDate
        {
            get;
            set;
        }
        public string Dates
        {
            get;
            set;
        }
        public string ApprovalStatus
        {
            get;
            set;
        }
        public string FullDayHalfDayStatus
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
        public string UptoDate
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }

        public string CheckInTime
        {
            get;
            set;
        }
        public string CheckOutTime
        {
            get;
            set;
        }
    }
}
