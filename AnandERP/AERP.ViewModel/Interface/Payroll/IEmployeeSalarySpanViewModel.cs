using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class IEmployeeSalarySpanViewModel
    {
        public EmployeeSalarySpan EmployeeSalarySpanDTO
        {
            get;
            set;
        }
        int ID { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int ModifiedBy { get; set; }
        Nullable<System.DateTime> ModifiedDate { get; set; }
        int DeletedBy { get; set; }
        Nullable<System.DateTime> DeletedDate { get; set; }
        string errorMessage { get; set; }
    }
}
