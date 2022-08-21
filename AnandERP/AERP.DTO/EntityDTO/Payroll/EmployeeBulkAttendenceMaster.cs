using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AERP.DTO
{
    public class EmployeeBulkAttendenceMaster : BaseDTO
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

        public string EmployeeCode
        {
            get;
            set;
        }

        public string EmployeeName
        {
            get;
            set;
        }

        public int TotalAttendence
        {
            get;
            set;
        }

        public int TotalOvertime
        {
            get;
            set;
        }

        public int TotalDays
        {
            get;
            set;
        }

        public string CentreCode
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

        public int ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }

        public string XMLString
        {
            get;
            set;
        }
        public string errorMessage
        {
            get; set;
        }

        public int SpanID
        {
            get;
            set;
        }

        public string Span
        {
            get;
            set;
        }
        public string ExcelSheetName
        {
            get;
            set;
        }
    }
}
