using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class EmployeeSalarySpan : BaseDTO
    {
        public Int16 ID
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

        public bool IsActive
        {
            get;
            set;
        }

        public bool IsSalaryGenerated
        {
            get;
            set;
        }

        public string CompletionDate
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

        public string CentreCode
        {
            get;
            set;
        }

        public string DepartmentID
        {
            get;
            set;
        }
    }
}
